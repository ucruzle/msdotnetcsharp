using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgRegGeralNaturezaDAO : BaseRepository<RgRegGeralNatureza>
    {
        public List<RgRegGeralNatureza> ListarRgRegGeraisNaturezas()
        {
            List<RgRegGeralNatureza> _RgRegGeraisNaturezas = this.GetQueryable().OrderBy(n => n.cod_natureza).ToList();
            return _RgRegGeraisNaturezas;
        }

        public RgRegGeralNatureza RecuperarRgRegGeralNatureza(int _CodEmpr, int _CodRg, int _CodNatureza)
        {
            RgRegGeralNatureza _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodRg, _CodNatureza);

            return _Result;
        }
    }
}
