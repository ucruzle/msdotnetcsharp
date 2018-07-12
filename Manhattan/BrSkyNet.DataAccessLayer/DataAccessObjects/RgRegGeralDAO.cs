using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgRegGeralDAO : BaseRepository<RgRegGeral>
    {
        public List<RgRegGeral> ListarRgRegGerais()
        {
            List<RgRegGeral> _RgRegGerais = this.GetQueryable().OrderBy(r => r.nome_fantasia).ToList();
            return _RgRegGerais;
        }

        public int NovoRgGeral(int _CodEmpr)
        {
            int _CodRg = Convert.ToInt16(ListarRgRegGerais().AsQueryable().Count(p => p.cod_empr == _CodEmpr).ToString());

            return _CodRg++;
        }
    }
}
