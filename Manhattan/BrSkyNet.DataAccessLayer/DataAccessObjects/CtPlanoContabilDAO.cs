using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class CtPlanoContabilDAO : BaseRepository<CtPlanoContabil>
    {
        public List<CtPlanoContabil> ListarCtPlanosContabeis()
        {
            List<CtPlanoContabil> _CtPlanosContabeis = this.GetQueryable().OrderBy(c => c.descr_plano_cont).ToList();
            return _CtPlanosContabeis;
        }

        public CtPlanoContabil RecuperarCtPlanoContabil(int _CodPlanoCont)
        {
            CtPlanoContabil _Result = null;

            _Result = this.FindByPrimaryKey(_CodPlanoCont);

            return _Result;
        }
    }
}
