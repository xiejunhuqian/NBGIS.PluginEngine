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
    class cPan : NBGIS.PluginEngine.ITool
    {
        private NBGIS.PluginEngine.IApplication hk;
        private System.Drawing.Bitmap m_hBitmap;
        private IActiveView pActiveView;

        public cPan()
        {
            m_hBitmap = new Bitmap(this.GetType().Assembly.
                GetManifestResourceStream("NBGIS.MainTools.平移.png"));
        }

        #region ITool 成员

        public Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "平移"; }
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
            get { return (int)
                ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerPan; }
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
            get { return "平移"; }
        }

        public string Name
        {
            get { return "Pan"; }
        }

        public void OnClick()
        {
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
            }
        }

        public void OnDbClick()
        {
        }

        public void OnKeyDown(int keyCode, int shift)
        {
            pActiveView = hk.MapControl.ActiveView;
            hk.MapControl.Pan();

            ITrackCancel pTrackCancel = new CancelTrackerClass();
            pActiveView.Draw(0, pTrackCancel);

            if (pTrackCancel.Continue())
            {
                hk.StatueBar.Panels[0].Text = "地图正在绘制";
            } 
            else
            {
                hk.StatueBar.Panels[0].Text = "地图绘制已经停止";
            }
            pActiveView.Refresh();
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
            get { return "平移"; }
        }

        #endregion
    }
}
