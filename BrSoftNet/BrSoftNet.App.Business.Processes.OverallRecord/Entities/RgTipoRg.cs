using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class RgTipoRg
    {
        public string TipoRg { get; set; }

        public string DescrTipo { get; set; }

        public RgTipoRg() { }

        public RgTipoRg(DataRow _Row) 
        {
            TipoRg = _Row["tipo_rg"].ToString();
            DescrTipo = _Row["descr_tipo_rg"].ToString();

        }

        public RgTipoRg(string _TipoRg, string _DescrTipo)
        {
            TipoRg = _TipoRg;
            DescrTipo = _DescrTipo;
        }
    }
}
