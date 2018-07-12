using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_empresa_consol")]
    public class GeEmpresaConsol
    {
        [Key]
        [DisplayName("Empresa Consolidada")]
        public int? cod_empr_consol { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição")]
        public string descr_empr_consol { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Ativo")]
        public string ativa { get; set; } 
    }
}
