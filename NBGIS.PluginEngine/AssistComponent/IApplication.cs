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
 *  IApplication 定义的全部都是属性，是框架宿主对象告诉插件对象的内容。
 * 
 * 
 * 
 * 
 */

namespace NBGIS.PluginEngine
{
    /// <summary>
    ///     IApplication 接口定义了宿主程序的属性
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        ///     主程序标题
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        ///     主程序当前使用的工具 Tool 名称
        /// </summary>
        string CurrentTool { get; set; }

        /// <summary>
        ///     主程序存储 GIS 数据的数据集
        /// </summary>
        DataSet MainDataSet { get; set; }

        /// <summary>
        ///     主程序包含的文档对象
        /// </summary>
        IMapDocument Document { get; set; }

        /// <summary>
        ///     主程序中的 MapControl 控件
        /// </summary>
        IMapControlDefault MapControl { get; set; }

        /// <summary>
        ///     主程序中的 PageLayoutControlDefault 控件
        /// </summary>
        IPageLayoutControlDefault PageLayoutControl { get; set; }

        /// <summary>
        ///     主程序名
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     主程序窗体对象
        /// </summary>
        Form MainPlatform { get; set; }

        /// <summary>
        ///     主程序窗体中的状态栏
        /// </summary>
        UIStatusBar StatueBar { get; set; }

        /// <summary>
        ///     主程序 UI 界面的 Visible 属性
        /// </summary>
        bool Visible { get; set; }
    }
}
