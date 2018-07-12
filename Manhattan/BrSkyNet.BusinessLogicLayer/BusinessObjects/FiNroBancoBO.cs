using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class FiNroBancoBO
    {
        [Dependency]
        public FiNroBancoDAO DAO { get; set; }

        public List<FiNroBanco> ListarFiNrosBancos()
        {
            List<FiNroBanco> _FiNrosBancos = DAO.ListarFiNrosBancos();
            return _FiNrosBancos;
        }

        public FiNroBanco RecuperarFiNroBanco(int _NroBanco)
        {
            FiNroBanco _Result = DAO.RecuperarFiNroBanco(_NroBanco);
            return _Result;
        }

        public void AdicionarFiNroBanco(FiNroBanco _FiNroBanco)
        {
            DAO.Insert(_FiNroBanco);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarFiNroBanco(FiNroBanco _FiNroBanco)
        {
            DAO.Update(_FiNroBanco);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarFiNroBanco(FiNroBanco _FiNroBanco)
        {
            FiNroBanco _Result = null;

            _Result = DAO.FindByPrimaryKey(_FiNroBanco.nro_banco);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
