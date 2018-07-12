using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{

    [Table("ge_grupo")]
    public class GeGrupo 
    {
        [Key]
        [DisplayName("Grupo")]
        public int? cod_grupo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Grupo")]
        public string descr_grupo { get; set; } 
    }
}
