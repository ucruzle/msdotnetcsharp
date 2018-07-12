using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgEnderecoDAO : BaseRepository<RgEndereco>
    {
        public List<RgEndereco> ListarRgEnderecos()
        {
            List<RgEndereco> _RgEnderecos = this.GetQueryable().OrderBy(e => e.endereco).ToList();
            return _RgEnderecos;
        }

        public RgEndereco RecuperarRgEndereco(int _CodEmpr, int _CodRg)
        {
            RgEndereco _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodRg);

            return _Result;
        }
    }
}
