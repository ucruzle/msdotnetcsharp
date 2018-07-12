using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class GeProcesso
    {
        #region Properties
        
        public int CodigoProcesso { get; set; }

        public string DescricaoProcesso { get; set; }

        public int CodigoTipoProcesso { get; set; }

        public int CodigoAplicacao { get; set; }

        public string Ativo { get; set; }

        public string Form { get; set; }

        public int SequenciaProcesso { get; set; }

        #endregion

        #region Constructors

        public GeProcesso(DataRow _Row) 
        {
            CodigoProcesso = int.Parse(_Row["cod_proc"].ToString());
            DescricaoProcesso = _Row["descr_proc"].ToString();
            CodigoTipoProcesso = int.Parse(_Row["cod_tipo_proc"].ToString());
            CodigoAplicacao = int.Parse(_Row["cod_aplic"].ToString());
            Ativo = _Row["ativo"].ToString();
            Form = _Row["form"].ToString();
            SequenciaProcesso = int.Parse(_Row["sequ_proc"].ToString());
        }

        public GeProcesso() { }

        #endregion
    }
}
