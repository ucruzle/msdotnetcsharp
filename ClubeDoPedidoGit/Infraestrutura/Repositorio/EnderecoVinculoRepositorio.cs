using Dominio.Modelo;
using Infraestrutura.Dao;

namespace Infraestrutura.Repositorio
{
    public class EnderecoVinculoRepositorio
    {
        // Campo
        private readonly ContextoDb _contexto;

        // Construtor
        public EnderecoVinculoRepositorio(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Métodos
        public EnderecoVinculo CadastrarEnderecoVinculo(EnderecoVinculo enderecoVinculo)
        {
            return _contexto.EnderecoVinculoDb.Add(enderecoVinculo);
        }
    }
}
