using System;
using System.Data;
using System.Xml.Serialization;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class RgFisicaJuridica
    {
        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public int NroCPF { get; set; }
        public int DigCPF { get; set; }
        public string NroRg { get; set; }
        public string DigRg { get; set; }
        public DateTime DtEmissao { get; set; }
        public string OrgaoExpRg { get; set; }
        public string InscrMunicipal { get; set; }
        public int CGC { get; set; }
        public int FilialCGC { get; set; }
        public int DigCGC { get; set; }
        public string InscEstadual { get; set; }
        public int NroBanco { get; set; }
        public int NroAgencia { get; set; }
        public int DigAgencia { get; set; }
        public int NroConta { get; set; }
        public int DigConta { get; set; }
        public int IdTipoCta { get; set; }
        public string CEI { get; set; }
        public RgFisicaJuridica() { }

        public RgFisicaJuridica(DataRow _Row) 
        {
            IdEmpr = int.Parse(_Row["cod_empr"].ToString());
            IdRg = int.Parse(_Row["cod_rg"].ToString());
            NroCPF = _Row["num_cpf"] != DBNull.Value ? int.Parse(_Row["num_cpf"].ToString()) : 0;
            DigCPF = _Row["dig_cpf"] != DBNull.Value ? int.Parse(_Row["dig_cpf"].ToString()) : 0;
            NroRg = _Row["num_rg"].ToString();
            DigRg = _Row["dig_rg"].ToString();
            DtEmissao = !string.IsNullOrEmpty(_Row["dt_emissao_rg"].ToString()) ? Convert.ToDateTime(_Row["dt_emissao_rg"].ToString()) : Convert.ToDateTime("01/01/0001 00:00:00");
            OrgaoExpRg = _Row["orgao_exp_rg"].ToString();
            InscrMunicipal = _Row["insc_municipal"].ToString();
            CGC = _Row["cgc"] != DBNull.Value ? int.Parse(_Row["cgc"].ToString()) : 0;
            FilialCGC = _Row["filial_cgc"] != DBNull.Value ? int.Parse(_Row["filial_cgc"].ToString()) : 0;
            DigCGC = _Row["dig_cgc"] != DBNull.Value ? int.Parse(_Row["dig_cgc"].ToString()) : 0;
            InscEstadual = _Row["insc_estadual"].ToString();
            NroBanco = _Row["nro_banco"] != DBNull.Value ? int.Parse(_Row["nro_banco"].ToString()) : 0;
            NroAgencia = _Row["nro_agencia"] != DBNull.Value ? int.Parse(_Row["nro_agencia"].ToString()) : 0;
            DigAgencia = _Row["dig_agencia"] != DBNull.Value ? int.Parse(_Row["dig_agencia"].ToString()) : 0;
            NroConta = _Row["nro_conta"] != DBNull.Value ? int.Parse(_Row["nro_conta"].ToString()) : 0;
            DigConta = _Row["dig_conta"] != DBNull.Value ? int.Parse(_Row["dig_conta"].ToString()) : 0;
            IdTipoCta = _Row["cod_tipo_cta"] != DBNull.Value ? int.Parse(_Row["cod_tipo_cta"].ToString()) : 0;
            CEI = _Row["cei"].ToString();
        }

        public RgFisicaJuridica(int _IdEmpr, int _IdRg, int _NroCPF, int _DigCPF, string _NroRg, string _DigRg, string _DtEmissao, string _OrgaoExpRg, string _InscrMunicipal, int _CGC, int _FilialCGC, int _DigCGC, string _InscEstadual, int _NroBanco, int _NroAgencia, int _DigAgencia, int _NroConta, int _DigConta, int _IdTipoCta, string _CEI) 
        {
	        IdEmpr = _IdEmpr;
	        IdRg = _IdRg;
	        NroCPF = _NroCPF;
	        DigCPF = _DigCPF;
	        NroRg = _NroRg;
	        DigRg = _DigRg;
	        DtEmissao = DateTime.Parse(_DtEmissao);
	        OrgaoExpRg = _OrgaoExpRg;
	        InscrMunicipal = _InscrMunicipal;
	        CGC = _CGC;
	        FilialCGC = _FilialCGC;
	        DigCGC = _DigCGC;
	        InscEstadual = _InscEstadual;
	        NroBanco = _NroBanco;
	        NroAgencia = _NroAgencia;
	        DigAgencia = _DigAgencia;
	        NroConta = _NroConta;
	        DigConta = _DigConta;
	        IdTipoCta = _IdTipoCta;
	        CEI = _CEI;
        }
    }
}
