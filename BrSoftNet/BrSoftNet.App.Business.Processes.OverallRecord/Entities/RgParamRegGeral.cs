using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.Business.Processes.OverallRecord.Entities
{
    public class RgParamRegGeral
    {
        #region Properties
        public int CodigoEmpresa { get; set; }

        public int CodigoNatFunc { get; set; }

        public int CodigoNatFuncLider { get; set; }

        public int CodigoNatCliente { get; set; }

        public int CodigoNatFornecedor { get; set; }

        public int CodigoNatBanco { get; set; }

        public int CodigoStatusAtivo { get; set; }

        public int CodigoStatusInativo { get; set; }

        public string PermiteCGCCPFZerado { get; set; }

        public int CodigoNatTomadora { get; set; }

        public int CodigoNatResp { get; set; }

        public string PermiteCGCCPFDuplicado { get; set; }

        #endregion

        #region Constructors
        
        public RgParamRegGeral(DataRow _Row) 
        {
            CodigoEmpresa = int.Parse(_Row["cod_empr"].ToString());
            CodigoNatFunc = int.Parse(_Row["cod_nat_func"].ToString());
            CodigoNatFuncLider = int.Parse(_Row["cod_nat_func_lider"].ToString());
            CodigoNatCliente = int.Parse(_Row["cod_nat_cliente"].ToString());
            CodigoNatFornecedor = int.Parse(_Row["cod_nat_fornec"].ToString());
            CodigoNatBanco = int.Parse(_Row["cod_nat_banco"].ToString());
            CodigoStatusAtivo = int.Parse(_Row["cod_status_ativo"].ToString());
            CodigoStatusInativo = int.Parse(_Row["cod_status_inativo"].ToString());
            PermiteCGCCPFZerado = _Row["permite_cgc_cpf_zerado"].ToString();
            CodigoNatTomadora = int.Parse(_Row["cod_nat_tomadora"].ToString());
            CodigoNatResp = int.Parse(_Row["cod_nat_resp"].ToString());
            PermiteCGCCPFDuplicado = _Row["permite_cgc_cpf_duplic"].ToString();
        }

        public RgParamRegGeral() { }

        #endregion
    }
}
