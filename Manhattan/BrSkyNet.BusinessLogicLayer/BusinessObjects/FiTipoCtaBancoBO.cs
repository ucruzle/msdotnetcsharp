using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class FiTipoCtaBancoBO
    {
        [Dependency]
        public FiTipoCtaBancoDAO DAO { get; set; }

        public List<FiTipoCtaBanco> ListarFiTiposCtasBancos()
        {
            List<FiTipoCtaBanco> _FiTiposCtasBancos = DAO.ListarFiTiposCtasBancos();
            return _FiTiposCtasBancos;
        }

        public FiTipoCtaBanco RecuperarFiTipoCtaBanco(int _NroBanco)
        {
            FiTipoCtaBanco _Result = DAO.RecuperarFiTipoCtaBanco(_NroBanco);
            return _Result;
        }

        public void AdicionarFiTipoCtaBanco(FiTipoCtaBanco _FiTipoCtaBanco)
        {
            DAO.Insert(_FiTipoCtaBanco);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarFiTipoCtaBanco(FiTipoCtaBanco _FiTipoCtaBanco)
        {
            DAO.Update(_FiTipoCtaBanco);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarFiTipoCtaBanco(FiTipoCtaBanco _FiTipoCtaBanco)
        {
            FiTipoCtaBanco _Result = null;

            _Result = DAO.FindByPrimaryKey(_FiTipoCtaBanco.cod_tipo_cta);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
