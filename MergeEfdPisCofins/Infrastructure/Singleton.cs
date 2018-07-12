using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergeEfdPisCofins.Infrastructure
{
    public abstract class Singleton<T> where T : class, new()
    {
        private static T _CreateInstance;

        public static T CreateInstance
        {
            get
            {
                lock (typeof(Singleton<T>))
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
