using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("fi_nro_banco")]
    public class FiNroBanco
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("N° Banco")]
        public int? nro_banco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição N° Banco")]
        public string descr_nro_banco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição N° Banco Reduzido")]
        public string descr_nro_banco_red { get; set; }
    }
}
