using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_sessao_usuario")]
    public class GeSessaoUsuario 
    {
        [Key]
        [DisplayName("Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("ID Sessão")]
        public string IdSession { get; set; } 
        
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Data / Hora Sessão")]
        public DateTime? DateTimeSession { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nome Dispositivo")]
        public string MachineName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("IP Dispositivo")]
        public string MachineIP { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nº Logon")]
        public int? LogonNumber { get; set; } 
    }
}
