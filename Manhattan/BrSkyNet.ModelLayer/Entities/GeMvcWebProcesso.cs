using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_mvc_web_processo")]
    public class GeMvcWebProcesso 
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Processo")]
        public int? cod_proc { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Processo")]
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
        [DisplayName("Sequência Processo")]
        public int? sequ_proc { get; set; }

        [DisplayName("Título do Processo")]
        public string title { get; set; }

        [DisplayName("Controle do Processo")]
        public string controller { get; set; }

        [DisplayName("Ação do Processo")]
        public string action { get; set; }

        [DisplayName("Local da Imagem do Processo")]
        public string imageUrl { get; set; }

        [DisplayName("Descrição")]
        public string description { get; set; }
    }
}
