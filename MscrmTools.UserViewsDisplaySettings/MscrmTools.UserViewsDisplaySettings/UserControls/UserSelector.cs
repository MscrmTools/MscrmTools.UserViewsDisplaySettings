using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using MscrmTools.UserViewsDisplaySettings.AppCode;
using MscrmTools.UserViewsDisplaySettings.AppCode.Args;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MscrmTools.UserViewsDisplaySettings.UserControls
{
    public partial class UserSelector : UserControl
    {
        private int currentColumnOrder;
        private List<ListViewItem> items = new List<ListViewItem>();
        private Thread searchThread;
        private IOrganizationService service;

        public UserSelector()
        {
            InitializeComponent();
        }

        public event EventHandler<UserEventArgs> OnSingleUserSelected;

        public List<Entity> CheckedItems
        {
            get { return lvUsers.CheckedItems.Cast<ListViewItem>().Select(e => (Entity)e.Tag).ToList(); }
        }

        public Entity SelectedItem
        {
            get { return lvUsers.SelectedItems.Cast<ListViewItem>().Select(e => (Entity)e.Tag).FirstOrDefault(); }
        }

        public IOrganizationService Service
        {
            set
            {
                service = value;
                if (service != null)
                {
                    LoadViews();
                }
            }
            get { return service; }
        }

        public void FilterDisplay(object term)
        {
            var filteredItems = items.Where(i => string.IsNullOrEmpty(term.ToString()) || i.Text.ToLower().IndexOf(term.ToString().ToLower()) >= 0
            || i.SubItems.Cast<ListViewItem.ListViewSubItem>().Any(s => s.Text.ToLower().IndexOf(term.ToString().ToLower()) >= 0));

            Invoke(new Action(() =>
            {
                lvUsers.Items.Clear();
                lvUsers.Items.AddRange(filteredItems.ToArray());

                lvUsers.ItemSelectionChanged += lvUsers_ItemSelectionChanged;
            }));
        }

        public List<ViewItem> LoadViews()
        {
            if (service == null)
            {
                throw new Exception("IOrganization service is not initialized for this control");
            }

            var vManager = new ViewManager(service);
            return vManager.RetrieveViews("systemuser");
        }

        public void PopulateUsers(string fetchXml)
        {
            lvUsers.Items.Clear();

            var bw = new BackgroundWorker();
            bw.DoWork += (sender, e) => { e.Result = QueryHelper.GetItems(e.Argument.ToString(), service); };
            bw.RunWorkerCompleted += (sender, e) =>
            {
                var records = (EntityCollection)e.Result;
                if (records.EntityName == "systemuser")
                {
                    items.Clear();
                    items.AddRange(records.Entities
                        .Select(record => new ListViewItem
                        {
                            Text = record.GetAttributeValue<string>("lastname"),
                            ImageIndex = 0,
                            StateImageIndex = 0,
                            Tag = record,
                            SubItems =
                            {
                                record.GetAttributeValue<string>("firstname"),
                                record.GetAttributeValue<EntityReference>("businessunitid").Name
                            }
                        })
                        .ToArray());

                    lvUsers.Items.AddRange(items.ToArray());
                }
            };
            bw.RunWorkerAsync(fetchXml);
        }

        public void SetViews(List<ViewItem> scViews)
        {
            cbbViews.SelectedIndexChanged -= cbbViews_SelectedIndexChanged;
            cbbViews.Items.Clear();
            cbbViews.Items.AddRange(scViews.ToArray());
            cbbViews.SelectedIndexChanged += cbbViews_SelectedIndexChanged;
            cbbViews.SelectedIndex = 0;
        }

        private void cbbViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            var viewItem = (ViewItem)cbbViews.SelectedItem;
            PopulateUsers(viewItem.FetchXml);
        }

        private void llCheckAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvUsers.Items)
            {
                item.Checked = true;
            }
        }

        private void llCheckNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvUsers.Items)
            {
                item.Checked = false;
            }
        }

        private void llInvertSelection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvUsers.Items)
            {
                item.Checked = !item.Checked;
            }
        }

        private void lvUsers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == currentColumnOrder)
            {
                lvUsers.Sorting = lvUsers.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

                lvUsers.ListViewItemSorter = new ListViewItemComparer(e.Column, lvUsers.Sorting);
            }
            else
            {
                currentColumnOrder = e.Column;
                lvUsers.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }
        }

        private void lvUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var user = e.Item.Tag as Entity;
            if (user == null) return;

            ((CrmServiceClient)service).CallerId = user.Id;

            var records = service.RetrieveMultiple(new QueryByAttribute("userentityuisettings")
            {
                Attributes = { "ownerid" },
                Values = { user.Id },
                ColumnSet = new ColumnSet("viewpersonalizationsettings", "objecttypecode")
            });

            ((CrmServiceClient)service).CallerId = Guid.Empty;

            OnSingleUserSelected?.Invoke(this, new UserEventArgs(user.Id, records.Entities.ToList()));
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            lvUsers.ItemSelectionChanged -= lvUsers_ItemSelectionChanged;

            searchThread?.Abort();
            searchThread = new Thread(FilterDisplay);
            searchThread.Start(txtFilter.Text);
        }
    }
}