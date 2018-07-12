using BrSkyNet.ModelLayer.Entities;
using BrSkyNet.ObjectRelationalMapping.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BrSkyNet.DataAccessLayer.DataAccessObjects
{
    public class GeAplicacaoDAO : BaseRepository<GeAplicacao>
    {
        public List<GeAplicacao> ListarGeAplicacoes()
        {
            List<GeAplicacao> _GeAplicacoes = this.GetQueryable().OrderBy(a => a.descr_aplic).ToList();
            return _GeAplicacoes;
        }

        public GeAplicacao RecuperarGeAplicacao(int _CodAplic)
        {
            GeAplicacao _Result = null;

            _Result = this.FindByPrimaryKey(_CodAplic);

            return _Result;
        }
    }
}
