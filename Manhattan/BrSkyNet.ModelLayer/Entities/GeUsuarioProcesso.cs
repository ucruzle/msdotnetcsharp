using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_usuario_processo")]
    public class GeUsuarioProcesso 
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
        [ForeignKey("GeUsuario")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Usuário")]
        public string usuario { get; set; }

        public GeUsuario GeUsuario { get; set; }

        [Key]
        [Column(Order = 3)]
        [ForeignKey("GeProcesso")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Processo")]
        public int? cod_proc { get; set; }

        public GeProcesso GeProcesso { get; set; }
    }
}
