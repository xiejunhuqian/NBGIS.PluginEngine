using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBGIS.PluginEngine
{
    /// <summary>
    ///     定义一个工具条
    /// </summary>
    public interface IToolBarDef : NBGIS.PluginEngine.IPlugin
    {
        /// <summary>
        ///     工具条的标题
        /// </summary>
        string Caption { get; }

        /// <summary>
        ///     工具条的名称
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     菜单栏携带 Item 的数量
        /// </summary>
        long ItemCount { get; }

        /// <summary>
        ///     访问工具条中每个 Item 的方法
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="itemDef"></param>
        void GetItemInfo(int pos, IItemDef itemDef);
    }
}
