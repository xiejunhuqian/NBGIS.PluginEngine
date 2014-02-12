using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using NBGIS.PluginEngine;
using Janus.Windows.UI.CommandBars;
using Janus.Windows.UI.Dock;
using AxESRI.ArcGIS.Controls;


namespace NBGIS.MainGIS
{
    public partial class MainGIS : Form
    {
        #region 定义对象

        private ESRI.ArcGIS.Controls.IMapControlDefault _mapControl = null;
        private ESRI.ArcGIS.Controls.IPageLayoutControlDefault _pageLayoutControl = null;
        private ESRI.ArcGIS.Controls.ITOCControlDefault _tocControl = null;

        //宿主对象
        private NBGIS.PluginEngine.IApplication _App = null;
        //保存地图数据的   DataSet
        private DataSet _DataSet = null;
        //当前使用的 Tool
        private NBGIS.PluginEngine.ITool _Tool = null;
        //插件对象集合
        private Dictionary<string, NBGIS.PluginEngine.ICommand> _CommandCol = null;
        private Dictionary<string, NBGIS.PluginEngine.ITool> _ToolCol = null;
        private Dictionary<string, NBGIS.PluginEngine.IToolBarDef> _ToolBarCol = null;
        private Dictionary<string, NBGIS.PluginEngine.IMenuDef> _MenuItemCol = null;
        private Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef>
            _DockableWindowCol = null;
        //用来区别对待UIToll_Click事件的结构对象
        public DELEGATE_UITOOLCLICK_HasDone UIToolClick_HasDone;

        #endregion

        #region 方法

        #region //定义UITool_Click 事件方法的代理类对象，并实例化它

        //定义UITool_Click 事件方法的代理类对象，并实例化它
        private delegate void DELEGATE_UITOOLCLICK(CommandEventArgs e,
            ref NBGIS.PluginEngine.ITool tool, object sender,
            ref DELEGATE_UITOOLCLICK_HasDone hasDone);
        private DELEGATE_UITOOLCLICK _delegate_uiToolClick = null;
        public struct DELEGATE_UITOOLCLICK_HasDone
        {
            public bool done;
        }
        /// <summary>
        /// //UITool对象的活动是接力赛，多人合作完成，情况比较多，我们采用维多代理的方式实现。
        /// </summary>
        /// <param name="e">触发事件的对象，一般是鼠标或者是键盘</param>
        /// <param name="tool">插件对象：ITool</param>
        /// <param name="sender">插件界面对象：UICommand</param>
        private void UITool_ClickOnceOwnTwiceOther(CommandEventArgs e,
            ref NBGIS.PluginEngine.ITool tool, object sender, 
            ref DELEGATE_UITOOLCLICK_HasDone hasDone)
        {
            if (hasDone.done == false)
            {
                //Tool1 点1下，Tool2点1下
                //先把Tool1关闭了，然后启动Tool2

                //先把Tool1关闭了
                //找到Tool1
                UICommand lastTool = this.uiCommandManager.Commands[this._App.CurrentTool];
                //设置Tool1为未选中
                if (lastTool != null)
                {
                    lastTool.Checked = Janus.Windows.UI.InheritableBoolean.False;
                }
                //清理主框架容器，等于把Tool1清理掉
                this._App.PageLayoutControl.CurrentTool = null;
                this._App.MapControl.CurrentTool = null;

                //启动tool2
                //显示Tool的个人信息，在状态栏中
                this._App.StatueBar.Panels[0].Text = tool.Message;
                //这里的sender代表的是一个Tool
                ((UICommand)sender).Checked = Janus.Windows.UI.InheritableBoolean.True;
                //设置不同容器中鼠标的样式
                this.axMapControl.MousePointer =
                    (ESRI.ArcGIS.Controls.esriControlsMousePointer)(tool.Cursor);
                this.axPageLayoutControl.MousePointer =
                    (ESRI.ArcGIS.Controls.esriControlsMousePointer)(tool.Cursor);
                //Tool执行OnClick()
                tool.OnClick();
                //Tool成为框架当前的活动对象
                this._App.CurrentTool = tool.ToString();

                hasDone.done = true;
            }
        }
        private void UITool_ClickOwnTwice(CommandEventArgs e,
            ref NBGIS.PluginEngine.ITool tool, object sender,
            ref DELEGATE_UITOOLCLICK_HasDone hasDone)
        {
            if (hasDone.done == false)
            {
                //Tool 点自己2下
                //让Tool先完成工作，知道完成工作，处于关闭状态。
                if (this._App.CurrentTool == e.Command.Key)
                {
                    ((UICommand)sender).Checked = Janus.Windows.UI.InheritableBoolean.False;
                    this.axMapControl.MousePointer =
                        ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerDefault;
                    this.axPageLayoutControl.MousePointer =
                        ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerDefault;
                    this._App.CurrentTool = null;
                    this._App.MapControl.CurrentTool = null;
                    this._App.PageLayoutControl.CurrentTool = null;
                    hasDone.done = true;
                }             
            }


        }
        private void UITool_ClickOwnOnce(CommandEventArgs e,
            ref NBGIS.PluginEngine.ITool tool, object sender,
            ref DELEGATE_UITOOLCLICK_HasDone hasDone)
        {
            //Tool 点自己1下
            if (this._App.CurrentTool == null &&
                this._mapControl.CurrentTool == null &&
                this._pageLayoutControl.CurrentTool == null)
            {
                //显示Tool的个人信息，在状态栏中
                this._App.StatueBar.Panels[0].Text = tool.Message;
                //这里的sender代表的是一个Tool
                ((UICommand)sender).Checked = Janus.Windows.UI.InheritableBoolean.True;
                //设置不同容器中鼠标的样式
                this.axMapControl.MousePointer =
                    (ESRI.ArcGIS.Controls.esriControlsMousePointer)(tool.Cursor);
                this.axPageLayoutControl.MousePointer =
                    (ESRI.ArcGIS.Controls.esriControlsMousePointer)(tool.Cursor);
                //Tool执行OnClick()
                tool.OnClick();
                //Tool成为框架当前的活动对象
                this._App.CurrentTool = tool.ToString();

                hasDone.done = true;
            }
        }


