using Comum.Auxiliares;

namespace Regras.Validacao
{
    public class ValidarBairro : RouleFactory<ValidarBairro>
    {
        public ValidarBairro() { }

        public string SetBairro(string bairro)
        {
            Guard.ForNullOrEmptyDefaultMessage(bairro, "Bairro");
            return TextoHelper.ToTitleCase(bairro);
        }
    }
}
