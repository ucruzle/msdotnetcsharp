using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("rg_fisica_juridica")]
    public class RgFisicaJuridica
    {
        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Registro Geral")]
        public int? cod_rg { get; set; }

        [DisplayName("N° CPF")]
        public int? num_cpf { get; set; }

        [DisplayName("Dígito CPF")]
        public int? dig_cpf { get; set; }

        [DisplayName("N° Registro")]
        public string num_rg { get; set; }

        [DisplayName("Dígito Registro")]
        public string dig_rg { get; set; }

        [DisplayName("Data Emissão Registro")]
        public DateTime? dt_emissao_rg { get; set; }

        [DisplayName("Orgão Expeditor Registro")]
        public string orgao_exp_rg { get; set; }

        [DisplayName("Inscrição Municipal")]
        public string insc_municipal { get; set; }

        [DisplayName("N° CGC")]
        public int? cgc { get; set; }

        [DisplayName("N° Filial CGC")]
        public int? filial_cgc { get; set; }

        [DisplayName("Dígito CGC")]
        public int? dig_cgc { get; set; }

        [DisplayName("Inscrição Estadual")]
        public string insc_estadual { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("N° Banco")]
        public int? nro_banco { get; set; }

        [DisplayName("N° Agência")]
        public int? nro_agencia { get; set; }

        [DisplayName("Dígito Agência")]
        public int? dig_agencia { get; set; }

        [DisplayName("N° Conta")]
        public int? nro_conta { get; set; }

        [DisplayName("Dígito Conta")]
        public int? dig_conta { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("N° Tipo Conta")]
        public int? cod_tipo_cta { get; set; }

        [DisplayName("CEI")]
        public string cei { get; set; }
    }
}
