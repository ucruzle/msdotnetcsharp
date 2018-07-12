
namespace BrSoftNet.Library.Messages
{
    public static class FormsMessages
    {
        #region ...::: Private Constants :::...

        #region ...::: Registro Geral :::...

        #region ...::: Infrastruture :::..

        public static string _TituloArquivoLogErro = "Arquivo Log de Erro";
        public static string _MensagemArqLogErro = "Existem processos executados com falha, criado arquivo log de erros!";
        
        #endregion

        #region ...::: Formulário Principal (Dashboard) :::...

        public static string _DataLogonUsuario = "Usuário - {0}";
        public static string _DataLogonUsuarioEmpresa = "Usuário - {0} | Empresa - {1}";
        public static string _CriaNovaSessaoDeUsuarioMensagemInformacao = "Existe uma sessão aberta para este usuário, deseja encerrar a sessão atual?";
        public static string _CriaNovaSessaoDeUsuarioMensagemTitulo = "Sessão de Usuário";
        public static string _EscolheProcessoPorTipoMensagem = "Usuário: {0} não autorizado para execução deste processo.";
        public static string _EscolheProcessoPorTipoTitulo = "Acesso não Autorizado";
        public static string _CodigoDeAcessoRapidoDoMenuMensagem = "Nº inválido! Entre com um nº de processo válido";
        public static string _CodigoDeAcessoRapidoDoMenuTitulo = "Acesso não Autorizado";
        public static string _CodigoDeAcessoRapidoDoMenuSomenteNumero = "Nº processo inválido !";
        public static string _CodigoDeAcessoRapidoDoMenuMenorZero = "Nº processo menor que 0 (zero) não permitido !";

        #endregion

        #region ...::: Processo Gestão de Estados :::...

        private const string _TituloProcessoEstado = "Processo Gestão de Estados - {0}";
        private const string _TituloProcessoEstadoAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoEstadoInclusao = "Inclusão";
        private const string _TituloProcessoAcaoEstadoAlteracao = "Alteração";
        private const string _TituloProcessoAcaoEstadoExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Login :::...

        private const string _NroTentativasLogin = "N° de tentativas de login {0} de 3, para o sistema ser encerrado!";
        private const string _NroTentativasLogoff = "N° de tentativas de login {0} de 3 excedidas, o sistema será encerrado!";
        private const string _LoginDoSistema = "Login do Sistema";

        #endregion

        #region ...::: Processo Gestão de Municípios :::...

        private const string _TituloProcessoMunicipio = "Processo Gestão de Municipios - {0}";
        private const string _TituloProcessoMunicipioAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoMunicipioInclusao = "Inclusão";
        private const string _TituloProcessoAcaoMunicipioAlteracao = "Alteração";
        private const string _TituloProcessoAcaoMunicipioExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Natureza :::...

        private const string _TituloProcessoNatureza = "Processo Gestão de Naturezas - {0}";
        private const string _TituloProcessoNaturezaAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoNaturezaInclusao = "Inclusão";
        private const string _TituloProcessoAcaoNaturezaAlteracao = "Alteração";
        private const string _TituloProcessoAcaoNaturezaExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Parametros Rg :::...

        private const string _TituloProcessoParametroRg = "Processo Gestão de Parametros de Registros Gerais - {0}";
        private const string _TituloProcessoParametroRgAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoParametroRgInclusao = "Inclusão";
        private const string _TituloProcessoAcaoParametroRgAlteracao = "Alteração";
        private const string _TituloProcessoAcaoParametroRgExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Região :::...

        private const string _TituloProcessoRegiao = "Processo Gestão de Regiões - {0}";
        private const string _TituloProcessoRegiaoAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoRegiaoInclusao = "Inclusão";
        private const string _TituloProcessoAcaoRegiaoAlteracao = "Alteração";
        private const string _TituloProcessoAcaoRegiaoExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Reg Geral :::...

        private const string _TituloProcessoRegGeral = "Processo Gestão de Registros Gerais - {0}";
        private const string _TituloProcessoRegGeralAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoRegGeralInclusao = "Inclusão";
        private const string _TituloProcessoAcaoRegGeralAlteracao = "Alteração";
        private const string _TituloProcessoAcaoRegGeralExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Status :::...

        private const string _TituloProcessoStatus = "Processo Gestão de Status - {0}";
        private const string _TituloProcessoStatusAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoStatusInclusao = "Inclusão";
        private const string _TituloProcessoAcaoStatusAlteracao = "Alteração";
        private const string _TituloProcessoAcaoStatusExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Tipo Fone :::...

