using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("rg_natureza")]
    public class RgNatureza 
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Natureza")]
        public int? cod_natureza { get; set; }

        [DisplayName("Descrição Natureza")]
        public string descr_natureza { get; set; }
    }
}
