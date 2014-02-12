using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace NBGIS.PluginEngine
{
    /// <summary>
    ///     解析插件容器中插件对象，将其分贝放置在不同的集合中
    /// </summary>
    public class ParsePluginCollection
    {
        //  Command 集合
        private Dictionary<string, NBGIS.PluginEngine.ICommand> _Commands;

        public Dictionary<string, NBGIS.PluginEngine.ICommand> GetCommands
        {
            get { return _Commands; }
        }
        //  Tool 集合
        private Dictionary<string, NBGIS.PluginEngine.ITool> _Tools;

        public Dictionary<string, NBGIS.PluginEngine.ITool> GetTools
        {
            get { return _Tools; }
        }
        //  Toolbar 集合
        private Dictionary<string, NBGIS.PluginEngine.IToolBarDef> _Toolbars;

        public Dictionary<string, NBGIS.PluginEngine.IToolBarDef> GetToolBarDefs
        {
            get { return _Toolbars; }
        }
        //  Menu 集合
        private Dictionary<string, NBGIS.PluginEngine.IMenuDef> _Menus;

        public Dictionary<string, NBGIS.PluginEngine.IMenuDef> GetMenuDefs
        {
            get { return _Menus; }
            set { _Menus = value; }
        }
        //  DockableWindow 集合
        private Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> _DockableWindows;

        public Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef> GetDockableWindows
        {
            get { return _DockableWindows; }
        }
        //  命令类型集合
        private ArrayList _CommandCategory;

        public ArrayList GetCommandCategorys
        {
            get { return _CommandCategory; }
        }

        public ParsePluginCollection()
        {
            //  初始化所有的集合容器
            this._Commands = new Dictionary<string, NBGIS.PluginEngine.ICommand>();
            this._Tools = new Dictionary<string, NBGIS.PluginEngine.ITool>();
            this._Toolbars = new Dictionary<string, NBGIS.PluginEngine.IToolBarDef>();
            this._Menus = new Dictionary<string, NBGIS.PluginEngine.IMenuDef>();
            this._DockableWindows = new Dictionary<string, NBGIS.PluginEngine.IDockableWindowDef>();
            this._CommandCategory = new ArrayList();
        }

        //  解析插件集合中所有对象
        //  将其分别装入 ICommand、ITool、IToolBarDef、IMenuDef 4个容器中
        public void GetPluginArray(PluginCollection pluginCol)
        {

            foreach (NBGIS.PluginEngine.IPlugin plugin in pluginCol)
            {

                NBGIS.PluginEngine.ICommand cmd = plugin as NBGIS.PluginEngine.ICommand;
                if (cmd != null)
                {
                    this._Commands.Add(cmd.ToString(), cmd);
                    //  找出该 Command 的 Category, 如果它还没有添加到 Category 中则添加；添加了就不用再装入了。
                    if (cmd.Category != null &&
                        _CommandCategory.Contains(cmd.Category) == false)
                    {
                        _CommandCategory.Add(cmd.Category);
                    }
                }


                NBGIS.PluginEngine.ITool tool = plugin as NBGIS.PluginEngine.ITool;
                if (tool != null)
                {
                    this._Tools.Add(tool.ToString(), tool);
                    //  找出该 Command 的 Category, 如果它还没有添加到 Category 中则添加；添加了就不用再装入了。
                    if (tool.Category != null &&
                        _CommandCategory.Contains(tool.Category) == false)
                    {
                        _CommandCategory.Add(tool.Category);
                    }
                }


                NBGIS.PluginEngine.IToolBarDef toolbardef = plugin as NBGIS.PluginEngine.IToolBarDef;
                if (toolbardef != null)
                {
                    this._Toolbars.Add(toolbardef.ToString(), toolbardef);
                    continue;
                }


                NBGIS.PluginEngine.IMenuDef menudef = plugin as NBGIS.PluginEngine.IMenuDef;
                if (menudef !=null)
                {
                    this._Menus.Add(menudef.ToString(), menudef);
                    continue;
                }


                NBGIS.PluginEngine.IDockableWindowDef dockablewindowdef = plugin as NBGIS.PluginEngine.IDockableWindowDef;
                if (dockablewindowdef != null)
                {
                    this._DockableWindows.Add(dockablewindowdef.ToString(), dockablewindowdef);
                    continue;
                }


            }











        }
    }
}
