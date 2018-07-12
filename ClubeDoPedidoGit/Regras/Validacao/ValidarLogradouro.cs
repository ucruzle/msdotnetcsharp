using Comum.Auxiliares;

namespace Regras.Validacao
{
    public class ValidarLogradouro : RouleFactory<ValidarLogradouro>
    {
        public ValidarLogradouro() { }

        public string SetLogradouro(string logradouro)
        {
            Guard.ForNullOrEmptyDefaultMessage(logradouro, "Endereço");
            return TextoHelper.ToTitleCase(logradouro);
        }
    }
}
