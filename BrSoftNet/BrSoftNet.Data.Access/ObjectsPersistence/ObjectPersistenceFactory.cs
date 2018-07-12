
namespace Data.Access.Logic.Components.ObjectsPersistence
{
    public abstract class ObjectPersistenceFactory<T> where T : class, new()
    {
        private static T _CreateInstance;

        protected static string ConnectionString { get; set; }

        protected static string ProviderType { get; set; }

        public static T CreateInstance(string _ConnectionString, string _ProviderType)
        {
            lock (typeof(ObjectPersistenceFactory<T>))
            {
                if (_CreateInstance == null)
                {
                    _CreateInstance = new T();
                }
            }

            ConnectionString = _ConnectionString;
            ProviderType = _ProviderType;

            return _CreateInstance;
        }
    }
}