        #endregion

        /// <summary>
        /// 建立联系 插件对象 与 UI对象（插件的摸样，行为的融合与激活）
        /// </summary>
        private void CreateUIObjectFromPluginObject()
        {
            if (this._CommandCol.Count != 0 || this._ToolCol.Count != 0 ||
                this._ToolBarCol.Count != 0 || this._MenuItemCol.Count != 0 ||
                this._DockableWindowCol.Count != 0)
            {
                CreateUICommandTool(this._CommandCol, this._ToolCol);
                CreateToolBar(this._ToolBarCol);
                CreateMenus(this._MenuItemCol);
                CreateDockableWindow(this._DockableWindowCol);
            }
        }

        #endregion

        #region 初始化主框架（建立 插件对象 与 UI对象 之间的联系）

        public MainGIS()
        {
            //初始化窗口的控件
            InitializeComponent();
            //初始化设计地图的控件和数据容器
            this.axTOCControl.SetBuddyControl(this.axMapControl.Object);
            _mapControl = axMapControl.Object as IMapControlDefault;
            _pageLayoutControl = axPageLayoutControl.Object as IPageLayoutControlDefault;
            _tocControl = axTOCControl.Object as ITOCControlDefault;

            this._DataSet = new DataSet();

            //初始化主框架对象
            this._App = new NBGIS.PluginEngine.Application();
            this._App.StatueBar = this.uiStatusBar;
            this._App.MapControl = _mapControl;
            this._App.PageLayoutControl = _pageLayoutControl;
            this._App.MainPlatform = this;
            this._App.Caption = this.Text;
            this._App.Visible = this.Visible;
            this._App.CurrentTool = null;
            this._App.MainDataSet = this._DataSet;

            //用来区别对待UIToll_Click事件的结构对象
            UIToolClick_HasDone = new DELEGATE_UITOOLCLICK_HasDone();

            //UITool_Click 可能出现的事件的罗列与绑定。实现方式：委托，代理
            _delegate_uiToolClick = UITool_ClickOwnOnce;
            _delegate_uiToolClick += UITool_ClickOwnTwice;
            _delegate_uiToolClick += UITool_ClickOnceOwnTwiceOther;
        }
        private void MainGIS_Load(object sender, EventArgs e)
        {
            #region 测试001

            //作者：谢军
            //日期：2014-01-04
            //事件1
            //this._App.Caption = "test";
            //this._App.StatueBar.Panels[0].Text = "test0";
            //this._App.StatueBar.Panels[1].Text = "test1";

            #endregion

            //从插件文件夹中获得实现了插件接口的对象
            PluginCollection pluginCol = PluginHandle.GetPluginsFromDll();

            //解析这些插件对象，获得不同类型的插件集合
            ParsePluginCollection parsePluginCol = new ParsePluginCollection();
            parsePluginCol.GetPluginArray(pluginCol);
            this._CommandCol = parsePluginCol.GetCommands;
            this._ToolCol = parsePluginCol.GetTools;
            this._ToolBarCol = parsePluginCol.GetToolBarDefs;
            this._MenuItemCol = parsePluginCol.GetMenuDefs;
            this._DockableWindowCol = parsePluginCol.GetDockableWindows;

            //获得 Command 和 Tool 在 UI 层上的 Category 属性
            foreach (string categoryName in parsePluginCol.GetCommandCategorys)
            {
                this.uiCommandManager.Categories.Add(new
                    UICommandCategory(categoryName));
            }

            //建立联系 插件对象 与 UI对象（插件的摸样，行为的融合与激活）
            CreateUIObjectFromPluginObject();

        }

