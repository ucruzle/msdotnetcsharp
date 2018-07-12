using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeUsuarioAplicacaoDAO : BaseRepository<GeUsuarioAplicacao>
    {
        public List<GeUsuarioAplicacao> ListarGeUsuariosAplicacoes()
        {
            List<GeUsuarioAplicacao> _GeUsuariosAplicacoes = this.GetQueryable().OrderBy(u => u.usuario).ToList();
            return _GeUsuariosAplicacoes;
        }

        public GeUsuarioAplicacao RecuperarGeUsuarioAplicacao(int _CodEmpr, string _Usuario, int _CodAplic)
        {
            GeUsuarioAplicacao _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _Usuario, _CodAplic);

            return _Result;
        }
    }
}
