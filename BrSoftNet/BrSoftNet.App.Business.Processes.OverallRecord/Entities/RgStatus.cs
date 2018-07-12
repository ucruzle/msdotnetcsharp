using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class RgStatus
    {
        public int IdRgStatus { get; set; }
        public string DescrStatus { get; set; }

        public RgStatus() { }

        public RgStatus(DataRow _Row) 
        {
            IdRgStatus = int.Parse(_Row["cod_status"].ToString());
            DescrStatus = _Row["descr_status"].ToString();
        }

        public RgStatus(int _IdRgStatus, string _DescrStatus)
        {
            IdRgStatus = _IdRgStatus;
            DescrStatus = _DescrStatus;
        }
    }
}
