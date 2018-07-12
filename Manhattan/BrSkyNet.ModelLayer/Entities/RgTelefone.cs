using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("rg_telefone")]
    public class RgTelefone 
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

        [Key]
        [Column(Order = 3)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Seguência")]
        public int? seq_tel { get; set; }

        [ForeignKey("RgTipoFone")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Tipo Telefone")]
        public int? cod_tipo_fone { get; set; }

        public RgTipoFone RgTipoFone { get; set; }

        [DisplayName("(DDD) Telefone")]
        public string ddd_fone { get; set; }

        [DisplayName("Nº Telefone")]
        public string numero_fone { get; set; }

        [DisplayName("Contato")]
        public string contato { get; set; }

        [DisplayName("E-Mail")]
        public string e_mail { get; set; }

        [DisplayName("Telefone Principal")]
        public string principal { get; set; } 
    }
}
