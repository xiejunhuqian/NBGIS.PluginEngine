using System;
using System.Drawing;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using NBGIS.PluginEngine;
using Janus.Windows.UI.StatusBar;

namespace NBGIS.MainTools
{
    class cZoomIn:NBGIS.PluginEngine.ITool
    {
        private NBGIS.PluginEngine.IApplication hk;
        private System.Drawing.Bitmap m_hBitmap;
        private ESRI.ArcGIS.SystemUI.ITool tool = null;
        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;

        public cZoomIn()
        {
            m_hBitmap = new Bitmap(this.GetType().Assembly.
                GetManifestResourceStream("NBGIS.MainTools.放大.png"));
        }


        #region ITool 成员

        public Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "地图放大"; }
        }

        public string Category
        {
            get { return "MainTool"; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public int Cursor
        {
            get
            {
                return (int)
                    ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerZoomIn;
            }
        }

        public bool Deactivate()
        {
            return false;
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
            get { return "地图放大"; }
        }

        public string Name
        {
            get { return "ZoomIn"; }
        }

        public void OnClick()
        {
            cmd.OnClick();
            this.hk.MapControl.CurrentTool = tool;
        }

        public bool OnContextMenu(int x, int y)
        {
            return false;
        }

        public void OnCreate(PluginEngine.IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
                tool = new ControlsMapZoomInToolClass();
                cmd = tool as ESRI.ArcGIS.SystemUI.ICommand;
                cmd.OnCreate(this.hk.MapControl);
            }
        }

        public void OnDbClick()
        {
        }

        public void OnKeyDown(int keyCode, int shift)
        {
        }
        public void OnKeyUp(int keyCode, int shift)
        {
        }

        public void OnMouseDown(int button, int shift, int x, int y)
        {
        }

        public void OnMouseMove(int button, int shift, int x, int y)
        {
        }

        public void OnMouseUp(int button, int shift, int x, int y)
        {
        }

        public void Refresh(int hDc)
        {
        }

        public string Tooltip
        {
            get { return "地图放大"; }
        }

        #endregion
    }
}
