using System;
using Comum.Mensagens;
using Dominio.ObjetoValor;

namespace Regras.Validacao
{
    public class ValidarEmail : RouleFactory<ValidarEmail>
    {
        public ValidarEmail() { }

        public string SetEmail(string email)
        {
            if (email == null)
                throw new Exception(MensagensValidacao.ObrigatorioEmail);
            var resultado = new Email(email);
            return resultado.Endereco;
        }
    }
}
