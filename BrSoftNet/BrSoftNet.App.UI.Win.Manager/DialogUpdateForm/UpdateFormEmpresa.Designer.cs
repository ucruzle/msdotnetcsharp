namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    partial class UpdateFormEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFormEmpresa));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.tlstrpLblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblTitleModule = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.cmbBxCodigoRg = new System.Windows.Forms.ComboBox();
            this.cmbBxEmpresaConsolidada = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBxUsername = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtBxPort = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtBxEmail = new System.Windows.Forms.TextBox();
            this.lblVersao = new System.Windows.Forms.Label();
            this.txtBxSenha = new System.Windows.Forms.TextBox();
            this.txtBxEnderecoBanco = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtBxVersao = new System.Windows.Forms.TextBox();
            this.lblEnderecoBanco = new System.Windows.Forms.Label();
            this.ckBxAtiva = new System.Windows.Forms.CheckBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtBxHost = new System.Windows.Forms.TextBox();
            this.lblCodigoRg = new System.Windows.Forms.Label();
            this.lblCodigoEmpresaConsolidada = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtBxDescricaoEmpresaRed = new System.Windows.Forms.TextBox();
            this.txtBxCodigoEmpresa = new System.Windows.Forms.TextBox();
            this.lblDescricaoEmpresaRed = new System.Windows.Forms.Label();
            this.txtBxDescricaoEmpresa = new System.Windows.Forms.TextBox();
            this.lblCodigoGrupo = new System.Windows.Forms.Label();
            this.ErrPrvdrEmpresa = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlstrpLblExcecao = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttstrUpdateForm.SuspendLayout();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpLblError,
            this.tlstrpLblExcecao});
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 333);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(550, 22);
            this.sttstrUpdateForm.TabIndex = 3;
            // 
            // tlstrpLblError
            // 
            this.tlstrpLblError.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.tlstrpLblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tlstrpLblError.Name = "tlstrpLblError";
            this.tlstrpLblError.Size = new System.Drawing.Size(202, 17);
            this.tlstrpLblError.Text = "Campo de preenchimento obrigatório";
            this.tlstrpLblError.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tlstrpLblError.Visible = false;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblTitleModule);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(550, 30);
            this.pnlUpdateFormTitle.TabIndex = 4;
            // 
            // lblTitleModule
            // 
            this.lblTitleModule.AutoSize = true;
            this.lblTitleModule.Location = new System.Drawing.Point(6, 9);
            this.lblTitleModule.Name = "lblTitleModule";
            this.lblTitleModule.Size = new System.Drawing.Size(106, 13);
            this.lblTitleModule.TabIndex = 0;
            this.lblTitleModule.Text = "Atualização Empresa";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(550, 25);
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
            this.tlstrpActionMenuBtnCancel.Click += new System.EventHandler(this.tlstrpActionMenuBtnCancel_Click_1);
            // 
            // grpBoxFields
            // 
            this.grpBoxFields.Controls.Add(this.cmbBxCodigoRg);
            this.grpBoxFields.Controls.Add(this.cmbBxEmpresaConsolidada);
            this.grpBoxFields.Controls.Add(this.groupBox1);
            this.grpBoxFields.Controls.Add(this.ckBxAtiva);
            this.grpBoxFields.Controls.Add(this.lblHost);
            this.grpBoxFields.Controls.Add(this.txtBxHost);
            this.grpBoxFields.Controls.Add(this.lblCodigoRg);
            this.grpBoxFields.Controls.Add(this.lblCodigoEmpresaConsolidada);
            this.grpBoxFields.Controls.Add(this.lblDescricao);
            this.grpBoxFields.Controls.Add(this.txtBxDescricaoEmpresaRed);
            this.grpBoxFields.Controls.Add(this.txtBxCodigoEmpresa);
            this.grpBoxFields.Controls.Add(this.lblDescricaoEmpresaRed);
            this.grpBoxFields.Controls.Add(this.txtBxDescricaoEmpresa);
            this.grpBoxFields.Controls.Add(this.lblCodigoGrupo);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(550, 278);
            this.grpBoxFields.TabIndex = 6;
            this.grpBoxFields.TabStop = false;
            // 
            // cmbBxCodigoRg
            // 
            this.cmbBxCodigoRg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxCodigoRg.FormattingEnabled = true;
            this.cmbBxCodigoRg.Location = new System.Drawing.Point(137, 118);
            this.cmbBxCodigoRg.Name = "cmbBxCodigoRg";
            this.cmbBxCodigoRg.Size = new System.Drawing.Size(396, 21);
            this.cmbBxCodigoRg.TabIndex = 3;
            // 
            // cmbBxEmpresaConsolidada
            // 
            this.cmbBxEmpresaConsolidada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxEmpresaConsolidada.FormattingEnabled = true;
            this.cmbBxEmpresaConsolidada.Location = new System.Drawing.Point(137, 91);
            this.cmbBxEmpresaConsolidada.Name = "cmbBxEmpresaConsolidada";
            this.cmbBxEmpresaConsolidada.Size = new System.Drawing.Size(396, 21);
            this.cmbBxEmpresaConsolidada.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBxUsername);
            this.groupBox1.Controls.Add(this.lblPort);
            this.groupBox1.Controls.Add(this.txtBxPort);
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Controls.Add(this.lblSenha);
            this.groupBox1.Controls.Add(this.txtBxEmail);
            this.groupBox1.Controls.Add(this.lblVersao);
            this.groupBox1.Controls.Add(this.txtBxSenha);
            this.groupBox1.Controls.Add(this.txtBxEnderecoBanco);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.txtBxVersao);
            this.groupBox1.Controls.Add(this.lblEnderecoBanco);
            this.groupBox1.Location = new System.Drawing.Point(3, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 103);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "E-mail";
            // 
            // txtBxUsername
            // 
            this.txtBxUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxUsername.Location = new System.Drawing.Point(249, 19);
            this.txtBxUsername.Name = "txtBxUsername";
            this.txtBxUsername.Size = new System.Drawing.Size(126, 20);
            this.txtBxUsername.TabIndex = 7;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(66, 22);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 25;
            this.lblPort.Text = "Port:";
            // 
            // txtBxPort
            // 
            this.txtBxPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxPort.Location = new System.Drawing.Point(101, 19);
            this.txtBxPort.Name = "txtBxPort";
            this.txtBxPort.Size = new System.Drawing.Size(78, 20);
            this.txtBxPort.TabIndex = 6;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(185, 22);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 26;
            this.lblUsername.Text = "Username:";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(381, 22);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 29;
            this.lblSenha.Text = "Senha:";
            // 
            // txtBxEmail
            // 
            this.txtBxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxEmail.Location = new System.Drawing.Point(101, 45);
            this.txtBxEmail.Name = "txtBxEmail";
            this.txtBxEmail.Size = new System.Drawing.Size(427, 20);
            this.txtBxEmail.TabIndex = 9;
            this.txtBxEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxEmail_Validating);
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(351, 74);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(43, 13);
            this.lblVersao.TabIndex = 34;
            this.lblVersao.Text = "Versão:";
            // 
            // txtBxSenha
            // 
            this.txtBxSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSenha.Location = new System.Drawing.Point(428, 19);
            this.txtBxSenha.Name = "txtBxSenha";
            this.txtBxSenha.Size = new System.Drawing.Size(100, 20);
            this.txtBxSenha.TabIndex = 8;
            this.txtBxSenha.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxSenha_Validating);
            // 
            // txtBxEnderecoBanco
            // 
            this.txtBxEnderecoBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxEnderecoBanco.Location = new System.Drawing.Point(101, 71);
            this.txtBxEnderecoBanco.Name = "txtBxEnderecoBanco";
            this.txtBxEnderecoBanco.Size = new System.Drawing.Size(244, 20);
            this.txtBxEnderecoBanco.TabIndex = 10;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(60, 48);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 30;
            this.lblEmail.Text = "Email:";
            // 
            // txtBxVersao
            // 
            this.txtBxVersao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxVersao.Location = new System.Drawing.Point(400, 71);
            this.txtBxVersao.MaxLength = 20;
            this.txtBxVersao.Name = "txtBxVersao";
            this.txtBxVersao.Size = new System.Drawing.Size(128, 20);
            this.txtBxVersao.TabIndex = 11;
            this.txtBxVersao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxVersao_KeyPress);
            this.txtBxVersao.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxVersao_Validating);
            // 
            // lblEnderecoBanco
            // 
            this.lblEnderecoBanco.AutoSize = true;
            this.lblEnderecoBanco.Location = new System.Drawing.Point(5, 74);
            this.lblEnderecoBanco.Name = "lblEnderecoBanco";
            this.lblEnderecoBanco.Size = new System.Drawing.Size(90, 13);
            this.lblEnderecoBanco.TabIndex = 33;
            this.lblEnderecoBanco.Text = "Endereço Banco:";
            // 
            // ckBxAtiva
            // 
            this.ckBxAtiva.AutoSize = true;
            this.ckBxAtiva.Location = new System.Drawing.Point(484, 147);
            this.ckBxAtiva.Name = "ckBxAtiva";
            this.ckBxAtiva.Size = new System.Drawing.Size(50, 17);
            this.ckBxAtiva.TabIndex = 5;
            this.ckBxAtiva.Text = "Ativa";
            this.ckBxAtiva.UseVisualStyleBackColor = true;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(99, 147);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(32, 13);
            this.lblHost.TabIndex = 22;
            this.lblHost.Text = "Host:";
            // 
            // txtBxHost
            // 
            this.txtBxHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxHost.Location = new System.Drawing.Point(137, 144);
            this.txtBxHost.Name = "txtBxHost";
            this.txtBxHost.Size = new System.Drawing.Size(341, 20);
            this.txtBxHost.TabIndex = 4;
            // 
            // lblCodigoRg
            // 
            this.lblCodigoRg.AutoSize = true;
            this.lblCodigoRg.Location = new System.Drawing.Point(69, 121);
            this.lblCodigoRg.Name = "lblCodigoRg";
            this.lblCodigoRg.Size = new System.Drawing.Size(62, 13);
            this.lblCodigoRg.TabIndex = 21;
            this.lblCodigoRg.Text = "Código RG:";
            // 
            // lblCodigoEmpresaConsolidada
            // 
            this.lblCodigoEmpresaConsolidada.AutoSize = true;
            this.lblCodigoEmpresaConsolidada.Location = new System.Drawing.Point(19, 95);
            this.lblCodigoEmpresaConsolidada.Name = "lblCodigoEmpresaConsolidada";
            this.lblCodigoEmpresaConsolidada.Size = new System.Drawing.Size(112, 13);
            this.lblCodigoEmpresaConsolidada.TabIndex = 18;
            this.lblCodigoEmpresaConsolidada.Text = "Empresa Consolidada:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(73, 43);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 14;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtBxDescricaoEmpresaRed
            // 
            this.txtBxDescricaoEmpresaRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxDescricaoEmpresaRed.Location = new System.Drawing.Point(137, 66);
            this.txtBxDescricaoEmpresaRed.MaxLength = 20;
            this.txtBxDescricaoEmpresaRed.Name = "txtBxDescricaoEmpresaRed";
            this.txtBxDescricaoEmpresaRed.Size = new System.Drawing.Size(397, 20);
            this.txtBxDescricaoEmpresaRed.TabIndex = 1;
            this.txtBxDescricaoEmpresaRed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxDescricaoEmpresaRed_KeyPress);
            this.txtBxDescricaoEmpresaRed.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxDescricaoEmpresaRed_Validating);
            // 
            // txtBxCodigoEmpresa
            // 
            this.txtBxCodigoEmpresa.Location = new System.Drawing.Point(137, 14);
            this.txtBxCodigoEmpresa.Name = "txtBxCodigoEmpresa";
            this.txtBxCodigoEmpresa.ReadOnly = true;
            this.txtBxCodigoEmpresa.Size = new System.Drawing.Size(78, 20);
            this.txtBxCodigoEmpresa.TabIndex = 11;
            this.txtBxCodigoEmpresa.TabStop = false;
            // 
            // lblDescricaoEmpresaRed
            // 
            this.lblDescricaoEmpresaRed.AutoSize = true;
            this.lblDescricaoEmpresaRed.Location = new System.Drawing.Point(6, 69);
            this.lblDescricaoEmpresaRed.Name = "lblDescricaoEmpresaRed";
            this.lblDescricaoEmpresaRed.Size = new System.Drawing.Size(125, 13);
            this.lblDescricaoEmpresaRed.TabIndex = 17;
            this.lblDescricaoEmpresaRed.Text = "Descrição Empresa Red:";
            // 
            // txtBxDescricaoEmpresa
            // 
            this.txtBxDescricaoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxDescricaoEmpresa.Location = new System.Drawing.Point(137, 40);
            this.txtBxDescricaoEmpresa.MaxLength = 100;
            this.txtBxDescricaoEmpresa.Name = "txtBxDescricaoEmpresa";
            this.txtBxDescricaoEmpresa.Size = new System.Drawing.Size(396, 20);
            this.txtBxDescricaoEmpresa.TabIndex = 0;
            this.txtBxDescricaoEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxDescricaoEmpresa_KeyPress);
            this.txtBxDescricaoEmpresa.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxDescricaoEmpresa_Validating);
            // 
            // lblCodigoGrupo
            // 
            this.lblCodigoGrupo.AutoSize = true;
            this.lblCodigoGrupo.Location = new System.Drawing.Point(88, 17);
            this.lblCodigoGrupo.Name = "lblCodigoGrupo";
            this.lblCodigoGrupo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigoGrupo.TabIndex = 13;
            this.lblCodigoGrupo.Text = "Código:";
            // 
            // ErrPrvdrEmpresa
            // 
            this.ErrPrvdrEmpresa.ContainerControl = this;
            // 
            // tlstrpLblExcecao
            // 
            this.tlstrpLblExcecao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tlstrpLblExcecao.Name = "tlstrpLblExcecao";
            this.tlstrpLblExcecao.Size = new System.Drawing.Size(0, 17);
            this.tlstrpLblExcecao.Visible = false;
            // 
            // UpdateFormEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 355);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateFormEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UpdateFormEmpresa_Load);
            this.sttstrUpdateForm.ResumeLayout(false);
            this.sttstrUpdateForm.PerformLayout();
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.grpBoxFields.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrEmpresa)).EndInit();
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
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtBxCodigoEmpresa;
        private System.Windows.Forms.TextBox txtBxDescricaoEmpresa;
        private System.Windows.Forms.Label lblCodigoGrupo;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.TextBox txtBxEnderecoBanco;
        private System.Windows.Forms.TextBox txtBxVersao;
        private System.Windows.Forms.Label lblEnderecoBanco;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtBxSenha;
        private System.Windows.Forms.TextBox txtBxEmail;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtBxPort;
        private System.Windows.Forms.TextBox txtBxUsername;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtBxHost;
        private System.Windows.Forms.Label lblCodigoRg;
        private System.Windows.Forms.Label lblCodigoEmpresaConsolidada;
        private System.Windows.Forms.TextBox txtBxDescricaoEmpresaRed;
        private System.Windows.Forms.Label lblDescricaoEmpresaRed;
        private System.Windows.Forms.CheckBox ckBxAtiva;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbBxCodigoRg;
        private System.Windows.Forms.ComboBox cmbBxEmpresaConsolidada;
        private System.Windows.Forms.ErrorProvider ErrPrvdrEmpresa;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblError;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblExcecao;
    }
}

