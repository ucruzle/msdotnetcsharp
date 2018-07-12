using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeMvcWebProcessoDAO : BaseRepository<GeMvcWebProcesso>
    {
        public List<GeMvcWebProcesso> ListarGeMvcWebProcessos()
        {
            List<GeMvcWebProcesso> _GeMvcWebProcessos = this.GetQueryable().OrderBy(w => w.description).ToList();
            return _GeMvcWebProcessos;
        }

        public GeMvcWebProcesso RecuperarGeMvcWebProcesso(int _CodProc)
        {
            GeMvcWebProcesso _Result = null;

            _Result = this.FindByPrimaryKey(_CodProc);

            return _Result;
        }
    }
}
