using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeGrupoProcessoDAO : BaseRepository<GeGrupoProcesso>
    {
        public List<GeGrupoProcesso> ListarGeGruposProcessos()
        {
            List<GeGrupoProcesso> _GeGruposProcessos = this.GetQueryable().OrderBy(g => g.cod_grupo).ToList();
            return _GeGruposProcessos;
        }

        public GeGrupoProcesso RecuperarGeGrupoProcesso(int _CodEmpr, int _CodGrupo, int _CodProc)
        {
            GeGrupoProcesso _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodGrupo, _CodProc);

            return _Result;
        }
    }
}
