using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgTelefoneDAO : BaseRepository<RgTelefone>
    {
        public List<RgTelefone> ListarRgTelefones()
        {
            List<RgTelefone> _RgTelefones = this.GetQueryable().OrderBy(t => t.cod_rg).ToList();
            return _RgTelefones;
        }

        public RgTelefone RecuperarRgTelefone(int _CodEmpr, int _CodRg, int _Seq_tel)
        {
            RgTelefone _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodRg, _Seq_tel);

            return _Result;
        }

    }
}
