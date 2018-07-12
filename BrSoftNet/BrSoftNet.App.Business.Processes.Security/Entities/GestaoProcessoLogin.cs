using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Security.Entities
{
    [Serializable]
    public class GestaoProcessoLogin
    {
        public int CodigoProcesso { get; set; }

        public string DescricaoProcesso { get; set; }

        public int CodigoTipoProcesso { get; set; }

        public int CodigoAplicacao { get; set; }

        public string Ativo { get; set; }

        public string Formulario { get; set; }

        public int SequenciaProcesso { get; set; }

        public GestaoProcessoLogin() { }

        public GestaoProcessoLogin(DataRow _Row) 
        {
            CodigoProcesso = int.Parse(_Row["cod_proc"].ToString());
            DescricaoProcesso = _Row["descr_proc"].ToString();
            CodigoTipoProcesso = int.Parse(_Row["cod_tipo_proc"].ToString());
            CodigoAplicacao = int.Parse(_Row["cod_aplic"].ToString());
            Ativo = _Row["ativo"].ToString();
            Formulario = _Row["form"].ToString();
            SequenciaProcesso = int.Parse(_Row["sequ_proc"].ToString());
        }
    }
}
