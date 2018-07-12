using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{

    [Table("rg_endereco")]
    public class RgEndereco
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("RgRegGeral")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("RgRegGeral")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Registro Geral")]
        public int? cod_rg { get; set; }

        public RgRegGeral RgRegGeral { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Endereço")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("N° Endereço")]
        public string nro_endereco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Bairro")]
        public string bairro { get; set; }


        [DisplayName("Complemento")]
        public string complemento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("CEP")]
        public int? cep { get; set; }


        [ForeignKey("RgMunicipio")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Município")]
        public int? cod_municipio { get; set; }

        public RgMunicipio RgMunicipio { get; set; }


        [DisplayName("Caixa Postal")]
        public int? cx_postal { get; set; }

        [DisplayName("Home Page")]
        public string home_page { get; set; }

        [DisplayName("E-Mail")]
        public string e_mail { get; set; }
    }
}
