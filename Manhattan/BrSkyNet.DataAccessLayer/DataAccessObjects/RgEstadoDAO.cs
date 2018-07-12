using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class RgEstadoDAO : BaseRepository<RgEstado>
    {
        public List<RgEstado> ListarRgEstados()
        {
            List<RgEstado> _RgEstados = this.GetQueryable().OrderBy(e => e.sigla_estado).ToList();
            return _RgEstados;
        }

        public RgEstado RecuperarRgEstado(string _SiglaEstado)
        {
            RgEstado _Result = null;

            _Result = this.FindByPrimaryKey(_SiglaEstado);

            return _Result;
        }
    }
}
