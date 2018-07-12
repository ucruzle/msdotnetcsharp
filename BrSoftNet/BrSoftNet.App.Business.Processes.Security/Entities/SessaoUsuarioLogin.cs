using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Security.Entities
{
    public class SessaoUsuarioLogin
    {
        #region ...::: Properties :::...

        public string Usuario { get; set; }
        public string IdSession { get; set; }
        public DateTime DateTimeSession { get; set; }
        public string MachineName { get; set; }
        public string MachineIP { get; set; }
        public int LogonNumber { get; set; }

        #endregion

        #region ...::: Constructors :::...

        public SessaoUsuarioLogin(DataRow _Row) 
        {
            Usuario = _Row["Usuario"].ToString();
            IdSession = _Row["IdSession"].ToString();
            DateTimeSession = Convert.ToDateTime(_Row["DateTimeSession"].ToString());
            MachineName = _Row["MachineName"].ToString();
            MachineIP = _Row["MachineIP"].ToString();
            LogonNumber = Convert.ToInt32(_Row["LogonNumber"].ToString());
        }
        
        public SessaoUsuarioLogin() { }

        #endregion
    }
}
