namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    partial class UpdateFormAplicacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFormAplicacao));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.tlstrpLblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.lblForm = new System.Windows.Forms.Label();
            this.txtBxForm = new System.Windows.Forms.TextBox();
            this.lblSequencia = new System.Windows.Forms.Label();
            this.txtBxSequencia = new System.Windows.Forms.TextBox();
            this.lblSigla = new System.Windows.Forms.Label();
            this.txtBxSigla = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCodAplicacao = new System.Windows.Forms.Label();
            this.txtBxDescricao = new System.Windows.Forms.TextBox();
            this.txtBxCodAplicacao = new System.Windows.Forms.TextBox();
            this.ckBxAtiva = new System.Windows.Forms.CheckBox();
            this.ErrPrvdrAplicacao = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlstrpLblExcecao = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttstrUpdateForm.SuspendLayout();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrAplicacao)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpLblError,
            this.tlstrpLblExcecao});
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 182);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(351, 22);
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
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(351, 30);
            this.pnlUpdateFormTitle.TabIndex = 4;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(112, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Atualização Aplicação";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(351, 25);
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
            this.grpBoxFields.Controls.Add(this.lblForm);
            this.grpBoxFields.Controls.Add(this.txtBxForm);
            this.grpBoxFields.Controls.Add(this.lblSequencia);
            this.grpBoxFields.Controls.Add(this.txtBxSequencia);
            this.grpBoxFields.Controls.Add(this.lblSigla);
            this.grpBoxFields.Controls.Add(this.txtBxSigla);
            this.grpBoxFields.Controls.Add(this.lblDescricao);
            this.grpBoxFields.Controls.Add(this.lblCodAplicacao);
            this.grpBoxFields.Controls.Add(this.txtBxDescricao);
            this.grpBoxFields.Controls.Add(this.txtBxCodAplicacao);
            this.grpBoxFields.Controls.Add(this.ckBxAtiva);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(351, 127);
            this.grpBoxFields.TabIndex = 6;
            this.grpBoxFields.TabStop = false;
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Location = new System.Drawing.Point(36, 100);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(63, 13);
            this.lblForm.TabIndex = 37;
            this.lblForm.Text = "Form Menu:";
            // 
            // txtBxForm
            // 
            this.txtBxForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxForm.Location = new System.Drawing.Point(105, 97);
            this.txtBxForm.MaxLength = 30;
            this.txtBxForm.Name = "txtBxForm";
            this.txtBxForm.Size = new System.Drawing.Size(229, 20);
            this.txtBxForm.TabIndex = 3;
            this.txtBxForm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxForm_KeyPress);
            this.txtBxForm.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxForm_Validating);
            // 
            // lblSequencia
            // 
            this.lblSequencia.AutoSize = true;
            this.lblSequencia.Location = new System.Drawing.Point(189, 74);
            this.lblSequencia.Name = "lblSequencia";
            this.lblSequencia.Size = new System.Drawing.Size(61, 13);
            this.lblSequencia.TabIndex = 35;
            this.lblSequencia.Text = "Sequência:";
            // 
            // txtBxSequencia
            // 
            this.txtBxSequencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSequencia.Location = new System.Drawing.Point(256, 71);
            this.txtBxSequencia.MaxLength = 4;
            this.txtBxSequencia.Name = "txtBxSequencia";
            this.txtBxSequencia.Size = new System.Drawing.Size(78, 20);
            this.txtBxSequencia.TabIndex = 2;
            this.txtBxSequencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxSequencia_KeyPress);
            this.txtBxSequencia.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxSequencia_Validating);
            // 
            // lblSigla
            // 
            this.lblSigla.AutoSize = true;
            this.lblSigla.Location = new System.Drawing.Point(66, 74);
            this.lblSigla.Name = "lblSigla";
            this.lblSigla.Size = new System.Drawing.Size(33, 13);
            this.lblSigla.TabIndex = 33;
            this.lblSigla.Text = "Sigla:";
            // 
            // txtBxSigla
            // 
            this.txtBxSigla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSigla.Location = new System.Drawing.Point(105, 71);
            this.txtBxSigla.MaxLength = 2;
            this.txtBxSigla.Name = "txtBxSigla";
            this.txtBxSigla.Size = new System.Drawing.Size(78, 20);
            this.txtBxSigla.TabIndex = 1;
            this.txtBxSigla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxSigla_KeyPress);
            this.txtBxSigla.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxSigla_Validating);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(41, 48);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 31;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblCodAplicacao
            // 
            this.lblCodAplicacao.AutoSize = true;
            this.lblCodAplicacao.Location = new System.Drawing.Point(12, 22);
            this.lblCodAplicacao.Name = "lblCodAplicacao";
            this.lblCodAplicacao.Size = new System.Drawing.Size(87, 13);
            this.lblCodAplicacao.TabIndex = 30;
            this.lblCodAplicacao.Text = "Código Empresa:";
            // 
            // txtBxDescricao
            // 
            this.txtBxDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxDescricao.Location = new System.Drawing.Point(105, 45);
            this.txtBxDescricao.MaxLength = 40;
            this.txtBxDescricao.Name = "txtBxDescricao";
            this.txtBxDescricao.Size = new System.Drawing.Size(229, 20);
            this.txtBxDescricao.TabIndex = 0;
            this.txtBxDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxDescricao_KeyPress);
            this.txtBxDescricao.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxDescricao_Validating);
            // 
            // txtBxCodAplicacao
            // 
            this.txtBxCodAplicacao.Location = new System.Drawing.Point(105, 19);
            this.txtBxCodAplicacao.Name = "txtBxCodAplicacao";
            this.txtBxCodAplicacao.ReadOnly = true;
            this.txtBxCodAplicacao.Size = new System.Drawing.Size(78, 20);
            this.txtBxCodAplicacao.TabIndex = 28;
            this.txtBxCodAplicacao.TabStop = false;
            // 
            // ckBxAtiva
            // 
            this.ckBxAtiva.AutoSize = true;
            this.ckBxAtiva.Location = new System.Drawing.Point(278, 18);
            this.ckBxAtiva.Name = "ckBxAtiva";
            this.ckBxAtiva.Size = new System.Drawing.Size(50, 17);
            this.ckBxAtiva.TabIndex = 4;
            this.ckBxAtiva.Text = "Ativa";
            this.ckBxAtiva.UseVisualStyleBackColor = true;
            // 
            // ErrPrvdrAplicacao
            // 
            this.ErrPrvdrAplicacao.ContainerControl = this;
            // 
            // tlstrpLblExcecao
            // 
            this.tlstrpLblExcecao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tlstrpLblExcecao.Name = "tlstrpLblExcecao";
            this.tlstrpLblExcecao.Size = new System.Drawing.Size(0, 17);
            this.tlstrpLblExcecao.Visible = false;
            // 
            // UpdateFormAplicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 204);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateFormAplicacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UpdateFormAplicacao_Load);
            this.sttstrUpdateForm.ResumeLayout(false);
            this.sttstrUpdateForm.PerformLayout();
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.grpBoxFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrAplicacao)).EndInit();
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
        private System.Windows.Forms.Label lblActionModuleTitle;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.TextBox txtBxForm;
        private System.Windows.Forms.Label lblSequencia;
        private System.Windows.Forms.TextBox txtBxSequencia;
        private System.Windows.Forms.Label lblSigla;
        private System.Windows.Forms.TextBox txtBxSigla;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblCodAplicacao;
        private System.Windows.Forms.TextBox txtBxDescricao;
        private System.Windows.Forms.TextBox txtBxCodAplicacao;
        private System.Windows.Forms.CheckBox ckBxAtiva;
        private System.Windows.Forms.ErrorProvider ErrPrvdrAplicacao;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblError;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblExcecao;
    }
}

