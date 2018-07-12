using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeProcessoDAO : BaseRepository<GeProcesso>
    {
        public List<GeProcesso> ListarGeProcessos()
        {
            List<GeProcesso> _GeProcessos = this.GetQueryable().OrderBy(p => p.descr_proc).ToList();
            return _GeProcessos;
        }

        public GeProcesso RecuperarGeProcesso(int _CodProc)
        {
            GeProcesso _Result = null;

            _Result = this.FindByPrimaryKey(_CodProc);

            return _Result;
        }
    }
}
