using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ct_nivel_3")]
    public class CtNivelTres
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("CtNivelDois")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("CtNivelDois")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Plano Contábil")]
        public int? cod_plano_cont { get; set; }

        [Key]
        [Column(Order = 3)]
        [ForeignKey("CtNivelDois")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 01")]
        public int? cod_nivel1 { get; set; }

        [Key]
        [Column(Order = 4)]
        [ForeignKey("CtNivelDois")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 02")]
        public int? cod_nivel2 { get; set; }

        public CtNivelDois CtNivelDois { get; set; }

        [Key]
        [Column(Order = 5)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Nível 03")]
        public int? cod_nivel3 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 03")]
        public string descr_nivel3 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sequência Nível 03")]
        public int? sequ_nivel3 { get; set; }
    }
}
