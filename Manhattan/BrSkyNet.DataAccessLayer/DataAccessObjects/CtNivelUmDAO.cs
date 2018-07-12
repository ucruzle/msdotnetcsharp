using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class CtNivelUmDAO : BaseRepository<CtNivelUm>
    {
        public List<CtNivelUm> ListarCtNiveisUm()
        {
            List<CtNivelUm> _CtNiveisUm = this.GetQueryable().OrderBy(c => c.descr_nivel1).ToList();
            return _CtNiveisUm;
        }

        public CtNivelUm RecuperarCtNivelUm(int _CodEmpr, int _CodPlanoCont, int _CodNivel1)
        {
            CtNivelUm _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodPlanoCont, _CodNivel1);

            return _Result;
        }
    }
}
