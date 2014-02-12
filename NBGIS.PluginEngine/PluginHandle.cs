using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Reflection;

namespace NBGIS.PluginEngine
{
    /// <summary>
    ///     我们用反射机制生产插件对象并将其装入插件容器中。
    /// </summary>
    public class PluginHandle
    {
        //  插件集合所在的文件路径
        private static readonly string pluginFoler =
            System.Windows.Forms.Application.StartupPath + "\\plugin";

        /// <summary>
        ///     从指定的插件文件夹，得到所有合法的程序集，找到有用的类型信息，
        ///     生成有效的插件对象。
        /// </summary>
        /// <returns></returns>
        public static PluginCollection GetPluginsFromDll()
        {
            //存储插件的容器
            PluginCollection _PluginCol = new PluginCollection();

            //监测插件文件夹是否存在，如果不存在则新建一个避免出现异常
            if (!Directory.Exists(pluginFoler))
            {
                Directory.CreateDirectory(pluginFoler);
                if (AppLog.log.IsDebugEnabled)
                {
                    AppLog.log.Debug("plugin 文件夹不存在，系统自动建立一个");
                }
            }

            //获得插件文件夹中每一个 dll 文件
            string[] _files = Directory.GetFiles(pluginFoler, "*.dll");
            foreach (string _file in _files)
            {
                Assembly _assembly = Assembly.LoadFrom(_file);
                if (_assembly != null)
                {
                    Type[] _types = null;
                    try
                    {
                        //获取程序集中定义的类型
                        _types = _assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        if (AppLog.log.IsErrorEnabled)
                        {
                            AppLog.log.Error("反射类型加载异常，内容：" + ex.Message);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        if (AppLog.log.IsErrorEnabled)
                        {
                            AppLog.log.Error(ex.Message);
                        }
                    }
                    finally
                    {
                        foreach (Type _type in _types)
                        {
                            //获得一个类型所有实现的接口
                            Type[] _interfaces = _type.GetInterfaces();

                            //遍历接口类型
                            foreach (Type theInterface in _interfaces)
                            {
                                //如果满足某种类型，就添加到插件集合对象中。
                                switch (theInterface.FullName)
                                {
                                    case "NBGIS.PluginEngine.ICommand":
                                    case "NBGIS.PluginEngine.ITool":
                                    case "NBGIS.PluginEngine.IMenuDef":
                                    case "NBGIS.PluginEngine.IToolBarDef":
                                    case "NBGIS.PluginEngine.IDockableWindowDef":
                                        getPluginObject(_PluginCol, _type);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            return _PluginCol;
        }

        private static void getPluginObject(PluginCollection _pluginCol, Type _type)
        {
            IPlugin plugin = null;

            try
            {
                plugin = Activator.CreateInstance(_type) as NBGIS.PluginEngine.IPlugin;
            }
            catch (System.Exception ex)
            {
                if (AppLog.log.IsErrorEnabled)
                {
                    AppLog.log.Error(_type.FullName + "反射生成对象时候发生异常！" + " 详细内容：" + ex.Message);
                }
            }
            finally
            {
                if (plugin != null)
                {
                    if (!_pluginCol.Contains(plugin))
                    {
                        _pluginCol.Add(plugin);
                    }
                }
            }

        }

    }
}
