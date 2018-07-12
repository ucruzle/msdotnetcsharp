using System;
using Dominio.Modelo;

namespace Regras.Geral
{
    public class TokenRegras : RouleFactory<TokenRegras>
    {
        // Construtor
        public TokenRegras() { }

        // Regras
        public Token RegistrarToken(int idParceiro)
        {
            var token = new Token();

            token.CodigoToken = GerarNovoToken();
            token.ParceiroID = idParceiro;
            token.DataInclusao = DateTime.Now;

            return token;
        }

        public Guid GerarNovoToken()
        {
            var token = Guid.NewGuid();
            return token;
        }
    }
}
