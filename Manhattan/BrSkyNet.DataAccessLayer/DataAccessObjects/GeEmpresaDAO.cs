using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeEmpresaDAO : BaseRepository<GeEmpresa>
    {
        public List<GeEmpresa> ListarGeEmpresas()
        {
            List<GeEmpresa> _GeEmpresas = this.GetQueryable().OrderBy(e => e.descr_empr).ToList();
            return _GeEmpresas;
        }

        public GeEmpresa RecuperarEmpresa(int _CodEmpr)
        {
            GeEmpresa _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr);

            return _Result;
        }
    }
}
