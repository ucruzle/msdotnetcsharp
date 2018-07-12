using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_aplicacao")]
    public class GeAplicacao
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Aplicação")]
        public int? cod_aplic { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Aplicação")]
        public string descr_aplic { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sigla Aplicação")]
        public string sigla_aplic { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sequência Aplicação")]
        public int? sequ_aplic { get; set; }

        [DisplayName("Ativo")]
        public string ativa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Formulário Aplicação")]
        public string form_aplic { get; set; }
    }
}
