using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ct_nivel_2")]
    public class CtNivelDois
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("CtNivelUm")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("CtNivelUm")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Plano Contábil")]
        public int? cod_plano_cont { get; set; }

        [Key]
        [Column(Order = 3)]
        [ForeignKey("CtNivelUm")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 01")]
        public int? cod_nivel1 { get; set; }

        public CtNivelUm CtNivelUm { get; set; }

        [Key]
        [Column(Order = 4)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Nível 02")]
        public int? cod_nivel2 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 02")]
        public string descr_nivel2 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sequência Nível 02")]
        public int? sequ_nivel2 { get; set; }
    }
}
