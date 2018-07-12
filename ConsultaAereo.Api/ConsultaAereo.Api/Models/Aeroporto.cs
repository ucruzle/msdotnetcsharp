using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaAereo.Api.Models
{
    public class Aeroporto
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string NomeCompleto { get; set; }

        public Aeroporto()
        {

        }
    }
}