        #region 建立联系 插件对象 与 UI对象（插件的摸样，行为的融合与激活）

        #region //他们（ICommand、ITool）是UI层对象，也有事件与之联系

        //产生 UICommand对象 和 ITool对象 （指的是摸样，相貌，行为，举止，灵魂，生活。）
        private void CreateUICommandTool(
            Dictionary<string, NBGIS.PluginEngine.ICommand> Cmds,
            Dictionary<string, NBGIS.PluginEngine.ITool> Tools)
        {
            #region 遍历 ICommand 对象集合

            //遍历 ICommand 对象集合
            foreach (KeyValuePair<string, NBGIS.PluginEngine.ICommand> cmd in Cmds)
            {
                //获得一个 ICommand 对象
                NBGIS.PluginEngine.ICommand nbcmd = cmd.Value;
                //产生一个 UICommand 对象
                UICommand UICommand = new UICommand();
                //根据 ICommand 的信息设置 UICommand 的属性
                UICommand.ToolTipText = nbcmd.Tooltip;
                UICommand.Text = nbcmd.Caption;
                UICommand.CategoryName = nbcmd.Category;
                UICommand.Image = nbcmd.Bitmap;
                UICommand.Key = nbcmd.ToString();
                //UICommand 的 Enable 默认为 true
                if (!nbcmd.Enabled)
                {
                    UICommand.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                //UICommand 的 Checked 默认为 false
                if (nbcmd.Checked)
                {
                    UICommand.Checked = Janus.Windows.UI.InheritableBoolean.True;
                }

                //产生 UICommand 时调用 OnCreate 方法，将主框架对象传递给插件对象
                nbcmd.OnCreate(this._App);
                //使用委托机制处理 Command 的事件
                //所有的 UICommand 对象 Click 事件均使用 this.Command_Click 方法处理
                UICommand.Click += new CommandEventHandler(UICommand_Click);
                //将生成的 UICommand 添加到 CommandManager 中
                this.uiCommandManager.Commands.Add(UICommand);
            }


            #endregion

            #region 遍历 ITool 对象集合

            foreach (KeyValuePair<string, NBGIS.PluginEngine.ITool> tool in Tools)
            {
                NBGIS.PluginEngine.ITool nbtool = tool.Value;
                UICommand UITool = new UICommand();
                UITool.ToolTipText = nbtool.Tooltip;
                UITool.Text = nbtool.Caption;
                UITool.CategoryName = nbtool.Category;
                UITool.Image = nbtool.Bitmap;
                UITool.Key = nbtool.ToString();
                if (!nbtool.Enabled)
                {
                    UITool.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                if (nbtool.Checked)
                {
                    UITool.Checked = Janus.Windows.UI.InheritableBoolean.True;
                }
                //把主框架对象传递给插件对象
                nbtool.OnCreate(this._App);
                //使用委托机制处理 ITool 事件
                UITool.Click += new CommandEventHandler(UITool_Click);
                //将生成的 UICommand 添加到 CommandManager 中
                this.uiCommandManager.Commands.Add(UITool);
            }

            #endregion
        }

        #endregion

        #region //他们（ToolBar、Menu、DockableWindow）是纯粹的UI层对象，没有事件与之联系

        //产生 Toolbar的UI层对象，（指的是摸样，相貌）
        private void CreateToolBar(
            Dictionary<string, NBGIS.PluginEngine.IToolBarDef> toolBars)
        {
            foreach (KeyValuePair<string, NBGIS.PluginEngine.IToolBarDef> toolbar in toolBars)
            {
                NBGIS.PluginEngine.IToolBarDef nbtoolbar = toolbar.Value;
                //产生 UICommand对象
                UICommandBar UIToolbar = new UICommandBar();
                UIToolbar.CommandManager = this.uiCommandManager;
                UIToolbar.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
                UIToolbar.Name = nbtoolbar.Name;
                UIToolbar.Tag = nbtoolbar.Caption;
                UIToolbar.Key = nbtoolbar.ToString();


                //将 Command 和 Tool 插入 ToolBar 中
                NBGIS.PluginEngine.IItemDef itemDef = new NBGIS.PluginEngine.ItemDef();
                for (int i = 0; i < nbtoolbar.ItemCount; i++)
                {
                    nbtoolbar.GetItemInfo(i, itemDef);
                    UICommand uiCmd = null;

                    /*  如果一个 ICommand对象 由于某些我们未捕捉到问题，而没有正确的产生，
                     *  可是在 Toolbar 或 Menu 中又存在它的名字，
                     *  使用 this.uiCommandManager.Commands[itemdef.ID] 属性获取该
                     *  ICommand对象 就会出现异常。                    
                     */
                    try
                    {
                        uiCmd = this.uiCommandManager.Commands[itemDef.ID];
                    }
                    catch (System.Exception ex)
                    {
                        //这里为什么不做错误处理呢？

                    }
                    finally
                    {
                        //这里为什么不做错误处理呢？
                    }

                    if (uiCmd != null)
                    {
                        //如果是分组，就应在该 UI对象之间加上一个分隔符。
                        if (itemDef.Group)
                        {
                            UIToolbar.Commands.AddSeparator();
                        }
                        UIToolbar.Commands.Add(uiCmd);
                    }

                }
            }
        }

        /// <summary>
        /// 它是个工具条 MainToolbar，它定义了自己的名称，标题，携带的项数量，根据用户
        /// 的需要返回自己携带项的详细信息。
        /// </summary>
        class MainToolbar : NBGIS.PluginEngine.IToolBarDef
        {
            #region IToolBarDef 成员

            public string Caption
            {
                get { return "MainTools"; }
            }

            public string Name
            {
                get { return "MainTools"; }
            }

            public long ItemCount
            {
                get { return 3; }
            }

            public void GetItemInfo(int pos, PluginEngine.IItemDef itemDef)
            {
                switch (pos)
                {
                    case 0:
                        itemDef.ID = "NBGIS.MainTools.cAddData";
                        itemDef.Group = false;
                        break;

                    case 1:
                        itemDef.ID = "NBGIS.MainTools.cZoomIn";
                        itemDef.Group = true;
                        break;

                    case 2:
                        itemDef.ID = "NBGIS.MainTools.cZoomOut";
                        itemDef.Group = false;
                        break;

                    case 3:
                        itemDef.ID = "NBGIS.DockOverMap";
                        itemDef.Group = false;
                        break;

                    default:
                        break;
                }
            }

            #endregion
        }

        //产生 UI层的菜单栏
        private void CreateMenus(Dictionary<string, NBGIS.PluginEngine.IMenuDef> Menus)
        {
            /* 遍历 menuCol 中的元素、
             * 创建躯体UIMenu、
             * 把元素给予躯体，将彼此激活（固定的名字，动态的思想与行为）、
             * 将人放入都市中让其经历各种各样的事件，学会这东西可以吃，那东西不能吃等这些知识，好让他生存下去。
             */

            foreach (KeyValuePair<string, NBGIS.PluginEngine.IMenuDef> menu in Menus)
            {
                NBGIS.PluginEngine.IMenuDef nbMenu = menu.Value;

                UICommand UIMenu = new UICommand();
                UIMenu.Text = nbMenu.Caption;
                UIMenu.Tag = nbMenu;
                UIMenu.Key = nbMenu.ToString();

                this.MainMenu.Commands.Add(UIMenu);

                //我们把 Command、ITool 放入 menu 中
                NBGIS.PluginEngine.IItemDef itemDef = new NBGIS.PluginEngine.ItemDef();
                for (int i = 0; i < nbMenu.ItemCount; i++)
                {
                    //看看准备进入UIMenu的itemDef是单个人呢，还是以小组呢？
                    nbMenu.GetItemInfo(i, itemDef);

                    //如果 插件itemDef 与 框架UI层 插件itemDef 的名称不一致，就要提示错误。
                    UICommand uiCmd = null;
                    try
                    {
                        uiCmd = this.uiCommandManager.Commands[itemDef.ID];
                    }
                    catch (System.Exception ex)
                    {

                    }

                    //如果 UICommand 存在，就添加它到框架上的UIMenu中
                    if (uiCmd != null)
                    {
                        //暂时不考虑小小组的情况，只要是小组就用分割线区分
                        if (itemDef.Group)
                        {
                            UIMenu.Commands.AddSeparator();
                        }
                        UIMenu.Commands.Add(uiCmd);
                    }
                }
            }


        }


        //产生 UI层的浮动窗口， IDockableWindowDef
        private void CreateDockableWindow(Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef>
            dockWindows)
        {
            foreach (KeyValuePair<string, NBGIS.PluginEngine.IDockableWindowDef>
                dockWindowItem in dockWindows)
            {
                NBGIS.PluginEngine.IDockableWindowDef item = dockWindowItem.Value;
                item.OnCreate(this._App);
                UIPanel panel = new Janus.Windows.UI.Dock.UIPanel();
                panel.FloatingLocation = new System.Drawing.Point(120, 180);
                panel.FloatingSize = new System.Drawing.Size(188, 188);
                panel.Name = item.Name;
                panel.Text = item.Caption;
                panel.DockState = PanelDockState.Floating;

                ((System.ComponentModel.ISupportInitialize)(panel)).BeginInit();
                panel.SuspendLayout();
                panel.Id = Guid.NewGuid();
                this.uiPanelManager.Panels.Add(panel);

                UIPanelInnerContainer panelContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
                panel.InnerContainer = panelContainer;
                //异常发生处
                try
                {
                    //这个地方容易发生异常，插件必须保证 ChildHWND 完全正确
                    panelContainer.Controls.Add(item.ChildHWND);
                    panelContainer.Location = new System.Drawing.Point(1, 27);
                    panelContainer.Name = item.Name + "Container";
                    panelContainer.Size = new System.Drawing.Size(188, 188);
                    panelContainer.TabIndex = 0;
                }
                catch (System.Exception ex)
                {
                    if (AppLog.log.IsErrorEnabled)
                    {
                        AppLog.log.Error("浮动窗插件的子控件没有正确加载");
                    }
                }
            }
        }

        #endregion

        #endregion

        #region UI层对象事件

        //UITool_Click 事件
        //UITool对象的活动是接力赛，多人合作完成，情况比较多，我们采用维多代理的方式实现。
        private void UITool_Click(object sender, CommandEventArgs e)
        {
            NBGIS.PluginEngine.ITool tool = this._ToolCol[e.Command.Key];

            UIToolClick_HasDone.done = false;

            _delegate_uiToolClick(e, ref tool, sender, ref UIToolClick_HasDone);
        }

        //UICommand_Click 事件
        //UICommand对象的活动是单人100M，自己独自完成，相比UITool的多人合作情况少。
        private void UICommand_Click(object sender, CommandEventArgs e)
        {
            //when Command was passed，this._App's CurrentTool set null
            //MapControl and PageLayoutCOntrol's CurrentTool set null.
            this._App.CurrentTool = null;
            this._App.MapControl.CurrentTool = null;
            this._App.PageLayoutControl.CurrentTool = null;

            //set all command's checked to false.
            foreach (UICommand UICmd in this.uiCommandManager.Commands)
            {
                UICmd.Checked = Janus.Windows.UI.InheritableBoolean.False;
            }

            //get current command
            NBGIS.PluginEngine.ICommand iCmd = this._CommandCol[e.Command.Key];
            //show plugin's information in statubar's panel
            this.uiStatusBar.Panels[0].Text = iCmd.Message;
            //set iCmd live.
            ((UICommand)sender).Checked = Janus.Windows.UI.InheritableBoolean.True;
            //set Map-Control's mouse
            this.axMapControl.MousePointer =
                ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerDefault;
            //process command's event
            iCmd.OnClick();
            //set iCmd unlive.
            ((UICommand)sender).Checked = Janus.Windows.UI.InheritableBoolean.False;


        }

        //ITool 的地图交互事件
        //涉及到的对象：MapControl、PageLayoutControl
        private void axMapControl_OnMouseMove(object sender,
            IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.OnMouseMove(e.button, e.shift, (int)e.mapX, (int)e.mapY);
                this.uiStatusBar.Panels[2].Text = "当前坐标 X：" + e.mapX.ToString() +
                    "   Y：" + e.mapY.ToString();
            }
            this.uiStatusBar.Panels[3].Text = "比例尺：" +
                ((long)(this._mapControl.MapScale)).ToString();
        }

        private void axMapControl_OnMouseUp(object sender,
            IMapControlEvents2_OnMouseUpEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.OnMouseUp(e.button, e.shift, (int)e.mapX, (int)e.mapY);
                this.uiStatusBar.Panels[2].Text = "当前坐标 X：" + e.mapX.ToString() +
                    "   Y：" + e.mapY.ToString();
            }
        }

