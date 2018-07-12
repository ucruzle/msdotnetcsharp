using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeParametroBO
    {
        [Dependency]
        public GeParametroDAO DAO { get; set; }

        public List<GeParametro> ListarGeParametros()
        {
            List<GeParametro> _GeParametros = DAO.ListarGeParametros();
            return _GeParametros;
        }

        public GeParametro RecuperaGeGeParametro(int _IdTabela)
        {
            GeParametro _Result = DAO.RecuperarGeParametro(_IdTabela);
            return _Result;
        }

        public void AdicionarGeParametro(GeParametro _GeParametro)
        {
            DAO.Insert(_GeParametro);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarGeParametro(GeParametro _GeParametro)
        {
            DAO.Update(_GeParametro);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeParametro(int _IdTabela)
        {
            GeParametro _Result = null;

            _Result = DAO.FindByPrimaryKey(_IdTabela);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
