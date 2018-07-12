using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeEmpresaConsolBO
    {
        [Dependency]
        public GeEmpresaConsolDAO DAO { get; set; }

        public List<GeEmpresaConsol> ListarGeEmpresasConsols()
        {
            List<GeEmpresaConsol> _GeEmpresasConsols = DAO.ListarGeEmpresasConsols();
            return _GeEmpresasConsols;
        }

        public GeEmpresaConsol RecuperaGeEmpresaConsol(int _CodEmprConsol)
        {
            GeEmpresaConsol _Result = DAO.RecuperarGeEmpresaConsol(_CodEmprConsol);
            return _Result;
        }

        public void AdicionarGeEmpresaConsol(GeEmpresaConsol _GeEmpresaConsol)
        {
            DAO.Insert(_GeEmpresaConsol);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarGeEmpresaConsol(GeEmpresaConsol _GeEmpresaConsol)
        {
            DAO.Update(_GeEmpresaConsol);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeEmpresaConsol(int _Id)
        {
            GeEmpresaConsol _GeEmpresaConsol = null;

            _GeEmpresaConsol = DAO.FindByPrimaryKey(_Id);

            DAO.Delete(_GeEmpresaConsol);
            DAO.UnitOfWork.Commit();
        }
    }
}
