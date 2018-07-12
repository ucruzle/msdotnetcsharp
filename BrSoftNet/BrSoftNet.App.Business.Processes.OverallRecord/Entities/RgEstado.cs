using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class RgEstado
    {
        public string UF { get; set; }

        public string DescrEstado { get; set; }

        public string SiglaRegiao { get; set; }

        public RgEstado() { }

        public RgEstado(DataRow _Row) 
        {
            UF = _Row["sigla_estado"].ToString();
            DescrEstado = _Row["descr_estado"].ToString();
            SiglaRegiao = _Row["sigla_regiao"].ToString();
        }

        public RgEstado(string _UF, string _DescrEstado, string _SiglaRegiao)
        {
            UF = _UF;
            DescrEstado = _DescrEstado;
            SiglaRegiao = _SiglaRegiao;
        }
    }
}
