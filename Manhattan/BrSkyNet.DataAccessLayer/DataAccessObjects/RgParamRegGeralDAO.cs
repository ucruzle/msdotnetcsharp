using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgParamRegGeralDAO : BaseRepository<RgParamRegGeral>
    {
        public List<RgParamRegGeral> ListarRgParamRegsGerais()
        {
            List<RgParamRegGeral> _RgParamRegsGerais = this.GetQueryable().OrderBy(p => p.cod_empr).ToList();
            return _RgParamRegsGerais;
        }

        public RgParamRegGeral RecuperarRgParamRegGeral(int _CodEmpr)
        {
            RgParamRegGeral _Result = null;
            _Result = this.FindByPrimaryKey(_CodEmpr);

            return _Result;
        }
    }
}