        private void axMapControl_OnKeyDown(object sender,
            IMapControlEvents2_OnKeyDownEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.OnKeyDown(e.keyCode, e.shift);
            }
        }

        private void axMapControl_OnKeyUp(object sender,
            IMapControlEvents2_OnKeyUpEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.OnKeyUp(e.keyCode, e.shift);
            }
        }

        private void axMapControl_OnDoubleClick(object sender,
            IMapControlEvents2_OnDoubleClickEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.OnDbClick();
            }
        }

        private void axMapControl_OnViewRefreshed(object sender,
            IMapControlEvents2_OnViewRefreshedEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.Refresh(0);
            }
        }

        private void axPageLayoutControl_OnMouseDown(object sender,
            IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                if (e.button == 1)
                {
                    this._Tool.OnMouseDown(e.button, e.shift, (int)e.pageX, (int)e.pageY);
                }
                else
                {
                    this._Tool.OnContextMenu(e.x, e.y);
                }
            }
        }

        private void axPageLayoutControl_OnMouseMove(object sender,
            IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.OnMouseMove(e.button, e.shift, (int)e.pageX, (int)e.pageY);
            }
        }

        private void axPageLayoutControl_OnMouseUp(object sender,
            IPageLayoutControlEvents_OnMouseUpEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.OnMouseUp(e.button, e.shift, (int)e.pageX, (int)e.pageY);
            }
        }

        private void axPageLayoutControl_OnDoubleClick(object sender,
            IPageLayoutControlEvents_OnDoubleClickEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.OnDbClick();
            }
        }

        private void axPageLayoutControl_OnKeyDown(object sender,
            IPageLayoutControlEvents_OnKeyDownEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.OnKeyDown(e.keyCode, e.shift);
            }
        }

        private void axPageLayoutControl_OnKeyUp(object sender,
            IPageLayoutControlEvents_OnKeyUpEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.OnKeyUp(e.keyCode, e.shift);
            }
        }

        private void axPageLayoutControl_OnViewRefreshed(object sender,
            IPageLayoutControlEvents_OnViewRefreshedEvent e)
        {
            if (this._App.CurrentTool != null)
            {
                this._Tool = this._ToolCol[this._App.CurrentTool];
                this._Tool.Refresh(0);
            }
        }

        #endregion

        
        #endregion

    }



}
