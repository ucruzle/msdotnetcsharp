using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("rg_estado")]
    public class RgEstado
    {
        [Key]
        [DisplayName("UF")]
        public string sigla_estado { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Estado")]
        public string descr_estado { get; set; }

        [ForeignKey("RgRegiao")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Região")]
        public string sigla_regiao { get; set; }

        public RgRegiao RgRegiao { get; set; }
    }
}
