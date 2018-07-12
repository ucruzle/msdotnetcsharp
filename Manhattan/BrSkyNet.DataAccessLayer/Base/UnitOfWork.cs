using BrSkyNet.ObjectRelationalMapping.Contracts;
using System.Data.Entity;

namespace BrSkyNet.DataAccessLayer.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _DbContext;

        public DbContext DefaultContext
        {
            get
            {
                return _DbContext;
            }
        }

        public UnitOfWork()
        {
            this._DbContext = new DefaultContext();
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
