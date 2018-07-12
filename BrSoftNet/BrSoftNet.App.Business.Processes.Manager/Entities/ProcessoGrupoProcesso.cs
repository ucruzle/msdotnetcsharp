using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    public class ProcessoGrupoProcesso
    {
        #region Properties
        public bool Liberar { get; set; }
        public int CodigoProcesso { get; set; }

        public string DescricaoProcesso { get; set; }

        public int CodigoTipoProcesso { get; set; }

        public int CodigoAplicacao { get; set; }

        public string Ativo { get; set; }

        public string Form { get; set; }

        public int SequenciaProcesso { get; set; }

        #endregion

        #region Constructors

        public ProcessoGrupoProcesso(DataRow _Row) 
        {
            CodigoProcesso = int.Parse(_Row["cod_proc"].ToString());
            DescricaoProcesso = _Row["descr_proc"].ToString();
            CodigoTipoProcesso = int.Parse(_Row["cod_tipo_proc"].ToString());
            CodigoAplicacao = int.Parse(_Row["cod_aplic"].ToString());
            Ativo = _Row["ativo"].ToString();
            Form = _Row["form"].ToString();
            SequenciaProcesso = int.Parse(_Row["sequ_proc"].ToString());
        }

        public ProcessoGrupoProcesso(bool _Liberar, int _CodigoProcesso, string _DescricaoProcesso, int _CodigoTipoProcesso, int _CodigoAplicacao, string _Ativo, string _Form, int _SequenciaProcesso) 
        {
            Liberar = _Liberar;
            CodigoProcesso = _CodigoProcesso;
            DescricaoProcesso = _DescricaoProcesso;
            CodigoTipoProcesso = _CodigoTipoProcesso;
            CodigoAplicacao = _CodigoAplicacao;
            Ativo = _Ativo;
            Form = _Form;
            SequenciaProcesso = _SequenciaProcesso;
        }

        public ProcessoGrupoProcesso() { }

        #endregion
    }
}
