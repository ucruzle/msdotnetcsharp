using Comum.Auxiliares;

namespace Regras.Validacao
{
    public class ValidarNumero : RouleFactory<ValidarNumero>
    {
        public ValidarNumero() { }

        public string SetNumero(string numero)
        {
            Guard.ForNullOrEmptyDefaultMessage(numero, "Número");
            return numero;
        }
    }
}
