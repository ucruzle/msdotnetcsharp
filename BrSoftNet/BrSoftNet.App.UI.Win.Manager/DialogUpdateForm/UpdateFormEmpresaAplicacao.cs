using System.Windows.Forms;
using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using System;
using System.Data;
using System.Collections.Generic;
using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.UI.Win.Manager.State;
using System.Drawing;
using BrSoftNet.Log.Structures;
using BrSoftNet.Log.Helpers;
using BrSoftNet.Log.Actions;

namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormEmpresaAplicacao : Form
    {
        #region...::: Properties :::...
        public ModificaEmpresaAplicacaoType _ModificaEmpresaAplicacaoType { get; set; }
        public int CodigoEmpresa { get; set; }
        public int CodigoAplicacao { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }
        public string UsuarioLogin { get; set; }

        // Private Properties
        private List<GeEmpresa> GeEmpresaCollection { get; set; }
        private List<GeAplicacao> GeAplicacaoCollection { get; set; }

        

        #endregion

        #region ...::: Private Fields :::...

        private DataSet _DataSetEmpresaAplicacaoPorVinculo = null;
        private List<GeEmpresa> _GeEmpresaCollection = null;
        private List<GeAplicacao> _GeAplicacaoCollection = null;

        #endregion

        #region ...::: Private Log Variable :::...

        private ChangesHeader _ChangesHeader = null;

        private ChangeItem _LogCodigoEmpresa = null;
        private ChangeItem _LogCodigoAplicacao = null;

        private List<ChangeItem> _ChangeItems = null;
        private ThrowingException _ThrowingException = null;

        private string _IdExcepitionLog = string.Empty;
        private string _MenssageLogError = string.Empty;

        #endregion
        public UpdateFormEmpresaAplicacao()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.cmbBxEmpresa.GotFocus += cmbBxEmpresa_GotFocus;
            this.cmbBxEmpresa.LostFocus += cmbBxEmpresa_LostFocus;

            this.cmbBxAplicacao.GotFocus += cmbBxAplicacao_GotFocus;
            this.cmbBxAplicacao.LostFocus += cmbBxAplicacao_LostFocus;
        }

        private void cmbBxAplicacao_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxAplicacao.BackColor = Color.White;
        }

        private void cmbBxAplicacao_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxAplicacao.BackColor = Color.LightYellow;
        }

        private void cmbBxEmpresa_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresa.BackColor = Color.White;
        }

        private void cmbBxEmpresa_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresa.BackColor = Color.LightYellow;
        }

        private void InicialiazeUpdateForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void UpdateFormEmpresaAplicacao_Load(object sender, EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            _DataSetEmpresaAplicacaoPorVinculo = EmpresaAplicacaoProcess.CreateInstance.TaskGetCollectionGeEmpresaAplicacaoPorVinculo();

            FillEmpesaCollection();
            FillAplicacaoCollection();

            switch (_ModificaEmpresaAplicacaoType)
            {
                case ModificaEmpresaAplicacaoType.EmpresaAplicacaoAdicionar:
                    FillEmpresaAplicacaoToAddModify();
                    break;
                case ModificaEmpresaAplicacaoType.EmpresaAplicacaoAlterar:
                    FillEmpresaAplicacaoToUpdateModify();
                    break;
                default:
                    break;
            }
        }

        private void FillEmpresaAplicacaoToUpdateModify()
        {
            cmbBxEmpresa.DataSource = GeEmpresaCollection;
            cmbBxEmpresa.ValueMember = "CodigoEmpresa";
            cmbBxEmpresa.DisplayMember = "DescricaoEmpresa";
            cmbBxEmpresa.SelectedValue = this.CodigoEmpresa;

            cmbBxAplicacao.DataSource = GeAplicacaoCollection;
            cmbBxAplicacao.ValueMember = "CodigoAplicacao";
            cmbBxAplicacao.DisplayMember = "DescricaoAplicacao";
            cmbBxAplicacao.SelectedValue = this.CodigoAplicacao;

            AppStateManager.CodigoEmpresaPorVinculo = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            AppStateManager.CodigoApicacaoPorVinculo = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
        }

        private void FillEmpresaAplicacaoToAddModify()
        {
            cmbBxEmpresa.DataSource = GeEmpresaCollection;
            cmbBxEmpresa.ValueMember = "CodigoEmpresa";
            cmbBxEmpresa.DisplayMember = "DescricaoEmpresa";

            cmbBxAplicacao.DataSource = GeAplicacaoCollection;
            cmbBxAplicacao.ValueMember = "CodigoAplicacao";
            cmbBxAplicacao.DisplayMember = "DescricaoAplicacao";

            AppStateManager.CodigoEmpresaPorVinculo = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            AppStateManager.CodigoApicacaoPorVinculo = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
        }

        private void FillAplicacaoCollection()
        {
            if (_GeAplicacaoCollection == null)
            {
                _GeAplicacaoCollection = new List<GeAplicacao>();
            }

            foreach (DataRow _Row in _DataSetEmpresaAplicacaoPorVinculo.Tables[1].Rows)
            {
                _GeAplicacaoCollection.Add(new GeAplicacao(_Row));
            }

            GeAplicacaoCollection = _GeAplicacaoCollection;
        }

        private void FillEmpesaCollection()
        {
            if (_GeEmpresaCollection == null)
            {
                _GeEmpresaCollection = new List<GeEmpresa>();
            }

            foreach (DataRow _Row in _DataSetEmpresaAplicacaoPorVinculo.Tables[0].Rows)
            {
                _GeEmpresaCollection.Add(new GeEmpresa(_Row));
            }

            GeEmpresaCollection = _GeEmpresaCollection;
        }

        private void tlstrpActionMenuBtnConfirm_Click(object sender, EventArgs e)
        {
            ExecuteModifyEmpresaAplicacao();

            if (_IdExcepitionLog != string.Empty)
            {
                tlstrpActionMenuBtnConfirm.Enabled = false;
                tlstrpLblExcecao.Text = _MenssageLogError;
                tlstrpLblExcecao.Visible = true;
                return;
            }

            this.Close();
        }
        private void ExecuteModifyEmpresaAplicacao()
        {
            switch (_ModificaEmpresaAplicacaoType)
            {
                case ModificaEmpresaAplicacaoType.EmpresaAplicacaoAdicionar:
                    FillLogHeaderFromAddModify();
                    ExecuteAdicionaEmpresaAplicacao();
                    break;
               /* case ModificaEmpresaAplicacaoType.EmpresaAplicacaoAlterar:
                    ExecuteUpdateEmpresaAplicacao();
                    break;*/
            }
        }
          

        private void ExecuteAdicionaEmpresaAplicacao()
        {
            const string _FUNCAO_DISPARADOR = "ExecuteAddEmpresaAplicação";

            int _CodigoEmpresa = 0;
            int _CodigoAplicacao = 0;
            int _IdExecute = 0;
            string _TipoModificacao = string.Empty;

            _CodigoEmpresa = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            _CodigoAplicacao = Convert.ToInt32(cmbBxAplicacao.SelectedValue);
            _TipoModificacao = EmpresaAplicacaoProcess.CreateInstance.FromToModificaEmpresaAplicacao(ModificaEmpresaAplicacaoType.EmpresaAplicacaoAlterar);
            _TipoModificacao = EmpresaAplicacaoProcess.CreateInstance.FromToModificaEmpresaAplicacao(ModificaEmpresaAplicacaoType.EmpresaAplicacaoAdicionar);
            
            try
            {
                if (_ThrowingException != null) { _ThrowingException = null; }
                _IdExecute = EmpresaAplicacaoProcess.CreateInstance.TaskModifyProcessEmpresaAplicacao(_CodigoEmpresa, _CodigoAplicacao, string.Empty, string.Empty, _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "E"; }

                #endregion

                #region ...::: Atualiza o cabeçalho do Log de Exceções :::...

                _ThrowingException = new ThrowingException();
                _ThrowingException.Id = ServiceHelper.CreateInstance.GetIDExceptions();
                _ThrowingException.IdChangeHeader = _ChangesHeader.Id;
                _ThrowingException.Formulario = this.Name;
                _ThrowingException.FuncaoDisparador = _FUNCAO_DISPARADOR;
                _ThrowingException.Tarefa = _Exception.TargetSite.ToString();
                _ThrowingException.TipoExcecao = _Exception.GetType().ToString();
                _ThrowingException.MensagemExcecao = _Exception.Message;

                #endregion

                #region ...::: Atualiza os Itens do Log de Modificações :::...

                if (_LogCodigoEmpresa != null) { _LogCodigoEmpresa.ValorNovo = _CodigoEmpresa; }
                if (_LogCodigoAplicacao != null) { _LogCodigoAplicacao.ValorNovo = _CodigoAplicacao; }


                _ChangeItems = new List<ChangeItem>();
                _ChangeItems.Add(_LogCodigoEmpresa);
                _ChangeItems.Add(_LogCodigoAplicacao);

                #endregion

                ExecuteModifyExceptionLogEmpresaAplicacao(_ChangesHeader, _ChangeItems, _ThrowingException);
            }
            finally
            {
                if (_ThrowingException == null)
                {

                    #region ...::: Atualiza o cabeçalho do Log de Modificações :::...

                    if (_ChangesHeader != null) { _ChangesHeader.StatusExecucao = "S"; }

                    #endregion

                    #region ...::: Atualiza os Itens do Log de Modificações :::...

                    if (_LogCodigoEmpresa != null) { _LogCodigoEmpresa.ValorNovo = _CodigoEmpresa; }
                    if (_LogCodigoAplicacao != null) { _LogCodigoAplicacao.ValorNovo = _CodigoAplicacao; }


                    _ChangeItems = new List<ChangeItem>();
                    _ChangeItems.Add(_LogCodigoEmpresa);
                    _ChangeItems.Add(_LogCodigoAplicacao);

                    #endregion


                    ExecuteModifyLogEmpresaAplicacao(_ChangesHeader, _ChangeItems);
                }
                else
                {
                    _MenssageLogError = string.Format("Erro na execução do processo, nº incidente {0}", _IdExcepitionLog);
                }
            }
        }
        private void ExecuteModifyLogEmpresaAplicacao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems)
        {
            ChangeAction.CreateInstance.ActionExecuteChangeLog(_ChangesHeader, _ChangeItems);
        }

        private void ExecuteModifyExceptionLogEmpresaAplicacao(ChangesHeader _ChangesHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            ExceptionAction.CreateInstance.ActionExecuteExceptionLog(_ChangesHeader, _ChangeItems, _ThrowingException);
        }

        private void FillLogHeaderFromAddModify()
        {
            #region ...::: Log Header :::...

            _ChangesHeader = new ChangesHeader();
            _ChangesHeader.Id = ServiceHelper.CreateInstance.GetIDChanges();
            _ChangesHeader.NomeProcesso = DboGeEmpresaAplicacao.NomeProcesso;
            _ChangesHeader.CodigoRegistro = this.CodigoEmpresa;
            _ChangesHeader.TipoModificacao = EmpresaAplicacaoProcess.CreateInstance.FromToModificaEmpresaAplicacao(ModificaEmpresaAplicacaoType.EmpresaAplicacaoAdicionar);
            _ChangesHeader.Usuario = this.UsuarioLogin;
            _ChangesHeader.DataHora = DateTime.Now;

            #endregion

            #region ...::: Log Item :::...

            //Codigo Empresa
            _LogCodigoEmpresa = new ChangeItem();
            _LogCodigoEmpresa.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoEmpresa.IdItem = 1;
            _LogCodigoEmpresa.NomeTabela = DboGeEmpresaAplicacao.NomeTabela;
            _LogCodigoEmpresa.NomeCampo = DboGeEmpresaAplicacao.NomeCodigoEmpresa;
            _LogCodigoEmpresa.ValorAntigo = CodigoEmpresa;

            //Codigo Aplicação
            _LogCodigoAplicacao = new ChangeItem();
            _LogCodigoAplicacao.IdChangeHeader = _ChangesHeader.Id;
            _LogCodigoAplicacao.IdItem = 2;
            _LogCodigoAplicacao.NomeTabela = DboGeEmpresaAplicacao.NomeTabela;
            _LogCodigoAplicacao.NomeCampo = DboGeEmpresaAplicacao.NomeCodigoAplicacao;
            _LogCodigoAplicacao.ValorAntigo = CodigoAplicacao;

            #endregion
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    internal static class DboGeEmpresaAplicacao
    {
        #region ...::: Private Constantes :::...

        private const string _NomeCodigoAplicacao = "cod_aplic";
        private const string _NomeCodigoEmpresa = "cod_empr";
        private const string _NomeTabela = "ge_empresa_aplicacao";
        private const string _NomeProcesso = "Empresa Aplicação";

        #endregion

        #region ...::: Public Properties :::...

        public static string NomeCodigoAplicacao { get { return _NomeCodigoAplicacao; } }
        public static string NomeCodigoEmpresa { get { return _NomeCodigoEmpresa; } }
        public static string NomeTabela { get { return _NomeTabela; } }
        public static string NomeProcesso { get { return _NomeProcesso; } }

        #endregion
    }
}
