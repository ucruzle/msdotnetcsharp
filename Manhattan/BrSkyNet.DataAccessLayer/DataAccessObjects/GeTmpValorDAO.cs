using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeTmpValorDAO : BaseRepository<GeTmpValor>
    {
        public List<GeTmpValor> ListarGeTmpValores()
        {
            List<GeTmpValor> _GeTmpValores = this.GetQueryable().OrderBy(t => t.status).ToList();
            return _GeTmpValores;
        }

        public GeTmpValor RecuperarGeTmpValor(string _Usuario)
        {
            GeTmpValor _Result = null;

            _Result = this.FindByPrimaryKey(_Usuario);

            return _Result;
        }
    }
}
