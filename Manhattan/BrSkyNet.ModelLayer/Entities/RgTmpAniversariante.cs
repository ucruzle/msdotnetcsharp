using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("rg_tmp_aniversariante")]
    public class RgTmpAniversariante 
    {
        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Usuário")]
        public string usuario { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("RG")]
        public int? cod_rg { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Empresa")]
        public string descr_empr { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Dia / Mês Inicial")]
        public string dia_mes_inicial { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Dia / Mês Final")]
        public string dia_mes_final { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Data Nascimento")]
        public DateTime? dt_nascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("E-Mail")]
        public string e_mail { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Dia Aniversário")]
        public int? dia_aniv { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Mês Aniversário")]
        public int? mes_aniv { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Descrição Mês Aniversário")]
        public string descr_mes_aniv { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Telefone")]
        public string telefone { get; set; } 
    }
}
