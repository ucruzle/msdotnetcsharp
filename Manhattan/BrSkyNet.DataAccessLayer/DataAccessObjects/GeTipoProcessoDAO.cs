using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeTipoProcessoDAO : BaseRepository<GeTipoProcesso>
    {
        public List<GeTipoProcesso> ListarGeTiposProcessos()
        {
            List<GeTipoProcesso> _GeTiposProcessos = this.GetQueryable().OrderBy(s => s.cod_tipo_proc).ToList();
            return _GeTiposProcessos;
        }

        public GeTipoProcesso RecuperarGeTipoProcesso(int _CodTipoProc)
        {
            GeTipoProcesso _Result = null;

            _Result = this.FindByPrimaryKey(_CodTipoProc);

            return _Result;
        }
    }
}
