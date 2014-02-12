using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using Janus.Windows.UI.StatusBar;

/* 
 * Application 它来实现宿主抽象内容。
 * 注意：如果更改接口，绝对不要在眼前的接口中修改，而是新设计一个新的接口就可以了。
 * 
 * 
 * 
 * 
 * 
 */ 

namespace NBGIS.PluginEngine
{
    /// <summary>
    ///     IApplication 接口的实现
    /// </summary>
    public class Application : IApplication
    {
        string _Caption;
        string _CurrentTool;
        DataSet _MainDataSet;
        IMapDocument _Document;
        IMapControlDefault _MapControl;
        IPageLayoutControlDefault _PagelayoutControl;
        string _Name = "";
        Form _MainPlatfrom;
        UIStatusBar _StatusBar;
        bool _Visible;

        #region IApplication 成员

        public string Caption
        {
            get
            {
                this._Caption = this._MainPlatfrom.Text;
                return this._Caption;
            }
            set
            {
                this._Caption = value;
                this._MainPlatfrom.Text = this._Caption;
            }
        }

        public string CurrentTool
        {
            get
            {                
                return this._CurrentTool;
            }
            set
            {
                this._CurrentTool = value;
            }
        }

        public DataSet MainDataSet
        {
            get
            {
                return this._MainDataSet;
            }
            set
            {
                this._MainDataSet = value;
            }
        }

        public ESRI.ArcGIS.Carto.IMapDocument Document
        {
            get
            {
                return this._Document;
            }
            set
            {
                this._Document = value;
            }
        }

        public ESRI.ArcGIS.Controls.IMapControlDefault MapControl
        {
            get
            {
                return this._MapControl;
            }
            set
            {
                this._MapControl = value;
            }
        }

        public ESRI.ArcGIS.Controls.IPageLayoutControlDefault PageLayoutControl
        {
            get
            {
                return this._PagelayoutControl;
            }
            set
            {
                this._PagelayoutControl = value;
            }
        }

        public string Name
        {
            get
            {
                this._Name = this._MainPlatfrom.Name;
                return this._Name;
            }
            set
            {
                this._Name = value;
                this._MainPlatfrom.Name = this._Name;
            }
        }

        public Form MainPlatform
        {
            get
            {
                return this._MainPlatfrom;
            }
            set
            {
                this._MainPlatfrom = value;
            }
        }

        public Janus.Windows.UI.StatusBar.UIStatusBar StatueBar
        {
            get
            {
                return this._StatusBar;
            }
            set
            {
                this._StatusBar = value;
            }
        }

        public bool Visible
        {
            get
            {
                this._Visible = this._MainPlatfrom.Visible;
                return this._Visible;
            }
            set
            {
                this._Visible = value;
                this._MainPlatfrom.Visible = this._Visible;
            }
        }

        #endregion
    }
}
