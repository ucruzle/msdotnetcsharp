using System;

namespace TesteCodeFirst.Entities
{
    public class ResumoDadosProfissional
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string NmProfissional { get; set; }
        public string DsOcupacao { get; set; }
        public decimal VlHora { get; set; }

        public decimal VlBase168Horas
        {
            get
            {
                return VlHora * 168;
            }
        }
    }
}