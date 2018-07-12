using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeParametroDAO : BaseRepository<GeParametro>
    {
        public List<GeParametro> ListarGeParametros()
        {
            List<GeParametro> _GeParametros = this.GetQueryable().OrderBy(p => p.id_tabela).ToList();
            return _GeParametros;
        }

        public GeParametro RecuperarGeParametro(int _IdTabela)
        {
            GeParametro _Result = null;

            _Result = this.FindByPrimaryKey(_IdTabela);

            return _Result;
        }
    }
}
