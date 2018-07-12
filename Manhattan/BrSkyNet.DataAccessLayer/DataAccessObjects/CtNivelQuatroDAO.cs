using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class CtNivelQuatroDAO : BaseRepository<CtNivelQuatro>
    {
        public List<CtNivelQuatro> ListarCtNiveisQuatro()
        {
            List<CtNivelQuatro> _CtNiveisQuatro = this.GetQueryable().OrderBy(c => c.descr_nivel4).ToList();
            return _CtNiveisQuatro;
        }

        public CtNivelQuatro RecuperarCtNivelQuatro(int _CodEmpr, int _CodPlanoCont, int _CodNivel1, int _CodNivel2, int _CodNivel3, int _CodNivel4)
        {
            CtNivelQuatro _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodPlanoCont, _CodNivel1, _CodNivel2, _CodNivel3, _CodNivel4);

            return _Result;
        }
    }
}
