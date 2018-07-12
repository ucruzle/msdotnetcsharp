//using BrSoftNet.App.Business.Processes.Security.Entities;
//using BrSoftNet.App.Business.Processes.Security.Tasks;
//using BrSoftNet.App.UI.Win.Main.AuthenticationForm;
//using BrSoftNet.App.UI.Win.Main.State;
//using BrSoftNet.App.UI.Win.Manager.FullScreenSearchForm;
//using BrSoftNet.App.UI.Win.OverallRecord.FullScreenSearchForm;
//using BrSoftNet.App.UI.Win.Security.AuthenticationForm;
using BrSoftNet.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BrSoftNet.Log.App.UI.Win.MonitorChanges
{
    public partial class frmDashboard : Form
    {
        public string _DataLogonUsuario = "Usuário - {0}";
        public string _DataLogonUsuarioEmpresa = "Usuário - {0} | Empresa - {1}";
        public string _DataLogonUsuarioEmpresaAplicacao = "Usuário - {0} | Empresa - {1} | Aplicação - {2}";
        public int _CodigoProcesso = 0;
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

        //private void tlstrBtnLogin_Click(object sender, EventArgs e)
        //{
        //    LoginForm _LoginForm = new LoginForm();

        //    try
        //    {
        //        _LoginForm.ShowDialog();
        //    }
        //    finally
        //    {
        //        AppStateSecurity.Usuario = _LoginForm.Usuario;
        //        AppStateSecurity.Nome = _LoginForm.Nome;
        //        AppStateSecurity.EmpresaLoginCollection = _LoginForm.EmpresaLoginCollection;

        //        _LoginForm = null;
        //    }

        //    if (!string.IsNullOrEmpty(AppStateSecurity.Nome))
        //    {
        //        tlstrlblDataLogon.Text = string.Format(_DataLogonUsuario, AppStateSecurity.Nome);
        //    }
        //}

        //private void tlstrBtnEmpresas_Click(object sender, EventArgs e)
        //{
        //    CompanyForm _CompanyForm = new CompanyForm();

        //    try
        //    {
        //        _CompanyForm.ShowDialog();
        //    }
        //    finally
        //    {
        //        AppStateSecurity.CodigoEmpresa = _CompanyForm.CodigoEmpresa;
        //        AppStateSecurity.NomeFantasia = _CompanyForm.NomeFantasia;
        //        AppStateSecurity.AplicacaoLoginCollection = _CompanyForm.AplicacaoLoginCollection;

        //        _CompanyForm = null;
        //    }

        //    if (!string.IsNullOrEmpty(AppStateSecurity.Nome) && !string.IsNullOrEmpty(AppStateSecurity.NomeFantasia))
        //    {
        //        tlstrlblDataLogon.Text = string.Format(_DataLogonUsuarioEmpresa, AppStateSecurity.Nome, AppStateSecurity.NomeFantasia);
        //    }
        //}

        //private void tlstrBtnApps_Click(object sender, EventArgs e)
        //{
        //    ApplicationForm _ApplicationForm = new ApplicationForm();

        //    try
        //    {
        //        _ApplicationForm.ShowDialog();
        //    }
        //    finally
        //    {
        //        AppStateSecurity.CodigoAplicacao = _ApplicationForm.CodigoAplicacao;
        //        AppStateSecurity.NomeAplicacao = _ApplicationForm.NomeAplicacao;
        //        AppStateSecurity.TipoProcessoCollection = _ApplicationForm.TipoProcessoCollection;

        //        _ApplicationForm = null;
        //    }

        //    if (!string.IsNullOrEmpty(AppStateSecurity.Nome) && !string.IsNullOrEmpty(AppStateSecurity.NomeFantasia) && !string.IsNullOrEmpty(AppStateSecurity.NomeAplicacao))
        //    {
        //        tlstrlblDataLogon.Text = string.Format(_DataLogonUsuarioEmpresaAplicacao, AppStateSecurity.Nome, AppStateSecurity.NomeFantasia, AppStateSecurity.NomeAplicacao);
        //    }

        //    FillProcessesMenu();
        //}

        //private void FillProcessesMenu()
        //{
            //if (AppStateSecurity.TipoProcessoCollection != null)
            //{
            //    if (trvwMainMenu.Nodes.Count > 0)
            //    {
            //        trvwMainMenu.Nodes.Clear();
            //    }

            //    TreeNode _Root = new TreeNode(AppStateSecurity.NomeAplicacao);
            //    _Root.Name = AppStateSecurity.NomeAplicacao;
            //    trvwMainMenu.Nodes.Add(_Root);

            //    foreach (TipoProcessoLogin _TipoProcessoLogin in AppStateSecurity.TipoProcessoCollection)
            //    {
            //        TreeNode _TipoProcessoNode = new TreeNode(_TipoProcessoLogin.DescricaoTipoProcesso);
            //        _TipoProcessoNode.Name = _TipoProcessoLogin.DescricaoTipoProcesso;

            //        _Root.Nodes.Add(_TipoProcessoNode);

            //        List<ProcessoLogin> _ProcessoLoginCollection = null;

            //        _ProcessoLoginCollection = AccessTask.CreateInstance.GetProcessoLoginTask(AppStateSecurity.CodigoAplicacao, _TipoProcessoLogin.CodigoTipoProcesso);

            //        foreach (ProcessoLogin _ProcessoLogin in _ProcessoLoginCollection)
            //        {
            //            string _ProcessName = string.Format("{0} - {1}", _ProcessoLogin.CodigoProcesso.ToString(), _ProcessoLogin.DescricaoProcesso);

            //            TreeNode _Processo = new TreeNode(_ProcessName);
            //            _Processo.Tag = _ProcessoLogin.CodigoProcesso;
            //            _Processo.Name = _ProcessName;

            //            _TipoProcessoNode.Nodes.Add(_Processo);
            //        }
            //    }
            //}
        //}

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
            if (trvwMainMenu.Nodes.Count > 0)
            {
                foreach (TreeNode _TreeNode in trvwMainMenu.Nodes)
                {
                    _TreeNode.ExpandAll();
                }
            }
        }

        private void tlstpBtnMinusMenu_Click(object sender, EventArgs e)
        {
            if (trvwMainMenu.Nodes.Count > 0)
            {
                foreach (TreeNode _TreeNode in trvwMainMenu.Nodes)
                {
                    _TreeNode.Collapse();
                }
            }
        }

        private void trvwMainMenu_DoubleClick(object sender, EventArgs e)
        {
            if (trvwMainMenu.SelectedNode != null)
            {
                object _TagProcesso = trvwMainMenu.SelectedNode.Tag;

                if (_TagProcesso != null)
                {
                    //AppStateSecurity.CodigoProcesso = (int)_TagProcesso;
                }

                //ChoosesProcessesByType(AppStateSecurity.CodigoProcesso);
            }
        }

        private void ChoosesProcessesByType(int _CodigoProcesso)
        {
            switch (_CodigoProcesso)
            {
                //case 1:
                //    ProcessCallEmpresa();
                //    break;
                //case 2:
                //    ProcessCallAplicacao();
                //    break;
                //case 3:
                //    ProcessCallProcesso();
                //    break;
                //case 4:
                //    ProcessCallUsuario();
                //    break;
                //case 5:
                //    ProcessCallGrupo();
                //    break;
                //case 6:
                //    ProcessCallRegistroGeral();
                //    break;
                //case 7:
                //    ProcessCallMunicipio();
                //    break;
                //case 8:
                //    ProcessCallEstado();
                //    break;
                //case 9:
                //    ProcessCallNatureza();
                //    break;
                //case 10:
                //    ProcessCallStatus();
                //    break;
                //case 11:
                //    ProcessCallTipoFone();
                //    break;
                //case 12:
                //    ProcessCallTipoRG();
                //    break;
                //case 35:
                //    ProcessCallTipoProcesso();
                //    break;
                //case 51:
                //    ProcessCallGrupoProcesso();
                //    break;
                //case 52:
                //    ProcessCallParametroGerenciador();
                //    break;
                //case 53:
                //    ProcessCallEmpresaAplicacao();
                //    break;
                //case 54:
                //    ProcessCallUsuarioGrupo();
                //    break;
                //case 55:
                //    ProcessCallLiberacaoUsuario();
                //    break;
                //case 57:
                //    ProcessCallRegiao();
                //    break;
                //case 61:
                //    ProcessCallParamRegGeral();
                //    break;
                //case 75:
                //    ProcessCallEmpresaConsolidada();
                //    break;
                //default:
                //    MessageBox.Show(string.Format("Usuário: {0} não autorizado para execução deste processo.", AppStateSecurity.Usuario), "Acesso não Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    break;
            }
        }

        //private void ProcessCallEmpresaAplicacao()
        //{
             
        //    SearchFormEmpresaAplicacao _SearchFormEmpresaAplicacao = new SearchFormEmpresaAplicacao();
        //    _SearchFormEmpresaAplicacao.MdiParent = this;

        //    try
        //    {
        //        _SearchFormEmpresaAplicacao.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
                
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormEmpresaAplicacao = null;
        //    }

        //}

        //private void ProcessCallLiberacaoUsuario()
        //{
        //    SearchFormLiberacaoUsuario _SearchFormLiberacaoUsuario = new SearchFormLiberacaoUsuario();
        //    _SearchFormLiberacaoUsuario.MdiParent = this;

        //    try
        //    {
        //        _SearchFormLiberacaoUsuario.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormLiberacaoUsuario = null;
        //    }
        //}

        //private void ProcessCallEmpresa()
        //{
        //    SearchFormEmpresa _SearchFormEmpresa = new SearchFormEmpresa();
        //    _SearchFormEmpresa.MdiParent = this;

        //    try
        //    {
        //        _SearchFormEmpresa.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormEmpresa = null;
        //    }
        //}

        //private void ProcessCallAplicacao()
        //{
        //    SearchFormAplicacao _SearchFormAplicacao = new SearchFormAplicacao();
        //    _SearchFormAplicacao.MdiParent = this;

        //    try
        //    {
        //        _SearchFormAplicacao.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormAplicacao = null;
        //    }
        //}

        //private void ProcessCallProcesso() 
        //{
        //    SearchFormProcesso _SearchFormProcesso = new SearchFormProcesso();
        //    _SearchFormProcesso.MdiParent = this;

        //    try
        //    {
        //        _SearchFormProcesso.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally 
        //    {
        //        _SearchFormProcesso = null;
        //    }
        //}

        //private void ProcessCallUsuario()
        //{
        //    SearchFormUsuario _SearchFormUsuario = new SearchFormUsuario();
        //    _SearchFormUsuario.MdiParent = this;

        //    try
        //    {
        //        _SearchFormUsuario.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormUsuario = null;
        //    }
        //}

        //private void ProcessCallGrupo()
        //{
        //    SearchFormGrupo _SearchFormGrupo = new SearchFormGrupo();
        //    _SearchFormGrupo.MdiParent = this;

        //    try
        //    {
        //        _SearchFormGrupo.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormGrupo = null;
        //    }
        //}

        //private void ProcessCallRegistroGeral() 
        //{
        //    SearchFormRegistroGeral _SearchFormRegistroGeral = new SearchFormRegistroGeral();
        //    _SearchFormRegistroGeral.MdiParent = this;

        //    _SearchFormRegistroGeral.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
        //    _SearchFormRegistroGeral.UsuarioLoginDashboard = AppStateSecurity.Usuario;

        //    try
        //    {
        //        _SearchFormRegistroGeral.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally 
        //    {
        //        _SearchFormRegistroGeral = null;
        //    }
        //}

        //private void ProcessCallMunicipio()
        //{
        //    SearchFormMunicipio _SearchFormMunicipio = new SearchFormMunicipio();
        //    _SearchFormMunicipio.MdiParent = this;

        //    try
        //    {
        //        _SearchFormMunicipio.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormMunicipio = null;
        //    }
        //}

        //private void ProcessCallEstado()
        //{
        //    SearchFormEstado _SearchFormEstado = new SearchFormEstado();
        //    _SearchFormEstado.MdiParent = this;

        //    try
        //    {
        //        _SearchFormEstado.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormEstado = null;
        //    }
        //}

        //private void ProcessCallNatureza()
        //{
        //    SearchFormNatureza _SearchFormNatureza = new SearchFormNatureza();
        //    _SearchFormNatureza.MdiParent = this;

        //    _SearchFormNatureza.IdEmpresaFromDashboard = AppStateSecurity.CodigoEmpresa;
        //    _SearchFormNatureza.UsuarioLoginDashboard = AppStateSecurity.Usuario;

        //    try
        //    {
        //        _SearchFormNatureza.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormNatureza = null;
        //    }
        //}

        //private void ProcessCallStatus()
        //{
        //    SearchFormStatus _SearchFormStatus = new SearchFormStatus();
        //    _SearchFormStatus.MdiParent = this;

        //    try
        //    {
        //        _SearchFormStatus.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormStatus = null;
        //    }
        //}

        //private void ProcessCallTipoFone()
        //{
        //    SearchFormTipoFone _SearchFormTipoFone = new SearchFormTipoFone();
        //    _SearchFormTipoFone.MdiParent = this;

        //    try
        //    {
        //        _SearchFormTipoFone.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormTipoFone = null;
        //    }
        //}

        //private void ProcessCallTipoRG()
        //{
        //    SearchFormTipoRg _SearchFormTipoRg = new SearchFormTipoRg();
        //    _SearchFormTipoRg.MdiParent = this;

        //    try
        //    {
        //        _SearchFormTipoRg.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormTipoRg = null;
        //    }
        //}

        //private void ProcessCallTipoProcesso()
        //{
        //    SearchFormTipoProcesso _SearchFormTipoProcesso = new SearchFormTipoProcesso();
        //    _SearchFormTipoProcesso.MdiParent = this;

        //    try
        //    {
        //        _SearchFormTipoProcesso.Show();
        //    }
        //    catch (Exception _Exception)
        //    {
                
        //        throw _Exception;
        //    }
        //    finally
        //    {
        //        _SearchFormTipoProcesso = null;
        //    }
        //}
        //private void ProcessCallGrupoProcesso()
        //{
        //    SearchFormGrupoProcesso _SearchFormGrupoProcesso = new SearchFormGrupoProcesso();
        //    _SearchFormGrupoProcesso.MdiParent = this;

        //    try
        //    {
        //        _SearchFormGrupoProcesso.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormGrupoProcesso = null;
        //    }
        //}

        //private void ProcessCallParametroGerenciador()
        //{
        //    SearchFormParametroGerenciador _SearchFormParametroGerenciador = new SearchFormParametroGerenciador();
        //    _SearchFormParametroGerenciador.MdiParent = this;

        //    try
        //    {
        //        _SearchFormParametroGerenciador.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormParametroGerenciador = null;
        //    }
        //}

        //private void ProcessCallUsuarioGrupo()
        //{
        //    SearchFormUsuarioUsuarioGrupo _SearchFormUsuarioUsuarioGrupo = new SearchFormUsuarioUsuarioGrupo();
        //    _SearchFormUsuarioUsuarioGrupo.MdiParent = this;

        //    try
        //    {
        //        _SearchFormUsuarioUsuarioGrupo.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormUsuarioUsuarioGrupo = null;
        //    }
        //}

        //private void ProcessCallRegiao()
        //{
        //    SearchFormRegiao _SearchFormRegiao = new SearchFormRegiao();
        //    _SearchFormRegiao.MdiParent = this;

        //    try
        //    {
        //        _SearchFormRegiao.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormRegiao = null;
        //    }
        //}

        //private void ProcessCallParamRegGeral()
        //{
        //    SearchFormParamRegGeral _SearchFormParamRegGeral = new SearchFormParamRegGeral();
        //    _SearchFormParamRegGeral.MdiParent = this;

        //    try
        //    {
        //        _SearchFormParamRegGeral.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormParamRegGeral = null;
        //    }
        //}

        //private void ProcessCallEmpresaConsolidada()
        //{
        //    SearchFormEmpresaConsolidada _SearchFormEmpresaConsolidada = new SearchFormEmpresaConsolidada();
        //    _SearchFormEmpresaConsolidada.MdiParent = this;

        //    try
        //    {
        //        _SearchFormEmpresaConsolidada.Show();
        //    }
        //    catch (Exception _Ex)
        //    {
        //        throw _Ex;
        //    }
        //    finally
        //    {
        //        _SearchFormEmpresaConsolidada = null;
        //    }
        //}

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //tlstrBtnLogin_Click(sender, e);
        }

        private void empresasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //tlstrBtnEmpresas_Click(sender, e);
        }

        private void aplicaçõesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //tlstrBtnApps_Click(sender, e);
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
            //tlstrBtnLogin_Click(sender, e);
        }

        private void empresasVinculadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tlstrBtnEmpresas_Click(sender, e);
        }

        private void aplicaçõesDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tlstrBtnApps_Click(sender, e);
        }

        private void logoutDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tlstrBtnLogout_Click(sender, e);
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
            //if (AppStateSecurity.TipoProcessoCollection != null)
            //{
            //    int _CodigoDoProcesso = Convert.ToInt16(tlstptxtFastAccessCodeMenu.Text) > 0 ? Convert.ToInt16(tlstptxtFastAccessCodeMenu.Text) : 0;

            //    AppStateSecurity.CodigoProcesso = _CodigoDoProcesso;

            //    ChoosesProcessesByType(AppStateSecurity.CodigoProcesso);
            //}

            //tlstptxtFastAccessCodeMenu.Clear();
        }

        private void frmDashboard_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    //tlstrBtnLogin_Click(sender, e);
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    //tlstrBtnHideMenu_Click(sender, e);
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
                    //tlstrBtnEmpresas_Click(sender, e);
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
                case Keys.F3:
                    //tlstrBtnApps_Click(sender, e);
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
                default:
                    break;
            }
        }

    }
}
