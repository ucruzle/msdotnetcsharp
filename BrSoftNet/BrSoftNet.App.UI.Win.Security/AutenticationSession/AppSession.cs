using BrSoftNet.App.Business.Processes.Security.Entities;
using System;
using System.Collections.Generic;

namespace BrSoftNet.App.UI.Win.Security.AutenticationSession
{
    public class AppSession
    {
        public string IdSession { get; set; }

        public string Usuario { get; set; }
        public string Nome { get; set; }
        public List<EmpresaLogin> EmpresaLoginCollection { get; set; }
        public List<AplicacaoLogin> AplicacaoLoginCollection { get; set; }
        public List<TipoProcessoLogin> TipoProcessoCollection { get; set; }
        public List<ProcessoLogin> ProcessoCollection { get; set; }
        public AppSession() 
        {
            IdSession = Guid.NewGuid().ToString();
        }
    }
}
