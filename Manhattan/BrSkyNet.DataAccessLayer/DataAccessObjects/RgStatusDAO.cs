using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgStatusDAO : BaseRepository<RgStatus>
    {
        public List<RgStatus> ListarRgStatusCollection()
        {
            List<RgStatus> _RgStatusCollection = this.GetQueryable().OrderBy(s => s.descr_status).ToList();
            return _RgStatusCollection;
        }

        public RgStatus RecuperarRgStatus(int _CodStatus)
        {
            RgStatus _Result = null;

            _Result = this.FindByPrimaryKey(_CodStatus);

            return _Result;
        }
    }
}
