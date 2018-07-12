using System;
using System.Collections.Generic;

namespace Dominio.Modelo
{
    public class Usuario
    {
        // Propriedades
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] Senha { get; set; }
        public int TipoUsuarioID { get; set; }
        public string Foto { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string CnpjCpf { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        // Relacionamentos
        public virtual ICollection<Endereco> ListaEndereco { get; set; }
        public virtual ICollection<PedidoPromocao> ListaPedidoPromocao { get; set; }

        // Construtor
        public Usuario()
        {
            ListaEndereco = new List<Endereco>();
            ListaPedidoPromocao = new List<PedidoPromocao>();
        }
    }
}
