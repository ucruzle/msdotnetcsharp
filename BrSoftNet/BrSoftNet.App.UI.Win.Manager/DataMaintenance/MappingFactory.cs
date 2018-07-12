using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.UI.Win.Manager.DataMaintenance
{
    public abstract class MappingFactory<T> where T : class, new()
    {
        private static T _CreateInstance;

        public static T CreateInstance
        {
            get
            {
                lock (typeof(MappingFactory<T>))
                {
                    if (_CreateInstance == null)
                    {
                        _CreateInstance = new T();
                    }
                }

                return _CreateInstance;
            }
        }
    }
}
