using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeUsuarioGrupoDAO : BaseRepository<GeUsuarioGrupo>
    {
        public List<GeUsuarioGrupo> ListarGeUsuariosGrupos()
        {
            List<GeUsuarioGrupo> _GeUsuariosGrupos = this.GetQueryable().OrderBy(u => u.cod_grupo).ToList();
            return _GeUsuariosGrupos;
        }

        public GeUsuarioGrupo RecuperarGeUsuarioGrupo(int _CodEmpr, int _CodGrupo, string _Usuario)
        {
            GeUsuarioGrupo _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodGrupo, _Usuario);

            return _Result;
        }
    }
}
