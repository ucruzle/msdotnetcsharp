namespace Comum.Mensagens
{
    public static class MensagensGlobal
    {

        #region mensagens de manipulação do banco

        // Geral
        private const string _inclusaoSucesso = "registro incluido com sucesso.";
        private const string _edicaoSucesso = "registro alterado com sucesso.";
        private const string _exlusaoSucesso = "registro excluído com sucesso.";
        private const string _desejaExcluirRegistro = "Deseja realmente excluir o registro?.";

        public static string InclusaoSucesso { get { return _inclusaoSucesso; } }
        public static string EdicaoSucesso { get { return _edicaoSucesso; } }
        public static string ExlusaoSucesso { get { return _exlusaoSucesso; } }
        public static string DesejaExcluirRegistro { get { return _desejaExcluirRegistro; } }


        // Usuário
        private const string _usuarioEmailDuplicado = "Já existe um usuário cadastrado para esse e-mail";
        private const string _usuarioDesativado = "Usuário desativado";

        public static string UsuarioEmailDuplicado{ get { return _usuarioEmailDuplicado; } }
        public static string UsuarioDesativado { get { return _usuarioDesativado; } }


        // Parceiro
        private const string _parceiroEmailDuplicado = "Já existe uma conta vinculada para esse e-mail";

        public static string ParceiroEmailDuplicado { get { return _parceiroEmailDuplicado; } }


        #endregion

    }
}