        private const string _TituloProcessoTipoFone = "Processo Gestão de Tipos de Telefones - {0}";
        private const string _TituloProcessoTipoFoneAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoTipoFoneInclusao = "Inclusão";
        private const string _TituloProcessoAcaoTipoFoneAlteracao = "Alteração";
        private const string _TituloProcessoAcaoTipoFoneExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Tipo Rg :::...

        private const string _TituloProcessoTipoRg = "Processo Gestão de Tipos de Registros - {0}";
        private const string _TituloProcessoTipoRgAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoTipoRgInclusao = "Inclusão";
        private const string _TituloProcessoAcaoTipoRgAlteracao = "Alteração";
        private const string _TituloProcessoAcaoTipoRgExclusao = "Exclusão";

        #endregion

        #endregion

        #region ...::: Gerenciador :::...

        #region ...::: Processo Gestão de Aplicação :::...

        private const string _TituloProcessoAplicacao = "Processo Gestão de Aplicações - {0}";
        private const string _TituloProcessoAplicacaoAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoAplicacaoInclusao = "Inclusão";
        private const string _TituloProcessoAcaoAplicacaoAlteracao = "Alteração";
        private const string _TituloProcessoAcaoAplicacaoExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Empresas :::...

        private const string _TituloProcessoEmpresa = "Processo Gestão de Empresas - {0}";
        private const string _TituloProcessoEmpresaAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoEmpresaInclusao = "Inclusão";
        private const string _TituloProcessoAcaoEmpresaAlteracao = "Alteração";
        private const string _TituloProcessoAcaoEmpresaExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Empresa Aplicação :::...

        private const string _TituloProcessoEmpresaAplicacao = "Processo Gestão de Empresas Aplicações - {0}";
        private const string _TituloProcessoEmpresaAplicacaoAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoEmpresaAplicacaoInclusao = "Inclusão";
        private const string _TituloProcessoAcaoEmpresaAplicacaoAlteracao = "Alteração";
        private const string _TituloProcessoAcaoEmpresaAplicacaoExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Empresa Consolidada :::...

        private const string _TituloProcessoEmpresaConsolidada = "Processo Gestão de Empresas Consolidadas - {0}";
        private const string _TituloProcessoEmpresaConsolidadaAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoEmpresaConsolidadaInclusao = "Inclusão";
        private const string _TituloProcessoAcaoEmpresaConsolidadaAlteracao = "Alteração";
        private const string _TituloProcessoAcaoEmpresaConsolidadaExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Grupo :::...

        private const string _TituloProcessoGrupo = "Processo Gestão de Grupos de Usuarios - {0}";
        private const string _TituloProcessoGrupoAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoGrupoInclusao = "Inclusão";
        private const string _TituloProcessoAcaoGrupoAlteracao = "Alteração";
        private const string _TituloProcessoAcaoGrupoExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Grupo Processo :::...

        private const string _TituloProcessoGrupoProcesso = "Processo Gestão de Grupos de Processos - {0}";
        private const string _TituloProcessoGrupoProcessoAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoGrupoProcessoInclusao = "Inclusão";
        private const string _TituloProcessoAcaoGrupoProcessoAlteracao = "Alteração";
        private const string _TituloProcessoAcaoGrupoProcessoExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Liberação Usuario :::...

        private const string _TituloProcessoLiberacaoUsuario = "Processo Gestão de Liberações de Usuarios - {0}";
        private const string _TituloProcessoLiberacaoUsuarioAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoLiberacaoUsuarioInclusao = "Inclusão";
        private const string _TituloProcessoAcaoLiberacaoUsuarioAlteracao = "Alteração";
        private const string _TituloProcessoAcaoLiberacaoUsuarioExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Parametro Gerenciador :::...

        private const string _TituloProcessoParametroGerenciador = "Processo Gestão de Parametros do Gerenciador - {0}";
        private const string _TituloProcessoParametroGerenciadorAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoParametroGerenciadorInclusao = "Inclusão";
        private const string _TituloProcessoAcaoParametroGerenciadorAlteracao = "Alteração";
        private const string _TituloProcessoAcaoParametroGerenciadorExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Processos :::...

        private const string _TituloProcessoProcessos = "Processo Gestão de Processos - {0}";
        private const string _TituloProcessoProcessosAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoProcessosInclusao = "Inclusão";
        private const string _TituloProcessoAcaoProcessosAlteracao = "Alteração";
        private const string _TituloProcessoAcaoProcessosExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Tipo Processo :::...

