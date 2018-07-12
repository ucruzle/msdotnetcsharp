using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeUsuarioProcessoDAO : BaseRepository<GeUsuarioProcesso>
    {
        public List<GeUsuarioProcesso> ListarGeUsuariosProcessos()
        {
            List<GeUsuarioProcesso> _GeUsuariosProcessos = this.GetQueryable().OrderBy(u => u.usuario).ToList();
            return _GeUsuariosProcessos;
        }

        public GeUsuarioProcesso RecuperarGeUsuarioProcesso(int _CodEmpr, string _Usuario, int _CodProc)
        {
            GeUsuarioProcesso _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _Usuario, _CodProc);

            return _Result;
        }
    }
}
