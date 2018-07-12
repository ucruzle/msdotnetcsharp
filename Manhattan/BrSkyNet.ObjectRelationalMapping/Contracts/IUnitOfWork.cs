using System;
using System.Data.Entity;

namespace BrSkyNet.ObjectRelationalMapping.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DefaultContext { get; }
        void Commit();
    }
}
