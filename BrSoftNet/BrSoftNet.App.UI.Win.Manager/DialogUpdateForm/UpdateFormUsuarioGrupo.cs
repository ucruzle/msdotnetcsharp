using BrSoftNet.App.Business.Processes.Manager.Entities;
using BrSoftNet.App.Business.Processes.Manager.Enumerators;
using BrSoftNet.App.Business.Processes.Manager.Tasks;
using BrSoftNet.App.UI.Win.Manager.State;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    public partial class UpdateFormUsuarioGrupo : Form
    {
        #region ...::: Private Variable :::...

        private string _TipoModificacao = string.Empty;

        private int _IdExecute = 0;

        private DataSet _DataSetProcessoUsuarioGrupo = null;

        public List<GeEmpresa> _EmpresaCollection = null;

        public List<GeUsuario> _UsuarioCollection = null;

        public List<GeGrupo> _GrupoCollection = null;

        #endregion

        #region ...::: Public Properties :::...

        public int IdEmpr { get; set; }
        public int IdRg { get; set; }
        public string UsuarioLogin { get; set; }
        public ModificaUsuarioGrupoType ModificaUsuarioGrupoType { get; set; }
        public int CodigoEmpresa { get; set; }
        public int CodigoGrupo { get; set; }
        public string Usuario { get; set; }
        public string TextoDoTilutoDoFormulario { get; set; }

        #endregion

        #region ...::: Private Properties :::...

        public List<GeEmpresa> EmpresaCollection { get; set; }
        public List<GeUsuario> UsuarioCollection { get; set; }
        public List<GeGrupo> GrupoCollection { get; set; }

        #endregion

        public UpdateFormUsuarioGrupo()
        {
            InitializeComponent();
            this.InicialiazeUpdateForm();

            this.cmbBxEmpresa.GotFocus += cmbBxEmpresa_GotFocus;
            this.cmbBxEmpresa.LostFocus += cmbBxEmpresa_LostFocus;

            this.cmbBxUsuario.GotFocus += cmbBxUsuario_GotFocus;
            this.cmbBxUsuario.LostFocus += cmbBxUsuario_LostFocus;

            this.cmbBxGrupo.LostFocus += cmbBxGrupo_LostFocus;
            this.cmbBxGrupo.GotFocus += cmbBxGrupo_GotFocus;
        }

        void cmbBxGrupo_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxGrupo.BackColor = Color.LightYellow;
        }

        void cmbBxGrupo_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxGrupo.BackColor = Color.White;
        }

        void cmbBxUsuario_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxUsuario.BackColor = Color.White;
        }

        void cmbBxUsuario_GotFocus(object sender, EventArgs e)
        {
            this.cmbBxUsuario.BackColor = Color.LightYellow;
        }

        void cmbBxEmpresa_LostFocus(object sender, EventArgs e)
        {
            this.cmbBxEmpresa.BackColor = Color.White;
        }

        void cmbBxEmpresa_GotFocus(object sender, EventArgs e)
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

        private void tlstrpActionMenuBtnConfirm_Click(object sender, System.EventArgs e)
        {
            ExecuteModifyUsuarioGrupo();
            this.Close();
        }

        private void tlstrpActionMenuBtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ExecuteModifyUsuarioGrupo()
        {
            switch (ModificaUsuarioGrupoType)
            {
                case ModificaUsuarioGrupoType.UsuarioGrupoAdicionar:
                    ExecuteAddUsuarioGrupo();
                    break;
                case ModificaUsuarioGrupoType.UsuarioGrupoAlterar:
                    ExecuteUpdateUsuarioGrupo();
                    break;
            }
        }

        private void ExecuteUpdateUsuarioGrupo()
        {
            int _CodigoEmpresa = 0;
            string _Usuario = string.Empty;
            int _CodigoGrupo = 0;

            _CodigoEmpresa = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            _Usuario = Convert.ToString(cmbBxUsuario.SelectedValue);
            _CodigoGrupo = Convert.ToInt32(cmbBxGrupo.SelectedValue);
            _TipoModificacao = UsuarioGrupoProcess.CreateInstance.FromToModificaUsuarioGrupo(ModificaUsuarioGrupoType.UsuarioGrupoAlterar);

            try
            {
                _IdExecute = UsuarioGrupoProcess.CreateInstance.TaskModifyProcessUsuarioGrupo(_CodigoEmpresa, _CodigoGrupo, _Usuario, _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
            finally
            {

            }
        }

        private void ExecuteAddUsuarioGrupo()
        {
            int _CodigoEmpresa = 0;
            string _Usuario = string.Empty;
            int _CodigoGrupo = 0;

            _CodigoEmpresa = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            _Usuario = Convert.ToString(cmbBxUsuario.SelectedValue);
            _CodigoGrupo = Convert.ToInt32(cmbBxGrupo.SelectedValue);
            _TipoModificacao = UsuarioGrupoProcess.CreateInstance.FromToModificaUsuarioGrupo(ModificaUsuarioGrupoType.UsuarioGrupoAlterar);
            _TipoModificacao = UsuarioGrupoProcess.CreateInstance.FromToModificaUsuarioGrupo(ModificaUsuarioGrupoType.UsuarioGrupoAdicionar);

            try
            {
                _IdExecute = UsuarioGrupoProcess.CreateInstance.TaskModifyProcessUsuarioGrupo(_CodigoEmpresa, _CodigoGrupo, _Usuario, _TipoModificacao);
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
            finally
            {

            }
        }

        private void UpdateFormUsuarioGrupo_Load(object sender, System.EventArgs e)
        {
            this.lblTitleModule.Text = TextoDoTilutoDoFormulario;

            _DataSetProcessoUsuarioGrupo = UsuarioGrupoProcess.CreateInstance.TaskGetCollectionsProcessoUsuarioGrupo();

            if (ModificaUsuarioGrupoType == ModificaUsuarioGrupoType.UsuarioGrupoAlterar)
            {
                FillDataParametersToExecuteUpdateModify();
            }

            if (ModificaUsuarioGrupoType == ModificaUsuarioGrupoType.UsuarioGrupoAdicionar)
            {
                FillDataParametersToExecuteAddModify();
            }
        }

        private void FillDataParametersToExecuteAddModify()
        {
            PreencheEmpresaCollection();
            PreencheUsuarioCollection();
            PreencheGrupoCollection();

            cmbBxEmpresa.DataSource = EmpresaCollection;
            cmbBxEmpresa.ValueMember = "CodigoEmpresa";
            cmbBxEmpresa.DisplayMember = "DescricaoEmpresa";

            cmbBxUsuario.DataSource = UsuarioCollection;
            cmbBxUsuario.ValueMember = "Usuario";
            cmbBxUsuario.DisplayMember = "Nome";

            cmbBxGrupo.DataSource = GrupoCollection;
            cmbBxGrupo.ValueMember = "CodigoGrupo";
            cmbBxGrupo.DisplayMember = "DescricaoGrupo";

            AppStateManager.CodigoEmpresaUsuarioGrupo = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            AppStateManager.UserUsuarioGrupo = Convert.ToString(cmbBxUsuario.SelectedValue);
            AppStateManager.CodigoGrupoUsuarioGrupo = Convert.ToInt32(cmbBxGrupo.SelectedValue);
        }

        private void PreencheGrupoCollection()
        {
            if (_GrupoCollection == null)
            {
                _GrupoCollection = new List<GeGrupo>();
            }

            foreach (DataRow _Row in _DataSetProcessoUsuarioGrupo.Tables[2].Rows)
            {
                _GrupoCollection.Add(new GeGrupo(_Row));
            }

            GrupoCollection = _GrupoCollection;
        }

        private void PreencheUsuarioCollection()
        {
            if (_UsuarioCollection == null)
            {
                _UsuarioCollection = new List<GeUsuario>();
            }

            foreach (DataRow _Row in _DataSetProcessoUsuarioGrupo.Tables[1].Rows)
            {
                _UsuarioCollection.Add(new GeUsuario(_Row));
            }

            UsuarioCollection = _UsuarioCollection;
        }

        private void PreencheEmpresaCollection()
        {
            if (_EmpresaCollection == null)
            {
                _EmpresaCollection = new List<GeEmpresa>();
            }

            foreach (DataRow _Row in _DataSetProcessoUsuarioGrupo.Tables[0].Rows)
            {
                _EmpresaCollection.Add(new GeEmpresa(_Row));
            }

            EmpresaCollection = _EmpresaCollection;
        }

        private void FillDataParametersToExecuteUpdateModify()
        {
            PreencheEmpresaCollection();
            PreencheUsuarioCollection();
            PreencheGrupoCollection();

            cmbBxEmpresa.DataSource = EmpresaCollection;
            cmbBxEmpresa.ValueMember = "CodigoEmpresa";
            cmbBxEmpresa.DisplayMember = "DescricaoEmpresa";
            cmbBxEmpresa.SelectedValue = this.CodigoEmpresa;

            cmbBxUsuario.DataSource = UsuarioCollection;
            cmbBxUsuario.ValueMember = "Usuario";
            cmbBxUsuario.DisplayMember = "Nome";
            cmbBxUsuario.SelectedValue = this.Usuario;

            cmbBxGrupo.DataSource = GrupoCollection;
            cmbBxGrupo.ValueMember = "CodigoGrupo";
            cmbBxGrupo.DisplayMember = "DescricaoGrupo";
            cmbBxGrupo.SelectedValue = this.CodigoGrupo;

            AppStateManager.CodigoEmpresaUsuarioGrupo = Convert.ToInt32(cmbBxEmpresa.SelectedValue);
            AppStateManager.UserUsuarioGrupo = Convert.ToString(cmbBxUsuario.SelectedValue);
            AppStateManager.CodigoGrupoUsuarioGrupo = Convert.ToInt32(cmbBxGrupo.SelectedValue);
        }
    }
}
