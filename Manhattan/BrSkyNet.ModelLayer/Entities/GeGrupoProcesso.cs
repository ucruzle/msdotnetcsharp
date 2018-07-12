using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{

    [Table("ge_grupo_processo")]
    public class GeGrupoProcesso
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("GeEmpresa")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        public GeEmpresa GeEmpresa { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("GeGrupo")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Grupo")]
        public int? cod_grupo { get; set; }

        public GeGrupo GeGrupo { get; set; }

        [Key]
        [Column(Order = 3)]
        [ForeignKey("GeProcesso")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Processo")]
        public int? cod_proc { get; set; }

        public GeProcesso GeProcesso { get; set; }
    }
}
