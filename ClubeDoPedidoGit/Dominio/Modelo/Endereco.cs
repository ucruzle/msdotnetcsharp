using System;
using System.Collections.Generic;

namespace Dominio.Modelo
{
    public class Endereco
    {
        // Propriedades
        public int EnderecoID { get; set; }
        public int TipoEnderecoID { get; set; }
        public  string Logradouro { get; set; }
        public  string Complemento { get; set; }
        public  string Numero { get; set; }
        public  string Bairro { get; set; }
        public  string Cidade { get; set; }
        public  string Uf { get; set; }
        public  string Cep { get; set; }
        public string PontoReferencia { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        // Relacionamentos
        public virtual TipoEndereco TipoEndereco { get; set; }
        public virtual ICollection<Parceiro> ListaParceiro { get; set; }
        public virtual ICollection<Usuario> ListaUsuario { get; set; }

        // Construtor
        public Endereco()
        {
            ListaParceiro = new List<Parceiro>();
            ListaUsuario = new List<Usuario>();
        }
    }
}
