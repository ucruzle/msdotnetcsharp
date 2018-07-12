using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_tipo_processo")]
    public class GeTipoProcesso 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Tipo Processo")]
        public int? cod_tipo_proc { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Tipo Processo")]
        public string descr_tipo_proc { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Sequência Tipo Processo")]
        public int? sequ_tipo_proc { get; set; }
    }
}
