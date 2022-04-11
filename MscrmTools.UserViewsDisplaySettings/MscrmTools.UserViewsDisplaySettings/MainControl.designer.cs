namespace MscrmTools.UserViewsDisplaySettings
{
    partial class MainControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbApplyToUsers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.gbViews = new System.Windows.Forms.GroupBox();
            this.tlpViews = new System.Windows.Forms.TableLayoutPanel();
            this.gbVisibleViews = new System.Windows.Forms.GroupBox();
            this.lvDisplayedViews = new System.Windows.Forms.ListView();
            this.chDisplayViewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilViewTypes = new System.Windows.Forms.ImageList(this.components);
            this.gbHiddenViews = new System.Windows.Forms.GroupBox();
            this.lvHiddenViews = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.pnlSorting = new System.Windows.Forms.Panel();
            this.cbbSortOption = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTableSelection = new System.Windows.Forms.Panel();
            this.cbbTables = new System.Windows.Forms.ComboBox();
            this.lblTableSelection = new System.Windows.Forms.Label();
            this.userSelector1 = new MscrmTools.UserViewsDisplaySettings.UserControls.UserSelector();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSelectWithFxb = new System.Windows.Forms.ToolStripButton();
            this.tsbApplyToSelectedUser = new System.Windows.Forms.ToolStripButton();
            this.tsbCanel = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbUsers.SuspendLayout();
            this.gbViews.SuspendLayout();
            this.tlpViews.SuspendLayout();
            this.gbVisibleViews.SuspendLayout();
            this.gbHiddenViews.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlSorting.SuspendLayout();
            this.pnlTableSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSelectWithFxb,
            this.toolStripSeparator3,
            this.tsbApplyToUsers,
            this.toolStripSeparator1,
            this.tsbApplyToSelectedUser,
            this.toolStripSeparator2,
            this.tsbCanel});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1569, 34);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "tsMain";
            this.toolStripMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenu_ItemClicked);
            // 
            // tsbApplyToUsers
            // 
            this.tsbApplyToUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbApplyToUsers.Name = "tsbApplyToUsers";
            this.tsbApplyToUsers.Size = new System.Drawing.Size(200, 29);
            this.tsbApplyToUsers.Text = "Apply to checked users";
            this.tsbApplyToUsers.ToolTipText = "Apply the current view configuration to the users checked in the users list";
            this.tsbApplyToUsers.Click += new System.EventHandler(this.tsbApplyToUsers_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 34);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbUsers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbViews);
            this.splitContainer1.Size = new System.Drawing.Size(1569, 908);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 5;
            // 
            // gbUsers
            // 
            this.gbUsers.Controls.Add(this.userSelector1);
            this.gbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUsers.Location = new System.Drawing.Point(0, 0);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Size = new System.Drawing.Size(520, 908);
            this.gbUsers.TabIndex = 1;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "Users";
            // 
            // gbViews
            // 
            this.gbViews.Controls.Add(this.tlpViews);
            this.gbViews.Controls.Add(this.pnlSorting);
            this.gbViews.Controls.Add(this.pnlTableSelection);
            this.gbViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbViews.Location = new System.Drawing.Point(0, 0);
            this.gbViews.Name = "gbViews";
            this.gbViews.Size = new System.Drawing.Size(1045, 908);
            this.gbViews.TabIndex = 3;
            this.gbViews.TabStop = false;
            this.gbViews.Text = "Views";
            // 
            // tlpViews
            // 
            this.tlpViews.ColumnCount = 3;
            this.tlpViews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpViews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViews.Controls.Add(this.gbVisibleViews, 0, 0);
            this.tlpViews.Controls.Add(this.gbHiddenViews, 2, 0);
            this.tlpViews.Controls.Add(this.panel2, 1, 0);
            this.tlpViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpViews.Location = new System.Drawing.Point(3, 108);
            this.tlpViews.Name = "tlpViews";
            this.tlpViews.RowCount = 1;
            this.tlpViews.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpViews.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 825F));
            this.tlpViews.Size = new System.Drawing.Size(1039, 797);
            this.tlpViews.TabIndex = 3;
            // 
            // gbVisibleViews
            // 
            this.gbVisibleViews.Controls.Add(this.lvDisplayedViews);
            this.gbVisibleViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbVisibleViews.Location = new System.Drawing.Point(3, 3);
            this.gbVisibleViews.Name = "gbVisibleViews";
            this.gbVisibleViews.Size = new System.Drawing.Size(488, 791);
            this.gbVisibleViews.TabIndex = 0;
            this.gbVisibleViews.TabStop = false;
            this.gbVisibleViews.Text = "Displayed views";
            // 
            // lvDisplayedViews
            // 
            this.lvDisplayedViews.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDisplayViewName});
            this.lvDisplayedViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDisplayedViews.HideSelection = false;
            this.lvDisplayedViews.Location = new System.Drawing.Point(3, 22);
            this.lvDisplayedViews.Name = "lvDisplayedViews";
            this.lvDisplayedViews.Size = new System.Drawing.Size(482, 766);
            this.lvDisplayedViews.SmallImageList = this.ilViewTypes;
            this.lvDisplayedViews.TabIndex = 0;
            this.lvDisplayedViews.UseCompatibleStateImageBehavior = false;
            this.lvDisplayedViews.View = System.Windows.Forms.View.Details;
            this.lvDisplayedViews.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvViews_MouseDoubleClick);
            // 
            // chDisplayViewName
            // 
            this.chDisplayViewName.Text = "Name";
            this.chDisplayViewName.Width = 400;
            // 
            // ilViewTypes
            // 
            this.ilViewTypes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilViewTypes.ImageStream")));
            this.ilViewTypes.TransparentColor = System.Drawing.Color.Transparent;
            this.ilViewTypes.Images.SetKeyName(0, "ico_16_1039.gif");
            this.ilViewTypes.Images.SetKeyName(1, "userquery.png");
            // 
            // gbHiddenViews
            // 
            this.gbHiddenViews.Controls.Add(this.lvHiddenViews);
            this.gbHiddenViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbHiddenViews.Location = new System.Drawing.Point(547, 3);
            this.gbHiddenViews.Name = "gbHiddenViews";
            this.gbHiddenViews.Size = new System.Drawing.Size(489, 791);
            this.gbHiddenViews.TabIndex = 1;
            this.gbHiddenViews.TabStop = false;
            this.gbHiddenViews.Text = "Hidden Views";
            // 
            // lvHiddenViews
            // 
            this.lvHiddenViews.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvHiddenViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHiddenViews.HideSelection = false;
            this.lvHiddenViews.Location = new System.Drawing.Point(3, 22);
            this.lvHiddenViews.Name = "lvHiddenViews";
            this.lvHiddenViews.Size = new System.Drawing.Size(483, 766);
            this.lvHiddenViews.SmallImageList = this.ilViewTypes;
            this.lvHiddenViews.TabIndex = 1;
            this.lvHiddenViews.UseCompatibleStateImageBehavior = false;
            this.lvHiddenViews.View = System.Windows.Forms.View.Details;
            this.lvHiddenViews.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvViews_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 400;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnShow);
            this.panel2.Controls.Add(this.btnHide);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(497, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(44, 791);
            this.panel2.TabIndex = 2;
            // 
            // btnShow
            // 
            this.btnShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShow.Location = new System.Drawing.Point(0, 34);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(44, 34);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "<<";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnHide
            // 
            this.btnHide.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHide.Location = new System.Drawing.Point(0, 0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(44, 34);
            this.btnHide.TabIndex = 3;
            this.btnHide.Text = ">>";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // pnlSorting
            // 
            this.pnlSorting.Controls.Add(this.cbbSortOption);
            this.pnlSorting.Controls.Add(this.label1);
            this.pnlSorting.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSorting.Location = new System.Drawing.Point(3, 66);
            this.pnlSorting.Name = "pnlSorting";
            this.pnlSorting.Size = new System.Drawing.Size(1039, 42);
            this.pnlSorting.TabIndex = 1;
            // 
            // cbbSortOption
            // 
            this.cbbSortOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbSortOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSortOption.FormattingEnabled = true;
            this.cbbSortOption.Items.AddRange(new object[] {
            "Personal views before system views, A to Z",
            "System views before personal views, A to Z",
            "A to Z"});
            this.cbbSortOption.Location = new System.Drawing.Point(80, 0);
            this.cbbSortOption.Name = "cbbSortOption";
            this.cbbSortOption.Size = new System.Drawing.Size(959, 28);
            this.cbbSortOption.TabIndex = 2;
            this.cbbSortOption.SelectedIndexChanged += new System.EventHandler(this.cbbSortOption_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sort ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTableSelection
            // 
            this.pnlTableSelection.Controls.Add(this.cbbTables);
            this.pnlTableSelection.Controls.Add(this.lblTableSelection);
            this.pnlTableSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTableSelection.Location = new System.Drawing.Point(3, 22);
            this.pnlTableSelection.Name = "pnlTableSelection";
            this.pnlTableSelection.Size = new System.Drawing.Size(1039, 44);
            this.pnlTableSelection.TabIndex = 0;
            // 
            // cbbTables
            // 
            this.cbbTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbTables.FormattingEnabled = true;
            this.cbbTables.Location = new System.Drawing.Point(80, 0);
            this.cbbTables.Name = "cbbTables";
            this.cbbTables.Size = new System.Drawing.Size(959, 28);
            this.cbbTables.TabIndex = 1;
            this.cbbTables.SelectedIndexChanged += new System.EventHandler(this.cbbTables_SelectedIndexChanged);
            // 
            // lblTableSelection
            // 
            this.lblTableSelection.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTableSelection.Location = new System.Drawing.Point(0, 0);
            this.lblTableSelection.Name = "lblTableSelection";
            this.lblTableSelection.Size = new System.Drawing.Size(80, 44);
            this.lblTableSelection.TabIndex = 0;
            this.lblTableSelection.Text = "Table";
            this.lblTableSelection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userSelector1
            // 
            this.userSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSelector1.Location = new System.Drawing.Point(3, 22);
            this.userSelector1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.userSelector1.Name = "userSelector1";
            this.userSelector1.Service = null;
            this.userSelector1.Size = new System.Drawing.Size(514, 883);
            this.userSelector1.TabIndex = 0;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbSelectWithFxb
            // 
            this.tsbSelectWithFxb.Image = global::MscrmTools.UserViewsDisplaySettings.Properties.Resources.fxb;
            this.tsbSelectWithFxb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectWithFxb.Name = "tsbSelectWithFxb";
            this.tsbSelectWithFxb.Size = new System.Drawing.Size(164, 29);
            this.tsbSelectWithFxb.Text = "FetchXml Builder";
            this.tsbSelectWithFxb.ToolTipText = "Select users with FetchXml Builder";
            // 
            // tsbApplyToSelectedUser
            // 
            this.tsbApplyToSelectedUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbApplyToSelectedUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbApplyToSelectedUser.Image")));
            this.tsbApplyToSelectedUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbApplyToSelectedUser.Name = "tsbApplyToSelectedUser";
            this.tsbApplyToSelectedUser.Size = new System.Drawing.Size(192, 29);
            this.tsbApplyToSelectedUser.Text = "Apply to selected user";
            this.tsbApplyToSelectedUser.ToolTipText = "Apply the current view configuration to the selected user in the users list";
            this.tsbApplyToSelectedUser.Click += new System.EventHandler(this.tsbApplyToSelectedUser_Click);
            // 
            // tsbCanel
            // 
            this.tsbCanel.Image = global::MscrmTools.UserViewsDisplaySettings.Properties.Resources._16_cancelsystemjob;
            this.tsbCanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCanel.Name = "tsbCanel";
            this.tsbCanel.Size = new System.Drawing.Size(83, 29);
            this.tsbCanel.Text = "Cancel";
            this.tsbCanel.Visible = false;
            this.tsbCanel.Click += new System.EventHandler(this.tsbCanel_Click);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(1569, 942);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbUsers.ResumeLayout(false);
            this.gbViews.ResumeLayout(false);
            this.tlpViews.ResumeLayout(false);
            this.gbVisibleViews.ResumeLayout(false);
            this.gbHiddenViews.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlSorting.ResumeLayout(false);
            this.pnlTableSelection.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbApplyToUsers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private UserControls.UserSelector userSelector1;
        private System.Windows.Forms.Panel pnlSorting;
        private System.Windows.Forms.Panel pnlTableSelection;
        private System.Windows.Forms.ComboBox cbbTables;
        private System.Windows.Forms.Label lblTableSelection;
        private System.Windows.Forms.ComboBox cbbSortOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbCanel;
        private System.Windows.Forms.GroupBox gbUsers;
        private System.Windows.Forms.GroupBox gbViews;
        private System.Windows.Forms.TableLayoutPanel tlpViews;
        private System.Windows.Forms.GroupBox gbVisibleViews;
        private System.Windows.Forms.ListView lvDisplayedViews;
        private System.Windows.Forms.ColumnHeader chDisplayViewName;
        private System.Windows.Forms.GroupBox gbHiddenViews;
        private System.Windows.Forms.ListView lvHiddenViews;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.ImageList ilViewTypes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbApplyToSelectedUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSelectWithFxb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
