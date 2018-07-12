using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeEmpresaAplicacaoDAO : BaseRepository<GeEmpresaAplicacao>
    {
        public List<GeEmpresaAplicacao> ListarGeEmpresasAplicacoes()
        {
            List<GeEmpresaAplicacao> _GeEmpresasAplicacoes = this.GetQueryable().OrderBy(e => e.cod_empr).ToList();
            return _GeEmpresasAplicacoes;
        }

        public GeEmpresaAplicacao RecuperarGeEmpresaAplicacao(int _CodEmpr, int _CodAplic)
        {
            GeEmpresaAplicacao _Result = null;

            _Result = this.FindByPrimaryKey(_CodEmpr, _CodAplic);

            return _Result;
        }
    }
}
