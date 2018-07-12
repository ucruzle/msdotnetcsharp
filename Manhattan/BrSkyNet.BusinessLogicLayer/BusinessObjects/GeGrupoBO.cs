using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeGrupoBO
    {
        [Dependency]
        public GeGrupoDAO DAO { get; set; }

        public List<GeGrupo> ListarGeGrupos()
        {
            List<GeGrupo> _GeGrupos = DAO.ListarGeGrupos();
            return _GeGrupos;
        }

        public GeGrupo RecuperaGeGrupo(int _CodGrupo)
        {
            GeGrupo _Result = DAO.RecuperarGeGrupo(_CodGrupo);
            return _Result;
        }

        public void AdicionarGeGrupo(GeGrupo _GeGrupo)
        {
            DAO.Insert(_GeGrupo);
            DAO.UnitOfWork.Commit();
        }

        public void AlterarGeGrupo(GeGrupo _GeGrupo)
        {
            DAO.Update(_GeGrupo);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeGrupo(int _CodGrupo)
        {
            GeGrupo _GeGrupo = null;

            _GeGrupo = DAO.FindByPrimaryKey(_CodGrupo);

            DAO.Delete(_GeGrupo);
            DAO.UnitOfWork.Commit();
        }
    }
}
