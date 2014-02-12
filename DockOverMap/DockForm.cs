using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NBGIS.PluginEngine;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;


namespace NBGIS.DockOverMap
{
    public partial class DockForm : Form
    {
        private IApplication hook;
        private IMap pOverMap = null;
        private IGraphicsContainer pGraCon = null;
        private IActiveView pAV = null;
        private IElement pEle;

        /// <summary>
        /// 看起来DockFrom的代码很长，但它做的事情很简单：
        /// 在只写属性 Hook 中，
        /// 
        ///     （1- 事件绑定）
        ///     当宿主对象 hook 被传给窗体类后，窗体将通过委托机制将宿主地图控件的3个事件与处理函数进行绑定处理，
        ///         3个事件分别是：
        ///         OnExtentUpdated：宿主地图的视图范围发生变化后触发的事件，这时鸟瞰窗体中的地图视图也随之变化。
        ///         ItemAdded：      宿主地图中添加数据后，鸟瞰地图设置背景层的方法。
        ///         ContentsCleared：宿主地图数据删除后，鸟瞰地图也随之改变。
        ///         看的出来，这几个事件与绑定的函数都是在描述 宿主地图与鸟瞰地图之间的你来我往的互动。
        ///         
        ///     （2- 在DockForm上画画）
        ///     画出一个矩形线框，在DockForm上，线框的中心点即为点击处。
        ///     鸟瞰地图上下移动，宿主地图也随之移动，这个互动过程在OnMouseDown事件的处理函数中直接进行了处理，
        ///     而没有使用委托类实现。
        ///     
        ///     （3- 制作，实现一个DockableWindow控件对象，供大家来用用。）
        /// </summary>
        

        public DockForm()
        {
            InitializeComponent();
            pOverMap = this.axMapControl1.Map;
            pGraCon = (IGraphicsContainer)pOverMap;
            pAV = (IActiveView)pOverMap;
        }
        public NBGIS.PluginEngine.IApplication Hook
        {
            set
            {
                //将 hook 设置给插件对象
                this.hook = value;

                if (this.hook != null)
                {
                    //设置事件，这是主控件与鸟瞰控件互动的关键

                    //地图控制的长度、范围变换、更新的事件 交给 DockForm_OnExtentUpdated 处理。
                    ((ESRI.ArcGIS.Controls.IMapControlEvents2_Event)
                        this.hook.MapControl).OnExtentUpdated +=
                        new ESRI.ArcGIS.Controls.IMapControlEvents2_OnExtentUpdatedEventHandler
                            (DockForm_OnExtentUpdated);

                    //地图控制的显示的添加事件 交给 DockForm_ItemAdded 处理。
                    ((ESRI.ArcGIS.Carto.IActiveViewEvents_Event)
                        this.hook.MapControl.ActiveView).ItemAdded +=
                        new ESRI.ArcGIS.Carto.IActiveViewEvents_ItemAddedEventHandler
                            (DockForm_ItemAdded);

                    //地图控制的显示的内容的清空事件 交给 DockForm_ContentsCleared 处理。
                    ((ESRI.ArcGIS.Carto.IActiveViewEvents_Event)
                        this.hook.MapControl.ActiveView).ContentsCleared +=
                        new ESRI.ArcGIS.Carto.IActiveViewEvents_ContentsClearedEventHandler
                            (DockForm_ContentsCleared);

                    //显示设置：在鸟瞰控件上显示一个全范围的红色框体元素
                    this.pAV.Extent = this.hook.MapControl.ActiveView.FullExtent;
                    IEnvelope pEnv = this.pAV.Extent;
                    IRectangleElement pRectangleEle = new RectangleElementClass();
                    pEle = (IElement)pRectangleEle;
                    pEle.Geometry = pEnv;

                    IFillShapeElement pFillShapEle = (IFillShapeElement)pEle;
                    pFillShapEle.Symbol = this.CreateFillSymbol();

                    pGraCon.AddElement((IElement)pFillShapEle, 0);
                    pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);



                }
            }
        }
        /// <summary>
        /// 宿主地图的图层全部删除后，鸟瞰地图也删除所有数据
        /// </summary>
        void DockForm_ContentsCleared()
        {
            pOverMap.ClearLayers();
            pAV.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }
        /// <summary>
        /// 宿主地图添加数据后，鸟瞰地图选择一个图层作为背景层
        /// </summary>
        /// <param name="Item"></param>
        void DockForm_ItemAdded(Object Item)
        {
            if (this.pOverMap.LayerCount == 0)
            {
                this.pOverMap.AddLayer(this.GetBackgroundLayer(this.hook.MapControl.Map));
                this.pAV.Extent = this.hook.MapControl.FullExtent;
                this.pAV.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                this.pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            }
        }
        /// <summary>
        /// 选择 AreaOfInterest 范围最大的图层作为鸟瞰地图的背景层
        /// </summary>
        /// <param name="iMap"></param>
        /// <returns></returns>
        private ILayer GetBackgroundLayer(IMap iMap)
        {
            ILayer pLyr = iMap.get_Layer(0);
            ILayer tmpLyr = null;
            for (int i = 1; i < iMap.LayerCount; i++)
            {
                tmpLyr = iMap.get_Layer(i);
                if (pLyr.AreaOfInterest.Width < tmpLyr.AreaOfInterest.Width)
                {
                    pLyr = tmpLyr;
                }
            }

            return pLyr;
        }
        /// <summary>
        /// 宿主地图视图改变后，鸟瞰地图的视图也要随之改变，保证同步，即：红框体发生变化
        /// </summary>
        /// <param name="displayTransformation"></param>
        /// <param name="sizeChanged"></param>
        /// <param name="newEnvelope"></param>
        void DockForm_OnExtentUpdated(object displayTransformation, bool sizeChanged,
            object newEnvelope)
        {
            this.pAV.Extent = this.hook.MapControl.ActiveView.FullExtent;
            pEle.Geometry = (IGeometry)newEnvelope;
            this.pGraCon.UpdateElement(pEle);
            this.pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        /// <summary>
        /// 鸟瞰地图的视图（红框体）变化后，宿主地图视图也要随之改变。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axMapControl1_OnMouseDown(object sender,
            AxESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            IPoint cenpt = new PointClass();
            cenpt.PutCoords(e.mapX, e.mapY);
            IEnvelope pEleEnv = pEle.Geometry.Envelope;
            pEleEnv.CenterAt(cenpt);
            pEle.Geometry = (IGeometry)pEleEnv;

            this.hook.MapControl.Extent = pEleEnv;
            this.hook.MapControl.ActiveView.PartialRefresh(
                esriViewDrawPhase.esriViewGeography, null, null);
            this.pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        /// <summary>
        /// 产生一个红色范围指示框体
        /// </summary>
        /// <returns></returns>
        private IFillSymbol CreateFillSymbol()
        {
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Transparency = 255;

            ILineSymbol pOutLine = new SimpleLineSymbolClass();
            pOutLine.Color = pColor;
            pOutLine.Width = 1;
            pColor.Transparency = 0;

            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutLine;
            ISimpleFillSymbol pSimpleFillSymbol = (ISimpleFillSymbol)pFillSymbol;
            pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSCross;


            return pFillSymbol;
        }

    }
}
