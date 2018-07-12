namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    partial class UpdateFormUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFormUsuario));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.tlstrpLblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblTitleModule = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.cmbBxRegGeral = new System.Windows.Forms.ComboBox();
            this.cmbBxEmpresaRegGeral = new System.Windows.Forms.ComboBox();
            this.lblRamal = new System.Windows.Forms.Label();
            this.txtBxRamal = new System.Windows.Forms.TextBox();
            this.lblSenhaAtual = new System.Windows.Forms.Label();
            this.txtBxSenhaAtual = new System.Windows.Forms.TextBox();
            this.lblConfirmaSenha = new System.Windows.Forms.Label();
            this.txtBxConfirmaSenha = new System.Windows.Forms.TextBox();
            this.lblNovaSenha = new System.Windows.Forms.Label();
            this.txtBxNovaSenha = new System.Windows.Forms.TextBox();
            this.ckBxStatusDBA = new System.Windows.Forms.CheckBox();
            this.lblRgGeral = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.ckBxAtiva = new System.Windows.Forms.CheckBox();
            this.lblDataCadastro = new System.Windows.Forms.Label();
            this.txtBxUsuario = new System.Windows.Forms.TextBox();
            this.txtBxDataCadastro = new System.Windows.Forms.TextBox();
            this.txtBxNome = new System.Windows.Forms.TextBox();
            this.lblEmpresaRgGeral = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.ErrPrvdrUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.sttstrUpdateForm.SuspendLayout();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpLblError});
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 257);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(482, 22);
            this.sttstrUpdateForm.TabIndex = 3;
            // 
            // tlstrpLblError
            // 
            this.tlstrpLblError.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.tlstrpLblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tlstrpLblError.Name = "tlstrpLblError";
            this.tlstrpLblError.Size = new System.Drawing.Size(202, 17);
            this.tlstrpLblError.Text = "Campo de preenchimento obrigatório";
            this.tlstrpLblError.Visible = false;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblTitleModule);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(482, 30);
            this.pnlUpdateFormTitle.TabIndex = 4;
            // 
            // lblTitleModule
            // 
            this.lblTitleModule.AutoSize = true;
            this.lblTitleModule.Location = new System.Drawing.Point(6, 9);
            this.lblTitleModule.Name = "lblTitleModule";
            this.lblTitleModule.Size = new System.Drawing.Size(101, 13);
            this.lblTitleModule.TabIndex = 0;
            this.lblTitleModule.Text = "Atualização Usuário";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(482, 25);
            this.tlstrpActionMenuUpdateForm.TabIndex = 5;
            this.tlstrpActionMenuUpdateForm.Text = "toolStrip1";
            // 
            // tlstrpActionMenuBtnConfirm
            // 
            this.tlstrpActionMenuBtnConfirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpActionMenuBtnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpActionMenuBtnConfirm.Image")));
            this.tlstrpActionMenuBtnConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpActionMenuBtnConfirm.Name = "tlstrpActionMenuBtnConfirm";
            this.tlstrpActionMenuBtnConfirm.Size = new System.Drawing.Size(23, 22);
            this.tlstrpActionMenuBtnConfirm.ToolTipText = "Confirmar";
            this.tlstrpActionMenuBtnConfirm.Click += new System.EventHandler(this.tlstrpActionMenuBtnConfirm_Click);
            // 
            // tlstrpActionMenuBtnCancel
            // 
            this.tlstrpActionMenuBtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpActionMenuBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpActionMenuBtnCancel.Image")));
            this.tlstrpActionMenuBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpActionMenuBtnCancel.Name = "tlstrpActionMenuBtnCancel";
            this.tlstrpActionMenuBtnCancel.Size = new System.Drawing.Size(23, 22);
            this.tlstrpActionMenuBtnCancel.ToolTipText = "Cancelar";
            this.tlstrpActionMenuBtnCancel.Click += new System.EventHandler(this.tlstrpActionMenuBtnCancel_Click);
            // 
            // grpBoxFields
            // 
            this.grpBoxFields.Controls.Add(this.cmbBxRegGeral);
            this.grpBoxFields.Controls.Add(this.cmbBxEmpresaRegGeral);
            this.grpBoxFields.Controls.Add(this.lblRamal);
            this.grpBoxFields.Controls.Add(this.txtBxRamal);
            this.grpBoxFields.Controls.Add(this.lblSenhaAtual);
            this.grpBoxFields.Controls.Add(this.txtBxSenhaAtual);
            this.grpBoxFields.Controls.Add(this.lblConfirmaSenha);
            this.grpBoxFields.Controls.Add(this.txtBxConfirmaSenha);
            this.grpBoxFields.Controls.Add(this.lblNovaSenha);
            this.grpBoxFields.Controls.Add(this.txtBxNovaSenha);
            this.grpBoxFields.Controls.Add(this.ckBxStatusDBA);
            this.grpBoxFields.Controls.Add(this.lblRgGeral);
            this.grpBoxFields.Controls.Add(this.lblUsuario);
            this.grpBoxFields.Controls.Add(this.ckBxAtiva);
            this.grpBoxFields.Controls.Add(this.lblDataCadastro);
            this.grpBoxFields.Controls.Add(this.txtBxUsuario);
            this.grpBoxFields.Controls.Add(this.txtBxDataCadastro);
            this.grpBoxFields.Controls.Add(this.txtBxNome);
            this.grpBoxFields.Controls.Add(this.lblEmpresaRgGeral);
            this.grpBoxFields.Controls.Add(this.lblNome);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(482, 202);
            this.grpBoxFields.TabIndex = 6;
            this.grpBoxFields.TabStop = false;
            // 
            // cmbBxRegGeral
            // 
            this.cmbBxRegGeral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxRegGeral.FormattingEnabled = true;
            this.cmbBxRegGeral.Location = new System.Drawing.Point(99, 92);
            this.cmbBxRegGeral.Name = "cmbBxRegGeral";
            this.cmbBxRegGeral.Size = new System.Drawing.Size(371, 21);
            this.cmbBxRegGeral.TabIndex = 4;
            // 
            // cmbBxEmpresaRegGeral
            // 
            this.cmbBxEmpresaRegGeral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxEmpresaRegGeral.FormattingEnabled = true;
            this.cmbBxEmpresaRegGeral.Location = new System.Drawing.Point(99, 64);
            this.cmbBxEmpresaRegGeral.Name = "cmbBxEmpresaRegGeral";
            this.cmbBxEmpresaRegGeral.Size = new System.Drawing.Size(371, 21);
            this.cmbBxEmpresaRegGeral.TabIndex = 3;
            // 
            // lblRamal
            // 
            this.lblRamal.AutoSize = true;
            this.lblRamal.Location = new System.Drawing.Point(285, 123);
            this.lblRamal.Name = "lblRamal";
            this.lblRamal.Size = new System.Drawing.Size(40, 13);
            this.lblRamal.TabIndex = 59;
            this.lblRamal.Text = "Ramal:";
            // 
            // txtBxRamal
            // 
            this.txtBxRamal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxRamal.Location = new System.Drawing.Point(331, 120);
            this.txtBxRamal.MaxLength = 15;
            this.txtBxRamal.Name = "txtBxRamal";
            this.txtBxRamal.Size = new System.Drawing.Size(139, 20);
            this.txtBxRamal.TabIndex = 8;
            this.txtBxRamal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxRamal_KeyPress);
            this.txtBxRamal.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxRamal_Validating);
            // 
            // lblSenhaAtual
            // 
            this.lblSenhaAtual.AutoSize = true;
            this.lblSenhaAtual.Location = new System.Drawing.Point(25, 120);
            this.lblSenhaAtual.Name = "lblSenhaAtual";
            this.lblSenhaAtual.Size = new System.Drawing.Size(68, 13);
            this.lblSenhaAtual.TabIndex = 55;
            this.lblSenhaAtual.Text = "Senha Atual:";
            // 
            // txtBxSenhaAtual
            // 
            this.txtBxSenhaAtual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSenhaAtual.Location = new System.Drawing.Point(99, 117);
            this.txtBxSenhaAtual.MaxLength = 40;
            this.txtBxSenhaAtual.Name = "txtBxSenhaAtual";
            this.txtBxSenhaAtual.Size = new System.Drawing.Size(180, 20);
            this.txtBxSenhaAtual.TabIndex = 5;
            this.txtBxSenhaAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxSenhaAtual_KeyPress);
            this.txtBxSenhaAtual.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxSenhaAtual_Validating);
            // 
            // lblConfirmaSenha
            // 
            this.lblConfirmaSenha.AutoSize = true;
            this.lblConfirmaSenha.Location = new System.Drawing.Point(8, 172);
            this.lblConfirmaSenha.Name = "lblConfirmaSenha";
            this.lblConfirmaSenha.Size = new System.Drawing.Size(85, 13);
            this.lblConfirmaSenha.TabIndex = 53;
            this.lblConfirmaSenha.Text = "Confirma Senha:";
            // 
            // txtBxConfirmaSenha
            // 
            this.txtBxConfirmaSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxConfirmaSenha.Location = new System.Drawing.Point(99, 169);
            this.txtBxConfirmaSenha.MaxLength = 40;
            this.txtBxConfirmaSenha.Name = "txtBxConfirmaSenha";
            this.txtBxConfirmaSenha.Size = new System.Drawing.Size(180, 20);
            this.txtBxConfirmaSenha.TabIndex = 7;
            this.txtBxConfirmaSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxConfirmaSenha_KeyPress);
            this.txtBxConfirmaSenha.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxConfirmaSenha_Validating);
            // 
            // lblNovaSenha
            // 
            this.lblNovaSenha.AutoSize = true;
            this.lblNovaSenha.Location = new System.Drawing.Point(23, 146);
            this.lblNovaSenha.Name = "lblNovaSenha";
            this.lblNovaSenha.Size = new System.Drawing.Size(70, 13);
            this.lblNovaSenha.TabIndex = 51;
            this.lblNovaSenha.Text = "Nova Senha:";
            this.lblNovaSenha.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBxNovaSenha
            // 
            this.txtBxNovaSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxNovaSenha.Location = new System.Drawing.Point(99, 143);
            this.txtBxNovaSenha.MaxLength = 40;
            this.txtBxNovaSenha.Name = "txtBxNovaSenha";
            this.txtBxNovaSenha.Size = new System.Drawing.Size(180, 20);
            this.txtBxNovaSenha.TabIndex = 6;
            this.txtBxNovaSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxNovaSenha_KeyPress);
            this.txtBxNovaSenha.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxNovaSenha_Validating);
            // 
            // ckBxStatusDBA
            // 
            this.ckBxStatusDBA.AutoSize = true;
            this.ckBxStatusDBA.Location = new System.Drawing.Point(288, 146);
            this.ckBxStatusDBA.Name = "ckBxStatusDBA";
            this.ckBxStatusDBA.Size = new System.Drawing.Size(81, 17);
            this.ckBxStatusDBA.TabIndex = 9;
            this.ckBxStatusDBA.Text = "Status DBA";
            this.ckBxStatusDBA.UseVisualStyleBackColor = true;
            // 
            // lblRgGeral
            // 
            this.lblRgGeral.AutoSize = true;
            this.lblRgGeral.Location = new System.Drawing.Point(67, 94);
            this.lblRgGeral.Name = "lblRgGeral";
            this.lblRgGeral.Size = new System.Drawing.Size(26, 13);
            this.lblRgGeral.TabIndex = 48;
            this.lblRgGeral.Text = "RG:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(47, 13);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 41;
            this.lblUsuario.Text = "Usuário:";
            // 
            // ckBxAtiva
            // 
            this.ckBxAtiva.AutoSize = true;
            this.ckBxAtiva.Location = new System.Drawing.Point(288, 172);
            this.ckBxAtiva.Name = "ckBxAtiva";
            this.ckBxAtiva.Size = new System.Drawing.Size(50, 17);
            this.ckBxAtiva.TabIndex = 10;
            this.ckBxAtiva.Text = "Ativa";
            this.ckBxAtiva.UseVisualStyleBackColor = true;
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.AutoSize = true;
            this.lblDataCadastro.Location = new System.Drawing.Point(299, 16);
            this.lblDataCadastro.Name = "lblDataCadastro";
            this.lblDataCadastro.Size = new System.Drawing.Size(78, 13);
            this.lblDataCadastro.TabIndex = 46;
            this.lblDataCadastro.Text = "Data Cadastro:";
            // 
            // txtBxUsuario
            // 
            this.txtBxUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxUsuario.Location = new System.Drawing.Point(99, 13);
            this.txtBxUsuario.MaxLength = 15;
            this.txtBxUsuario.Name = "txtBxUsuario";
            this.txtBxUsuario.Size = new System.Drawing.Size(194, 20);
            this.txtBxUsuario.TabIndex = 0;
            this.txtBxUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxUsuario_KeyPress);
            this.txtBxUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxUsuario_Validating);
            // 
            // txtBxDataCadastro
            // 
            this.txtBxDataCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxDataCadastro.Location = new System.Drawing.Point(378, 13);
            this.txtBxDataCadastro.MaxLength = 8;
            this.txtBxDataCadastro.Name = "txtBxDataCadastro";
            this.txtBxDataCadastro.Size = new System.Drawing.Size(93, 20);
            this.txtBxDataCadastro.TabIndex = 1;
            this.txtBxDataCadastro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxDataCadastro_KeyPress);
            this.txtBxDataCadastro.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxDataCadastro_Validating);
            // 
            // txtBxNome
            // 
            this.txtBxNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxNome.Location = new System.Drawing.Point(99, 39);
            this.txtBxNome.MaxLength = 40;
            this.txtBxNome.Name = "txtBxNome";
            this.txtBxNome.Size = new System.Drawing.Size(372, 20);
            this.txtBxNome.TabIndex = 2;
            this.txtBxNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxNome_KeyPress);
            this.txtBxNome.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxNome_Validating);
            // 
            // lblEmpresaRgGeral
            // 
            this.lblEmpresaRgGeral.AutoSize = true;
            this.lblEmpresaRgGeral.Location = new System.Drawing.Point(23, 68);
            this.lblEmpresaRgGeral.Name = "lblEmpresaRgGeral";
            this.lblEmpresaRgGeral.Size = new System.Drawing.Size(70, 13);
            this.lblEmpresaRgGeral.TabIndex = 44;
            this.lblEmpresaRgGeral.Text = "Empresa RG:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(55, 39);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 42;
            this.lblNome.Text = "Nome:";
            // 
            // ErrPrvdrUsuario
            // 
            this.ErrPrvdrUsuario.ContainerControl = this;
            // 
            // UpdateFormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 279);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateFormUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UpdateFormUsuario_Load);
            this.sttstrUpdateForm.ResumeLayout(false);
            this.sttstrUpdateForm.PerformLayout();
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.grpBoxFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sttstrUpdateForm;
        private System.Windows.Forms.Panel pnlUpdateFormTitle;
        private System.Windows.Forms.ToolStrip tlstrpActionMenuUpdateForm;
        private System.Windows.Forms.ToolStripButton tlstrpActionMenuBtnConfirm;
        private System.Windows.Forms.ToolStripButton tlstrpActionMenuBtnCancel;
        private System.Windows.Forms.GroupBox grpBoxFields;
        private System.Windows.Forms.Label lblTitleModule;
        private System.Windows.Forms.CheckBox ckBxStatusDBA;
        private System.Windows.Forms.Label lblRgGeral;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.CheckBox ckBxAtiva;
        private System.Windows.Forms.Label lblDataCadastro;
        private System.Windows.Forms.TextBox txtBxUsuario;
        private System.Windows.Forms.TextBox txtBxDataCadastro;
        private System.Windows.Forms.TextBox txtBxNome;
        private System.Windows.Forms.Label lblEmpresaRgGeral;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblRamal;
        private System.Windows.Forms.TextBox txtBxRamal;
        private System.Windows.Forms.Label lblSenhaAtual;
        private System.Windows.Forms.TextBox txtBxSenhaAtual;
        private System.Windows.Forms.Label lblConfirmaSenha;
        private System.Windows.Forms.TextBox txtBxConfirmaSenha;
        private System.Windows.Forms.Label lblNovaSenha;
        private System.Windows.Forms.TextBox txtBxNovaSenha;
        private System.Windows.Forms.ComboBox cmbBxRegGeral;
        private System.Windows.Forms.ComboBox cmbBxEmpresaRegGeral;
        private System.Windows.Forms.ErrorProvider ErrPrvdrUsuario;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblError;
    }
}

