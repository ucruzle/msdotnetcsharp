using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeProcessoBO
    {
        [Dependency]
        public GeProcessoDAO DAO { get; set; }

        public List<GeProcesso> ListarGeProcessos()
        {
            List<GeProcesso> _GeProcessos = DAO.ListarGeProcessos();
            return _GeProcessos;
        }

        public GeProcesso RecuperaGeProcesso(int _CodProc)
        {
            GeProcesso _Result = DAO.RecuperarGeProcesso(_CodProc);
            return _Result;
        }

        public void AdicionarGeProcesso(GeProcesso _GeProcesso)
        {
            DAO.Insert(_GeProcesso);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarGeProcesso(GeProcesso _GeProcesso)
        {
            DAO.Update(_GeProcesso);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeProcesso(int _CodProc)
        {
            GeProcesso _GeProcesso = null;

            _GeProcesso = DAO.FindByPrimaryKey(_CodProc);

            DAO.Delete(_GeProcesso);
            DAO.UnitOfWork.Commit();
        }
    }
}
