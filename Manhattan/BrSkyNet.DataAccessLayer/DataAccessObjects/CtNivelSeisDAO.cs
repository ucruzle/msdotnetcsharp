using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class CtNivelSeisDAO : BaseRepository<CtNivelSeis>
    {
        public List<CtNivelSeis> ListarCtNiveisSeis()
        {
            List<CtNivelSeis> _CtNiveisSeis = this.GetQueryable().OrderBy(c => c.descr_nivel6).ToList();
            return _CtNiveisSeis;
        }

        public CtNivelSeis RecuperarCtNivelSeis(int _CodEmpr, int _CodPlanoCont, int _CodNivel1, int _CodNivel2, int _CodNivel3, int _CodNivel4, int _CodNivel5, int _CodNivel6)
        {
            CtNivelSeis _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodPlanoCont, _CodNivel1, _CodNivel2, _CodNivel3, _CodNivel4, _CodNivel5, _CodNivel6);

            return _Result;
        }
    }
}
