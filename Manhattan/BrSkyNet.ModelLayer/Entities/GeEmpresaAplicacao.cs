using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_empresa_aplicacao")]
    public class GeEmpresaAplicacao
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
        [ForeignKey("GeAplicacao")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Aplicação")]
        public int? cod_aplic { get; set; }

        public GeAplicacao GeAplicacao { get; set; }
    }
}
