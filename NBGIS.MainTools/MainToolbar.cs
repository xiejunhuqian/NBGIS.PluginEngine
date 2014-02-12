using System;
using NBGIS.PluginEngine;

namespace NBGIS.MainTools
{
    class MainToolbar : IToolBarDef
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

        public void GetItemInfo(int pos, IItemDef itemDef)
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
                    itemDef.ID = "NBGIS.MainTools.cPan";
                    itemDef.Group = true;
                    break;
                default:
                    break;
            }
        }



        #endregion
    }
}
