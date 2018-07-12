using Comum.Auxiliares;

namespace Regras.Validacao
{
    public class ValidarUF : RouleFactory<ValidarUF>
    {
        public ValidarUF() { }

        public string SetUF(string uf)
        {
            Guard.ForNullOrEmptyDefaultMessage(uf, "Estado");
            return TextoHelper.ToTitleCase(uf);
        }
    }
}
