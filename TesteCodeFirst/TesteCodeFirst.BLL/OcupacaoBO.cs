using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using TesteCodeFirst.Entities;
using TesteCodeFirst.DAL;

namespace TesteCodeFirst.BLL
{
    public class OcupacaoBO
    {
        [Dependency]
        public OcupacaoDAO DAO { get; set; }

        public List<Ocupacao> ListarOcupacoes()
        {
            return DAO.ListarOcupacoes();
        }
    }
}