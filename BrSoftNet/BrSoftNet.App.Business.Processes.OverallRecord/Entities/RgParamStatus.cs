using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.OverallRecord.Entities
{
    public class RgParamStatus
    {
        public int IdRgStatusAtivo { get; set; }
        public string DescrStatusAtivo { get; set; }

        public int IdRgStatusInativo { get; set; }
        public string DescrStatusInativo { get; set; }

        public RgParamStatus(DataRow _Row, int _Tbl)
        {
            switch (_Tbl)
            {
                case 6:
                    IdRgStatusAtivo = int.Parse(_Row["cod_status_ativo"].ToString());
                    DescrStatusAtivo = _Row["descr_status_ativo"].ToString();
                    break;
                case 7:
                    IdRgStatusInativo = int.Parse(_Row["cod_status_inativo"].ToString());
                    DescrStatusInativo = _Row["descr_status_inativo"].ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
