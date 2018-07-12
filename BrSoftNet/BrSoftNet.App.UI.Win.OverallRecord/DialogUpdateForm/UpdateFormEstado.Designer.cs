namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm
{
    partial class UpdateFormEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFormEstado));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.tlstrpLblExcecao = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlstrpLblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlstrpLblException = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.cbBxRegiao = new System.Windows.Forms.ComboBox();
            this.lblTpProcInt = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblSigla = new System.Windows.Forms.Label();
            this.txtBxDescricao = new System.Windows.Forms.TextBox();
            this.txtBxSigla = new System.Windows.Forms.TextBox();
            this.ErrPrvdrEstado = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttstrUpdateForm.SuspendLayout();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrEstado)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttstrUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpLblExcecao,
            this.tlstrpLblError,
            this.tlstrpLblException,
            this.toolStripStatusLabel1});
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 162);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(367, 22);
            this.sttstrUpdateForm.TabIndex = 3;
            // 
            // tlstrpLblExcecao
            // 
            this.tlstrpLblExcecao.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.tlstrpLblExcecao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tlstrpLblExcecao.Name = "tlstrpLblExcecao";
            this.tlstrpLblExcecao.Size = new System.Drawing.Size(0, 17);
            this.tlstrpLblExcecao.Visible = false;
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
            // tlstrpLblException
            // 
            this.tlstrpLblException.Name = "tlstrpLblException";
            this.tlstrpLblException.Size = new System.Drawing.Size(0, 17);
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(367, 30);
            this.pnlUpdateFormTitle.TabIndex = 4;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(98, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Atualização Estado";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(367, 27);
            this.tlstrpActionMenuUpdateForm.TabIndex = 5;
            this.tlstrpActionMenuUpdateForm.Text = "toolStrip1";
            // 
            // tlstrpActionMenuBtnConfirm
            // 
            this.tlstrpActionMenuBtnConfirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpActionMenuBtnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpActionMenuBtnConfirm.Image")));
            this.tlstrpActionMenuBtnConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpActionMenuBtnConfirm.Name = "tlstrpActionMenuBtnConfirm";
            this.tlstrpActionMenuBtnConfirm.Size = new System.Drawing.Size(24, 24);
            this.tlstrpActionMenuBtnConfirm.ToolTipText = "Confirmar";
            this.tlstrpActionMenuBtnConfirm.Click += new System.EventHandler(this.tlstrpActionMenuBtnConfirm_Click);
            // 
            // tlstrpActionMenuBtnCancel
            // 
            this.tlstrpActionMenuBtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpActionMenuBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpActionMenuBtnCancel.Image")));
            this.tlstrpActionMenuBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpActionMenuBtnCancel.Name = "tlstrpActionMenuBtnCancel";
            this.tlstrpActionMenuBtnCancel.Size = new System.Drawing.Size(24, 24);
            this.tlstrpActionMenuBtnCancel.ToolTipText = "Cancelar";
            this.tlstrpActionMenuBtnCancel.Click += new System.EventHandler(this.tlstrpActionMenuBtnCancel_Click);
            // 
            // grpBoxFields
            // 
            this.grpBoxFields.Controls.Add(this.cbBxRegiao);
            this.grpBoxFields.Controls.Add(this.lblTpProcInt);
            this.grpBoxFields.Controls.Add(this.lblDescricao);
            this.grpBoxFields.Controls.Add(this.lblSigla);
            this.grpBoxFields.Controls.Add(this.txtBxDescricao);
            this.grpBoxFields.Controls.Add(this.txtBxSigla);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 57);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(367, 105);
            this.grpBoxFields.TabIndex = 6;
            this.grpBoxFields.TabStop = false;
            this.grpBoxFields.Text = "Estado";
            // 
            // cbBxRegiao
            // 
            this.cbBxRegiao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBxRegiao.FormattingEnabled = true;
            this.cbBxRegiao.Location = new System.Drawing.Point(70, 71);
            this.cbBxRegiao.Name = "cbBxRegiao";
            this.cbBxRegiao.Size = new System.Drawing.Size(280, 21);
            this.cbBxRegiao.TabIndex = 22;
            // 
            // lblTpProcInt
            // 
            this.lblTpProcInt.AutoSize = true;
            this.lblTpProcInt.Location = new System.Drawing.Point(20, 74);
            this.lblTpProcInt.Name = "lblTpProcInt";
            this.lblTpProcInt.Size = new System.Drawing.Size(44, 13);
            this.lblTpProcInt.TabIndex = 21;
            this.lblTpProcInt.Text = "Região:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(6, 48);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 7;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblSigla
            // 
            this.lblSigla.AutoSize = true;
            this.lblSigla.Location = new System.Drawing.Point(21, 22);
            this.lblSigla.Name = "lblSigla";
            this.lblSigla.Size = new System.Drawing.Size(43, 13);
            this.lblSigla.TabIndex = 6;
            this.lblSigla.Text = "Estado:";
            // 
            // txtBxDescricao
            // 
            this.txtBxDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxDescricao.Location = new System.Drawing.Point(70, 45);
            this.txtBxDescricao.Name = "txtBxDescricao";
            this.txtBxDescricao.Size = new System.Drawing.Size(280, 20);
            this.txtBxDescricao.TabIndex = 5;
            this.txtBxDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxDescricao_KeyPress);
            this.txtBxDescricao.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxDescricao_Validating);
            // 
            // txtBxSigla
            // 
            this.txtBxSigla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSigla.Location = new System.Drawing.Point(70, 19);
            this.txtBxSigla.MaxLength = 2;
            this.txtBxSigla.Name = "txtBxSigla";
            this.txtBxSigla.Size = new System.Drawing.Size(78, 20);
            this.txtBxSigla.TabIndex = 4;
            this.txtBxSigla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxSigla_KeyPress);
            this.txtBxSigla.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxSigla_Validating);
            // 
            // ErrPrvdrEstado
            // 
            this.ErrPrvdrEstado.ContainerControl = this;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // UpdateFormEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 184);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateFormEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UpdateFormEstado_Load);
            this.sttstrUpdateForm.ResumeLayout(false);
            this.sttstrUpdateForm.PerformLayout();
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.grpBoxFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrEstado)).EndInit();
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
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblSigla;
        private System.Windows.Forms.TextBox txtBxDescricao;
        private System.Windows.Forms.TextBox txtBxSigla;
        private System.Windows.Forms.ComboBox cbBxRegiao;
        private System.Windows.Forms.Label lblTpProcInt;
        private System.Windows.Forms.ErrorProvider ErrPrvdrEstado;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblError;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblException;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblExcecao;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

