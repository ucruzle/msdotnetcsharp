using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ct_nivel_1")]
    public class CtNivelUm
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("GeEmpresa")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }
        public GeEmpresa GeEmpresa { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("CtPlanoContabil")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Plano Contábil")]
        public int? cod_plano_cont { get; set; }
        public CtPlanoContabil CtPlanoContabil { get; set; }

        [Key]
        [Column(Order = 3)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Nível 01")]
        public int? cod_nivel1 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 01")]
        public string descr_nivel1 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sequência Nível 01")]
        public int? sequ_nivel1 { get; set; }
    }
}
