using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_usuario")]
    public class GeUsuario 
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Usuário")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nome")]
        public string nome { get; set; }

        [ForeignKey("RgRegGeral")]
        [Column("cod_empr", Order = 1)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Empresa")]
        public int? cod_empr { get; set; }

        [ForeignKey("RgRegGeral")]
        [Column("cod_rg", Order = 2)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Registro Geral")]
        public int? cod_rg { get; set; }

        public RgRegGeral RgRegGeral { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Status DBA")]
        public string status_dba { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Data Cadastro")]
        public DateTime? dt_cadastro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Senha")]
        public string senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Ramal")]
        public string ramal { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Ativo")]
        public string ativo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Usuário Inclusão")]
        public string usuario_incl { get; set; } 
    }
}
