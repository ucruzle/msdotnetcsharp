using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ct_nivel_5")]
    public class CtNivelCinco
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("CtNivelQuatro")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("CtNivelQuatro")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Plano Contábil")]
        public int? cod_plano_cont { get; set; }

        [Key]
        [Column(Order = 3)]
        [ForeignKey("CtNivelQuatro")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 01")]
        public int? cod_nivel1 { get; set; }

        [Key]
        [Column(Order = 4)]
        [ForeignKey("CtNivelQuatro")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 02")]
        public int? cod_nivel2 { get; set; }

        [Key]
        [Column(Order = 5)]
        [ForeignKey("CtNivelQuatro")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 03")]
        public int? cod_nivel3 { get; set; }

        [Key]
        [Column(Order = 6)]
        [ForeignKey("CtNivelQuatro")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 04")]
        public int? cod_nivel4 { get; set; }

        public CtNivelQuatro CtNivelQuatro { get; set; }

        [Key]
        [Column(Order = 7)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Nível 05")]
        public int? cod_nivel5 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 05")]
        public string descr_nivel5 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sequência Nível 05")]
        public int? sequ_nivel5 { get; set; }
    }
}
