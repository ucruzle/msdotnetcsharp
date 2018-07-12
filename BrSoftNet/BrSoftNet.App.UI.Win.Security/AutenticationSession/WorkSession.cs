using BrSoftNet.App.UI.Win.Main.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.UI.Win.Security.AutenticationSession
{
    public class WorkSession : IWorkSession
    {
        public AppSession Session { get; set; }

        public void Execute()
        {
            lock (typeof(WorkSession))
            {
                if (Session == null)
                {
                    Session = new AppSession();
                }
            }

            Session.Nome = AppStateSecurity.Nome;
            Session.Usuario = AppStateSecurity.Usuario;
            Session.EmpresaLoginCollection = AppStateSecurity.EmpresaLoginCollection;
            Session.AplicacaoLoginCollection = AppStateSecurity.AplicacaoLoginCollection;
            Session.TipoProcessoCollection = AppStateSecurity.TipoProcessoCollection;
            Session.ProcessoCollection = AppStateSecurity.ProcessoCollection;
        }
    }
}
