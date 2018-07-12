using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class GeAplicacao
    {
        #region Properties
        public int CodigoAplicacao { get; set; }

        public string DescricaoAplicacao { get; set; }

        public string SiglaAplicacao { get; set; }

        public int SequenciaAplicacao { get; set; }

        public string AtivaAplicacao { get; set; }

        public string FormAplicacao { get; set; }

        #endregion

        #region Constructors

        public GeAplicacao(DataRow _Row) 
        {
            CodigoAplicacao = int.Parse(_Row["cod_aplic"].ToString());
            DescricaoAplicacao = _Row["descr_aplic"].ToString();
            SiglaAplicacao = _Row["sigla_aplic"].ToString();
            SequenciaAplicacao = int.Parse(_Row["sequ_aplic"].ToString());
            AtivaAplicacao = _Row["ativa"].ToString();
            FormAplicacao = _Row["form_aplic"].ToString();
        }

        public GeAplicacao() { }

        #endregion
    }
}
