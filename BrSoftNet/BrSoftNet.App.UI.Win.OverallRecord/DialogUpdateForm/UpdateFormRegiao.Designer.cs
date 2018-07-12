namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm
{
    partial class UpdateFormRegiao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFormRegiao));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.tlstrpLblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlstrpLblExcecao = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblTitleModule = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblSigla = new System.Windows.Forms.Label();
            this.txtBxDescricao = new System.Windows.Forms.TextBox();
            this.txtBxSigla = new System.Windows.Forms.TextBox();
            this.ErrPrvdrRegiao = new System.Windows.Forms.ErrorProvider(this.components);
            this.sttstrUpdateForm.SuspendLayout();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrRegiao)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpLblError,
            this.tlstrpLblExcecao});
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 132);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(367, 22);
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
            // tlstrpLblExcecao
            // 
            this.tlstrpLblExcecao.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.tlstrpLblExcecao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tlstrpLblExcecao.Name = "tlstrpLblExcecao";
            this.tlstrpLblExcecao.Size = new System.Drawing.Size(0, 17);
            this.tlstrpLblExcecao.Visible = false;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblTitleModule);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(367, 30);
            this.pnlUpdateFormTitle.TabIndex = 4;
            // 
            // lblTitleModule
            // 
            this.lblTitleModule.AutoSize = true;
            this.lblTitleModule.Location = new System.Drawing.Point(6, 9);
            this.lblTitleModule.Name = "lblTitleModule";
            this.lblTitleModule.Size = new System.Drawing.Size(99, 13);
            this.lblTitleModule.TabIndex = 0;
            this.lblTitleModule.Text = "Atualização Região";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(367, 25);
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
            this.grpBoxFields.Controls.Add(this.lblDescricao);
            this.grpBoxFields.Controls.Add(this.lblSigla);
            this.grpBoxFields.Controls.Add(this.txtBxDescricao);
            this.grpBoxFields.Controls.Add(this.txtBxSigla);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(367, 77);
            this.grpBoxFields.TabIndex = 6;
            this.grpBoxFields.TabStop = false;
            this.grpBoxFields.Text = "Região";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(7, 48);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 3;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblSigla
            // 
            this.lblSigla.AutoSize = true;
            this.lblSigla.Location = new System.Drawing.Point(32, 22);
            this.lblSigla.Name = "lblSigla";
            this.lblSigla.Size = new System.Drawing.Size(33, 13);
            this.lblSigla.TabIndex = 2;
            this.lblSigla.Text = "Sigla:";
            // 
            // txtBxDescricao
            // 
            this.txtBxDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxDescricao.Location = new System.Drawing.Point(71, 45);
            this.txtBxDescricao.MaxLength = 20;
            this.txtBxDescricao.Name = "txtBxDescricao";
            this.txtBxDescricao.Size = new System.Drawing.Size(273, 20);
            this.txtBxDescricao.TabIndex = 1;
            this.txtBxDescricao.TextChanged += new System.EventHandler(this.txtBxDescricao_TextChanged);
            this.txtBxDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxDescricao_KeyPress);
            // 
            // txtBxSigla
            // 
            this.txtBxSigla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSigla.Location = new System.Drawing.Point(71, 19);
            this.txtBxSigla.MaxLength = 2;
            this.txtBxSigla.Name = "txtBxSigla";
            this.txtBxSigla.Size = new System.Drawing.Size(84, 20);
            this.txtBxSigla.TabIndex = 0;
            this.txtBxSigla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxSigla_KeyPress);
            this.txtBxSigla.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxSigla_Validating);
            // 
            // ErrPrvdrRegiao
            // 
            this.ErrPrvdrRegiao.ContainerControl = this;
            // 
            // UpdateFormRegiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 154);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateFormRegiao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UpdateFormRegiao_Load);
            this.sttstrUpdateForm.ResumeLayout(false);
            this.sttstrUpdateForm.PerformLayout();
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.grpBoxFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrRegiao)).EndInit();
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
        private System.Windows.Forms.Label lblSigla;
        private System.Windows.Forms.TextBox txtBxDescricao;
        private System.Windows.Forms.TextBox txtBxSigla;
        private System.Windows.Forms.ErrorProvider ErrPrvdrRegiao;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblError;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblExcecao;
    }
}

