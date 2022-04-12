using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using MscrmTools.UserViewsDisplaySettings.AppCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.UserViewsDisplaySettings
{
    public partial class MainControl : PluginControlBase, IGitHubPlugin, IPayPalPlugin, IMessageBusHost
    {
        private const string ACTIVE_USERS_FETCH = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' ><entity name='systemuser' ><attribute name='fullname' /><order attribute='fullname' descending='false' /><attribute name='businessunitid' /><attribute name='siteid' /><filter type='and' ><condition attribute='isdisabled' operator='eq' value='0' /><condition attribute='accessmode' operator='ne' value='3' /></filter><attribute name='systemuserid' /></entity></fetch>";
        private BackgroundWorker _currentWorker;
        private List<EntityInfo> _emds;
        private Dictionary<int, ViewPersonalizationSettings> _personalizationSettings;
        private List<ListViewItem> _views = new List<ListViewItem>();

        public MainControl()
        {
            InitializeComponent();

            cbbSortOption.SelectedIndex = 0;
            userSelector1.OnSingleUserSelected += UserSelector1_OnSingleUserSelected;
        }

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        public string DonationDescription => "Donation for XrmToolBox tool User Views Display Settings";
        public string EmailAccount => "tanguy92@hotmail.com";
        public string RepositoryName => "MscrmTools.UserViewsDisplaySettings";

        public string UserName => "MscrmTools";

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            if (message.SourcePlugin == "FetchXML Builder")
            {
                var fetchXml = (string)message.TargetArgument;
                if (Service != null && userSelector1.Service == null)
                {
                    userSelector1.Service = Service;
                }
                userSelector1.PopulateUsers(fetchXml);
            }
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (detail.OrganizationMajorVersion < 9
                || detail.OrganizationMajorVersion == 9 && detail.OrganizationMinorVersion < 2)
            {
                MessageBox.Show(this, "This tool is compatible with Dataverse 9.2 and above only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Enabled = false;
                return;
            }

            LoadItems();
        }

        private void ApplyToUsers(List<Entity> users)
        {
            var settings = new ViewPersonalizationSettings
            {
                Info = new ViewPersonalizationSettingsInfo
                {
                    SortOrder = cbbSortOption.SelectedIndex + 1,
                    HiddenSavedQueryIds = lvHiddenViews.Items.Cast<ListViewItem>().Where(i => ((ViewItem)i.Tag).IsSystemView).Select(i => ((ViewItem)i.Tag).Id.ToString("B")).ToArray(),
                    HiddenUserQueryIds = lvHiddenViews.Items.Cast<ListViewItem>().Where(i => !((ViewItem)i.Tag).IsSystemView).Select(i => ((ViewItem)i.Tag).Id.ToString("B")).ToArray(),
                }
            };

            var typeCode = ((EntityInfo)cbbTables.SelectedItem).ObjectTypeCode;
            var processed = 0;

            tsbApplyToUsers.Visible = false;
            tsbCanel.Visible = true;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Updating user(s)...",
                IsCancelable = true,
                Work = (bw, evt) =>
                {
                    _currentWorker = bw;
                    foreach (var user in users)
                    {
                        if (bw.CancellationPending) return;

                        bw.ReportProgress(processed / users.Count * 100, $"Updating settings for {user.GetAttributeValue<string>("fullname")}...");
                        ((CrmServiceClient)Service).CallerId = user.Id;

                        var uiSetting = Service.RetrieveMultiple(new QueryExpression("userentityuisettings")
                        {
                            NoLock = true,
                            Criteria = new FilterExpression
                            {
                                Conditions =
                                {
                                    new ConditionExpression("ownerid", ConditionOperator.EqualUserId),
                                    new ConditionExpression("objecttypecode", ConditionOperator.Equal, typeCode)
                                }
                            }
                        }).Entities.FirstOrDefault();

                        if (uiSetting == null)
                        {
                            uiSetting = new Entity("userentityuisettings")
                            {
                                Attributes =
                                {
                                    {"ownerid", user.ToEntityReference() },
                                    {"objecttypecode", typeCode },
                                }
                            };

                            uiSetting.Id = Service.Create(uiSetting);
                        }

                        // Avoid to lose personal views settings
                        var currentSettings = ParseViewSettings(uiSetting.GetAttributeValue<string>("viewpersonalizationsettings"));
                        var currentUserQueriesHidden = currentSettings.Info?.HiddenUserQueryIds ?? new string[0];
                        settings.Info.HiddenUserQueryIds = currentUserQueriesHidden;
                        settings.Info.HiddenUserQueryIds = settings.Info.HiddenUserQueryIds.Union(currentUserQueriesHidden).ToArray();

                        uiSetting["viewpersonalizationsettings"] = WriteObject(settings);
                        Service.Update(uiSetting);

                        ((CrmServiceClient)Service).CallerId = Guid.Empty;

                        processed++;
                    }
                },
                PostWorkCallBack = (evt) =>
                {
                    tsbApplyToUsers.Visible = true;
                    tsbCanel.Visible = false;

                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $"Error: {evt.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                },
                ProgressChanged = (evt) =>
                {
                    SetWorkingMessage(evt.UserState.ToString());
                }
            });
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            var item = lvDisplayedViews.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (item != null)
            {
                lvDisplayedViews.Items.Remove(item);
                lvHiddenViews.Items.Add(item);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var item = lvHiddenViews.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (item != null)
            {
                lvHiddenViews.Items.Remove(item);
                lvDisplayedViews.Items.Add(item);
            }
        }

        private void cbbSortOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sort();
        }

        private void cbbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTables.SelectedIndex < 0) return;

            var logicalName = ((EntityInfo)cbbTables.SelectedItem).LogicalName;
            var typeCode = ((EntityInfo)cbbTables.SelectedItem).ObjectTypeCode;
            var isMultiple = userSelector1.CheckedItems.Count > 0;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading views...",
                Work = (bw, evt) =>
                {
                    var vm = new ViewManager(Service);
                    evt.Result = vm.RetrieveViews(logicalName, bw);
                },
                PostWorkCallBack = (evt) =>
                {
                    var views = (List<ViewItem>)evt.Result;
                    ViewPersonalizationSettings uiSettings = null;
                    if (_personalizationSettings?.ContainsKey(typeCode) ?? false)
                    {
                        uiSettings = _personalizationSettings[typeCode];
                    }
                    _views = new List<ListViewItem>();
                    lvHiddenViews.Items.Clear();
                    lvDisplayedViews.Items.Clear();
                    foreach (var view in views)
                    {
                        var item = new ListViewItem(view.Name) { Tag = view };
                        item.ImageIndex = view.IsSystemView ? 0 : 1;
                        _views.Add(item);

                        if (uiSettings?.Info?.HiddenSavedQueryIds.Contains(view.Id.ToString("B")) ?? false)
                        {
                            lvHiddenViews.Items.Add(item);
                        }
                        else
                        {
                            lvDisplayedViews.Items.Add(item);
                        }
                    }

                    cbbSortOption.SelectedIndex = (uiSettings?.Info?.SortOrder ?? 1) - 1;

                    Sort();
                },
                ProgressChanged = (evt) =>
                {
                    SetWorkingMessage(evt.UserState.ToString());
                }
            });
        }

        private void LoadItems()
        {
            List<ViewItem> views = null;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading...",
                Work = (bw, e) =>
                {
                    bw.ReportProgress(0, "Loading users...");
                    userSelector1.Service = Service;
                    views = userSelector1.LoadViews();

                    bw.ReportProgress(0, "Loading tables...");
                    var mm = new MetadataManager(Service);
                    _emds = mm.GetTables();
                },
                PostWorkCallBack = (e) =>
                {
                    userSelector1.SetViews(views);

                    cbbTables.Items.Clear();
                    cbbTables.Items.AddRange(_emds.OrderBy(emd => emd.LogicalName).ToArray());
                },
                ProgressChanged = (e) =>
                {
                    SetWorkingMessage(e.UserState.ToString());
                }
            });
        }

        private void lvViews_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender == lvDisplayedViews)
            {
                btnHide_Click(btnShow, new EventArgs());
            }
            else
            {
                btnShow_Click(btnShow, new EventArgs());
            }
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
        }

        private ViewPersonalizationSettings ParseViewSettings(string value)
        {
            if (value == null)
            {
                return new ViewPersonalizationSettings();
            }

            var serializer = new DataContractJsonSerializer(typeof(ViewPersonalizationSettings), new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            });

            return (ViewPersonalizationSettings)serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(value)));
        }

        private void Sort()
        {
            if (cbbTables.SelectedIndex < 0) return;

            if (cbbSortOption.SelectedIndex == 0)
            {
                _views = _views.OrderBy(v => ((ViewItem)v.Tag).IsSystemView).ThenBy(v => ((ViewItem)v.Tag).Name).ToList();
            }
            else if (cbbSortOption.SelectedIndex == 1)
            {
                _views = _views.OrderBy(v => !((ViewItem)v.Tag).IsSystemView).ThenBy(v => ((ViewItem)v.Tag).Name).ToList();
            }
            else
            {
                _views = _views.OrderBy(v => ((ViewItem)v.Tag).Name).ToList();
            }

            var typeCode = ((EntityInfo)cbbTables.SelectedItem).ObjectTypeCode;
            ViewPersonalizationSettings uiSettings = null;
            if (_personalizationSettings?.ContainsKey(typeCode) ?? false)
            {
                uiSettings = _personalizationSettings[typeCode];
            }

            lvHiddenViews.Items.Clear();
            lvDisplayedViews.Items.Clear();
            foreach (var item in _views)
            {
                var view = (ViewItem)item.Tag;

                if (uiSettings?.Info?.HiddenSavedQueryIds.Contains(view.Id.ToString("B")) ?? false)
                {
                    lvHiddenViews.Items.Add(item);
                }
                else
                {
                    lvDisplayedViews.Items.Add(item);
                }
            }
        }

        private void tsbApplyToSelectedUser_Click(object sender, EventArgs e)
        {
            var user = userSelector1.SelectedItem;
            if (user == null) return;

            if (MessageBox.Show(this, $"Are you sure you want to apply these UI settings to user {user.GetAttributeValue<string>("fullname")}?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ApplyToUsers(new List<Entity> { user });
        }

        private void tsbApplyToUsers_Click(object sender, EventArgs e)
        {
            var count = userSelector1.CheckedItems.Count;

            if (MessageBox.Show(this, $"Are you sure you want to apply these UI settings to {count} user(s)?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ApplyToUsers(userSelector1.CheckedItems);
        }

        private void tsbCanel_Click(object sender, EventArgs e)
        {
            _currentWorker?.CancelAsync();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void TsbSelectWithFxb_Click(object sender, System.EventArgs e)
        {
            var messageBusEventArgs = new MessageBusEventArgs("FetchXML Builder");
            var fetchXml = (((ComboBox)userSelector1.Controls.Find("cbbViews", true)?[0]).SelectedItem as ViewItem)?.FetchXml;
            messageBusEventArgs.TargetArgument = fetchXml ?? ACTIVE_USERS_FETCH;
            OnOutgoingMessage(this, messageBusEventArgs);
        }

        private void UserSelector1_OnSingleUserSelected(object sender, AppCode.Args.UserEventArgs e)
        {
            _personalizationSettings = new Dictionary<int, ViewPersonalizationSettings>();

            foreach (var settings in e.UiSettings)
            {
                _personalizationSettings.Add(settings.GetAttributeValue<int>("objecttypecode"), ParseViewSettings(settings.GetAttributeValue<string>("viewpersonalizationsettings")));
            }

            if (cbbTables.SelectedItem != null && _personalizationSettings.Any(p => p.Key == ((EntityInfo)cbbTables.SelectedItem).ObjectTypeCode))
            {
                if (DialogResult.Yes == MessageBox.Show(this, "Do you want to display current user UI settings?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    cbbTables_SelectedIndexChanged(cbbTables, new EventArgs());
                }
            }
        }

        private string WriteObject<T>(T content, DataContractJsonSerializerSettings settings = null)
        {
            var serializer = settings == null
                ? new DataContractJsonSerializer(typeof(T))
                : new DataContractJsonSerializer(typeof(T), settings);

            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, content);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}