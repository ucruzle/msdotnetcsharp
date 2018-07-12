using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("rg_reg_geral_natureza")]
    public class RgRegGeralNatureza
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
        [ForeignKey("RgNatureza")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Natureza")]
        
        public int? cod_natureza { get; set; }

        public RgNatureza RgNatureza { get; set; }

        [ForeignKey("RgStatus")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Status Natureza")]
        public int? cod_status_nat_rg { get; set; }

        public RgStatus RgStatus { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Data / Hora")]
        public DateTime? data_hora { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Usuário")]
        public string usuario { get; set; }
    }
}
