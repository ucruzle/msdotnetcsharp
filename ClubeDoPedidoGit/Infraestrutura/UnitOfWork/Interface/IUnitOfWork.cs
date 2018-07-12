using Infraestrutura.Dao;

namespace Infraestrutura.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
