using Comum.Auxiliares;

namespace Regras.Validacao
{
    public class ValidarSenha : RouleFactory<ValidarSenha>
    {
        public ValidarSenha() { }

        public byte[] SetSenha(string senha)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            Guard.StringLength("Senha", senha, 6, 20);
            return Criptografia.CriptografarSenha(senha);
        }
    }
}
