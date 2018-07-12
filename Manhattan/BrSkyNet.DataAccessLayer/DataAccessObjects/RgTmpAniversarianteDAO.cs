using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgTmpAniversarianteDAO : BaseRepository<RgTmpAniversariante>
    {
        public List<RgTmpAniversariante> ListarRgTmpAniversariantes()
        {
            List<RgTmpAniversariante> _RgTmpAniversariantes = this.GetQueryable().OrderBy(a => a.cod_rg).ToList();
            return _RgTmpAniversariantes;
        }

        public RgTmpAniversariante RecuperarRgTmpAniversariante(string _Usuario, int _CodRg)
        {
            RgTmpAniversariante _Result = null;
            _Result = this.FindByPrimaryKey(_Usuario, _CodRg);

            return _Result;
        }
    }
}
