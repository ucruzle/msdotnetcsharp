using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaAereo.Api.Models
{
    public class PassagemAerea
    {
        public int Id { get; set; }
        public Aeroporto Origem { get; set; }
        public Aeroporto Destino { get; set; }
        public DateTime DataIda { get; set; }
        public DateTime? DataVolta { get; set; }
        public int QuantidadePax { get; set; }

        public PassagemAerea()
        {
            this.DataIda = DateTime.Now;
        }
    }
}