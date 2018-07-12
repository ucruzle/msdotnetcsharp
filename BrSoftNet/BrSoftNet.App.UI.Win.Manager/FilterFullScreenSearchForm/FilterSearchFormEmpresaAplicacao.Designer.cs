namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    partial class FilterSearchFormEmpresaAplicacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormEmpresaAplicacao));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.tbControlEmpresaAplicacao = new System.Windows.Forms.TabControl();
            this.tbPageCodigoEmpresa = new System.Windows.Forms.TabPage();
            this.lblCodigoEmpresa = new System.Windows.Forms.Label();
            this.txtBxCodigoEmpresa = new System.Windows.Forms.TextBox();
            this.tbPageCodigoAplicacao = new System.Windows.Forms.TabPage();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.txtBxCodigoAplicacao = new System.Windows.Forms.TextBox();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            this.tbControlEmpresaAplicacao.SuspendLayout();
            this.tbPageCodigoEmpresa.SuspendLayout();
            this.tbPageCodigoAplicacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 151);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(326, 22);
            this.sttstrUpdateForm.TabIndex = 7;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(326, 30);
            this.pnlUpdateFormTitle.TabIndex = 11;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(134, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Título do Filtro de Consulta";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(326, 25);
            this.tlstrpActionMenuUpdateForm.TabIndex = 12;
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
            this.grpBoxFields.Controls.Add(this.tbControlEmpresaAplicacao);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(326, 96);
            this.grpBoxFields.TabIndex = 13;
            this.grpBoxFields.TabStop = false;
            // 
            // tbControlEmpresaAplicacao
            // 
            this.tbControlEmpresaAplicacao.Controls.Add(this.tbPageCodigoEmpresa);
            this.tbControlEmpresaAplicacao.Controls.Add(this.tbPageCodigoAplicacao);
            this.tbControlEmpresaAplicacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlEmpresaAplicacao.Location = new System.Drawing.Point(3, 16);
            this.tbControlEmpresaAplicacao.Name = "tbControlEmpresaAplicacao";
            this.tbControlEmpresaAplicacao.SelectedIndex = 0;
            this.tbControlEmpresaAplicacao.Size = new System.Drawing.Size(320, 77);
            this.tbControlEmpresaAplicacao.TabIndex = 18;
            // 
            // tbPageCodigoEmpresa
            // 
            this.tbPageCodigoEmpresa.Controls.Add(this.lblCodigoEmpresa);
            this.tbPageCodigoEmpresa.Controls.Add(this.txtBxCodigoEmpresa);
            this.tbPageCodigoEmpresa.Location = new System.Drawing.Point(4, 22);
            this.tbPageCodigoEmpresa.Name = "tbPageCodigoEmpresa";
            this.tbPageCodigoEmpresa.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageCodigoEmpresa.Size = new System.Drawing.Size(312, 51);
            this.tbPageCodigoEmpresa.TabIndex = 0;
            this.tbPageCodigoEmpresa.Text = "Empresa";
            this.tbPageCodigoEmpresa.UseVisualStyleBackColor = true;
            // 
            // lblCodigoEmpresa
            // 
            this.lblCodigoEmpresa.AutoSize = true;
            this.lblCodigoEmpresa.Location = new System.Drawing.Point(6, 3);
            this.lblCodigoEmpresa.Name = "lblCodigoEmpresa";
            this.lblCodigoEmpresa.Size = new System.Drawing.Size(48, 13);
            this.lblCodigoEmpresa.TabIndex = 1;
            this.lblCodigoEmpresa.Text = "Empresa";
            // 
            // txtBxCodigoEmpresa
            // 
            this.txtBxCodigoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodigoEmpresa.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodigoEmpresa.Name = "txtBxCodigoEmpresa";
            this.txtBxCodigoEmpresa.Size = new System.Drawing.Size(294, 20);
            this.txtBxCodigoEmpresa.TabIndex = 0;
            // 
            // tbPageCodigoAplicacao
            // 
            this.tbPageCodigoAplicacao.Controls.Add(this.lblGrupo);
            this.tbPageCodigoAplicacao.Controls.Add(this.txtBxCodigoAplicacao);
            this.tbPageCodigoAplicacao.Location = new System.Drawing.Point(4, 22);
            this.tbPageCodigoAplicacao.Name = "tbPageCodigoAplicacao";
            this.tbPageCodigoAplicacao.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageCodigoAplicacao.Size = new System.Drawing.Size(312, 51);
            this.tbPageCodigoAplicacao.TabIndex = 2;
            this.tbPageCodigoAplicacao.Text = "Aplicação";
            this.tbPageCodigoAplicacao.UseVisualStyleBackColor = true;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(6, 3);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(54, 13);
            this.lblGrupo.TabIndex = 3;
            this.lblGrupo.Text = "Aplicação";
            // 
            // txtBxCodigoAplicacao
            // 
            this.txtBxCodigoAplicacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodigoAplicacao.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodigoAplicacao.Name = "txtBxCodigoAplicacao";
            this.txtBxCodigoAplicacao.Size = new System.Drawing.Size(290, 20);
            this.txtBxCodigoAplicacao.TabIndex = 2;
            // 
            // FilterSearchFormEmpresaAplicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 173);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSearchFormEmpresaAplicacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.tbControlEmpresaAplicacao.ResumeLayout(false);
            this.tbPageCodigoEmpresa.ResumeLayout(false);
            this.tbPageCodigoEmpresa.PerformLayout();
            this.tbPageCodigoAplicacao.ResumeLayout(false);
            this.tbPageCodigoAplicacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sttstrUpdateForm;
        private System.Windows.Forms.Panel pnlUpdateFormTitle;
        private System.Windows.Forms.Label lblActionModuleTitle;
        private System.Windows.Forms.ToolStrip tlstrpActionMenuUpdateForm;
        private System.Windows.Forms.ToolStripButton tlstrpActionMenuBtnConfirm;
        private System.Windows.Forms.ToolStripButton tlstrpActionMenuBtnCancel;
        private System.Windows.Forms.GroupBox grpBoxFields;
        private System.Windows.Forms.TabControl tbControlEmpresaAplicacao;
        private System.Windows.Forms.TabPage tbPageCodigoEmpresa;
        private System.Windows.Forms.Label lblCodigoEmpresa;
        private System.Windows.Forms.TextBox txtBxCodigoEmpresa;
        private System.Windows.Forms.TabPage tbPageCodigoAplicacao;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.TextBox txtBxCodigoAplicacao;
    }
}

