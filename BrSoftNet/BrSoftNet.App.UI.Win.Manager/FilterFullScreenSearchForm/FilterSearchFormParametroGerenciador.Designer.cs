namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    partial class FilterSearchFormParametroGerenciador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormParametroGerenciador));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.tbcntrlFiltrParamRegGeral = new System.Windows.Forms.TabControl();
            this.tbpgConsCod = new System.Windows.Forms.TabPage();
            this.txtCodParamGer = new System.Windows.Forms.TextBox();
            this.lblCodParamGer = new System.Windows.Forms.Label();
            this.tbpgConsTpProcEspc = new System.Windows.Forms.TabPage();
            this.cmbBoxTpProcEspCons = new System.Windows.Forms.ComboBox();
            this.lblTpProcEspCons = new System.Windows.Forms.Label();
            this.tbpgConsTpProcInt = new System.Windows.Forms.TabPage();
            this.cmbBoxTpProcIntCons = new System.Windows.Forms.ComboBox();
            this.lblTpProcIntCons = new System.Windows.Forms.Label();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            this.tbcntrlFiltrParamRegGeral.SuspendLayout();
            this.tbpgConsCod.SuspendLayout();
            this.tbpgConsTpProcEspc.SuspendLayout();
            this.tbpgConsTpProcInt.SuspendLayout();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 154);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(419, 22);
            this.sttstrUpdateForm.TabIndex = 7;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(419, 30);
            this.pnlUpdateFormTitle.TabIndex = 11;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(141, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Filtro Parâmetro Gerenciador";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(419, 25);
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
            this.grpBoxFields.Controls.Add(this.tbcntrlFiltrParamRegGeral);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(419, 99);
            this.grpBoxFields.TabIndex = 13;
            this.grpBoxFields.TabStop = false;
            // 
            // tbcntrlFiltrParamRegGeral
            // 
            this.tbcntrlFiltrParamRegGeral.Controls.Add(this.tbpgConsCod);
            this.tbcntrlFiltrParamRegGeral.Controls.Add(this.tbpgConsTpProcEspc);
            this.tbcntrlFiltrParamRegGeral.Controls.Add(this.tbpgConsTpProcInt);
            this.tbcntrlFiltrParamRegGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcntrlFiltrParamRegGeral.Location = new System.Drawing.Point(3, 16);
            this.tbcntrlFiltrParamRegGeral.Name = "tbcntrlFiltrParamRegGeral";
            this.tbcntrlFiltrParamRegGeral.SelectedIndex = 0;
            this.tbcntrlFiltrParamRegGeral.Size = new System.Drawing.Size(413, 80);
            this.tbcntrlFiltrParamRegGeral.TabIndex = 0;
            // 
            // tbpgConsCod
            // 
            this.tbpgConsCod.Controls.Add(this.txtCodParamGer);
            this.tbpgConsCod.Controls.Add(this.lblCodParamGer);
            this.tbpgConsCod.Location = new System.Drawing.Point(4, 22);
            this.tbpgConsCod.Name = "tbpgConsCod";
            this.tbpgConsCod.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgConsCod.Size = new System.Drawing.Size(405, 54);
            this.tbpgConsCod.TabIndex = 0;
            this.tbpgConsCod.Text = "Dados de Registro";
            this.tbpgConsCod.UseVisualStyleBackColor = true;
            // 
            // txtCodParamGer
            // 
            this.txtCodParamGer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodParamGer.Location = new System.Drawing.Point(5, 20);
            this.txtCodParamGer.MaxLength = 18;
            this.txtCodParamGer.Name = "txtCodParamGer";
            this.txtCodParamGer.Size = new System.Drawing.Size(390, 20);
            this.txtCodParamGer.TabIndex = 3;
            // 
            // lblCodParamGer
            // 
            this.lblCodParamGer.AutoSize = true;
            this.lblCodParamGer.Location = new System.Drawing.Point(5, 4);
            this.lblCodParamGer.Name = "lblCodParamGer";
            this.lblCodParamGer.Size = new System.Drawing.Size(68, 13);
            this.lblCodParamGer.TabIndex = 2;
            this.lblCodParamGer.Text = "Cód.Registro";
            // 
            // tbpgConsTpProcEspc
            // 
            this.tbpgConsTpProcEspc.Controls.Add(this.cmbBoxTpProcEspCons);
            this.tbpgConsTpProcEspc.Controls.Add(this.lblTpProcEspCons);
            this.tbpgConsTpProcEspc.Location = new System.Drawing.Point(4, 22);
            this.tbpgConsTpProcEspc.Name = "tbpgConsTpProcEspc";
            this.tbpgConsTpProcEspc.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgConsTpProcEspc.Size = new System.Drawing.Size(405, 54);
            this.tbpgConsTpProcEspc.TabIndex = 1;
            this.tbpgConsTpProcEspc.Text = "Dados Tipo Processo Especial";
            this.tbpgConsTpProcEspc.UseVisualStyleBackColor = true;
            // 
            // cmbBoxTpProcEspCons
            // 
            this.cmbBoxTpProcEspCons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxTpProcEspCons.FormattingEnabled = true;
            this.cmbBoxTpProcEspCons.Location = new System.Drawing.Point(5, 25);
            this.cmbBoxTpProcEspCons.Name = "cmbBoxTpProcEspCons";
            this.cmbBoxTpProcEspCons.Size = new System.Drawing.Size(390, 21);
            this.cmbBoxTpProcEspCons.TabIndex = 6;
            // 
            // lblTpProcEspCons
            // 
            this.lblTpProcEspCons.AutoSize = true;
            this.lblTpProcEspCons.Location = new System.Drawing.Point(5, 9);
            this.lblTpProcEspCons.Name = "lblTpProcEspCons";
            this.lblTpProcEspCons.Size = new System.Drawing.Size(118, 13);
            this.lblTpProcEspCons.TabIndex = 4;
            this.lblTpProcEspCons.Text = "Tipo Processo Especial";
            // 
            // tbpgConsTpProcInt
            // 
            this.tbpgConsTpProcInt.Controls.Add(this.cmbBoxTpProcIntCons);
            this.tbpgConsTpProcInt.Controls.Add(this.lblTpProcIntCons);
            this.tbpgConsTpProcInt.Location = new System.Drawing.Point(4, 22);
            this.tbpgConsTpProcInt.Name = "tbpgConsTpProcInt";
            this.tbpgConsTpProcInt.Size = new System.Drawing.Size(405, 54);
            this.tbpgConsTpProcInt.TabIndex = 2;
            this.tbpgConsTpProcInt.Text = "Dados Tipo Processo Internet";
            this.tbpgConsTpProcInt.UseVisualStyleBackColor = true;
            // 
            // cmbBoxTpProcIntCons
            // 
            this.cmbBoxTpProcIntCons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxTpProcIntCons.FormattingEnabled = true;
            this.cmbBoxTpProcIntCons.Location = new System.Drawing.Point(5, 25);
            this.cmbBoxTpProcIntCons.Name = "cmbBoxTpProcIntCons";
            this.cmbBoxTpProcIntCons.Size = new System.Drawing.Size(390, 21);
            this.cmbBoxTpProcIntCons.TabIndex = 5;
            // 
            // lblTpProcIntCons
            // 
            this.lblTpProcIntCons.AutoSize = true;
            this.lblTpProcIntCons.Location = new System.Drawing.Point(5, 9);
            this.lblTpProcIntCons.Name = "lblTpProcIntCons";
            this.lblTpProcIntCons.Size = new System.Drawing.Size(114, 13);
            this.lblTpProcIntCons.TabIndex = 4;
            this.lblTpProcIntCons.Text = "Tipo Processo Interner";
            // 
            // FilterSearchFormParametroGerenciador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 176);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSearchFormParametroGerenciador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.tbcntrlFiltrParamRegGeral.ResumeLayout(false);
            this.tbpgConsCod.ResumeLayout(false);
            this.tbpgConsCod.PerformLayout();
            this.tbpgConsTpProcEspc.ResumeLayout(false);
            this.tbpgConsTpProcEspc.PerformLayout();
            this.tbpgConsTpProcInt.ResumeLayout(false);
            this.tbpgConsTpProcInt.PerformLayout();
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
        private System.Windows.Forms.TabControl tbcntrlFiltrParamRegGeral;
        private System.Windows.Forms.TabPage tbpgConsCod;
        private System.Windows.Forms.TabPage tbpgConsTpProcEspc;
        private System.Windows.Forms.TabPage tbpgConsTpProcInt;
        private System.Windows.Forms.TextBox txtCodParamGer;
        private System.Windows.Forms.Label lblCodParamGer;
        private System.Windows.Forms.Label lblTpProcEspCons;
        private System.Windows.Forms.Label lblTpProcIntCons;
        private System.Windows.Forms.ComboBox cmbBoxTpProcIntCons;
        private System.Windows.Forms.ComboBox cmbBoxTpProcEspCons;
    }
}

