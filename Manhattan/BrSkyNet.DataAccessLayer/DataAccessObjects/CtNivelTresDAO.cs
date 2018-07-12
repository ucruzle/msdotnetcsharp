using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class CtNivelTresDAO : BaseRepository<CtNivelTres>
    {
        public List<CtNivelTres> ListarCtNiveisTres()
        {
            List<CtNivelTres> _CtNiveisTres = this.GetQueryable().OrderBy(c => c.descr_nivel3).ToList();
            return _CtNiveisTres;
        }

        public CtNivelTres RecuperarCtNivelTres(int _CodEmpr, int _CodPlanoCont, int _CodNivel1, int _CodNivel2, int _CodNivel3)
        {
            CtNivelTres _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodPlanoCont, _CodNivel1, _CodNivel2, _CodNivel3);

            return _Result;
        }
    }
}
