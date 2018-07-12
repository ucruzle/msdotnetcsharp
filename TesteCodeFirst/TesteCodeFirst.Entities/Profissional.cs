using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteCodeFirst.Entities
{
    [Table("TB_PROFISSIONAL")]
    public class Profissional
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Nome do Profissional")]
        public string NmProfissional { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [ForeignKey("Ocupacao")]
        [DisplayName("Ocupação")]
        public int? CdOcupacao { get; set; }

        public Ocupacao Ocupacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*" +
            @"@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$",
            ErrorMessage = "Formato de E-mail inválido.")]
        [DisplayName("E-mail para Contato")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Telefone para Contato")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Range(10, 9999.99,
            ErrorMessage = "O Valor Hora deve estar entre " +
                           "10,00 e 9999,99.")]
        [DataType(DataType.Currency,
            ErrorMessage = "Valor inválido.")]
        [DisplayName("Valor Hora")]
        public decimal? VlHora { get; set; }

        [DisplayName("Observação")]
        public string DsObservacao { get; set; }
    }
}