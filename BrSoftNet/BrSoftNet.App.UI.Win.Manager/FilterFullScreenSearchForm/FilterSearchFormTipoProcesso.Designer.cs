namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    partial class FilterSearchFormTipoProcesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormTipoProcesso));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tbControlTipoProcesso = new System.Windows.Forms.TabControl();
            this.tbPageCodigoTipoProcesso = new System.Windows.Forms.TabPage();
            this.lblCodigoTipoProcesso = new System.Windows.Forms.Label();
            this.txtBxCodigoTipoProcesso = new System.Windows.Forms.TextBox();
            this.tbPageDecricaoTipoProcesso = new System.Windows.Forms.TabPage();
            this.lblDescricaoTipoProcesso = new System.Windows.Forms.Label();
            this.txtBxDescricaoTipoProcesso = new System.Windows.Forms.TextBox();
            this.tbPageSequenciaTipoProcesso = new System.Windows.Forms.TabPage();
            this.lblSequenciaTipoProcesso = new System.Windows.Forms.Label();
            this.txtBxSequenciaTipoProcesso = new System.Windows.Forms.TextBox();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.tbControlTipoProcesso.SuspendLayout();
            this.tbPageCodigoTipoProcesso.SuspendLayout();
            this.tbPageDecricaoTipoProcesso.SuspendLayout();
            this.tbPageSequenciaTipoProcesso.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 165);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(319, 22);
            this.sttstrUpdateForm.TabIndex = 7;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(319, 30);
            this.pnlUpdateFormTitle.TabIndex = 11;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(100, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Filtro Tipo Processo";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(319, 25);
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
            // tbControlTipoProcesso
            // 
            this.tbControlTipoProcesso.Controls.Add(this.tbPageCodigoTipoProcesso);
            this.tbControlTipoProcesso.Controls.Add(this.tbPageDecricaoTipoProcesso);
            this.tbControlTipoProcesso.Controls.Add(this.tbPageSequenciaTipoProcesso);
            this.tbControlTipoProcesso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlTipoProcesso.Location = new System.Drawing.Point(0, 13);
            this.tbControlTipoProcesso.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tbControlTipoProcesso.Name = "tbControlTipoProcesso";
            this.tbControlTipoProcesso.Padding = new System.Drawing.Point(6, 0);
            this.tbControlTipoProcesso.SelectedIndex = 0;
            this.tbControlTipoProcesso.Size = new System.Drawing.Size(319, 97);
            this.tbControlTipoProcesso.TabIndex = 18;
            // 
            // tbPageCodigoTipoProcesso
            // 
            this.tbPageCodigoTipoProcesso.Controls.Add(this.lblCodigoTipoProcesso);
            this.tbPageCodigoTipoProcesso.Controls.Add(this.txtBxCodigoTipoProcesso);
            this.tbPageCodigoTipoProcesso.Location = new System.Drawing.Point(4, 20);
            this.tbPageCodigoTipoProcesso.Name = "tbPageCodigoTipoProcesso";
            this.tbPageCodigoTipoProcesso.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageCodigoTipoProcesso.Size = new System.Drawing.Size(311, 73);
            this.tbPageCodigoTipoProcesso.TabIndex = 0;
            this.tbPageCodigoTipoProcesso.Text = "Processo";
            this.tbPageCodigoTipoProcesso.UseVisualStyleBackColor = true;
            // 
            // lblCodigoTipoProcesso
            // 
            this.lblCodigoTipoProcesso.AutoSize = true;
            this.lblCodigoTipoProcesso.Location = new System.Drawing.Point(6, 3);
            this.lblCodigoTipoProcesso.Name = "lblCodigoTipoProcesso";
            this.lblCodigoTipoProcesso.Size = new System.Drawing.Size(40, 13);
            this.lblCodigoTipoProcesso.TabIndex = 1;
            this.lblCodigoTipoProcesso.Text = "Código";
            // 
            // txtBxCodigoTipoProcesso
            // 
            this.txtBxCodigoTipoProcesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodigoTipoProcesso.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodigoTipoProcesso.Name = "txtBxCodigoTipoProcesso";
            this.txtBxCodigoTipoProcesso.Size = new System.Drawing.Size(294, 20);
            this.txtBxCodigoTipoProcesso.TabIndex = 0;
            // 
            // tbPageDecricaoTipoProcesso
            // 
            this.tbPageDecricaoTipoProcesso.Controls.Add(this.lblDescricaoTipoProcesso);
            this.tbPageDecricaoTipoProcesso.Controls.Add(this.txtBxDescricaoTipoProcesso);
            this.tbPageDecricaoTipoProcesso.Location = new System.Drawing.Point(4, 20);
            this.tbPageDecricaoTipoProcesso.Name = "tbPageDecricaoTipoProcesso";
            this.tbPageDecricaoTipoProcesso.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageDecricaoTipoProcesso.Size = new System.Drawing.Size(311, 73);
            this.tbPageDecricaoTipoProcesso.TabIndex = 2;
            this.tbPageDecricaoTipoProcesso.Text = "Descrição";
            this.tbPageDecricaoTipoProcesso.UseVisualStyleBackColor = true;
            // 
            // lblDescricaoTipoProcesso
            // 
            this.lblDescricaoTipoProcesso.AutoSize = true;
            this.lblDescricaoTipoProcesso.Location = new System.Drawing.Point(6, 3);
            this.lblDescricaoTipoProcesso.Name = "lblDescricaoTipoProcesso";
            this.lblDescricaoTipoProcesso.Size = new System.Drawing.Size(55, 13);
            this.lblDescricaoTipoProcesso.TabIndex = 3;
            this.lblDescricaoTipoProcesso.Text = "Descrição";
            // 
            // txtBxDescricaoTipoProcesso
            // 
            this.txtBxDescricaoTipoProcesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxDescricaoTipoProcesso.Location = new System.Drawing.Point(9, 19);
            this.txtBxDescricaoTipoProcesso.Name = "txtBxDescricaoTipoProcesso";
            this.txtBxDescricaoTipoProcesso.Size = new System.Drawing.Size(294, 20);
            this.txtBxDescricaoTipoProcesso.TabIndex = 2;
            // 
            // tbPageSequenciaTipoProcesso
            // 
            this.tbPageSequenciaTipoProcesso.Controls.Add(this.lblSequenciaTipoProcesso);
            this.tbPageSequenciaTipoProcesso.Controls.Add(this.txtBxSequenciaTipoProcesso);
            this.tbPageSequenciaTipoProcesso.Location = new System.Drawing.Point(4, 20);
            this.tbPageSequenciaTipoProcesso.Name = "tbPageSequenciaTipoProcesso";
            this.tbPageSequenciaTipoProcesso.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageSequenciaTipoProcesso.Size = new System.Drawing.Size(311, 73);
            this.tbPageSequenciaTipoProcesso.TabIndex = 1;
            this.tbPageSequenciaTipoProcesso.Text = "Sequência";
            this.tbPageSequenciaTipoProcesso.UseVisualStyleBackColor = true;
            // 
            // lblSequenciaTipoProcesso
            // 
            this.lblSequenciaTipoProcesso.AutoSize = true;
            this.lblSequenciaTipoProcesso.Location = new System.Drawing.Point(6, 3);
            this.lblSequenciaTipoProcesso.Name = "lblSequenciaTipoProcesso";
            this.lblSequenciaTipoProcesso.Size = new System.Drawing.Size(58, 13);
            this.lblSequenciaTipoProcesso.TabIndex = 1;
            this.lblSequenciaTipoProcesso.Text = "Sequência";
            // 
            // txtBxSequenciaTipoProcesso
            // 
            this.txtBxSequenciaTipoProcesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSequenciaTipoProcesso.Location = new System.Drawing.Point(9, 19);
            this.txtBxSequenciaTipoProcesso.Name = "txtBxSequenciaTipoProcesso";
            this.txtBxSequenciaTipoProcesso.Size = new System.Drawing.Size(294, 20);
            this.txtBxSequenciaTipoProcesso.TabIndex = 0;
            // 
            // grpBoxFields
            // 
            this.grpBoxFields.Controls.Add(this.tbControlTipoProcesso);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Margin = new System.Windows.Forms.Padding(0);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Padding = new System.Windows.Forms.Padding(0);
            this.grpBoxFields.Size = new System.Drawing.Size(319, 110);
            this.grpBoxFields.TabIndex = 13;
            this.grpBoxFields.TabStop = false;
            // 
            // FilterSearchFormTipoProcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 187);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSearchFormTipoProcesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.tbControlTipoProcesso.ResumeLayout(false);
            this.tbPageCodigoTipoProcesso.ResumeLayout(false);
            this.tbPageCodigoTipoProcesso.PerformLayout();
            this.tbPageDecricaoTipoProcesso.ResumeLayout(false);
            this.tbPageDecricaoTipoProcesso.PerformLayout();
            this.tbPageSequenciaTipoProcesso.ResumeLayout(false);
            this.tbPageSequenciaTipoProcesso.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tbControlTipoProcesso;
        private System.Windows.Forms.TabPage tbPageCodigoTipoProcesso;
        private System.Windows.Forms.Label lblCodigoTipoProcesso;
        private System.Windows.Forms.TextBox txtBxCodigoTipoProcesso;
        private System.Windows.Forms.TabPage tbPageDecricaoTipoProcesso;
        private System.Windows.Forms.Label lblDescricaoTipoProcesso;
        private System.Windows.Forms.TextBox txtBxDescricaoTipoProcesso;
        private System.Windows.Forms.TabPage tbPageSequenciaTipoProcesso;
        private System.Windows.Forms.Label lblSequenciaTipoProcesso;
        private System.Windows.Forms.TextBox txtBxSequenciaTipoProcesso;
        private System.Windows.Forms.GroupBox grpBoxFields;
    }
}

