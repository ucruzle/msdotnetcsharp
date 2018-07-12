using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ct_nivel_4")]
    public class CtNivelQuatro
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("CtNivelTres")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("CtNivelTres")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Plano Contábil")]
        public int? cod_plano_cont { get; set; }

        [Key]
        [Column(Order = 3)]
        [ForeignKey("CtNivelTres")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 01")]
        public int? cod_nivel1 { get; set; }

        [Key]
        [Column(Order = 4)]
        [ForeignKey("CtNivelTres")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 02")]
        public int? cod_nivel2 { get; set; }

        [Key]
        [Column(Order = 5)]
        [ForeignKey("CtNivelTres")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nível 03")]
        public int? cod_nivel3 { get; set; }

        public CtNivelTres CtNivelTres { get; set; }

        [Key]
        [Column(Order = 6)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Nível 04")]
        public int? cod_nivel4 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 04")]
        public string descr_nivel4 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sequência Nível 04")]
        public int? sequ_nivel4 { get; set; }
    }
}
