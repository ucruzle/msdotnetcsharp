using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgTipoFoneDAO : BaseRepository<RgTipoFone>
    {
        public List<RgTipoFone> ListarRgTiposFones()
        {
            List<RgTipoFone> _RgTiposFones = this.GetQueryable().OrderBy(t => t.descr_tipo_fone).ToList();
            return _RgTiposFones;
        }

        public RgTipoFone RecuperarRgTipoFone(int _CodTipoFone)
        {
            RgTipoFone _Result = null;
            _Result = this.FindByPrimaryKey(_CodTipoFone);

            return _Result;
        }
    }
}
