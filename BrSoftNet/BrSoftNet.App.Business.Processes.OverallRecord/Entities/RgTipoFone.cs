using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class RgTipoFone
    {
        public int IdTipoFone { get; set; }

        public string DescrTipoFone { get; set; }

        public RgTipoFone() { }

        public RgTipoFone(DataRow _Row) 
        {
            IdTipoFone = int.Parse(_Row["cod_tipo_fone"].ToString());
            DescrTipoFone = _Row["descr_tipo_fone"].ToString();
        }

        public RgTipoFone(int _IdTipoFone, string _DescrRegiao)
        {
            IdTipoFone = _IdTipoFone;
            DescrTipoFone = _DescrRegiao;
        }
    }
}
