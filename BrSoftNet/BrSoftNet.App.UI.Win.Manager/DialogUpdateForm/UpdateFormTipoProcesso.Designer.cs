namespace BrSoftNet.App.UI.Win.Manager.DialogUpdateForm
{
    partial class UpdateFormTipoProcesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFormTipoProcesso));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.tlstrpLblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblTitleModule = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.lblSequencia = new System.Windows.Forms.Label();
            this.txtBxSequenciaProcesso = new System.Windows.Forms.TextBox();
            this.txtBxCodTipoProcesso = new System.Windows.Forms.TextBox();
            this.lblDecricaoProcesso = new System.Windows.Forms.Label();
            this.lblCodigoProcesso = new System.Windows.Forms.Label();
            this.txtBxDecricaoProcesso = new System.Windows.Forms.TextBox();
            this.ErrPrvdrTipoProcesso = new System.Windows.Forms.ErrorProvider(this.components);
            this.sttstrUpdateForm.SuspendLayout();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrTipoProcesso)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpLblError});
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 220);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(347, 22);
            this.sttstrUpdateForm.TabIndex = 2;
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
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(347, 30);
            this.pnlUpdateFormTitle.TabIndex = 3;
            // 
            // lblTitleModule
            // 
            this.lblTitleModule.AutoSize = true;
            this.lblTitleModule.Location = new System.Drawing.Point(6, 9);
            this.lblTitleModule.Name = "lblTitleModule";
            this.lblTitleModule.Size = new System.Drawing.Size(133, 13);
            this.lblTitleModule.TabIndex = 0;
            this.lblTitleModule.Text = "Atualização Tipo Processo";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(347, 25);
            this.tlstrpActionMenuUpdateForm.TabIndex = 0;
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
            this.grpBoxFields.Controls.Add(this.lblSequencia);
            this.grpBoxFields.Controls.Add(this.txtBxSequenciaProcesso);
            this.grpBoxFields.Controls.Add(this.txtBxCodTipoProcesso);
            this.grpBoxFields.Controls.Add(this.lblDecricaoProcesso);
            this.grpBoxFields.Controls.Add(this.lblCodigoProcesso);
            this.grpBoxFields.Controls.Add(this.txtBxDecricaoProcesso);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(347, 165);
            this.grpBoxFields.TabIndex = 1;
            this.grpBoxFields.TabStop = false;
            // 
            // lblSequencia
            // 
            this.lblSequencia.AutoSize = true;
            this.lblSequencia.Location = new System.Drawing.Point(12, 116);
            this.lblSequencia.Name = "lblSequencia";
            this.lblSequencia.Size = new System.Drawing.Size(105, 13);
            this.lblSequencia.TabIndex = 5;
            this.lblSequencia.Text = "Sequência Processo";
            // 
            // txtBxSequenciaProcesso
            // 
            this.txtBxSequenciaProcesso.Location = new System.Drawing.Point(12, 129);
            this.txtBxSequenciaProcesso.MaxLength = 4;
            this.txtBxSequenciaProcesso.Name = "txtBxSequenciaProcesso";
            this.txtBxSequenciaProcesso.Size = new System.Drawing.Size(321, 20);
            this.txtBxSequenciaProcesso.TabIndex = 1;
            this.txtBxSequenciaProcesso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxSequenciaProcesso_KeyPress);
            this.txtBxSequenciaProcesso.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxSequenciaProcesso_Validating);
            // 
            // txtBxCodTipoProcesso
            // 
            this.txtBxCodTipoProcesso.Location = new System.Drawing.Point(12, 31);
            this.txtBxCodTipoProcesso.Name = "txtBxCodTipoProcesso";
            this.txtBxCodTipoProcesso.ReadOnly = true;
            this.txtBxCodTipoProcesso.Size = new System.Drawing.Size(321, 20);
            this.txtBxCodTipoProcesso.TabIndex = 3;
            // 
            // lblDecricaoProcesso
            // 
            this.lblDecricaoProcesso.AutoSize = true;
            this.lblDecricaoProcesso.Location = new System.Drawing.Point(12, 67);
            this.lblDecricaoProcesso.Name = "lblDecricaoProcesso";
            this.lblDecricaoProcesso.Size = new System.Drawing.Size(102, 13);
            this.lblDecricaoProcesso.TabIndex = 4;
            this.lblDecricaoProcesso.Text = "Descrição Processo";
            // 
            // lblCodigoProcesso
            // 
            this.lblCodigoProcesso.AutoSize = true;
            this.lblCodigoProcesso.Location = new System.Drawing.Point(12, 18);
            this.lblCodigoProcesso.Name = "lblCodigoProcesso";
            this.lblCodigoProcesso.Size = new System.Drawing.Size(87, 13);
            this.lblCodigoProcesso.TabIndex = 2;
            this.lblCodigoProcesso.Text = "Código Processo";
            // 
            // txtBxDecricaoProcesso
            // 
            this.txtBxDecricaoProcesso.Location = new System.Drawing.Point(12, 80);
            this.txtBxDecricaoProcesso.MaxLength = 30;
            this.txtBxDecricaoProcesso.Name = "txtBxDecricaoProcesso";
            this.txtBxDecricaoProcesso.Size = new System.Drawing.Size(321, 20);
            this.txtBxDecricaoProcesso.TabIndex = 0;
            this.txtBxDecricaoProcesso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxDecricaoProcesso_KeyPress);
            this.txtBxDecricaoProcesso.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxDecricaoProcesso_Validating);
            // 
            // ErrPrvdrTipoProcesso
            // 
            this.ErrPrvdrTipoProcesso.ContainerControl = this;
            // 
            // UpdateFormTipoProcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 242);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateFormTipoProcesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UpdateFormTipoProcesso_Load);
            this.sttstrUpdateForm.ResumeLayout(false);
            this.sttstrUpdateForm.PerformLayout();
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.grpBoxFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrTipoProcesso)).EndInit();
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
        private System.Windows.Forms.Label lblDecricaoProcesso;
        private System.Windows.Forms.Label lblCodigoProcesso;
        private System.Windows.Forms.TextBox txtBxDecricaoProcesso;
        private System.Windows.Forms.TextBox txtBxCodTipoProcesso;
        private System.Windows.Forms.Label lblSequencia;
        private System.Windows.Forms.TextBox txtBxSequenciaProcesso;
        private System.Windows.Forms.ErrorProvider ErrPrvdrTipoProcesso;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblError;
    }
}

