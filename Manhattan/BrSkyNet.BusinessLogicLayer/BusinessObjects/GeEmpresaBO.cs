using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeEmpresaBO
    {
        [Dependency]
        public GeEmpresaDAO DAO { get; set; }

        public List<GeEmpresa> ListarGeEmpresas()
        {
            List<GeEmpresa> _GeEmpresas = DAO.ListarGeEmpresas();
            return _GeEmpresas;
        }

        public GeEmpresa RecuperaEmpresa(int _CodEmpr)
        {
            GeEmpresa _Result = DAO.RecuperarEmpresa(_CodEmpr);
            return _Result;
        }

        public void AdicionarEmpresa(GeEmpresa _GeEmpresa)
        {
            DAO.Insert(_GeEmpresa);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarEmpresa(GeEmpresa _GeEmpresa)
        {
            DAO.Update(_GeEmpresa);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarEmpresa(int _Id)
        {
            GeEmpresa _GeEmpresa = null;

            _GeEmpresa = DAO.FindByPrimaryKey(_Id);

            DAO.Delete(_GeEmpresa);
            DAO.UnitOfWork.Commit();
        }        
    }
}
