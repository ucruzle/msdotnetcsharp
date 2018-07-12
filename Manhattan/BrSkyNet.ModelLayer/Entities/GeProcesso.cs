using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_processo")]
    public class GeProcesso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Processo")]
        public int? cod_proc { get; set; }

        public string descr_proc { get; set; }

        [ForeignKey("GeTipoProcesso")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Tipo Processo")]
        public int? cod_tipo_proc { get; set; }

        public GeTipoProcesso GeTipoProcesso { get; set; }

        [ForeignKey("GeAplicacao")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Aplicação")]
        public int? cod_aplic { get; set; }

        public GeAplicacao GeAplicacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Ativo")]
        public string ativo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Formulário")]
        public string form { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sequência do Processo")]
        public int? sequ_proc { get; set; }
    }
}
