
namespace BrSoftNet.Log.Helpers
{
    public abstract class HelperFactory<T> where T : class, new()
    {
        private static T _CreateInstance;

        public static T CreateInstance
        {
            get
            {
                lock (typeof(HelperFactory<T>))
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
