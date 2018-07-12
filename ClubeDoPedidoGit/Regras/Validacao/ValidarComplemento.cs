using Comum.Auxiliares;

namespace Regras.Validacao
{
    public class ValidarComplemento  : RouleFactory<ValidarComplemento>
    {
        public ValidarComplemento() { }

        public string SetComplemento(string complemento)
        {
            if (string.IsNullOrEmpty(complemento))
                complemento = "";
            return TextoHelper.ToTitleCase(complemento);
        }
    }
}
