using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("rg_tipo_rg")]
    public class RgTipoRg 
    {
        [Key]
        [DisplayName("Tipo Registro Geral")]
        public string tipo_rg { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição")]
        public string descr_tipo_rg { get; set; }
    }
}
