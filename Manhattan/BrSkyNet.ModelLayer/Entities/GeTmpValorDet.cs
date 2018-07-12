using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_tmp_valor_det")]
    public class GeTmpValorDet 
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("GeUsuario")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Usuario")]
        public string usuario { get; set; }

        public GeUsuario GeUsuario { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("ID")]
        public int? codigo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Valor")]
        public decimal? valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Valor %")]
        public decimal? perc_valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Status")]
        public string status { get; set; } 
    }
}
