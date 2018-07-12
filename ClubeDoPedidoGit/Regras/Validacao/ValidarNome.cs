using Comum.Auxiliares;
using Comum.Mensagens;

namespace Regras.Validacao
{
    public class ValidarNome : RouleFactory<ValidarNome>
    {
        public ValidarNome() { }

        public string SetNome(string nome)
        {
            Guard.ForNullOrEmptyDefaultMessage(nome, MensagensValidacao.ObrigatorioNomeUsuario);
            return nome;
        }
    }
}
