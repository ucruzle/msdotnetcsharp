
namespace BrSoftNet.App.Business.Processes.OverallRecord.Tasks
{
    public abstract class TaskFactory<T> where T : class, new()
    {
        private static T _CreateInstance;
        public static T CreateInstance
        {
            get
            {
                lock (typeof(TaskFactory<T>))
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