        private const string _TituloProcessoTipoProcessos = "Processo Gestão de Tipos de Processos - {0}";
        private const string _TituloProcessoTipoProcessosAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoTipoProcessosInclusao = "Inclusão";
        private const string _TituloProcessoAcaoTipoProcessosAlteracao = "Alteração";
        private const string _TituloProcessoAcaoTipoProcessosExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Usuário :::...

        private const string _TituloProcessoUsuario = "Processo Gestão de Usuarios - {0}";
        private const string _TituloProcessoUsuarioAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoUsuarioInclusao = "Inclusão";
        private const string _TituloProcessoAcaoUsuarioAlteracao = "Alteração";
        private const string _TituloProcessoAcaoUsuarioExclusao = "Exclusão";

        #endregion

        #region ...::: Processo Gestão de Usuário Grupo :::...

        private const string _TituloProcessoUsuarioGrupo = "Processo Gestão de Usuarios de Grupos - {0}";
        private const string _TituloProcessoUsuarioGrupoAcaoConsulta = "Consulta";
        private const string _TituloProcessoAcaoUsuarioGrupoInclusao = "Inclusão";
        private const string _TituloProcessoAcaoUsuarioGrupoAlteracao = "Alteração";
        private const string _TituloProcessoAcaoUsuarioGrupoExclusao = "Exclusão";

        #endregion

        #endregion
        #endregion


        #region ...::: Public Properties :::...

        #region ...::: Registro Geral :::...

        #region ...::: Formulário Principal (Dashboard) :::...

        public static string DataLogonUsuario { get { return _DataLogonUsuario; } }
        public static string DataLogonUsuarioEmpresa { get { return _DataLogonUsuarioEmpresa; } }
        public static string CriaNovaSessaoDeUsuarioMensagemInformacao { get { return _CriaNovaSessaoDeUsuarioMensagemInformacao; } }
        public static string CriaNovaSessaoDeUsuarioMensagemTitulo { get { return _CriaNovaSessaoDeUsuarioMensagemTitulo; } }
        public static string EscolheProcessoPorTipoMensagem { get { return _EscolheProcessoPorTipoMensagem; } }
        public static string EscolheProcessoPorTipoTitulo { get { return _EscolheProcessoPorTipoTitulo; } }
        public static string CodigoDeAcessoRapidoDoMenuMensagem { get { return _CodigoDeAcessoRapidoDoMenuMensagem; } }
        public static string CodigoDeAcessoRapidoDoMenuTitulo { get { return _CodigoDeAcessoRapidoDoMenuTitulo; } }
        public static string CodigoDeAcessoRapidoDoMenuMenorZero { get { return _CodigoDeAcessoRapidoDoMenuMenorZero; } }

        #endregion

        #region ...::: Infrastructure :::...

        public static string TituloArquivoLogErro { get { return _TituloArquivoLogErro; } }
        public static string MensagemArqLogErro { get { return _MensagemArqLogErro; } }

        #endregion

        #region ...::: Processo Gestão de Estados :::...

