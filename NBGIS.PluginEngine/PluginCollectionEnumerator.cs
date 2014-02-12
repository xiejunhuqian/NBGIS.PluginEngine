using System;
using System.Text;
using System.Collections;

namespace NBGIS.PluginEngine
{
    public class PluginCollectionEnumerator : IEnumerable
    {
        //private PluginCollection pluginCollection;
        private IEnumerable _temp;
        private IEnumerator _enumerator;

        public PluginCollectionEnumerator(PluginCollection pluginCollection)
        {
            // TODO: Complete member initialization
            //this.pluginCollection = pluginCollection;

            _temp = (IEnumerable)pluginCollection;
            _enumerator = _temp.GetEnumerator();
        }

        #region IEnumerator 成员


        public IEnumerator GetEnumerator()
        {
            return _enumerator;
        }

        public object Current
        {
            get
            {
                return _enumerator.Current;
            }
        }

        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }

        public void Reset()
        {
            _enumerator.Reset();
        }
        
        
        #endregion
    }
}
