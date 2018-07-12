using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_empresa")]
    public class GeEmpresa 
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição")]
        public string descr_empr { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Redentora")]
        public string descr_empr_red { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa Consolidada")]
        public int? cod_empr_consol { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Ativo")]
        public string ativa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Registro Regal")]
        public int? cod_rg { get; set; }

        [DisplayName("Local")]
        public string host { get; set; }

        [DisplayName("Porta")]
        public int? port { get; set; }

        [DisplayName("Nome Usuário")]
        public string username { get; set; }

        [DisplayName("Senha Acesso")]
        public string senha { get; set; }

        [DisplayName("E-Mail")]
        public string e_mail { get; set; }

        [DisplayName("Endereço Banco de Dados")]
        public string endereco_banco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Versão")]
        public string versao { get; set; } 
    }
}
