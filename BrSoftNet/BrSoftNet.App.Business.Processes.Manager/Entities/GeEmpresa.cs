using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class GeEmpresa
    {
        #region Properties
        public int CodigoEmpresa { get; set; }

        public string DescricaoEmpresa { get; set; }

        public string DescricaoEmpresaRed { get; set; }

        public int CodigoEmpresaConsolidada { get; set; }

        public string Ativa { get; set; }

        public int CodigoRg { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public string EnderecoBanco { get; set; }

        public string Versao { get; set; }

        #endregion

        #region Constructors

        public GeEmpresa(DataRow _Row) 
        {
            CodigoEmpresa = int.Parse(_Row["cod_empr"].ToString());
            DescricaoEmpresa = _Row["descr_empr"].ToString();
            DescricaoEmpresaRed = _Row["descr_empr_red"].ToString();
            CodigoEmpresaConsolidada = int.Parse(_Row["cod_empr_consol"].ToString());
            Ativa = _Row["ativa"].ToString();
            CodigoRg = int.Parse(_Row["cod_rg"].ToString());
            Host = _Row["host"].ToString();
            Port = int.Parse(_Row["port"].ToString());
            Username = _Row["username"].ToString();
            Senha = _Row["senha"].ToString();
            Email = _Row["e_mail"].ToString();
            EnderecoBanco = _Row["endereco_banco"].ToString();
            Versao = _Row["versao"].ToString();
        }

        public GeEmpresa() { }

        #endregion
    }
}
