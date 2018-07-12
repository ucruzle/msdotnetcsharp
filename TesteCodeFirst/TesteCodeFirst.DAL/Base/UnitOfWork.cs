using System;
using System.Data.Entity;
using TesteCodeFirst.Utils.ORM;

namespace TesteCodeFirst.DAL.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _defaultContext;

        public DbContext DefaultContext
        {
            get
            {
                return _defaultContext;
            }
        }

        public UnitOfWork()
        {
            this._defaultContext = new DefaultContext();
        }

        public void Commit()
        {
            DefaultContext.SaveChanges();
        }

        public void Dispose()
        {
            DefaultContext.Dispose();
        }
    }
}