using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgMunicipioDAO : BaseRepository<RgMunicipio>
    {
        public List<RgMunicipio> ListarRgMunicipios()
        {
            List<RgMunicipio> _RgMunicipios = this.GetQueryable().OrderBy(m => m.municipio).ToList();
            return _RgMunicipios;
        }

        public RgMunicipio RecuperarRgMunicipio(int _CodMunicipio)
        {
            RgMunicipio _Result = null;

            _Result = this.FindByPrimaryKey(_CodMunicipio);

            return _Result;
        }
    }
}
