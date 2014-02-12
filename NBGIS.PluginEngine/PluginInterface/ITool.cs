using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

/*
 *  ITool 插件是平台上UI层的一个工具按钮。
 *  他与ICommand相似，区别是ICommand启动的是一个交互的过程；ITool启动的是一个直接开始执行的过程。
 * 
 * 
 * 
 * 
 * 
 */
namespace NBGIS.PluginEngine
{
    /// <summary>
    ///     AcrMap 中产生一个Tool对象，需要同时实现ICommand和ITool两个接口，
    ///     其中ICommand定义启动Tool交互过程的方法；
    ///     而ITool定义人机交互时候需要的所有方法；
    /// 
    ///     这里我们把ICommand和ITool的内容混合到一个接口中，ITool。
    ///     
    ///     ITool 接口混合了 AO 中的 ICoomand 接口和 ITool 接口。
    /// 
    /// </summary>
    public interface ITool : NBGIS.PluginEngine.IPlugin
    {
        #region ICommand 定义启动Tool交互过程的方法

        /// <summary>
        ///     命令按钮的图标
        /// </summary>
        Bitmap Bitmap { get; }
        /// <summary>
        ///     命令按钮的文字
        /// </summary>
        string Caption { get; }
        /// <summary>
        ///     命令按钮所属的类别
        /// </summary>
        string Category { get; }
        /// <summary>
        ///     命令按钮是否被选择
        /// </summary>
        bool Checked { get; }
        /// <summary>
        ///     命令按钮是否可用
        /// </summary>
        bool Enabled { get; }
        /// <summary>
        ///     快捷帮助 ID
        /// </summary>
        int HelpContextID { get; }
        /// <summary>
        ///     帮助文件路径
        /// </summary>
        string HelpFile { get; }
        /// <summary>
        ///     鼠标移动到按钮上时状态栏出现的文字
        /// </summary>
        string Message { get; }
        /// <summary>
        ///     按钮名称
        /// </summary>
        string Name { get; }
        /// <summary>
        ///     按钮点击时触发的方法
        /// </summary>
        void OnClick();
        /// <summary>
        ///     按钮产生时触发的方法
        /// </summary>
        void OnCreate(NBGIS.PluginEngine.IApplication hook);
        /// <summary>
        ///     鼠标移动到按钮上时弹出的文字
        /// </summary>
        string Tooltip { get; }


        #endregion

        #region ITool 定义人机交互时候需要的所有方法

        /// <summary>
        ///     鼠标在地图上的样式
        /// </summary>
        int Cursor { get; }

        /// <summary>
        ///     Tool 的激活状态设置
        /// </summary>
        /// <returns></returns>
        bool Deactivate();

        /// <summary>
        ///     鼠标双击地图时候出发的事件
        /// </summary>
        void OnDbClick();

        /// <summary>
        ///     鼠标点击右键弹出快捷菜单时候出发的事件
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool OnContextMenu(int x, int y);

        /// <summary>
        ///    鼠标在地图上移动的时候出发的事件 
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseMove(int button, int shift, int x, int y);

        /// <summary>
        ///     鼠标点击地图时候触发的事件
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseDown(int button, int shift, int x, int y);

        /// <summary>
        ///     鼠标在地图上弹起时候出发的事件
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void OnMouseUp(int button, int shift, int x, int y);

        /// <summary>
        ///     地图刷新的时候出发的事件
        /// </summary>
        /// <param name="hDc"></param>
        void Refresh(int hDc);

        /// <summary>
        ///     键盘某个按键点击时候出发的事件
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="shift"></param>
        void OnKeyDown(int keyCode, int shift);

        /// <summary>
        ///     键盘某个按键点击后弹起时候出发的事件
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="shift"></param>
        void OnKeyUp(int keyCode, int shift);


        #endregion

    }
}