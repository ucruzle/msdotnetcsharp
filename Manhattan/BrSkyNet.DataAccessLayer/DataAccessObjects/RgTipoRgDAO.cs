using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgTipoRgDAO : BaseRepository<RgTipoRg>
    {
        public List<RgTipoRg> ListarRgTiposRgs()
        {
            List<RgTipoRg> _RgTiposRgs = this.GetQueryable().OrderBy(t => t.descr_tipo_rg).ToList();
            return _RgTiposRgs;
        }

        public RgTipoRg RecuperarRgTipoRg(string _TipoRg)
        {
            RgTipoRg _Result = null;
            _Result = this.FindByPrimaryKey(_TipoRg);

            return _Result;
        }
    }
}
