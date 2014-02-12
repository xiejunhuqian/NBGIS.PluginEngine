using System.Drawing;
using System;


namespace NBGIS.PluginEngine
{
    /// <summary>
    ///     ICommand 在框架的UI层上表现为一个命令按钮。他就是一段类似宏代码。
    ///     
    ///     Bitmap 属性返回的是对象
    ///     
    ///     宿主程序 与 插件程序的沟通是通过hook对象。
    /// 
    /// </summary>
    public interface ICommand : NBGIS.PluginEngine.IPlugin
    {
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

    }
}
