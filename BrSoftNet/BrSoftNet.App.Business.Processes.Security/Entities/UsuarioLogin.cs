using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Security.Entities
{
    [Serializable]
    public class UsuarioLogin
    {
        #region Properties

        public string Usuario { get; set; }        

        public string Nome { get; set; }

        public int CodigoEmpresa { get; set; }

        public int CodigoRegistroGeral { get; set; }

        public string StatusDba { get; set; }

        public string Ramal { get; set; }

        #endregion

        #region Constructors

        public UsuarioLogin(DataRow _Row) 
        {
            Usuario = _Row["Usuario"].ToString();
            Nome = _Row["Nome"].ToString();
            CodigoEmpresa = int.Parse(_Row["CodigoEmpresa"].ToString());
            CodigoRegistroGeral = int.Parse(_Row["CodigoRegistroGeral"].ToString());
            StatusDba = _Row["StatusDba"].ToString();
            Ramal = _Row["Ramal"].ToString();             
        }

        public UsuarioLogin() { }

        #endregion

    }
}
