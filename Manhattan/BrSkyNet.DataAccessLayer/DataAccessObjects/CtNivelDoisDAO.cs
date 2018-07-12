using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class CtNivelDoisDAO : BaseRepository<CtNivelDois>
    {
        public List<CtNivelDois> ListarCtNiveisDois()
        {
            List<CtNivelDois> _CtNiveisDois = this.GetQueryable().OrderBy(c => c.descr_nivel2).ToList();
            return _CtNiveisDois;
        }

        public CtNivelDois RecuperarCtNivelDois(int _CodEmpr, int _CodPlanoCont, int _CodNivel1, int _CodNivel2)
        {
            CtNivelDois _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodPlanoCont, _CodNivel1, _CodNivel2);

            return _Result;
        }
    }
}
