using BrSoftNet.App.Business.Processes.Security.Entities;
using BrSoftNet.App.Business.Processes.Security.Tasks;
using BrSoftNet.App.UI.Win.Main.AuthenticationForm;
using BrSoftNet.App.UI.Win.Main.State;
using BrSoftNet.App.UI.Win.Manager.FullScreenSearchForm;
using BrSoftNet.App.UI.Win.OverallRecord.FullScreenSearchForm;
using BrSoftNet.App.UI.Win.Security.State;
using BrSoftNet.Library.Messages;
using BrSoftNet.Library.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Security
{
    public partial class frmDashboard : Form
    {
        #region ...::: Private Fields from Dynamic Menu :::...

        private DataTable _TabelaDeAplicacoes = null;
        private DataTable _TabelaDeTipoDeProcessos = null;
        private DataTable _TabelaDeProcessos = null;

        private ArrayList _Aplicacoes = null;
        private ArrayList _TipoProcessos = null;
        private ArrayList _Processos = null;

        private int _NroProcessos = 0;
        private string _PathLogoEmpresa = string.Empty;
        
        #endregion

        public int _CodigoProcesso = 0;

        private static int IdExecuteSession { get; set; }
        private static SessaoUsuarioLogin SessaoUsuarioLoginFromDashBoard = null;
        public frmDashboard()
        {
            InitializeComponent();
            this.inicializeFormDashboard();
        }

        private void inicializeFormDashboard() 
        {
            UserInterfaceWin.CreateInstance.onInicializeProperties(this, true);
            UserInterfaceWin.CreateInstance.onInicializePositionFormModal(this);
            this.ContextMenuStrip = cntxMenuMain;
        }

        private void tlstrBtnLogin_Click(object sender, EventArgs e)
        {
            LoginForm _LoginForm = new LoginForm();

            try
            {
                _LoginForm.ShowDialog();
            }
            finally
            {
                AppStateSecurity.Usuario = _LoginForm.Usuario;
                AppStateSecurity.Nome = _LoginForm.Nome;

                if (_LoginForm.EmpresaLoginCollection != null)
                {
                    AppStateSecurity.EmpresaLoginCollection = _LoginForm.EmpresaLoginCollection; 
                }

                _LoginForm = null;
            }

            if (!string.IsNullOrEmpty(AppStateSecurity.Nome))
            {
                tlstrlblDataLogon.Text = string.Format(FormsMessages.DataLogonUsuario, AppStateSecurity.Nome);
            }
            
            //Se tem o retorno do usuário logado, nome e as empresas vinculadas ao seu logon, cria a sessão do usuário logado
            if ((!string.IsNullOrEmpty(AppStateSecurity.Usuario)) && 
                (!string.IsNullOrEmpty(AppStateSecurity.Nome)) && 
                (AppStateSecurity.EmpresaLoginCollection != null))
            {
                if (SessaoUsuarioLoginFromDashBoard == null)
                {
                    CreateUserSession();
                }
                else
                {
                    CreateNewUserSession();
                }
            }
        }

        private void EndCurrentSession()
        {
            UserInterfaceWin.CreateInstance.onCloseMDIChildrenForm(this);
            if (_NroProcessos > 0) { trvwMainMenu.Nodes.Clear(); }
            if (!string.IsNullOrEmpty(_PathLogoEmpresa)) { _PathLogoEmpresa = string.Empty; }
            if (!string.IsNullOrEmpty(pctrBoxProcessMenu.ImageLocation)) { pctrBoxProcessMenu.ImageLocation = string.Empty; }
            if (!string.IsNullOrEmpty(tlstrlblDataLogon.Text)) { tlstrlblDataLogon.Text = string.Empty; }
            AppStateSecurity.Usuario = string.Empty;
            AppStateSecurity.Nome = string.Empty;
            AppStateSecurity.EmpresaLoginCollection = null;
            AppStateSession.IdSession = string.Empty;
            AppStateSession.DateTimeSession = Convert.ToDateTime("01/01/0001 00:00:00");
            AppStateSession.MachineName = string.Empty;
            AppStateSession.MachineIP = string.Empty;
        }

        private void CreateUserSession()
        {
            string _Usuario = string.Empty;
            string _IdSession = string.Empty;
            DateTime _DateTimeSession = Convert.ToDateTime("01/01/0001 00:00:00");
            string _MachineName = string.Empty;
            string _MachineIP = string.Empty;
            int _LogonNumber = 0;

            AppStateSession.IdSession = UserInterfaceWin.CreateInstance.GetIDSession().Trim();
            AppStateSession.DateTimeSession = DateTime.Now;
            AppStateSession.MachineName = Environment.MachineName.Trim();

            IPHostEntry _SystemAC = Dns.GetHostEntry(Dns.GetHostName());

            string _IPAddress = string.Empty;

            foreach (IPAddress address in _SystemAC.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    _IPAddress = address.ToString();
                    break;
                }
            }

            AppStateSession.MachineIP = _IPAddress.Trim();

            _Usuario = AppStateSecurity.Usuario.Trim();
            _IdSession = AppStateSession.IdSession;
            _DateTimeSession = AppStateSession.DateTimeSession;
            _MachineName = AppStateSession.MachineName;
            _MachineIP = AppStateSession.MachineIP;
            _LogonNumber = AppStateSession.LogonNumber;

            IdExecuteSession = AccessTask.CreateInstance.ModificaProcessoSessaoUsuario(_Usuario, _IdSession, _DateTimeSession, _MachineName, _MachineIP, _LogonNumber);
            SessaoUsuarioLoginFromDashBoard = AccessTask.CreateInstance.RetornaProcessoSessaoUsuario(_Usuario);
        }

        private void CreateNewUserSession()
        {
            DialogResult _DialogResult;
            string _Usuario = string.Empty;
            string _IdSession = string.Empty;
            DateTime _DateTimeSession = Convert.ToDateTime("01/01/0001 00:00:00");
            string _MachineName = string.Empty;
            string _MachineIP = string.Empty;
            int _LogonNumber = 0;

            string _IdSessionForCheck = string.Empty;
            string _MachineNameForCheck = string.Empty;
            string _MachineIPForCheck = string.Empty;

            _Usuario = AppStateSecurity.Usuario.Trim();
            _IdSession = UserInterfaceWin.CreateInstance.GetIDSession().Trim();
            _DateTimeSession = DateTime.Now;
            _MachineName = Environment.MachineName.Trim();

            IPHostEntry _SystemAC = Dns.GetHostEntry(Dns.GetHostName());

            string _IPAddress = string.Empty;

            foreach (IPAddress address in _SystemAC.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    _IPAddress = address.ToString();
                    break;
                }
            }

            _MachineIP = _IPAddress.Trim();

            _IdSessionForCheck = AppStateSession.IdSession.Trim();
            _MachineNameForCheck = AppStateSession.MachineName.Trim();
            _MachineIPForCheck = AppStateSession.MachineIP.Trim();

            if ((_IdSession != _IdSessionForCheck) &&
                (_MachineName == _MachineNameForCheck) &&
                (_MachineIP == _MachineIPForCheck))
            {
                _DialogResult = MessageBox.Show(FormsMessages.CriaNovaSessaoDeUsuarioMensagemInformacao, 
                                                FormsMessages.CriaNovaSessaoDeUsuarioMensagemTitulo, 
                                                MessageBoxButtons.OKCancel, 
                                                MessageBoxIcon.Question);

                switch (_DialogResult)
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.OK:
                        this.EndCurrentSession();
                        ReloadUserLoginForNewSession(_Usuario);
                        ReloadCompanyLoginForNewSession();

                        IdExecuteSession = AccessTask.CreateInstance.ModificaProcessoSessaoUsuario(_Usuario, _IdSession, _DateTimeSession, _MachineName, _MachineIP, _LogonNumber);
                        SessaoUsuarioLoginFromDashBoard = AccessTask.CreateInstance.RetornaProcessoSessaoUsuario(_Usuario);

                        AppStateSecurity.Usuario = SessaoUsuarioLoginFromDashBoard.Usuario;
                        AppStateSession.IdSession = SessaoUsuarioLoginFromDashBoard.IdSession;
                        AppStateSession.DateTimeSession = SessaoUsuarioLoginFromDashBoard.DateTimeSession;
                        AppStateSession.MachineName = SessaoUsuarioLoginFromDashBoard.MachineName;
                        AppStateSession.MachineIP = SessaoUsuarioLoginFromDashBoard.MachineIP;
                        AppStateSession.LogonNumber = SessaoUsuarioLoginFromDashBoard.LogonNumber;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                this.EndCurrentSession();
                this.Close();
                Application.Exit();
            }
        }

        private void ReloadCompanyLoginForNewSession()
        {
            if ((!string.IsNullOrEmpty(AppStateSecurity.Usuario)) && (AppStateSecurity.CodigoEmpresa > 0))
            {
                AppStateSecurity.AplicacaoLoginCollection = AccessTask.CreateInstance.GetAplicacaoLoginTask(AppStateSecurity.Usuario, AppStateSecurity.CodigoEmpresa);
            }

            if (AppStateSecurity.CodigoEmpresa > 0)
            {
                AppStateSecurity.NomeFantasia = AccessTask.CreateInstance.GetNomeFantasiaTask(AppStateSecurity.CodigoEmpresa).NomeFantasia;
            }

            if (!string.IsNullOrEmpty(AppStateSecurity.Nome) && !string.IsNullOrEmpty(AppStateSecurity.NomeFantasia))
            {
                tlstrlblDataLogon.Text = string.Format(FormsMessages.DataLogonUsuarioEmpresa, AppStateSecurity.Nome, AppStateSecurity.NomeFantasia);
                FillProcessesMenu();
                FillCompanyImage();
            }
        }

        private void ReloadUserLoginForNewSession(string _Usuario)
        {
            DataSet _dsLogin = null;
            UsuarioLogin _UsuarioLogin = null;
            List<EmpresaLogin> _EmpresaLoginCollection = new List<EmpresaLogin>();
            _dsLogin = AccessTask.CreateInstance.GetLoginTask(_Usuario, AppStateSecurity.Senha);

            if ((_dsLogin.Tables[0].Rows.Count > 0) && (_dsLogin.Tables[1].Rows.Count > 0))
            {
                if (_dsLogin.Tables[0].Rows.Count.Equals(1))
                {
                    _UsuarioLogin = new UsuarioLogin(_dsLogin.Tables[0].Rows[0]);

                    AppStateSecurity.Usuario = _UsuarioLogin.Usuario;
                    AppStateSecurity.Nome = _UsuarioLogin.Nome;
                }

                if (_dsLogin.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow _Row in _dsLogin.Tables[1].Rows)
                    {
                        _EmpresaLoginCollection.Add(new EmpresaLogin(_Row));
                    }

                    AppStateSecurity.EmpresaLoginCollection = _EmpresaLoginCollection;
                }
            }

            if (!string.IsNullOrEmpty(AppStateSecurity.Nome))
            {
                tlstrlblDataLogon.Text = string.Format(FormsMessages.DataLogonUsuario, AppStateSecurity.Nome);
            }
        }

        private void tlstrBtnEmpresas_Click(object sender, EventArgs e)
        {
            CompanyForm _CompanyForm = new CompanyForm();

            try
            {
                _CompanyForm.ShowDialog();
            }
            finally
            {
                if ((_CompanyForm.CodigoEmpresa > 0) && (!string.IsNullOrEmpty(_CompanyForm.NomeFantasia)) && (_CompanyForm.AplicacaoLoginCollection != null))
                {
                    AppStateSecurity.CodigoEmpresa = _CompanyForm.CodigoEmpresa;
                    AppStateSecurity.NomeFantasia = _CompanyForm.NomeFantasia;
                    AppStateSecurity.AplicacaoLoginCollection = _CompanyForm.AplicacaoLoginCollection;
                }

                _CompanyForm = null;
            }

            if (!string.IsNullOrEmpty(AppStateSecurity.Nome) && !string.IsNullOrEmpty(AppStateSecurity.NomeFantasia))
            {
                tlstrlblDataLogon.Text = string.Format(FormsMessages.DataLogonUsuarioEmpresa, AppStateSecurity.Nome, AppStateSecurity.NomeFantasia);
                FillProcessesMenu();
                FillCompanyImage();
            }
        }

        private void FillCompanyImage()
        {
            if (string.IsNullOrEmpty(_PathLogoEmpresa))
            {
                _PathLogoEmpresa = AccessTask.CreateInstance.RetornaCaminhoDiretorioEmpresa(AppStateSecurity.CodigoEmpresa);

                bool _FileExiste = File.Exists(_PathLogoEmpresa);

                if (_FileExiste)
                {
                    if (!string.IsNullOrEmpty(_PathLogoEmpresa))
                    {
                        //vai ler o tamanho do arquivo selecionado
                        FileInfo _File = new FileInfo(_PathLogoEmpresa);

                        //testa se tem menos de 1MB (1MB em bytes = 1048576)
                        if (_File.Length <= 1048576)
                        {
                            pctrBoxProcessMenu.ImageLocation = _PathLogoEmpresa;
                            pctrBoxProcessMenu.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                }
            }
        }

        private void FillProcessesMenu()
        {
            if(_NroProcessos > 0)
            {
                _NroProcessos = 0;
            }

            if (trvwMainMenu.Nodes.Count > 0)
            {
                trvwMainMenu.Nodes.Clear();
            }

            // define o no raiz para o TreeView.
            trvwMainMenu.Nodes.Add("ERP - BrSoftNet");
            trvwMainMenu.Nodes[0].ImageIndex = 0;
            trvwMainMenu.Nodes[0].SelectedImageIndex = 0;
            trvwMainMenu.Nodes[0].Tag = "ERP_BrSoftNet";

            #region ...::: Inclui no TreeView os nós das aplicações :::...

            _TabelaDeAplicacoes = AccessTask.CreateInstance.RetornaNoDeAplicacoesNoMenuTask(AppStateSecurity.Usuario, AppStateSecurity.CodigoEmpresa);

            for (int i = 0; i < _TabelaDeAplicacoes.Rows.Count; i++)
            {
                trvwMainMenu.Nodes[0].Nodes.Add(_TabelaDeAplicacoes.Rows[i]["DescricaoAplicacao"].ToString());
                trvwMainMenu.Nodes[0].Nodes[i].Tag = "Aplicacoes";
                trvwMainMenu.Nodes[0].Nodes[i].ImageIndex = 2;
                trvwMainMenu.Nodes[0].Nodes[i].SelectedImageIndex = 2;
            }

            #endregion //Fim da Inclusão no TreeView os nós das aplicações

            #region ...::: Inclui no TreeView os nós dos Tipo de Processos :::...

            for (int i = 0; i < _TabelaDeAplicacoes.Rows.Count; i++)
            {
                int _CodigoAplicacao = Convert.ToInt32(_TabelaDeAplicacoes.Rows[i]["CodigoAplicacao"].ToString());

                _TabelaDeTipoDeProcessos = AccessTask.CreateInstance.RetornaNoDeTiposDeProcessosNoMenuTask(_CodigoAplicacao, AppStateSecurity.CodigoEmpresa);

                for (int j = 0; j < _TabelaDeTipoDeProcessos.Rows.Count; j++)
                {
                    trvwMainMenu.Nodes[0].Nodes[i].Nodes.Add(_TabelaDeTipoDeProcessos.Rows[j]["DescricaoTipoProcesso"].ToString());
                    trvwMainMenu.Nodes[0].Nodes[i].Nodes[j].Tag = "TiposDeProcessos";
                    trvwMainMenu.Nodes[0].Nodes[i].Nodes[j].ImageIndex = 4;
                    trvwMainMenu.Nodes[0].Nodes[i].Nodes[j].SelectedImageIndex = 4;
                }
            }

            #endregion //Fim da Inclusão no TreeView os nós dos Tipo de Processos

            #region ...::: Inclui no TreeView os nós de Processos :::...

            for (int i = 0; i < _TabelaDeAplicacoes.Rows.Count; i++)
            {
                int _CodigoAplicacao = Convert.ToInt32(_TabelaDeAplicacoes.Rows[i]["CodigoAplicacao"].ToString());

                _TabelaDeTipoDeProcessos = AccessTask.CreateInstance.RetornaNoDeTiposDeProcessosNoMenuTask(_CodigoAplicacao, AppStateSecurity.CodigoEmpresa);

                for (int j = 0; j < _TabelaDeTipoDeProcessos.Rows.Count; j++)
                {
                    int _CodigoTipoProcesso = Convert.ToInt32(_TabelaDeTipoDeProcessos.Rows[j]["CodigoTipoProcesso"].ToString());

                    _TabelaDeProcessos = AccessTask.CreateInstance.RetornaNoDeProcessosNoMenuTask(_CodigoAplicacao, _CodigoTipoProcesso, AppStateSecurity.CodigoEmpresa);

                    for (int k = 0; k < _TabelaDeProcessos.Rows.Count; k++)
                    {
                        int _CodigoProcesso = Convert.ToInt32(_TabelaDeProcessos.Rows[k]["CodigoProcesso"].ToString());
                        string _DescricaoProcesso = _TabelaDeProcessos.Rows[k]["DescricaoProcesso"].ToString();
                        string _DescricaoMenuProcesso = string.Format("{0} - {1}", _CodigoProcesso, _DescricaoProcesso);

                        trvwMainMenu.Nodes[0].Nodes[i].Nodes[j].Nodes.Add(_DescricaoMenuProcesso);
                        trvwMainMenu.Nodes[0].Nodes[i].Nodes[j].Nodes[k].Tag = "Processos";
                        trvwMainMenu.Nodes[0].Nodes[i].Nodes[j].Nodes[k].ImageIndex = 5;
                        trvwMainMenu.Nodes[0].Nodes[i].Nodes[j].Nodes[k].SelectedImageIndex = 5;

                        _NroProcessos += trvwMainMenu.Nodes[0].Nodes[i].Nodes[j].Nodes.Count;
                    }
                }
            }

            #endregion //Fim da Inclusão no TreeView os nós de Processos

            if (_NroProcessos > 0)
            {
                foreach (TreeNode _TreeNode in trvwMainMenu.Nodes)
                {
                    _TreeNode.ExpandAll();
                }

                this.tlstptxtFastAccessCodeMenu.Focus();
            }
        }

        private void PreencheNoDeAplicacoes(DataSet _DsPerfilMenu, out ArrayList _Aplicacoes)
        {
            _Aplicacoes = null;

            if (_Aplicacoes == null)
            {
                _Aplicacoes = new ArrayList();
            }

            foreach (DataRow _Row in _DsPerfilMenu.Tables[0].Rows)
            {
                _Aplicacoes.Add(_Row["DescricaoAplicacao"].ToString());
            }
        }

        private void PreencheNoDeTipoDeProcessos(DataSet _DsPerfilMenu, out ArrayList _TiposProcessos)
        {
            _TiposProcessos = null;

            if (_TiposProcessos == null)
            {
                _TiposProcessos = new ArrayList();
            }

            foreach (DataRow _Row in _DsPerfilMenu.Tables[1].Rows)
            {
                _TiposProcessos.Add(_Row["DescricaoTipoProcesso"].ToString());
            }
        }

        private void tlstrBtnLogout_Click(object sender, EventArgs e)
        {
            UserInterfaceWin.CreateInstance.onExit(this);
        }

        private void tlstrBtnShowMenu_Click(object sender, EventArgs e)
        {
            if (!pnlMenuProcesses.Visible)
            {
                pnlMenuProcesses.Visible = true;

                if (this.MdiChildren.Length > 0)
                {
                    foreach (var _FormMDIChildren in this.MdiChildren)
                    {
                        _FormMDIChildren.WindowState = FormWindowState.Maximized;
                    }
                }
            }
        }

        private void tlstrBtnHideMenu_Click(object sender, EventArgs e)
        {
            if (pnlMenuProcesses.Visible)
            {
                pnlMenuProcesses.Visible = false;

                if (this.MdiChildren.Length > 0)
                {
                    foreach (var _FormMDIChildren in this.MdiChildren)
                    {
                        _FormMDIChildren.WindowState = FormWindowState.Maximized;
                    }
                }
            }
        }

        private void tlstrBtnFecharApps_Click(object sender, EventArgs e)
        {
            UserInterfaceWin.CreateInstance.onCloseMDIChildrenForm(this);
        }

        private void tlstrDdbCascadeLayout_Click(object sender, EventArgs e)
        {
            UserInterfaceWin.CreateInstance.onPositionCascadeLayoutMDIChildrenForm(this);
        }

        private void tlstrDdbHorizontalLayout_Click(object sender, EventArgs e)
        {
            UserInterfaceWin.CreateInstance.onPositionHorizontalLayoutMDIChildrenForm(this);
        }

        private void tlstrDdbVerticalLayout_Click(object sender, EventArgs e)
        {
            UserInterfaceWin.CreateInstance.onPositionVerticalLayoutMDIChildrenForm(this);
        }

        private void tlstpBtnPlusMenu_Click(object sender, EventArgs e)
        {
            if (_NroProcessos > 0)
            {
                foreach (TreeNode _TreeNode in trvwMainMenu.Nodes)
                {
                    _TreeNode.ExpandAll();
                }

                this.tlstptxtFastAccessCodeMenu.Focus();
            }
        }

        private void tlstpBtnMinusMenu_Click(object sender, EventArgs e)
        {
            if (_NroProcessos > 0)
            {
                foreach (TreeNode _TreeNode in trvwMainMenu.Nodes)
                {
                    _TreeNode.Collapse();
                }

                this.tlstptxtFastAccessCodeMenu.Focus();
            }
        }

        private void ChoosesProcessesByType(int _CodigoProcesso)
        {
            switch (_CodigoProcesso)
            {
                case 1:
                    ProcessCallEmpresa();
                    break;
                case 2:
                    ProcessCallAplicacao();
                    break;
                case 3:
                    ProcessCallProcesso();
                    break;
                case 4:
                    ProcessCallUsuario();
                    break;
                case 5:
                    ProcessCallGrupo();
                    break;
                case 6:
                    ProcessCallRegistroGeral();
                    break;
                case 7:
                    ProcessCallMunicipio();
                    break;
                case 8:
                    ProcessCallEstado();
                    break;
                case 9:
                    ProcessCallNatureza();
                    break;
                case 10:
                    ProcessCallStatus();
                    break;
                case 11:
                    ProcessCallTipoFone();
                    break;
                case 12:
                    ProcessCallTipoRG();
                    break;
                case 35:
                    ProcessCallTipoProcesso();
                    break;
                case 51:
                    ProcessCallGrupoProcesso();
                    break;
                case 52:
                    ProcessCallParametroGerenciador();
                    break;
                case 53:
                    ProcessCallEmpresaAplicacao();
                    break;
                case 54:
                    ProcessCallUsuarioGrupo();
                    break;
                case 55:
                    ProcessCallLiberacaoUsuario();
                    break;
                case 57:
                    ProcessCallRegiao();
                    break;
                case 61:
                    ProcessCallParamRegGeral();
                    break;
                case 75:
                    ProcessCallEmpresaConsolidada();
                    break;
                default:
                    MessageBox.Show(string.Format(FormsMessages.EscolheProcessoPorTipoMensagem, AppStateSecurity.Usuario), 
                                    FormsMessages.EscolheProcessoPorTipoTitulo, 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
                    break;
            }
        }

        private void ProcessCallEmpresaAplicacao()
        {
             
            SearchFormEmpresaAplicacao _SearchFormEmpresaAplicacao = new SearchFormEmpresaAplicacao();
            _SearchFormEmpresaAplicacao.MdiParent = this;
            _SearchFormEmpresaAplicacao.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormEmpresaAplicacao.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormEmpresaAplicacao.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEmpresaAplicacao, FormsMessages.TituloProcessoEmpresaAplicacaoAcaoConsulta);

            try
            {
                _SearchFormEmpresaAplicacao.Show();
            }
            catch (Exception _Ex)
            {
                
                throw _Ex;
            }
            finally
            {
                _SearchFormEmpresaAplicacao = null;
            }

        }

        private void ProcessCallLiberacaoUsuario()
        {
            SearchFormLiberacaoUsuario _SearchFormLiberacaoUsuario = new SearchFormLiberacaoUsuario();
            _SearchFormLiberacaoUsuario.MdiParent = this;
            _SearchFormLiberacaoUsuario.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormLiberacaoUsuario.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormLiberacaoUsuario.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoLiberacaoUsuario, FormsMessages.TituloProcessoLiberacaoUsuarioAcaoConsulta);
            
            try
            {
                _SearchFormLiberacaoUsuario.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormLiberacaoUsuario = null;
            }
        }

        private void ProcessCallEmpresa()
        {
            SearchFormEmpresa _SearchFormEmpresa = new SearchFormEmpresa();
            _SearchFormEmpresa.MdiParent = this;
            _SearchFormEmpresa.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormEmpresa.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormEmpresa.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEmpresa, FormsMessages.TituloProcessoEmpresaAcaoConsulta);

            try
            {
                _SearchFormEmpresa.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormEmpresa = null;
            }
        }

        private void ProcessCallAplicacao()
        {
            SearchFormAplicacao _SearchFormAplicacao = new SearchFormAplicacao();
            _SearchFormAplicacao.MdiParent = this;

            _SearchFormAplicacao.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormAplicacao.IdAplicacaoLogDashboard = AppStateSecurity.CodigoAplicacao;
            _SearchFormAplicacao.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormAplicacao.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoAplicacao, FormsMessages.TituloProcessoAplicacaoAcaoConsulta);

            try
            {
                _SearchFormAplicacao.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormAplicacao = null;
            }
        }

        private void ProcessCallProcesso() 
        {
            SearchFormProcesso _SearchFormProcesso = new SearchFormProcesso();
            _SearchFormProcesso.MdiParent = this;
            _SearchFormProcesso.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormProcesso.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormProcesso.IdProcessoFromDashboard = AppStateSecurity.CodigoProcesso;
            _SearchFormProcesso.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoProcessos, FormsMessages.TituloProcessoProcessosAcaoConsulta);

            try
            {
                _SearchFormProcesso.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally 
            {
                _SearchFormProcesso = null;
            }
        }

        private void ProcessCallUsuario()
        {
            SearchFormUsuario _SearchFormUsuario = new SearchFormUsuario();
            _SearchFormUsuario.MdiParent = this;
            _SearchFormUsuario.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormUsuario.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormUsuario.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoUsuario, FormsMessages.TituloProcessoUsuarioAcaoConsulta);

            try
            {
                _SearchFormUsuario.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormUsuario = null;
            }
        }

        private void ProcessCallGrupo()
        {
            SearchFormGrupo _SearchFormGrupo = new SearchFormGrupo();
            _SearchFormGrupo.MdiParent = this;
            _SearchFormGrupo.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormGrupo.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormGrupo.IdGrupoFromDashboard = AppStateSecurity.CodigoGrupo;
            _SearchFormGrupo.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoGrupo, FormsMessages.TituloProcessoGrupoAcaoConsulta);
            
            try
            {
                _SearchFormGrupo.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormGrupo = null;
            }
        }

        private void ProcessCallRegistroGeral() 
        {
            SearchFormRegistroGeral _SearchFormRegistroGeral = new SearchFormRegistroGeral();
            _SearchFormRegistroGeral.MdiParent = this;

            _SearchFormRegistroGeral.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormRegistroGeral.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormRegistroGeral.IdRegGeralLogDashboard = AppStateSecurity.CodigoRegGeral;
            _SearchFormRegistroGeral.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoRegGeral, FormsMessages.TituloProcessoRegGeralAcaoConsulta);

            try
            {
                _SearchFormRegistroGeral.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally 
            {
                _SearchFormRegistroGeral = null;
            }
        }

        private void ProcessCallMunicipio()
        {
            SearchFormMunicipio _SearchFormMunicipio = new SearchFormMunicipio();
            _SearchFormMunicipio.MdiParent = this;

            _SearchFormMunicipio.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormMunicipio.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormMunicipio.IdMunicipioLogDashboard = AppStateSecurity.CodigoMunicipio;
            _SearchFormMunicipio.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoMunicipio, FormsMessages.TituloProcessoMunicipioAcaoConsulta );

            try
            {
                _SearchFormMunicipio.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormMunicipio = null;
            }
        }

        private void ProcessCallEstado()
        {
            SearchFormEstado _SearchFormEstado = new SearchFormEstado();
            _SearchFormEstado.MdiParent = this;

            _SearchFormEstado.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormEstado.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormEstado.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEstado, FormsMessages.TituloProcessoEstadoAcaoConsulta);

            try
            {
                _SearchFormEstado.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormEstado = null;
            }
        }

        private void ProcessCallNatureza()
        {
            SearchFormNatureza _SearchFormNatureza = new SearchFormNatureza();
            _SearchFormNatureza.MdiParent = this;

            _SearchFormNatureza.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormNatureza.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormNatureza.IdNaturezaLogDashboard = AppStateSecurity.CodigoNatureza;
            _SearchFormNatureza.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoNatureza, FormsMessages.TituloProcessoNaturezaAcaoConsulta);

            try
            {
                _SearchFormNatureza.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormNatureza = null;
            }
        }

        private void ProcessCallStatus()
        {
            SearchFormStatus _SearchFormStatus = new SearchFormStatus();
            _SearchFormStatus.MdiParent = this;

            _SearchFormStatus.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormStatus.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormStatus.IdStatusLogDashboard = AppStateSecurity.CodigoStatus;
           _SearchFormStatus.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoStatus, FormsMessages.TituloProcessoStatusAcaoConsulta);

            try
            {
                _SearchFormStatus.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormStatus = null;
            }
        }

        private void ProcessCallTipoFone()
        {
            SearchFormTipoFone _SearchFormTipoFone = new SearchFormTipoFone();
            _SearchFormTipoFone.MdiParent = this;

            _SearchFormTipoFone.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormTipoFone.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormTipoFone.IdTipoFoneLogDashboard = AppStateSecurity.CodigoTipoFone;
            _SearchFormTipoFone.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoFone, FormsMessages.TituloProcessoTipoFoneAcaoConsulta);

            try
            {
                _SearchFormTipoFone.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormTipoFone = null;
            }
        }

        private void ProcessCallTipoRG()
        {
            SearchFormTipoRg _SearchFormTipoRg = new SearchFormTipoRg();
            _SearchFormTipoRg.MdiParent = this;

            _SearchFormTipoRg.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormTipoRg.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormTipoRg.IdTipoRgLogDashboard = AppStateSecurity.CodigoTipoRg;
            _SearchFormTipoRg.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoRg, FormsMessages.TituloProcessoTipoRgAcaoConsulta);

            try
            {
                _SearchFormTipoRg.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormTipoRg = null;
            }
        }

        private void ProcessCallTipoProcesso()
        {
            SearchFormTipoProcesso _SearchFormTipoProcesso = new SearchFormTipoProcesso();
            _SearchFormTipoProcesso.MdiParent = this;
            _SearchFormTipoProcesso.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormTipoProcesso.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormTipoProcesso.IdTipoProcessoFromDashboard = AppStateSecurity.CodigoTipoProcesso;
            _SearchFormTipoProcesso.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoTipoProcessos, FormsMessages.TituloProcessoTipoProcessosAcaoConsulta);

            try
            {
                _SearchFormTipoProcesso.Show();
            }
            catch (Exception _Exception)
            {
                
                throw _Exception;
            }
            finally
            {
                _SearchFormTipoProcesso = null;
            }
        }
        private void ProcessCallGrupoProcesso()
        {
            SearchFormGrupoProcesso _SearchFormGrupoProcesso = new SearchFormGrupoProcesso();
            _SearchFormGrupoProcesso.MdiParent = this;
            _SearchFormGrupoProcesso.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormGrupoProcesso.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormGrupoProcesso.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoGrupoProcesso, FormsMessages.TituloProcessoGrupoProcessoAcaoConsulta);

            try
            {
                _SearchFormGrupoProcesso.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormGrupoProcesso = null;
            }
        }

        private void ProcessCallParametroGerenciador()
        {
            SearchFormParametroGerenciador _SearchFormParametroGerenciador = new SearchFormParametroGerenciador();
            _SearchFormParametroGerenciador.MdiParent = this;
            _SearchFormParametroGerenciador.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoParametroGerenciador, FormsMessages.TituloProcessoParametroGerenciadorAcaoConsulta);

            try
            {
                _SearchFormParametroGerenciador.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormParametroGerenciador = null;
            }
        }

        private void ProcessCallUsuarioGrupo()
        {
            SearchFormUsuarioUsuarioGrupo _SearchFormUsuarioUsuarioGrupo = new SearchFormUsuarioUsuarioGrupo();
            _SearchFormUsuarioUsuarioGrupo.MdiParent = this;
            _SearchFormUsuarioUsuarioGrupo.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormUsuarioUsuarioGrupo.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormUsuarioUsuarioGrupo.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoUsuarioGrupo, FormsMessages.TituloProcessoUsuarioGrupoAcaoConsulta);

            try
            {
                _SearchFormUsuarioUsuarioGrupo.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormUsuarioUsuarioGrupo = null;
            }
        }

        private void ProcessCallRegiao()
        {
            SearchFormRegiao _SearchFormRegiao = new SearchFormRegiao();
            _SearchFormRegiao.MdiParent = this;

            _SearchFormRegiao.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormRegiao.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormRegiao.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoRegiao, FormsMessages.TituloProcessoRegiaoAcaoConsulta);

            try
            {
                _SearchFormRegiao.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormRegiao = null;
            }
        }

        private void ProcessCallParamRegGeral()
        {
            SearchFormParamRegGeral _SearchFormParamRegGeral = new SearchFormParamRegGeral();
            _SearchFormParamRegGeral.MdiParent = this;

            _SearchFormParamRegGeral.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoParametroRg, FormsMessages.TituloProcessoParametroRgAcaoConsulta);

            try
            {
                _SearchFormParamRegGeral.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormParamRegGeral = null;
            }
        }

        private void ProcessCallEmpresaConsolidada()
        {
            SearchFormEmpresaConsolidada _SearchFormEmpresaConsolidada = new SearchFormEmpresaConsolidada();
            _SearchFormEmpresaConsolidada.MdiParent = this;
            _SearchFormEmpresaConsolidada.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
            _SearchFormEmpresaConsolidada.UsuarioLoginDashboard = AppStateSecurity.Usuario;
            _SearchFormEmpresaConsolidada.TextoDoTilutoDoFormulario = UserInterfaceWin.CreateInstance.GetFormTitleText(FormsMessages.TituloProcessoEmpresaConsolidada, FormsMessages.TituloProcessoEmpresaConsolidadaAcaoConsulta);

            try
            {
                _SearchFormEmpresaConsolidada.Show();
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
            finally
            {
                _SearchFormEmpresaConsolidada = null;
            }
        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tlstrBtnLogin_Click(sender, e);
        }

        private void empresasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tlstrBtnEmpresas_Click(sender, e);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrBtnLogout_Click(sender, e);
        }

        private void fecharAplicaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrBtnFecharApps_Click(sender, e);
        }

        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrDdbCascadeLayout_Click(sender, e);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrDdbHorizontalLayout_Click(sender, e);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrDdbVerticalLayout_Click(sender, e);
        }

        private void apresentarMenuDeModuloProcessosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrBtnShowMenu_Click(sender, e);
        }

        private void esconderMenuDeMóduloDeProcessosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrBtnHideMenu_Click(sender, e);
        }

        private void loginDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrBtnLogin_Click(sender, e);
        }

        private void empresasVinculadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrBtnEmpresas_Click(sender, e);
        }

        private void logoutDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrBtnLogout_Click(sender, e);
        }

        private void fecharTodosOsMódulosDeProcessosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrBtnFecharApps_Click(sender, e);
        }

        private void cascataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tlstrDdbCascadeLayout_Click(sender, e);
        }

        private void horizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tlstrDdbHorizontalLayout_Click(sender, e);
        }

        private void verticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tlstrDdbVerticalLayout_Click(sender, e);
        }

        private void apresentarMenuDeMódulosDeProcessosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrBtnShowMenu_Click(sender, e);
        }

        private void esconderMenuDeMódulosDeProcessosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlstrBtnHideMenu_Click(sender, e);
        }

        private void tlstpbtnFastAccessCodeMenu_Click(object sender, EventArgs e)
        {
            if (tlstptxtFastAccessCodeMenu.Text == string.Empty)
            {
                MessageBox.Show(FormsMessages.CodigoDeAcessoRapidoDoMenuMensagem,
                                    FormsMessages.CodigoDeAcessoRapidoDoMenuTitulo, 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
            }
            else 
            {
                if(!ValidationData.CreateInstance.ValidaAceiteSomenteNumeros(tlstptxtFastAccessCodeMenu.Text))
                {
                    MessageBox.Show(FormsMessages._CodigoDeAcessoRapidoDoMenuSomenteNumero,
                                    FormsMessages.CodigoDeAcessoRapidoDoMenuTitulo, 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
                }
                else
                {
                    if (_NroProcessos > 0)
                    {
                        int _CodigoDoProcesso = Convert.ToInt16(tlstptxtFastAccessCodeMenu.Text);

                        if (_CodigoDoProcesso == 0)
                        {
                            MessageBox.Show(FormsMessages.CodigoDeAcessoRapidoDoMenuMenorZero,
                                            FormsMessages.CodigoDeAcessoRapidoDoMenuTitulo,
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            AppStateSecurity.CodigoProcesso = _CodigoDoProcesso;

                            ChoosesProcessesByType(AppStateSecurity.CodigoProcesso);
                        }
                    }
                }
            }

            tlstptxtFastAccessCodeMenu.Clear();
        }

        private void frmDashboard_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    tlstrBtnLogin_Click(sender, e);
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    tlstrBtnHideMenu_Click(sender, e);
                    break;
                case Keys.F12:
                    tlstrBtnShowMenu_Click(sender, e);
                    break;
                case Keys.F13:
                    break;
                case Keys.F14:
                    break;
                case Keys.F15:
                    break;
                case Keys.F16:
                    break;
                case Keys.F17:
                    break;
                case Keys.F18:
                    break;
                case Keys.F19:
                    break;
                case Keys.F2:
                    tlstrBtnEmpresas_Click(sender, e);
                    break;
                case Keys.F20:
                    break;
                case Keys.F21:
                    break;
                case Keys.F22:
                    break;
                case Keys.F23:
                    break;
                case Keys.F24:
                    break;
                case Keys.F4:
                    tlstrBtnLogout_Click(sender, e);
                    break;
                case Keys.F5:
                    tlstrBtnFecharApps_Click(sender, e);
                    break;
                case Keys.F6:
                    tlstpBtnPlusMenu_Click(sender, e);
                    break;
                case Keys.F7:
                    tlstpBtnMinusMenu_Click(sender, e);
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    break;
                case Keys.Enter:
                    tlstpbtnFastAccessCodeMenu_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // inicializa o TreeView
            trvwMainMenu.ImageList = imgLstDashboard;
        }

        private void trvwMainMenu_AfterExpand(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Tag.ToString())
            {
                case "ERP_BrSoftNet":
                    e.Node.ImageIndex = 1;
                    e.Node.SelectedImageIndex = 1;
                    break;
                case "Aplicacoes":
                    e.Node.ImageIndex = 3;
                    e.Node.SelectedImageIndex = 3;
                    break;
                default:
                    break;
            }
        }

        private void trvwMainMenu_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Tag.ToString())
            {
                case "ERP_BrSoftNet":
                    e.Node.ImageIndex = 0;
                    e.Node.SelectedImageIndex = 0;
                    break;
                case "Aplicacoes":
                    e.Node.ImageIndex = 2;
                    e.Node.SelectedImageIndex = 2;
                    break;
                default:
                    break;
            }
        }

        private void trvwMainMenu_DoubleClick(object sender, EventArgs e)
        {
            string _DescricaoMenuProcesso;
            string[] _Texto = null;
            string _CodigoMenuProcesso;
            int _CodigoProcesso;

            switch (trvwMainMenu.SelectedNode.Tag.ToString())
            {
                case "Processos":
                    // Pega o Código do Processo na descrição do menu
                    _DescricaoMenuProcesso = trvwMainMenu.SelectedNode.Text;
                    _Texto = _DescricaoMenuProcesso.Split('-');
                    _CodigoMenuProcesso = _Texto[0];
                    _CodigoProcesso = Convert.ToInt32(_CodigoMenuProcesso);
                    this.ChoosesProcessesByType(_CodigoProcesso);
                    break;
                default:
                    break;
            }

        }
    }
}
