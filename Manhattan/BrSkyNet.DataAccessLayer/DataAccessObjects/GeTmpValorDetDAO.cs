using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeTmpValorDetDAO : BaseRepository<GeTmpValorDet>
    {
        public List<GeTmpValorDet> ListarGeTmpValoresDet()
        {
            List<GeTmpValorDet> _GeTmpValoresDet = this.GetQueryable().OrderBy(t => t.status).ToList();
            return _GeTmpValoresDet;
        }

        public GeTmpValorDet RecuperarGeTmpValorDet(string _Usuario, int _Codigo)
        {
            GeTmpValorDet _Result = null;

            _Result = this.FindByPrimaryKey(_Usuario, _Codigo);

            return _Result;
        }
    }
}
