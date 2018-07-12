using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("rg_reg_geral")]
    public class RgRegGeral
    {
        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Registro Geral")]
        public int? cod_rg { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Razão Social")]
        public string razao_social { get; set; }

        [ForeignKey("RgTipoRg")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Tipo Registro Geral")]
        public string tipo_rg { get; set; }

        public RgTipoRg RgTipoRg { get; set; }

        [ForeignKey("RgStatus")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Status Registro Geral")]
        public int? cod_status { get; set; }

        public RgStatus RgStatus { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Data / Hora")]
        public DateTime? data_hora { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Usuário")]
        public string usuario { get; set; }

        [DisplayName("Nome Fantasia")]
        public string nome_fantasia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Optante Simples")]
        public string optante_simples { get; set; } 
    }
}
