using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteCodeFirst.Entities
{
    [Table("TB_OCUPACAO")]
    public class Ocupacao
    {
        [Key]
        public int? Id { get; set; }
        
        public string NomeOcupacao { get; set; }
    }
}