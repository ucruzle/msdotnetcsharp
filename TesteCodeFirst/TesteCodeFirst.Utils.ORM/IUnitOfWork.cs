using System;
using System.Data.Entity;

namespace TesteCodeFirst.Utils.ORM
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DefaultContext { get; }
        void Commit();
    }
}