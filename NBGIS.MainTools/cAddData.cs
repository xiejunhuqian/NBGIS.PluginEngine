using System;
using System.Drawing;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using NBGIS.PluginEngine;


namespace NBGIS.MainTools
{
    class cAddData : NBGIS.PluginEngine.ICommand
    {
        private NBGIS.PluginEngine.IApplication hk;
        private System.Drawing.Bitmap m_hBitmap;

        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;

        public cAddData()
        {
            m_hBitmap = new System.Drawing.Bitmap(
                this.GetType().Assembly.GetManifestResourceStream(
                "NBGIS.MainTools.添加数据.png"));
        }

        #region ICommand 成员

        public Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "添加数据"; }
        }

        public string Category
        {
            get { return "MainTool"; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public bool Enabled
        {
            get { return true; }
        }

        public int HelpContextID
        {
            get { return 0; }
        }

        public string HelpFile
        {
            get { return ""; }
        }

        public string Message
        {
            get { return "添加数据"; }
        }

        public string Name
        {
            get { return "AddData"; }
        }

        public void OnClick()
        {
            cmd.OnClick();
        }

        public void OnCreate(PluginEngine.IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
                cmd = new ControlsAddDataCommandClass();
                cmd.OnCreate(this.hk.MapControl);
            }
            
        }

        public string Tooltip
        {
            get { return "添加数据"; }
        }

        #endregion
    }
}
