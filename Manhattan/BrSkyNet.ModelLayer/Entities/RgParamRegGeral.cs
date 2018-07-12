using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("rg_param_reg_geral")]
    public class RgParamRegGeral
    {
        [Key]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        [ForeignKey("RgNaturezaFunc")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("N° Natureza Funcionário")]
        public int? cod_nat_func { get; set; }

        public RgNatureza RgNaturezaFunc { get; set; }

        [ForeignKey("RgNaturezaLider")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("N° Natureza Funcionário Lider")]
        public int? cod_nat_func_lider { get; set; }

        public RgNatureza RgNaturezaLider { get; set; }

        [ForeignKey("RgNaturezaCliente")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("N° Natureza Cliente")]
        public int? cod_nat_cliente { get; set; }

        public RgNatureza RgNaturezaCliente { get; set; }

        [ForeignKey("RgNaturezaFornecedor")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("N° Natureza Fornecedor")]
        public int? cod_nat_fornec { get; set; }

        public RgNatureza RgNaturezaFornecedor { get; set; }

        [ForeignKey("RgNaturezaBanco")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("N° Natureza Banco")]
        public int? cod_nat_banco { get; set; }

        public RgNatureza RgNaturezaBanco { get; set; }

        [ForeignKey("RgStatusAtivo")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Status Ativo")]
        public int? cod_status_ativo { get; set; }

        public RgStatus RgStatusAtivo { get; set; }

        [ForeignKey("RgStatusInativo")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Status Inativo")]
        public int? cod_status_inativo { get; set; }

        public RgStatus RgStatusInativo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Permite CGC / CPF Zerado")]
        public string permite_cgc_cpf_zerado { get; set; }

        [ForeignKey("RgNaturezaTomadora")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("N° Natureza Tomadora")]
        public int? cod_nat_tomadora { get; set; }

        public RgNatureza RgNaturezaTomadora { get; set; }

        [ForeignKey("RgNaturezaResp")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("N° Natureza Responsável")]
        public int? cod_nat_resp { get; set; }

        public RgNatureza RgNaturezaResp { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Permite CGC / CPF Duplicado")]
        public string permite_cgc_cpf_duplic { get; set; }
    }
}
