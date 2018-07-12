using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgRegiaoDAO : BaseRepository<RgRegiao>
    {
        public List<RgRegiao> ListarRgRegioes()
        {
            List<RgRegiao> _RgRegioes = this.GetQueryable().OrderBy(r => r.descr_regiao).ToList();
            return _RgRegioes;
        }

        public RgRegiao RecuperarRgRegiao(string _SiglaRegiao)
        {
            RgRegiao _Result = null;
            _Result = this.FindByPrimaryKey(_SiglaRegiao);

            return _Result;
        }
    }
}
