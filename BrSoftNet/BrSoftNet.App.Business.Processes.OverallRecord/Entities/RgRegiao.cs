using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class RgRegiao
    {
        public string SiglaRegiao { get; set; }

        public string DescrRegiao { get; set; }
        public RgRegiao() { }

        public RgRegiao(DataRow _Row) 
        {
            SiglaRegiao = _Row["sigla_regiao"].ToString();
            DescrRegiao = _Row["descr_regiao"].ToString();
        }

        public RgRegiao(string _SiglaRegiao, string _DescrRegiao)
        {
            SiglaRegiao = _SiglaRegiao;
            DescrRegiao = _DescrRegiao;
        }
    }
}
