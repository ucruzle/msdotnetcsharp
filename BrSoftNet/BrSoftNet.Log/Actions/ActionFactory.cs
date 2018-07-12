
namespace BrSoftNet.Log.Actions
{
    public abstract class ActionFactory<T> where T : class, new()
    {
        private static T _CreateInstance;

        public static T CreateInstance
        {
            get
            {
                lock (typeof(ActionFactory<T>))
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
