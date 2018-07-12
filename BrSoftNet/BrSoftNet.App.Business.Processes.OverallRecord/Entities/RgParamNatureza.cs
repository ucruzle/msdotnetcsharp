using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.OverallRecord.Entities
{
    public class RgParamNatureza
    {
        public int IdNatureza { get; set; }
        public string DescrNatureza { get; set; }

        public int IdNaturezaFuncionario { get; set; }
        public string DescrNaturezaFuncionario { get; set; }

        public int IdNaturezaFuncionarioLider { get; set; }
        public string DescrNaturezaFuncionarioLider { get; set; }

        public int IdNaturezaCliente { get; set; }
        public string DescrNaturezaCliente { get; set; }

        public int IdNaturezaFornecedor { get; set; }
        public string DescrNaturezaFornecedor { get; set; }

        public int IdNaturezaBanco { get; set; }
        public string DescrNaturezaBanco { get; set; }

        public int IdNaturezaTomadora { get; set; }
        public string DescrNaturezaTomadora { get; set; }

        public int IdNaturezaResponsavel { get; set; }
        public string DescrNaturezaResponsavel { get; set; }

          public RgParamNatureza() { }

          public RgParamNatureza(DataRow _Row) 
        {
            IdNatureza = int.Parse(_Row["cod_natureza"].ToString());
            DescrNatureza = _Row["descr_natureza"].ToString();
        }

        public RgParamNatureza(DataRow _Row, int _Tbl)
        {
            switch (_Tbl)
            {
                case 1:
                    IdNaturezaFuncionario = int.Parse(_Row["cod_nat_func"].ToString());
                    DescrNaturezaFuncionario = _Row["descr_nat_func"].ToString();
                    break;
                case 2:
                    IdNaturezaFuncionarioLider = int.Parse(_Row["cod_nat_func_lider"].ToString());
                    DescrNaturezaFuncionarioLider = _Row["descr_nat_func_lider"].ToString();
                    break;
                case 3:
                    IdNaturezaCliente = int.Parse(_Row["cod_nat_cli"].ToString());
                    DescrNaturezaCliente = _Row["descr_nat_cli"].ToString();
                    break;
                case 4:
                    IdNaturezaFornecedor = int.Parse(_Row["cod_nat_fornec"].ToString());
                    DescrNaturezaFornecedor = _Row["descr_nat_fornec"].ToString();
                    break;
                case 5:
                    IdNaturezaBanco = int.Parse(_Row["cod_nat_banco"].ToString());
                    DescrNaturezaBanco = _Row["descr_nat_banco"].ToString();
                    break;
                case 8:
                    IdNaturezaTomadora = int.Parse(_Row["cod_nat_tomadora"].ToString());
                    DescrNaturezaTomadora = _Row["descr_nat_tomadora"].ToString();
                    break;
                case 9:
                    IdNaturezaResponsavel = int.Parse(_Row["cod_nat_resp"].ToString());
                    DescrNaturezaResponsavel = _Row["descr_nat_resp"].ToString();
                    break;
                default:
                    break;
            }
        }
    }  
}
