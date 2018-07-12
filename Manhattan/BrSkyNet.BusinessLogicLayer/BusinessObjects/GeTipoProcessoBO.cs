using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeTipoProcessoBO
    {
        [Dependency]
        public GeTipoProcessoDAO DAO { get; set; }

        public List<GeTipoProcesso> ListarGeTiposProcessos()
        {
            List<GeTipoProcesso> _GeTiposProcessos = DAO.ListarGeTiposProcessos();
            return _GeTiposProcessos;
        }

        public GeTipoProcesso RecuperaGeTipoProcesso(int _CodTipoProc)
        {
            GeTipoProcesso _Result = DAO.RecuperarGeTipoProcesso(_CodTipoProc);
            return _Result;
        }

        public void AdicionarGeTipoProcesso(GeTipoProcesso _GeTipoProcesso)
        {
            DAO.Insert(_GeTipoProcesso);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarGeTipoProcesso(GeTipoProcesso _GeTipoProcesso)
        {
            DAO.Update(_GeTipoProcesso);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeTipoProcesso(int _CodTipoProc)
        {
            GeTipoProcesso _GeTipoProcesso = null;

            _GeTipoProcesso = DAO.FindByPrimaryKey(_CodTipoProc);

            DAO.Delete(_GeTipoProcesso);
            DAO.UnitOfWork.Commit();
        }
    }
}
