using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeTmpValorDetBO
    {
        [Dependency]
        public GeTmpValorDetDAO DAO { get; set; }

        public List<GeTmpValorDet> ListarGeTmpValoresDet()
        {
            List<GeTmpValorDet> _GeTmpValoresDet = DAO.ListarGeTmpValoresDet();
            return _GeTmpValoresDet;
        }

        public GeTmpValorDet RecuperaGeTmpValorDet(string _Usuario, int _Codigo)
        {
            GeTmpValorDet _Result = DAO.RecuperarGeTmpValorDet(_Usuario, _Codigo);
            return _Result;
        }

        public void AdicionarGeTmpValorDet(GeTmpValorDet _GeTmpValorDet)
        {
            DAO.Insert(_GeTmpValorDet);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarGeTmpValorDet(GeTmpValorDet _GeTmpValorDet)
        {
            DAO.Update(_GeTmpValorDet);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeTmpValorDet(GeTmpValorDet _GeTmpValorDet)
        {
            GeTmpValorDet _GeTmpValor = null;

            _GeTmpValor = DAO.FindByPrimaryKey(_GeTmpValorDet.usuario, _GeTmpValorDet.codigo);

            DAO.Delete(_GeTmpValor);
            DAO.UnitOfWork.Commit();
        }
    }
}
