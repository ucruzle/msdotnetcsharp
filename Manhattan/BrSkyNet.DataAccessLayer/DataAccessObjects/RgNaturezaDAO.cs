using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgNaturezaDAO : BaseRepository<RgNatureza>
    {
        public List<RgNatureza> ListarRgNaturezas()
        {
            List<RgNatureza> _RgNaturezas = this.GetQueryable().OrderBy(n => n.descr_natureza).ToList();
            return _RgNaturezas;
        }

        public RgNatureza RecuperarRgNatureza(int CodNatureza)
        {
            RgNatureza _Result = null;

            _Result = this.FindByPrimaryKey(CodNatureza);

            return _Result;
        }
    }
}
