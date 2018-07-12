using Comum.Auxiliares;

namespace Regras.Validacao
{
    public class ValidarId : RouleFactory<ValidarId>
    {
        public ValidarId() { }

        public int SetId(string nomeCampo, int valorCampo)
        {
            Guard.ForValidId(nomeCampo, valorCampo);
            return valorCampo;
        }
    }
}
