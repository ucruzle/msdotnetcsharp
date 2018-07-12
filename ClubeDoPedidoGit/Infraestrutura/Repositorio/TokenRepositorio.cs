using Dominio.Modelo;
using Infraestrutura.Dao;

namespace Infraestrutura.Repositorio
{
    public class TokenRepositorio
    {
        // Campos
        private readonly ContextoDb _contexto;

        // Construtor
        public TokenRepositorio(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Métodos
        public Token RegistrarToken(Token token)
        {
            return _contexto.TokenDb.Add(token);
        }
    }
}
