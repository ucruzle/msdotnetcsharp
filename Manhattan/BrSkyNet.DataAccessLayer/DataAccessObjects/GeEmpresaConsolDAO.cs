using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeEmpresaConsolDAO : BaseRepository<GeEmpresaConsol>
    {
        public List<GeEmpresaConsol> ListarGeEmpresasConsols()
        {
            List<GeEmpresaConsol> _GeEmpresasConsols = this.GetQueryable().OrderBy(e => e.descr_empr_consol).ToList();
            return _GeEmpresasConsols;
        }

        public GeEmpresaConsol RecuperarGeEmpresaConsol(int _CodEmprConsol)
        {
            GeEmpresaConsol _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmprConsol);

            return _Result;
        }
    }
}
