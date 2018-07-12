using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class FiCtaBanco
    {
        public int IdTipoCta { get; set; }

        public string DescrCta { get; set; }

        public FiCtaBanco() { }

        public FiCtaBanco(DataRow _Row) 
        {
            IdTipoCta = int.Parse(_Row["cod_tipo_cta"].ToString());
            DescrCta = _Row["descr_cta_banco"].ToString();
        }

        public FiCtaBanco(int _IdTipoCta, string _DescrCta) 
        {
	        IdTipoCta = _IdTipoCta;
            DescrCta = _DescrCta;
        }
    }
}
