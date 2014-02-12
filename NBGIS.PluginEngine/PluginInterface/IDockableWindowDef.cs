using System;
using System.Collections.Generic;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    ///     我们使用WeifenLuo.WinFormsUI.Docking实现浮动窗口。
    ///     浮动窗体接口定义
    /// </summary>
    public interface IDockableWindowDef : NBGIS.PluginEngine.IPlugin
    {
        /// <summary>
        ///     浮动窗口标题    
        /// </summary>
        string Caption { get; }
        /// <summary>
        ///     浮动窗体上停靠的子控件
        /// </summary>
        System.Windows.Forms.Control ChildHWND { get; }
        /// <summary>
        ///     浮动窗体的名字
        /// </summary>
        string Name { get; }
        /// <summary>
        ///     浮动窗体产生时候触发的事件
        /// </summary>
        /// <param name="hook"></param>
        void OnCreate(NBGIS.PluginEngine.IApplication hook);
        /// <summary>
        ///     浮动窗体关闭时候触发的事件
        /// </summary>
        void OnDestroy();
        /// <summary>
        ///     浮动窗体与主框架之间用于交互的额外辅助数据对象
        /// </summary>
        object UserData { get; }

    }
}
