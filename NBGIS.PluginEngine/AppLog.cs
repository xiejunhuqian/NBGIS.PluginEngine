using System;
using log4net;


// 开启 Log4net 监听器
[assembly: log4net.Config.XmlConfigurator(Watch= true)]
namespace NBGIS.PluginEngine
{
    /// <summary>
    ///     使用 Log4net 插件的 log 日志对象
    /// </summary>
    public class AppLog
    {
        
        /// <summary>
        ///     ILog4net 日志静态对象
        /// </summary>
        public static readonly log4net.ILog log =
            log4net.LogManager.GetLogger("NBGIS");
    }
}