        public static string TituloProcessoEstado { get { return _TituloProcessoEstado; } }
        public static string TituloProcessoEstadoAcaoConsulta { get { return _TituloProcessoEstadoAcaoConsulta; } }
        public static string TituloProcessoEstadoAcaoInclusao { get { return _TituloProcessoAcaoEstadoInclusao; } }
        public static string TituloProcessoEstadoAcaoAlteracao { get { return _TituloProcessoAcaoEstadoAlteracao; } }
        public static string TituloProcessoEstadoAcaoExclusao { get { return _TituloProcessoAcaoEstadoExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Login :::...

        public static string NroTentativasLogin { get { return _NroTentativasLogin; } }
        public static string NroTentativasLogoff { get { return _NroTentativasLogoff; } }
        public static string LoginDoSistema { get { return _LoginDoSistema; } }

        #endregion

        #region ...::: Processo Gestão de Municipio :::...

        public static string TituloProcessoMunicipio { get { return _TituloProcessoMunicipio; } }
        public static string TituloProcessoMunicipioAcaoConsulta { get { return _TituloProcessoMunicipioAcaoConsulta; } }
        public static string TituloProcessoAcaoMunicipioInclusao { get { return _TituloProcessoAcaoMunicipioInclusao; } }
        public static string TituloProcessoAcaoMunicipioAlteracao { get { return _TituloProcessoAcaoMunicipioAlteracao; } }
        public static string TituloProcessoAcaoMunicipioExclusao { get { return _TituloProcessoAcaoMunicipioExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Natureza :::...

        public static string TituloProcessoNatureza { get { return _TituloProcessoNatureza; } }
        public static string TituloProcessoNaturezaAcaoConsulta { get { return _TituloProcessoNaturezaAcaoConsulta; } }
        public static string TituloProcessoAcaoNaturezaInclusao { get { return _TituloProcessoAcaoNaturezaInclusao; } }
        public static string TituloProcessoAcaoNaturezaAlteracao { get { return _TituloProcessoAcaoNaturezaAlteracao; } }
        public static string TituloProcessoAcaoNaturezaExclusao { get { return _TituloProcessoAcaoNaturezaExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Parametros Rg :::...

        public static string TituloProcessoParametroRg { get { return _TituloProcessoParametroRg; } }
        public static string TituloProcessoParametroRgAcaoConsulta { get { return _TituloProcessoParametroRgAcaoConsulta; } }
        public static string TituloProcessoAcaoParametroRgInclusao { get { return _TituloProcessoAcaoParametroRgInclusao; } }
        public static string TituloProcessoAcaoParametroRgAlteracao { get { return _TituloProcessoAcaoParametroRgAlteracao; } }
        public static string TituloProcessoAcaoParametroRgExclusao { get { return _TituloProcessoAcaoParametroRgExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Região :::...

        public static string TituloProcessoRegiao { get { return _TituloProcessoRegiao; } }
        public static string TituloProcessoRegiaoAcaoConsulta { get { return _TituloProcessoRegiaoAcaoConsulta; } }
        public static string TituloProcessoAcaoRegiaoInclusao { get { return _TituloProcessoAcaoRegiaoInclusao; } }
        public static string TituloProcessoAcaoRegiaoAlteracao { get { return _TituloProcessoAcaoRegiaoAlteracao; } }
        public static string TituloProcessoAcaoRegiaoExclusao { get { return _TituloProcessoAcaoRegiaoExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Reg Geral :::...

        public static string TituloProcessoRegGeral { get { return _TituloProcessoRegGeral; } }
        public static string TituloProcessoRegGeralAcaoConsulta { get { return _TituloProcessoRegGeralAcaoConsulta; } }
        public static string TituloProcessoAcaoRegGeralInclusao { get { return _TituloProcessoAcaoRegGeralInclusao; } }
        public static string TituloProcessoAcaoRegGeralAlteracao { get { return _TituloProcessoAcaoRegGeralAlteracao; } }
        public static string TituloProcessoAcaoRegGeralExclusao { get { return _TituloProcessoAcaoRegGeralExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Status :::...

        public static string TituloProcessoStatus { get { return _TituloProcessoStatus; } }
        public static string TituloProcessoStatusAcaoConsulta { get { return _TituloProcessoStatusAcaoConsulta; } }
        public static string TituloProcessoAcaoStatusInclusao { get { return _TituloProcessoAcaoStatusInclusao; } }
        public static string TituloProcessoAcaoStatusAlteracao { get { return _TituloProcessoAcaoStatusAlteracao; } }
        public static string TituloProcessoAcaoStatusExclusao { get { return _TituloProcessoAcaoStatusExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Tipo Fone :::...

        public static string TituloProcessoTipoFone { get { return _TituloProcessoTipoFone; } }
        public static string TituloProcessoTipoFoneAcaoConsulta { get { return _TituloProcessoTipoFoneAcaoConsulta; } }
        public static string TituloProcessoAcaoTipoFoneInclusao { get { return _TituloProcessoAcaoTipoFoneInclusao; } }
        public static string TituloProcessoAcaoTipoFoneAlteracao { get { return _TituloProcessoAcaoTipoFoneAlteracao; } }
        public static string TituloProcessoAcaoTipoFoneExclusao { get { return _TituloProcessoAcaoTipoFoneExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Tipo Rg :::...

        public static string TituloProcessoTipoRg { get { return _TituloProcessoTipoRg; } }
        public static string TituloProcessoTipoRgAcaoConsulta { get { return _TituloProcessoTipoRgAcaoConsulta; } }
        public static string TituloProcessoAcaoTipoRgInclusao { get { return _TituloProcessoAcaoTipoRgInclusao; } }
        public static string TituloProcessoAcaoTipoRgAlteracao { get { return _TituloProcessoAcaoTipoRgAlteracao; } }
        public static string TituloProcessoAcaoTipoRgExclusao { get { return _TituloProcessoAcaoTipoRgExclusao; } }

        #endregion

        #endregion

        #region ...::: Gerenciador :::...

        #region ...::: Processo Gestão de Aplicação :::...

        public static string TituloProcessoAplicacao { get { return _TituloProcessoAplicacao; } }
        public static string TituloProcessoAplicacaoAcaoConsulta { get { return _TituloProcessoAplicacaoAcaoConsulta; } }
        public static string TituloProcessoAcaoAplicacaoInclusao { get { return _TituloProcessoAcaoAplicacaoInclusao; } }
        public static string TituloProcessoAcaoAplicacaoAlteracao { get { return _TituloProcessoAcaoAplicacaoAlteracao; } }
        public static string TituloProcessoAcaoAplicacaoExclusao { get { return _TituloProcessoAcaoAplicacaoExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Empresa :::...

        public static string TituloProcessoEmpresa { get { return _TituloProcessoEmpresa; } }
        public static string TituloProcessoEmpresaAcaoConsulta { get { return _TituloProcessoEmpresaAcaoConsulta; } }
        public static string TituloProcessoAcaoEmpresaInclusao { get { return _TituloProcessoAcaoEmpresaInclusao; } }
        public static string TituloProcessoAcaoEmpresaAlteracao { get { return _TituloProcessoAcaoEmpresaAlteracao; } }
        public static string TituloProcessoAcaoEmpresaExclusao { get { return _TituloProcessoAcaoEmpresaExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Empresa Aplicação :::...

        public static string TituloProcessoEmpresaAplicacao { get { return _TituloProcessoEmpresaAplicacao; } }
        public static string TituloProcessoEmpresaAplicacaoAcaoConsulta { get { return _TituloProcessoEmpresaAplicacaoAcaoConsulta; } }
        public static string TituloProcessoAcaoEmpresaAplicacaoInclusao { get { return _TituloProcessoAcaoEmpresaAplicacaoInclusao; } }
        public static string TituloProcessoAcaoEmpresaAplicacaoAlteracao { get { return _TituloProcessoAcaoEmpresaAplicacaoAlteracao; } }
        public static string TituloProcessoAcaoEmpresaAplicacaoExclusao { get { return _TituloProcessoAcaoEmpresaAplicacaoExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Empresa Consolidada :::...

        public static string TituloProcessoEmpresaConsolidada { get { return _TituloProcessoEmpresaConsolidada; } }
        public static string TituloProcessoEmpresaConsolidadaAcaoConsulta { get { return _TituloProcessoEmpresaConsolidadaAcaoConsulta; } }
        public static string TituloProcessoAcaoEmpresaConsolidadaInclusao { get { return _TituloProcessoAcaoEmpresaConsolidadaInclusao; } }
        public static string TituloProcessoAcaoEmpresaConsolidadaAlteracao { get { return _TituloProcessoAcaoEmpresaConsolidadaAlteracao; } }
        public static string TituloProcessoAcaoEmpresaConsolidadaExclusao { get { return _TituloProcessoAcaoEmpresaConsolidadaExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Grupo :::...

        public static string TituloProcessoGrupo { get { return _TituloProcessoGrupo; } }
        public static string TituloProcessoGrupoAcaoConsulta { get { return _TituloProcessoGrupoAcaoConsulta; } }
        public static string TituloProcessoAcaoGrupoInclusao { get { return _TituloProcessoAcaoGrupoInclusao; } }
        public static string TituloProcessoAcaoGrupoAlteracao { get { return _TituloProcessoAcaoGrupoAlteracao; } }
        public static string TituloProcessoAcaoGrupoExclusao { get { return _TituloProcessoAcaoGrupoExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Grupo Processo :::...

        public static string TituloProcessoGrupoProcesso { get { return _TituloProcessoGrupoProcesso; } }
        public static string TituloProcessoGrupoProcessoAcaoConsulta { get { return _TituloProcessoGrupoProcessoAcaoConsulta; } }
        public static string TituloProcessoAcaoGrupoProcessoInclusao { get { return _TituloProcessoAcaoGrupoProcessoInclusao; } }
        public static string TituloProcessoAcaoGrupoProcessoAlteracao { get { return _TituloProcessoAcaoGrupoProcessoAlteracao; } }
        public static string TituloProcessoAcaoGrupoProcessoExclusao { get { return _TituloProcessoAcaoGrupoProcessoExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Liberação Usuario :::...

        public static string TituloProcessoLiberacaoUsuario { get { return _TituloProcessoLiberacaoUsuario; } }
        public static string TituloProcessoLiberacaoUsuarioAcaoConsulta { get { return _TituloProcessoLiberacaoUsuarioAcaoConsulta; } }
        public static string TituloProcessoAcaoLiberacaoUsuarioInclusao { get { return _TituloProcessoAcaoLiberacaoUsuarioInclusao; } }
        public static string TituloProcessoAcaoLiberacaoUsuarioAlteracao { get { return _TituloProcessoAcaoLiberacaoUsuarioAlteracao; } }
        public static string TituloProcessoAcaoLiberacaoUsuarioExclusao { get { return _TituloProcessoAcaoLiberacaoUsuarioExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Parametro Gerenciador :::...

        public static string TituloProcessoParametroGerenciador { get { return _TituloProcessoParametroGerenciador; } }
        public static string TituloProcessoParametroGerenciadorAcaoConsulta { get { return _TituloProcessoParametroGerenciadorAcaoConsulta; } }
        public static string TituloProcessoAcaoParametroGerenciadorInclusao { get { return _TituloProcessoAcaoParametroGerenciadorInclusao; } }
        public static string TituloProcessoAcaoParametroGerenciadorAlteracao { get { return _TituloProcessoAcaoParametroGerenciadorAlteracao; } }
        public static string TituloProcessoAcaoParametroGerenciadorExclusao { get { return _TituloProcessoAcaoParametroGerenciadorExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Processos :::...

        public static string TituloProcessoProcessos { get { return _TituloProcessoProcessos; } }
        public static string TituloProcessoProcessosAcaoConsulta { get { return _TituloProcessoProcessosAcaoConsulta; } }
        public static string TituloProcessoAcaoProcessosInclusao { get { return _TituloProcessoAcaoProcessosInclusao; } }
        public static string TituloProcessoAcaoProcessosAlteracao { get { return _TituloProcessoAcaoProcessosAlteracao; } }
        public static string TituloProcessoAcaoProcessosExclusao { get { return _TituloProcessoAcaoProcessosExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Tipo Processos :::...

        public static string TituloProcessoTipoProcessos { get { return _TituloProcessoTipoProcessos; } }
        public static string TituloProcessoTipoProcessosAcaoConsulta { get { return _TituloProcessoTipoProcessosAcaoConsulta; } }
        public static string TituloProcessoAcaoTipoProcessosInclusao { get { return _TituloProcessoAcaoTipoProcessosInclusao; } }
        public static string TituloProcessoAcaoTipoProcessosAlteracao { get { return _TituloProcessoAcaoTipoProcessosAlteracao; } }
        public static string TituloProcessoAcaoTipoProcessosExclusao { get { return _TituloProcessoAcaoTipoProcessosExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Usuários :::...

        public static string TituloProcessoUsuario { get { return _TituloProcessoUsuario; } }
        public static string TituloProcessoUsuarioAcaoConsulta { get { return _TituloProcessoUsuarioAcaoConsulta; } }
        public static string TituloProcessoAcaoUsuarioInclusao { get { return _TituloProcessoAcaoUsuarioInclusao; } }
        public static string TituloProcessoAcaoUsuarioAlteracao { get { return _TituloProcessoAcaoUsuarioAlteracao; } }
        public static string TituloProcessoAcaoUsuarioExclusao { get { return _TituloProcessoAcaoUsuarioExclusao; } }

        #endregion

        #region ...::: Processo Gestão de Usuários Grupo :::...

        public static string TituloProcessoUsuarioGrupo { get { return _TituloProcessoUsuarioGrupo; } }
        public static string TituloProcessoUsuarioGrupoAcaoConsulta { get { return _TituloProcessoUsuarioGrupoAcaoConsulta; } }
        public static string TituloProcessoAcaoUsuarioGrupoInclusao { get { return _TituloProcessoAcaoUsuarioGrupoInclusao; } }
        public static string TituloProcessoAcaoUsuarioGrupoAlteracao { get { return _TituloProcessoAcaoUsuarioGrupoAlteracao; } }
        public static string TituloProcessoAcaoUsuarioGrupoExclusao { get { return _TituloProcessoAcaoUsuarioGrupoExclusao; } }

        #endregion

        #endregion
        #endregion
    }
}
