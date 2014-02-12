using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    public class ItemDef : IItemDef
    {

        bool _Group;
        string _Id;
        long _SubType;


        #region IItemDef 成员

        public string ID
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }

        public bool Group
        {
            get
            {
                return this._Group;
            }
            set
            {
                this._Group = value;
            }
        }

        public long Subtype
        {
            get
            {
                return this._SubType;
            }
            set
            {
                this._SubType = value;
            }
        }

        #endregion
    }
}
