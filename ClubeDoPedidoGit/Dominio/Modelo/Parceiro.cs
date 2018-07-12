using System;
using System.Collections.Generic;

namespace Dominio.Modelo
{
    public class Parceiro
    {
        // Propriedades
        public int ParceiroID { get; set; }
        public string NomeFantasia { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public byte[] Senha { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int RamoAtividadeID { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        // Relacionamentos
        public virtual PlanoContratado PlanoContratado { get; set; }
        //public virtual ConfiguracaoParceiro ConfiguracaoParceiro { get; set; }
        //public virtual Token Token { get; set; }
        public virtual RamoAtividade RamoAtividade { get; set; }
        public virtual ICollection<Endereco> ListaEndereco { get; set; }
        public virtual ICollection<Produto> ListaProduto { get; set; }
        public virtual ICollection<Promocao> ListaPromocao { get; set; }

        // Contrutor
        public Parceiro()
        {
            ListaEndereco = new List<Endereco>();
            ListaProduto = new List<Produto>();
            ListaPromocao = new List<Promocao>();
        }
    }
}
