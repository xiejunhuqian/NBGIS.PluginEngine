using System;
using System.Text;
using System.Collections;

namespace NBGIS.PluginEngine
{
    /// <summary>
    ///     插件容器
    /// </summary>
    public class PluginCollection : CollectionBase
    {
        #region 构造函数

        public PluginCollection() { }
        public PluginCollection(PluginCollection value)
        {
            this.AddRange(value);
        }
        public PluginCollection(IPlugin[] value)
        {
            this.AddRange(value);
        }

        #endregion

        public IPlugin this[int index]
        {
            get { return (IPlugin)(this.List[index]); }
        }

        public int Add(IPlugin value)
        {
            return this.List.Add(value);
        }

        public int IndexOf(IPlugin value)
        {
            return this.List.IndexOf(value);
        }

        public bool Contains(IPlugin value)
        {
            return this.List.Contains(value);
        }

        public void CopyTo(IPlugin[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        public IPlugin[] ToArray()
        {
            IPlugin[] array = new IPlugin[this.Count];
            this.CopyTo(array, 0);
            return array;
        }

        public void Insert(int index, IPlugin value)
        {
            this.List.Insert(index, value);
        }

        public void Remove(IPlugin value)
        {
            this.List.Remove(value);
        }

        /// <summary>
        ///     GetEnumerator方法返回一个与PluginCollection相关的迭代器，
        ///     这个迭代器是PluginCollectionEnumberator类型，他能以一种
        ///     单向的方式从容器中取出数据。
        ///     
        ///     容器，迭代器，遍历容器中的元素
        /// 
        /// </summary>
        /// <returns></returns>
        public new PluginCollectionEnumerator GetEnumerator()
        {
            return new PluginCollectionEnumerator(this);
        }

        private void AddRange(IPlugin[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                this.Add(value[i]);
            }
        }
        private void AddRange(PluginCollection value)
        {
            for (int i = 0; i < value.Capacity; i++)
            {
                this.Add((IPlugin)value.List[i]);
            }
        }


    }
}
