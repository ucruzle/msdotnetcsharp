using BrSkyNet.DataAccessLayer.DataAccessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace BrSkyNet.BusinessLogicLayer.BusinessObjects
{
    public class GeUsuarioGrupoBO
    {
        [Dependency]
        public GeUsuarioGrupoDAO DAO { get; set; }

        public List<GeUsuarioGrupo> ListarGeUsuariosGrupos()
        {
            List<GeUsuarioGrupo> _GeUsuariosGrupos = DAO.ListarGeUsuariosGrupos();
            return _GeUsuariosGrupos;
        }

        public GeUsuarioGrupo RecuperaGeUsuarioGrupo(int _CodEmpr, int _CodGrupo, string _Usuario)
        {
            GeUsuarioGrupo _Result = DAO.RecuperarGeUsuarioGrupo(_CodEmpr, _CodGrupo, _Usuario);
            return _Result;
        }

        public void AdicionarGeUsuarioGrupo(GeUsuarioGrupo _GeUsuarioGrupo)
        {
            DAO.Insert(_GeUsuarioGrupo);
            DAO.UnitOfWork.Commit();
        }

        public void EliminarGeUsuarioGrupo(GeUsuarioGrupo _GeUsuarioGrupo)
        {
            GeUsuarioGrupo _Result = null;

            _Result = DAO.FindByPrimaryKey(_GeUsuarioGrupo.cod_empr,
                                           _GeUsuarioGrupo.cod_grupo,
                                           _GeUsuarioGrupo.usuario);

            DAO.Delete(_Result);
            DAO.UnitOfWork.Commit();
        }
    }
}
