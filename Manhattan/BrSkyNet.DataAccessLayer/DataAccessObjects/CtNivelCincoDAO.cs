using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class CtNivelCincoDAO : BaseRepository<CtNivelCinco>
    {
        public List<CtNivelCinco> ListarCtNiveisCinco()
        {
            List<CtNivelCinco> _CtNiveisCinco = this.GetQueryable().OrderBy(c => c.descr_nivel5).ToList();
            return _CtNiveisCinco;
        }

        public CtNivelCinco RecuperarCtNivelCinco(int _CodEmpr, int _CodPlanoCont, int _CodNivel1, int _CodNivel2, int _CodNivel3, int _CodNivel4, int _CodNivel5)
        {
            CtNivelCinco _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodPlanoCont, _CodNivel1, _CodNivel2, _CodNivel3, _CodNivel4, _CodNivel5);

            return _Result;
        }
    }
}
