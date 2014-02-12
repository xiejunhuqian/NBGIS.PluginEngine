namespace NBGIS.MainGIS
{
    partial class MainGIS
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel2 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel3 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel4 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGIS));
            this.uiCommandManager = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.MainMenu = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiStatusBar = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.uiPanelManager = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanelGroup = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.TOCPanel = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.LayerPanel = new Janus.Windows.UI.Dock.UIPanel();
            this.LayerPanelContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.axTOCControl = new AxESRI.ArcGIS.Controls.AxTOCControl();
            this.Property = new Janus.Windows.UI.Dock.UIPanel();
            this.PropertyContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.DataPanel = new Janus.Windows.UI.Dock.UIPanel();
            this.DataPanelContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MapContainer = new Janus.Windows.UI.Dock.UIPanel();
            this.MapContainerContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab = new Janus.Windows.UI.Tab.UITab();
            this.mapTab = new Janus.Windows.UI.Tab.UITabPage();
            this.axLicenseControl2 = new AxESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl = new AxESRI.ArcGIS.Controls.AxMapControl();
            this.pageTab = new Janus.Windows.UI.Tab.UITabPage();
            this.axPageLayoutControl = new AxESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.axLicenseControl1 = new AxESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new AxESRI.ArcGIS.Controls.AxMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelGroup)).BeginInit();
            this.uiPanelGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TOCPanel)).BeginInit();
            this.TOCPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayerPanel)).BeginInit();
            this.LayerPanel.SuspendLayout();
            this.LayerPanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Property)).BeginInit();
            this.Property.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataPanel)).BeginInit();
            this.DataPanel.SuspendLayout();
            this.DataPanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapContainer)).BeginInit();
            this.MapContainer.SuspendLayout();
            this.MapContainerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab)).BeginInit();
            this.uiTab.SuspendLayout();
            this.mapTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).BeginInit();
            this.pageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiCommandManager
            // 
            this.uiCommandManager.BottomRebar = this.BottomRebar1;
            this.uiCommandManager.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.MainMenu});
            this.uiCommandManager.ContainerControl = this;
            this.uiCommandManager.Id = new System.Guid("410cc0c5-aa80-4c52-9462-d757dacaf2e0");
            this.uiCommandManager.LeftRebar = this.LeftRebar1;
            this.uiCommandManager.RightRebar = this.RightRebar1;
            this.uiCommandManager.TopRebar = this.TopRebar1;
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 272);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(292, 0);
            // 
            // MainMenu
            // 
            this.MainMenu.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.MainMenu.CommandManager = this.uiCommandManager;
            this.MainMenu.Key = "MainMenu";
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RowIndex = 0;
            this.MainMenu.Size = new System.Drawing.Size(625, 26);
            this.MainMenu.Text = "CommandBar1";
            this.MainMenu.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 26);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 246);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(292, 26);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 246);
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.MainMenu});
            this.TopRebar1.CommandManager = this.uiCommandManager;
            this.TopRebar1.Controls.Add(this.MainMenu);
            this.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar1.Location = new System.Drawing.Point(0, 0);
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Size = new System.Drawing.Size(625, 26);
            // 
            // uiStatusBar
            // 
            this.uiStatusBar.Location = new System.Drawing.Point(0, 532);
            this.uiStatusBar.Name = "uiStatusBar";
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Key = "";
            uiStatusBarPanel1.ProgressBarValue = 0;
            uiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel2.Key = "";
            uiStatusBarPanel2.ProgressBarValue = 0;
            uiStatusBarPanel2.Width = 298;
            uiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel3.Key = "";
            uiStatusBarPanel3.ProgressBarValue = 0;
            uiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel4.Key = "";
            uiStatusBarPanel4.ProgressBarValue = 0;
            this.uiStatusBar.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1,
            uiStatusBarPanel2,
            uiStatusBarPanel3,
            uiStatusBarPanel4});
            this.uiStatusBar.Size = new System.Drawing.Size(625, 23);
            this.uiStatusBar.TabIndex = 1;
            this.uiStatusBar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // uiPanelManager
            // 
            this.uiPanelManager.ContainerControl = this;
            this.uiPanelManager.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            this.uiPanelGroup.Id = new System.Guid("6d1982d9-bd1d-46e5-9213-3c0430e9563d");
            this.TOCPanel.Id = new System.Guid("82f5ae0e-b02d-4829-9b9f-fbdb10912033");
            this.TOCPanel.StaticGroup = true;
            this.LayerPanel.Id = new System.Guid("9b3f03d5-3dad-46e2-8c78-31a5f90a7f40");
            this.TOCPanel.Panels.Add(this.LayerPanel);
            this.Property.Id = new System.Guid("f7ee2eb6-a436-4a82-af43-0b8fe36486c2");
            this.TOCPanel.Panels.Add(this.Property);
            this.uiPanelGroup.Panels.Add(this.TOCPanel);
            this.DataPanel.Id = new System.Guid("523ea4bd-e633-4524-9be8-7bf98194e2b0");
            this.uiPanelGroup.Panels.Add(this.DataPanel);
            this.uiPanelManager.Panels.Add(this.uiPanelGroup);
            this.MapContainer.Id = new System.Guid("30cb0cbc-14e6-4f43-aed0-cd6dd1130000");
            this.uiPanelManager.Panels.Add(this.MapContainer);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager.BeginPanelInfo();
            this.uiPanelManager.AddDockPanelInfo(new System.Guid("6d1982d9-bd1d-46e5-9213-3c0430e9563d"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Left, false, new System.Drawing.Size(200, 500), true);
            this.uiPanelManager.AddDockPanelInfo(new System.Guid("82f5ae0e-b02d-4829-9b9f-fbdb10912033"), new System.Guid("6d1982d9-bd1d-46e5-9213-3c0430e9563d"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, 187, true);
            this.uiPanelManager.AddDockPanelInfo(new System.Guid("9b3f03d5-3dad-46e2-8c78-31a5f90a7f40"), new System.Guid("82f5ae0e-b02d-4829-9b9f-fbdb10912033"), -1, true);
            this.uiPanelManager.AddDockPanelInfo(new System.Guid("f7ee2eb6-a436-4a82-af43-0b8fe36486c2"), new System.Guid("82f5ae0e-b02d-4829-9b9f-fbdb10912033"), -1, true);
            this.uiPanelManager.AddDockPanelInfo(new System.Guid("523ea4bd-e633-4524-9be8-7bf98194e2b0"), new System.Guid("6d1982d9-bd1d-46e5-9213-3c0430e9563d"), 187, true);
            this.uiPanelManager.AddDockPanelInfo(new System.Guid("30cb0cbc-14e6-4f43-aed0-cd6dd1130000"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(419, 500), true);
            this.uiPanelManager.AddFloatingPanelInfo(new System.Guid("82f5ae0e-b02d-4829-9b9f-fbdb10912033"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager.AddFloatingPanelInfo(new System.Guid("9b3f03d5-3dad-46e2-8c78-31a5f90a7f40"), new System.Guid("82f5ae0e-b02d-4829-9b9f-fbdb10912033"), -1, false);
            this.uiPanelManager.AddFloatingPanelInfo(new System.Guid("f7ee2eb6-a436-4a82-af43-0b8fe36486c2"), new System.Guid("82f5ae0e-b02d-4829-9b9f-fbdb10912033"), -1, false);
            this.uiPanelManager.AddFloatingPanelInfo(new System.Guid("523ea4bd-e633-4524-9be8-7bf98194e2b0"), new System.Drawing.Point(496, 398), new System.Drawing.Size(200, 200), false);
            this.uiPanelManager.AddFloatingPanelInfo(new System.Guid("30cb0cbc-14e6-4f43-aed0-cd6dd1130000"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager.EndPanelInfo();
            // 
            // uiPanelGroup
            // 
            this.uiPanelGroup.Location = new System.Drawing.Point(3, 29);
            this.uiPanelGroup.Name = "uiPanelGroup";
            this.uiPanelGroup.Size = new System.Drawing.Size(200, 500);
            this.uiPanelGroup.TabIndex = 5;
            // 
            // TOCPanel
            // 
            this.TOCPanel.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.Tab;
            this.TOCPanel.Location = new System.Drawing.Point(0, 0);
            this.TOCPanel.Name = "TOCPanel";
            this.TOCPanel.SelectedPanel = this.LayerPanel;
            this.TOCPanel.Size = new System.Drawing.Size(196, 248);
            this.TOCPanel.TabIndex = 4;
            this.TOCPanel.Text = "地图信息";
            // 
            // LayerPanel
            // 
            this.LayerPanel.InnerContainer = this.LayerPanelContainer;
            this.LayerPanel.Location = new System.Drawing.Point(0, 0);
            this.LayerPanel.Name = "LayerPanel";
            this.LayerPanel.Size = new System.Drawing.Size(196, 230);
            this.LayerPanel.TabIndex = 4;
            this.LayerPanel.Text = "图层";
            // 
            // LayerPanelContainer
            // 
            this.LayerPanelContainer.Controls.Add(this.axTOCControl);
            this.LayerPanelContainer.Location = new System.Drawing.Point(1, 24);
            this.LayerPanelContainer.Name = "LayerPanelContainer";
            this.LayerPanelContainer.Size = new System.Drawing.Size(194, 206);
            this.LayerPanelContainer.TabIndex = 0;
            // 
            // axTOCControl
            // 
            this.axTOCControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl.Name = "axTOCControl";
            this.axTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl.OcxState")));
            this.axTOCControl.Size = new System.Drawing.Size(194, 206);
            this.axTOCControl.TabIndex = 0;
            // 
            // Property
            // 
            this.Property.InnerContainer = this.PropertyContainer;
            this.Property.Location = new System.Drawing.Point(0, 0);
            this.Property.Name = "Property";
            this.Property.Size = new System.Drawing.Size(196, 230);
            this.Property.TabIndex = 4;
            this.Property.Text = "属性";
            // 
            // PropertyContainer
            // 
            this.PropertyContainer.Location = new System.Drawing.Point(1, 24);
            this.PropertyContainer.Name = "PropertyContainer";
            this.PropertyContainer.Size = new System.Drawing.Size(194, 206);
            this.PropertyContainer.TabIndex = 0;
            // 
            // DataPanel
            // 
            this.DataPanel.FloatingLocation = new System.Drawing.Point(496, 398);
            this.DataPanel.InnerContainer = this.DataPanelContainer;
            this.DataPanel.Location = new System.Drawing.Point(0, 252);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(196, 248);
            this.DataPanel.TabIndex = 4;
            this.DataPanel.Text = "数据";
            // 
            // DataPanelContainer
            // 
            this.DataPanelContainer.Controls.Add(this.dataGridView1);
            this.DataPanelContainer.Location = new System.Drawing.Point(1, 23);
            this.DataPanelContainer.Name = "DataPanelContainer";
            this.DataPanelContainer.Size = new System.Drawing.Size(194, 224);
            this.DataPanelContainer.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(194, 224);
            this.dataGridView1.TabIndex = 0;
            // 
            // MapContainer
            // 
            this.MapContainer.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.MapContainer.InnerContainer = this.MapContainerContainer;
            this.MapContainer.Location = new System.Drawing.Point(203, 29);
            this.MapContainer.Name = "MapContainer";
            this.MapContainer.Size = new System.Drawing.Size(419, 500);
            this.MapContainer.TabIndex = 4;
            this.MapContainer.Text = "地图容器";
            // 
            // MapContainerContainer
            // 
            this.MapContainerContainer.Controls.Add(this.uiTab);
            this.MapContainerContainer.Location = new System.Drawing.Point(1, 1);
            this.MapContainerContainer.Name = "MapContainerContainer";
            this.MapContainerContainer.Size = new System.Drawing.Size(417, 498);
            this.MapContainerContainer.TabIndex = 0;
            // 
            // uiTab
            // 
            this.uiTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTab.Location = new System.Drawing.Point(0, 0);
            this.uiTab.Name = "uiTab";
            this.uiTab.Size = new System.Drawing.Size(417, 498);
            this.uiTab.TabIndex = 0;
            this.uiTab.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.mapTab,
            this.pageTab});
            // 
            // mapTab
            // 
            this.mapTab.Controls.Add(this.axLicenseControl2);
            this.mapTab.Controls.Add(this.axMapControl);
            this.mapTab.Location = new System.Drawing.Point(1, 20);
            this.mapTab.Name = "mapTab";
            this.mapTab.Size = new System.Drawing.Size(415, 477);
            this.mapTab.TabStop = true;
            this.mapTab.Text = "地图";
            // 
            // axLicenseControl2
            // 
            this.axLicenseControl2.Enabled = true;
            this.axLicenseControl2.Location = new System.Drawing.Point(55, 322);
            this.axLicenseControl2.Name = "axLicenseControl2";
            this.axLicenseControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl2.OcxState")));
            this.axLicenseControl2.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl2.TabIndex = 1;
            // 
            // axMapControl
            // 
            this.axMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl.Location = new System.Drawing.Point(0, 0);
            this.axMapControl.Name = "axMapControl";
            this.axMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl.OcxState")));
            this.axMapControl.Size = new System.Drawing.Size(415, 477);
            this.axMapControl.TabIndex = 0;
            this.axMapControl.OnMouseUp += new AxESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseUpEventHandler(this.axMapControl_OnMouseUp);
            this.axMapControl.OnMouseMove += new AxESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEventHandler(this.axMapControl_OnMouseMove);
            this.axMapControl.OnDoubleClick += new AxESRI.ArcGIS.Controls.IMapControlEvents2_OnDoubleClickEventHandler(this.axMapControl_OnDoubleClick);
            this.axMapControl.OnViewRefreshed += new AxESRI.ArcGIS.Controls.IMapControlEvents2_OnViewRefreshedEventHandler(this.axMapControl_OnViewRefreshed);
            this.axMapControl.OnKeyDown += new AxESRI.ArcGIS.Controls.IMapControlEvents2_OnKeyDownEventHandler(this.axMapControl_OnKeyDown);
            this.axMapControl.OnKeyUp += new AxESRI.ArcGIS.Controls.IMapControlEvents2_OnKeyUpEventHandler(this.axMapControl_OnKeyUp);
            // 
            // pageTab
            // 
            this.pageTab.Controls.Add(this.axPageLayoutControl);
            this.pageTab.Location = new System.Drawing.Point(1, 20);
            this.pageTab.Name = "pageTab";
            this.pageTab.Size = new System.Drawing.Size(415, 477);
            this.pageTab.TabStop = true;
            this.pageTab.Text = "制版";
            // 
            // axPageLayoutControl
            // 
            this.axPageLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl.Location = new System.Drawing.Point(0, 0);
            this.axPageLayoutControl.Name = "axPageLayoutControl";
            this.axPageLayoutControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl.OcxState")));
            this.axPageLayoutControl.Size = new System.Drawing.Size(415, 477);
            this.axPageLayoutControl.TabIndex = 0;
            this.axPageLayoutControl.OnMouseDown += new AxESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnMouseDownEventHandler(this.axPageLayoutControl_OnMouseDown);
            this.axPageLayoutControl.OnMouseUp += new AxESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnMouseUpEventHandler(this.axPageLayoutControl_OnMouseUp);
            this.axPageLayoutControl.OnMouseMove += new AxESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnMouseMoveEventHandler(this.axPageLayoutControl_OnMouseMove);
            this.axPageLayoutControl.OnDoubleClick += new AxESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnDoubleClickEventHandler(this.axPageLayoutControl_OnDoubleClick);
            this.axPageLayoutControl.OnKeyDown += new AxESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnKeyDownEventHandler(this.axPageLayoutControl_OnKeyDown);
            this.axPageLayoutControl.OnKeyUp += new AxESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnKeyUpEventHandler(this.axPageLayoutControl_OnKeyUp);
            this.axPageLayoutControl.OnViewRefreshed += new AxESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnViewRefreshedEventHandler(this.axPageLayoutControl_OnViewRefreshed);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(0, 0);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(265, 265);
            this.axMapControl1.TabIndex = 0;
            // 
            // MainGIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 555);
            this.Controls.Add(this.MapContainer);
            this.Controls.Add(this.uiPanelGroup);
            this.Controls.Add(this.uiStatusBar);
            this.Controls.Add(this.TopRebar1);
            this.Name = "MainGIS";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainGIS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelGroup)).EndInit();
            this.uiPanelGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TOCPanel)).EndInit();
            this.TOCPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayerPanel)).EndInit();
            this.LayerPanel.ResumeLayout(false);
            this.LayerPanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Property)).EndInit();
            this.Property.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataPanel)).EndInit();
            this.DataPanel.ResumeLayout(false);
            this.DataPanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapContainer)).EndInit();
            this.MapContainer.ResumeLayout(false);
            this.MapContainerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab)).EndInit();
            this.uiTab.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).EndInit();
            this.pageTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar MainMenu;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager;
        private Janus.Windows.UI.Dock.UIPanelGroup TOCPanel;
        private Janus.Windows.UI.Dock.UIPanel LayerPanel;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer LayerPanelContainer;
        private Janus.Windows.UI.Dock.UIPanel Property;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer PropertyContainer;
        private Janus.Windows.UI.Dock.UIPanel DataPanel;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer DataPanelContainer;
        private Janus.Windows.UI.Dock.UIPanelGroup uiPanelGroup;
        private Janus.Windows.UI.Dock.UIPanel MapContainer;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer MapContainerContainer;
        private Janus.Windows.UI.Tab.UITab uiTab;
        private Janus.Windows.UI.Tab.UITabPage mapTab;
        private Janus.Windows.UI.Tab.UITabPage pageTab;
        private AxESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private AxESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private AxESRI.ArcGIS.Controls.AxMapControl axMapControl;
        private AxESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl;
        private AxESRI.ArcGIS.Controls.AxTOCControl axTOCControl;
        private AxESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

