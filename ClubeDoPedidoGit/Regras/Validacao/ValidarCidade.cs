using Comum.Auxiliares;

namespace Regras.Validacao
{
    public class ValidarCidade : RouleFactory<ValidarCidade>
    {
        public ValidarCidade() { }

        public string SetCidade(string cidade)
        {
            Guard.ForNullOrEmptyDefaultMessage(cidade, "Cidade");
            return TextoHelper.ToTitleCase(cidade);
        }
    }
}
