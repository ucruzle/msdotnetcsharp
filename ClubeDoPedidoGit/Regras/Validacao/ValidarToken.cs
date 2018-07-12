using System;
using Comum.Auxiliares;

namespace Regras.Validacao
{
    public class ValidarToken : RouleFactory<ValidarToken>
    {
        public ValidarToken() { }

        public Guid SetToken(Guid token)
        {
            Guard.ForValidId(token, "Token");
            return token;
        }
    }
}
