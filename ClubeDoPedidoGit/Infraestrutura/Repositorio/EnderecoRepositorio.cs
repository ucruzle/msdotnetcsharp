using System;
using System.Data.Entity;
using Comum.Mensagens;
using Dominio.Modelo;
using Infraestrutura.Dao;

namespace Infraestrutura.Repositorio
{
    public class EnderecoRepositorio
    {
        // Campos
        private readonly ContextoDb _contexto;

        // Construtor
        public EnderecoRepositorio(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Métodos
        public Endereco CadastrarEndereco(Endereco endereco)
        {
            return _contexto.EnderecoDb.Add(endereco);
        }

        public string AlterarEndereco(Endereco endereco)
        {
            endereco.DataAlteracao = DateTime.Now;
            _contexto.Entry(endereco).State = EntityState.Modified;
            return MensagensGlobal.EdicaoSucesso;
        }

    }
}
