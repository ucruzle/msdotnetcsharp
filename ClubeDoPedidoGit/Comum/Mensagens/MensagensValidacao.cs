namespace Comum.Mensagens
{
    public static class MensagensValidacao
    {
        #region Mensagens obrigatoriedade
       
        private const string _obrigatorioCelular = "Celular Obrigatório";
        private const string _obrigatorioTelefone = "Telefone Obrigatório";
        private const string _obrigatorioEmail = "E-mail Obrigatório";
        private const string _obrigatorioNomeUsuario = "Nome Usuário Obrigatório";
        private const string _obrigatorioCep = "CEP é obrigatório!";


        public static string ObrigatorioCelular { get { return _obrigatorioCelular; } }
        public static string ObrigatorioTelefone { get { return _obrigatorioTelefone; } }
        public static string ObrigatorioEmail { get { return _obrigatorioEmail; } }
        public static string ObrigatorioNomeUsuario { get { return _obrigatorioNomeUsuario; } }
        public static string ObrigatorioCep { get { return _obrigatorioCep; } }

        #endregion

        #region Mensagens Senha

        private const string _confirmacaoSenha = "Confirmação de Senha";
        private const string _comparacaoSenha = "As senhas não conferem!";

        public static string ConfirmacaoSenha { get { return _confirmacaoSenha; } }
        public static string ComparacaoSenha { get { return _comparacaoSenha; } }

        #endregion

    }
}
