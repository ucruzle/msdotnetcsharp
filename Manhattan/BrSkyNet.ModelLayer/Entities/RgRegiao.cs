using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{

    [Table("rg_regiao")]
    public class RgRegiao 
    {
        [Key]
        [DisplayName("Sigla Região")]
        public string sigla_regiao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Região")]
        public string descr_regiao { get; set; } 
    }
}
