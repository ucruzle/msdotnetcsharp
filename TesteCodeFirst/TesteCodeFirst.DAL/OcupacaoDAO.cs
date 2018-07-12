using System;
using System.Collections.Generic;
using System.Linq;
using TesteCodeFirst.Entities;
using TesteCodeFirst.Utils.ORM;

namespace TesteCodeFirst.DAL
{
    public class OcupacaoDAO : BaseRepository<Ocupacao>
    {
        public List<Ocupacao> ListarOcupacoes()
        {
            List<Ocupacao> ocupacoes =
                this.GetQueryable().OrderBy(
                    o => o.NomeOcupacao).ToList();
            return ocupacoes;
        }
    }
}