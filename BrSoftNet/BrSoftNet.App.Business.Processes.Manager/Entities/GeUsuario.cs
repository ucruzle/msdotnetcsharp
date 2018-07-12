using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class GeUsuario
    {
        #region Properties
        public string Usuario { get; set; }

        public string Nome { get; set; }

        public int CodigoEmpresa { get; set; }

        public int CodigoRG { get; set; }

        public string StatusDBA { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Senha { get; set; }

        public string Ramal { get; set; }

        public string Ativo { get; set; }

        public string UsuarioIncl { get; set; }

        #endregion

        #region Constructors

        public GeUsuario(DataRow _Row) 
        {
            Usuario = _Row["usuario"].ToString();
            Nome = _Row["nome"].ToString();
            CodigoEmpresa = int.Parse(_Row["cod_empr"].ToString());
            CodigoRG = int.Parse(_Row["cod_rg"].ToString());
            StatusDBA = _Row["status_dba"].ToString();
            DataCadastro = DateTime.Parse(_Row["dt_cadastro"].ToString());
            Senha = _Row["senha"].ToString();
            Ramal = _Row["ramal"].ToString();
            Ativo = _Row["ativo"].ToString();
            UsuarioIncl = _Row["usuario_incl"].ToString();
        }

        public GeUsuario() { }

        #endregion
    }
}
