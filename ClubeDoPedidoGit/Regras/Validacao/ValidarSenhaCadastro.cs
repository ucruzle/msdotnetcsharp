using Comum.Auxiliares;
using Comum.Mensagens;

namespace Regras.Validacao
{
    public class ValidarSenhaCadastro : RouleFactory<ValidarSenhaCadastro>
    {
        public ValidarSenhaCadastro() { }

        public byte[] SetSenhaCadastro(string senha, string senhaConfirmacao)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            Guard.ForNullOrEmptyDefaultMessage(senhaConfirmacao, MensagensValidacao.ConfirmacaoSenha);
            Guard.StringLength("Senha", senha, 6, 20);
            Guard.AreEqual(senha, senhaConfirmacao, MensagensValidacao.ComparacaoSenha);
            return Criptografia.CriptografarSenha(senha);
        }
    }
}
