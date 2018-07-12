
namespace BrSoftNet.Library.Utilities
{
    public abstract class UtilitiesFactory<T> where T : class, new()
    {
        private static T _CreateInstance;

        public static T CreateInstance
        {
            get
            {
                lock (typeof(UtilitiesFactory<T>))
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
