using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBGIS.PluginEngine;

namespace NBGIS.DockOverMap
{
    class dockableOverMapWin : NBGIS.PluginEngine.IDockableWindowDef
    {
        #region IDockableWindowDef 成员

        private DockForm frm = null;

        public string Caption
        {
            get { return "鸟瞰地图"; }
        }

        public System.Windows.Forms.Control ChildHWND
        {
            get { return frm; }
        }

        public string Name
        {
            get { return "OverMapWin"; }
        }

        public void OnCreate(IApplication hook)
        {
            frm = new DockForm();
            if (hook!= null)
            {
                frm.Hook = hook;
            }
        }

        public void OnDestroy()
        {
            frm = null;
        }

        public object UserData
        {
            get { return null; }
        }

        #endregion
    }
}
