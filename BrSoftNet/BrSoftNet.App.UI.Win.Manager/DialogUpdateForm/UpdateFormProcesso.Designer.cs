namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    partial class UpdateFormProcesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFormProcesso));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.tlstrpLblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblTitleModule = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.cmbBxAplicacao = new System.Windows.Forms.ComboBox();
            this.cmbBxTipoProcesso = new System.Windows.Forms.ComboBox();
            this.ckBxAtiva = new System.Windows.Forms.CheckBox();
            this.txtBxForm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAplicacao = new System.Windows.Forms.Label();
            this.lblCodigoTipoProcesso = new System.Windows.Forms.Label();
            this.lblDescricaoProcesso = new System.Windows.Forms.Label();
            this.txtBxCodigoProcesso = new System.Windows.Forms.TextBox();
            this.lblCodigoProcesso = new System.Windows.Forms.Label();
            this.txtBxDescricaoProcesso = new System.Windows.Forms.TextBox();
            this.ErrPrvdrProcesso = new System.Windows.Forms.ErrorProvider(this.components);
            this.sttstrUpdateForm.SuspendLayout();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrProcesso)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpLblError});
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 213);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(453, 22);
            this.sttstrUpdateForm.TabIndex = 3;
            // 
            // tlstrpLblError
            // 
            this.tlstrpLblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tlstrpLblError.Name = "tlstrpLblError";
            this.tlstrpLblError.Size = new System.Drawing.Size(208, 17);
            this.tlstrpLblError.Text = "Campo de preenchimento obrigatório";
            this.tlstrpLblError.Visible = false;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblTitleModule);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(453, 30);
            this.pnlUpdateFormTitle.TabIndex = 4;
            // 
            // lblTitleModule
            // 
            this.lblTitleModule.AutoSize = true;
            this.lblTitleModule.Location = new System.Drawing.Point(6, 9);
            this.lblTitleModule.Name = "lblTitleModule";
            this.lblTitleModule.Size = new System.Drawing.Size(109, 13);
            this.lblTitleModule.TabIndex = 0;
            this.lblTitleModule.Text = "Atualização Processo";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(453, 25);
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
            this.grpBoxFields.Controls.Add(this.cmbBxAplicacao);
            this.grpBoxFields.Controls.Add(this.cmbBxTipoProcesso);
            this.grpBoxFields.Controls.Add(this.ckBxAtiva);
            this.grpBoxFields.Controls.Add(this.txtBxForm);
            this.grpBoxFields.Controls.Add(this.label1);
            this.grpBoxFields.Controls.Add(this.lblAplicacao);
            this.grpBoxFields.Controls.Add(this.lblCodigoTipoProcesso);
            this.grpBoxFields.Controls.Add(this.lblDescricaoProcesso);
            this.grpBoxFields.Controls.Add(this.txtBxCodigoProcesso);
            this.grpBoxFields.Controls.Add(this.lblCodigoProcesso);
            this.grpBoxFields.Controls.Add(this.txtBxDescricaoProcesso);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(453, 158);
            this.grpBoxFields.TabIndex = 6;
            this.grpBoxFields.TabStop = false;
            // 
            // cmbBxAplicacao
            // 
            this.cmbBxAplicacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxAplicacao.FormattingEnabled = true;
            this.cmbBxAplicacao.Location = new System.Drawing.Point(89, 98);
            this.cmbBxAplicacao.Name = "cmbBxAplicacao";
            this.cmbBxAplicacao.Size = new System.Drawing.Size(343, 21);
            this.cmbBxAplicacao.TabIndex = 3;
            // 
            // cmbBxTipoProcesso
            // 
            this.cmbBxTipoProcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxTipoProcesso.FormattingEnabled = true;
            this.cmbBxTipoProcesso.Location = new System.Drawing.Point(89, 71);
            this.cmbBxTipoProcesso.Name = "cmbBxTipoProcesso";
            this.cmbBxTipoProcesso.Size = new System.Drawing.Size(343, 21);
            this.cmbBxTipoProcesso.TabIndex = 2;
            // 
            // ckBxAtiva
            // 
            this.ckBxAtiva.AutoSize = true;
            this.ckBxAtiva.Location = new System.Drawing.Point(382, 22);
            this.ckBxAtiva.Name = "ckBxAtiva";
            this.ckBxAtiva.Size = new System.Drawing.Size(50, 17);
            this.ckBxAtiva.TabIndex = 5;
            this.ckBxAtiva.Text = "Ativa";
            this.ckBxAtiva.UseVisualStyleBackColor = true;
            // 
            // txtBxForm
            // 
            this.txtBxForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxForm.Location = new System.Drawing.Point(89, 123);
            this.txtBxForm.Name = "txtBxForm";
            this.txtBxForm.Size = new System.Drawing.Size(343, 20);
            this.txtBxForm.TabIndex = 4;
            this.txtBxForm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxForm_KeyPress);
            this.txtBxForm.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxForm_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Form:";
            // 
            // lblAplicacao
            // 
            this.lblAplicacao.AutoSize = true;
            this.lblAplicacao.Location = new System.Drawing.Point(26, 100);
            this.lblAplicacao.Name = "lblAplicacao";
            this.lblAplicacao.Size = new System.Drawing.Size(57, 13);
            this.lblAplicacao.TabIndex = 41;
            this.lblAplicacao.Text = "Aplicação:";
            // 
            // lblCodigoTipoProcesso
            // 
            this.lblCodigoTipoProcesso.AutoSize = true;
            this.lblCodigoTipoProcesso.Location = new System.Drawing.Point(5, 75);
            this.lblCodigoTipoProcesso.Name = "lblCodigoTipoProcesso";
            this.lblCodigoTipoProcesso.Size = new System.Drawing.Size(78, 13);
            this.lblCodigoTipoProcesso.TabIndex = 40;
            this.lblCodigoTipoProcesso.Text = "Tipo Processo:";
            // 
            // lblDescricaoProcesso
            // 
            this.lblDescricaoProcesso.AutoSize = true;
            this.lblDescricaoProcesso.Location = new System.Drawing.Point(25, 48);
            this.lblDescricaoProcesso.Name = "lblDescricaoProcesso";
            this.lblDescricaoProcesso.Size = new System.Drawing.Size(58, 13);
            this.lblDescricaoProcesso.TabIndex = 14;
            this.lblDescricaoProcesso.Text = "Descrição:";
            // 
            // txtBxCodigoProcesso
            // 
            this.txtBxCodigoProcesso.BackColor = System.Drawing.SystemColors.Control;
            this.txtBxCodigoProcesso.Location = new System.Drawing.Point(89, 19);
            this.txtBxCodigoProcesso.Name = "txtBxCodigoProcesso";
            this.txtBxCodigoProcesso.ReadOnly = true;
            this.txtBxCodigoProcesso.Size = new System.Drawing.Size(78, 20);
            this.txtBxCodigoProcesso.TabIndex = 0;
            this.txtBxCodigoProcesso.TabStop = false;
            // 
            // lblCodigoProcesso
            // 
            this.lblCodigoProcesso.AutoSize = true;
            this.lblCodigoProcesso.Location = new System.Drawing.Point(29, 22);
            this.lblCodigoProcesso.Name = "lblCodigoProcesso";
            this.lblCodigoProcesso.Size = new System.Drawing.Size(54, 13);
            this.lblCodigoProcesso.TabIndex = 13;
            this.lblCodigoProcesso.Text = "Processo:";
            // 
            // txtBxDescricaoProcesso
            // 
            this.txtBxDescricaoProcesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxDescricaoProcesso.Location = new System.Drawing.Point(89, 45);
            this.txtBxDescricaoProcesso.MaxLength = 40;
            this.txtBxDescricaoProcesso.Name = "txtBxDescricaoProcesso";
            this.txtBxDescricaoProcesso.Size = new System.Drawing.Size(343, 20);
            this.txtBxDescricaoProcesso.TabIndex = 1;
            this.txtBxDescricaoProcesso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxDescricaoProcesso_KeyPress);
            this.txtBxDescricaoProcesso.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxDescricaoProcesso_Validating);
            // 
            // ErrPrvdrProcesso
            // 
            this.ErrPrvdrProcesso.ContainerControl = this;
            // 
            // UpdateFormProcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 235);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateFormProcesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UpdateFormProcesso_Load);
            this.sttstrUpdateForm.ResumeLayout(false);
            this.sttstrUpdateForm.PerformLayout();
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.grpBoxFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrProcesso)).EndInit();
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
        private System.Windows.Forms.Label lblDescricaoProcesso;
        private System.Windows.Forms.TextBox txtBxCodigoProcesso;
        private System.Windows.Forms.Label lblCodigoProcesso;
        private System.Windows.Forms.TextBox txtBxDescricaoProcesso;
        private System.Windows.Forms.Label lblAplicacao;
        private System.Windows.Forms.Label lblCodigoTipoProcesso;
        private System.Windows.Forms.TextBox txtBxForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckBxAtiva;
        private System.Windows.Forms.ComboBox cmbBxTipoProcesso;
        private System.Windows.Forms.ComboBox cmbBxAplicacao;
        private System.Windows.Forms.ErrorProvider ErrPrvdrProcesso;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblError;
    }
}

