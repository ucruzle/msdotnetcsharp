using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
     [Serializable]
    public class IntegracaoRegGeral
    {
        public int IdEmpr { get; set; }

        public int IdRg { get; set; }

        public string RazaoSocial { get; set; }

        public string TipoRg { get; set; }

        public int IdStatus { get; set; }

        public DateTime DataHora { get; set; }

        public string Usuario { get; set; }

        public string NomeFantasia { get; set; }

        public string OptanteSimples { get; set; }
        
        public IntegracaoRegGeral() { }

        public IntegracaoRegGeral(DataRow _Row) 
        {
            IdEmpr = int.Parse(_Row["cod_empr"].ToString());
            IdRg = int.Parse(_Row["cod_rg"].ToString());
            RazaoSocial = _Row["razao_social"].ToString();
            TipoRg = _Row["tipo_rg"].ToString();
            IdStatus = int.Parse(_Row["cod_status"].ToString());
            DataHora = DateTime.Parse(_Row["data_hora"].ToString());
            Usuario = _Row["usuario"].ToString();
            NomeFantasia = _Row["nome_fantasia"].ToString();
            OptanteSimples = _Row["optante_simples"].ToString();
        }

        public IntegracaoRegGeral(int _IdEmpr, int _IdRg, string _RazaoSocial, string _TipoRg, int _IdStatus, string _DataHora, string _Usuario, string _NomeFantasia, string _OptanteSimples)
        {
            IdEmpr = _IdEmpr;
            IdRg = _IdRg;
            RazaoSocial = _RazaoSocial;
            TipoRg = _TipoRg;
            IdStatus = _IdStatus;
            DataHora = DateTime.Parse(_DataHora);
            Usuario = _Usuario;
            NomeFantasia = _NomeFantasia;
            OptanteSimples = _OptanteSimples;
        }
    }
}
