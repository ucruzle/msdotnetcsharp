using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ct_nivel_6")]
    public class CtNivelSeis
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("CtNivelCinco")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("CtNivelCinco")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Plano Contábil")]
        public int? cod_plano_cont { get; set; }

        [Key]
        [Column(Order = 3)]
        [ForeignKey("CtNivelCinco")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 01")]
        public int? cod_nivel1 { get; set; }

        [Key]
        [Column(Order = 4)]
        [ForeignKey("CtNivelCinco")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 02")]
        public int? cod_nivel2 { get; set; }

        [Key]
        [Column(Order = 5)]
        [ForeignKey("CtNivelCinco")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 03")]
        public int? cod_nivel3 { get; set; }

        [Key]
        [Column(Order = 6)]
        [ForeignKey("CtNivelCinco")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 04")]
        public int? cod_nivel4 { get; set; }

        [Key]
        [Column(Order = 7)]
        [ForeignKey("CtNivelCinco")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 05")]
        public int? cod_nivel5 { get; set; }

        public CtNivelCinco CtNivelCinco { get; set; }

        [Key]
        [Column(Order = 8)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Nível 06")]
        public int? cod_nivel6 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 06")]
        public string descr_nivel6 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sequência Nível 06")]
        public int? sequ_nivel6 { get; set; }
    }
}
