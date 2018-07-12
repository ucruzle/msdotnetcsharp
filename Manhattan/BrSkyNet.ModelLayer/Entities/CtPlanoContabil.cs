using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ct_plano_contabil")]
    public class CtPlanoContabil
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Plano Contábil")]
        public int? cod_plano_cont { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Plano")]
        public string descr_plano_cont { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Qtd.Níeis")]
        public int? qtde_nivel { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 01")]
        public string descr_nivel1 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 02")]
        public string descr_nivel2 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 03")]
        public string descr_nivel3 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 04")]
        public string descr_nivel4 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 05")]
        public string descr_nivel5 { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Nível 06")]
        public string descr_nivel6 { get; set; }
    }
}
