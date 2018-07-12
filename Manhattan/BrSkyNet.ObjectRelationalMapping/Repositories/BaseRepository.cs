using BrSkyNet.ObjectRelationalMapping.Contracts;
using Microsoft.Practices.Unity;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BrSkyNet.ObjectRelationalMapping.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        [Dependency]
        public IUnitOfWork UnitOfWork { get; set; }

        private string[] _keyNames;

        private string[] GetKeyNames()
        {
            if (_keyNames == null)
            {
                ObjectSet<T> objectSet =
                    ((IObjectContextAdapter)UnitOfWork.DefaultContext)
                        .ObjectContext.CreateObjectSet<T>();
                _keyNames = objectSet.EntitySet.ElementType.
                    KeyMembers.Select(k => k.Name).ToArray();
            }

            return _keyNames;
        }

        private object[] GetPrimaryKeyValues(T item)
        {
            var keyNames = GetKeyNames();
            Type type = typeof(T);

            object[] keys = new object[keyNames.Length];
            for (int i = 0; i < keyNames.Length; i++)
            {
                keys[i] = type.GetProperty(keyNames[i])
                    .GetValue(item, null);
            }

            return keys;
        }

        public T FindByPrimaryKey(params object[] keyValues)
        {
            return UnitOfWork.DefaultContext.Set<T>()
                .Find(keyValues);
        }

        public IQueryable<T> GetQueryable()
        {
            return UnitOfWork.DefaultContext.Set<T>();
        }

        public void Insert(T entity)
        {
            UnitOfWork.DefaultContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            UnitOfWork.DefaultContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            object[] keyValues = this.GetPrimaryKeyValues(entity);
            T currentEntity = this.FindByPrimaryKey(keyValues);
            if (currentEntity == null)
            {
                throw new Exception(String.Format(
                    "Erro durante a atualização de uma instância " +
                    "do tipo {0}. Verifique se o registro " +
                    "correspondente existe na base de dados.",
                    typeof(T).Name));
            }

            var entry = UnitOfWork.DefaultContext
                .Entry(currentEntity);
            entry.CurrentValues.SetValues(entity);
            entry.State = EntityState.Modified;
        }
    }
}
