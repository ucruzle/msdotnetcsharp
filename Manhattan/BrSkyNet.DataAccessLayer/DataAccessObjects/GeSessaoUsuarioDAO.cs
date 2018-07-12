using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeSessaoUsuarioDAO : BaseRepository<GeSessaoUsuario>
    {
        public List<GeSessaoUsuario> ListarGeSessoesUsuarios()
        {
            List<GeSessaoUsuario> _GeSessoesUsuarios = this.GetQueryable().OrderBy(s => s.IdSession).ToList();
            return _GeSessoesUsuarios;
        }

        public GeSessaoUsuario RecuperarGeSessaoUsuario(string _Usuario)
        {
            GeSessaoUsuario _Result = null;

            _Result = this.FindByPrimaryKey(_Usuario);

            return _Result;
        }
    }
}
