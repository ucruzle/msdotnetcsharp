namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    partial class FilterSearchFormLiberacaoUsuarioProcessos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormLiberacaoUsuarioProcessos));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tbPageTipoDeProcessos = new System.Windows.Forms.TabPage();
            this.tbControlProcessos = new System.Windows.Forms.TabControl();
            this.cmbBxTipoDeProcessos = new System.Windows.Forms.ComboBox();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.tbPageTipoDeProcessos.SuspendLayout();
            this.tbControlProcessos.SuspendLayout();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 133);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(318, 22);
            this.sttstrUpdateForm.TabIndex = 4;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(318, 30);
            this.pnlUpdateFormTitle.TabIndex = 5;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(81, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Filtro Processos";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(318, 25);
            this.tlstrpActionMenuUpdateForm.TabIndex = 6;
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
            // 
            // tlstrpActionMenuBtnCancel
            // 
            this.tlstrpActionMenuBtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpActionMenuBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpActionMenuBtnCancel.Image")));
            this.tlstrpActionMenuBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpActionMenuBtnCancel.Name = "tlstrpActionMenuBtnCancel";
            this.tlstrpActionMenuBtnCancel.Size = new System.Drawing.Size(23, 22);
            this.tlstrpActionMenuBtnCancel.ToolTipText = "Cancelar";
            // 
            // tbPageTipoDeProcessos
            // 
            this.tbPageTipoDeProcessos.Controls.Add(this.cmbBxTipoDeProcessos);
            this.tbPageTipoDeProcessos.Location = new System.Drawing.Point(4, 22);
            this.tbPageTipoDeProcessos.Name = "tbPageTipoDeProcessos";
            this.tbPageTipoDeProcessos.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageTipoDeProcessos.Size = new System.Drawing.Size(310, 52);
            this.tbPageTipoDeProcessos.TabIndex = 0;
            this.tbPageTipoDeProcessos.Text = "Tipo Processos";
            this.tbPageTipoDeProcessos.UseVisualStyleBackColor = true;
            // 
            // tbControlProcessos
            // 
            this.tbControlProcessos.Controls.Add(this.tbPageTipoDeProcessos);
            this.tbControlProcessos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlProcessos.Location = new System.Drawing.Point(0, 55);
            this.tbControlProcessos.Name = "tbControlProcessos";
            this.tbControlProcessos.SelectedIndex = 0;
            this.tbControlProcessos.Size = new System.Drawing.Size(318, 78);
            this.tbControlProcessos.TabIndex = 17;
            // 
            // cmbBxTipoDeProcessos
            // 
            this.cmbBxTipoDeProcessos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxTipoDeProcessos.FormattingEnabled = true;
            this.cmbBxTipoDeProcessos.Location = new System.Drawing.Point(9, 19);
            this.cmbBxTipoDeProcessos.Name = "cmbBxTipoDeProcessos";
            this.cmbBxTipoDeProcessos.Size = new System.Drawing.Size(293, 21);
            this.cmbBxTipoDeProcessos.TabIndex = 13;
            // 
            // FilterSearchFormLiberacaoUsuarioProcessos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 155);
            this.Controls.Add(this.tbControlProcessos);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilterSearchFormLiberacaoUsuarioProcessos";
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.tbPageTipoDeProcessos.ResumeLayout(false);
            this.tbControlProcessos.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tbPageTipoDeProcessos;
        private System.Windows.Forms.TabControl tbControlProcessos;
        private System.Windows.Forms.ComboBox cmbBxTipoDeProcessos;

    }
}

