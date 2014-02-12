using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    ///     定义菜单栏和工具条的命令项（Item）
    /// </summary>
    public interface IItemDef
    {
        /// <summary>
        ///     Item的唯一号码
        /// </summary>
        string ID { get; set; }

        /// <summary>
        ///     Item是否属于一个组
        /// </summary>
        bool Group { get; set; }

        /// <summary>
        ///     Item的子类 Command 或 Tool
        /// </summary>
        long Subtype { get; set; }
    }
}
