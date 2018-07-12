using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_tmp_valor")]
    public class GeTmpValor 
    {
        [Key]
        [DisplayName("Usuário")]
        public string usuario { get; set; }

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
