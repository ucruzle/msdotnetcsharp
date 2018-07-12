using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeUsuarioDAO : BaseRepository<GeUsuario>
    {
        public List<GeUsuario> ListarGeUsuarios()
        {
            List<GeUsuario> _GeUsuarios = this.GetQueryable().OrderBy(u => u.nome).ToList();
            return _GeUsuarios;
        }

        public GeUsuario RecuperarGeUsuario(string _Usuario)
        {
            GeUsuario _Result = null;

            _Result = this.FindByPrimaryKey(_Usuario);

            return _Result;
        }
    }
}
