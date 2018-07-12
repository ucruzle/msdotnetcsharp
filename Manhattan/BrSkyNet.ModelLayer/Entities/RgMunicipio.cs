using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("rg_municipio")]
    public class RgMunicipio 
    {
        [Key]
        [DisplayName("Município")]
        public int? cod_municipio { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Município")]
        public string municipio { get; set; }

        [ForeignKey("RgEstado")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("UF")]
        public string sigla_estado { get; set; }

        public RgEstado RgEstado { get; set; }
    }
}
