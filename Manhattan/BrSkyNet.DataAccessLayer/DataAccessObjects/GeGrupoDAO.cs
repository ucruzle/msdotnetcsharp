using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeGrupoDAO : BaseRepository<GeGrupo>
    {
        public List<GeGrupo> ListarGeGrupos()
        {
            List<GeGrupo> _GeGrupos = this.GetQueryable().OrderBy(g => g.descr_grupo).ToList();
            return _GeGrupos;
        }

        public GeGrupo RecuperarGeGrupo(int _CodGrupo)
        {
            GeGrupo _Result = null;

            _Result = this.FindByPrimaryKey(_CodGrupo);

            return _Result;
        }
    }
}
