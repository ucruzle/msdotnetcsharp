namespace BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm
{
    partial class FilterSearchFormTipoRg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormTipoRg));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.tbControlTipoRg = new System.Windows.Forms.TabControl();
            this.tbPageTipo = new System.Windows.Forms.TabPage();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtBxTipo = new System.Windows.Forms.TextBox();
            this.tbPageDescricao = new System.Windows.Forms.TabPage();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtBxDescricao = new System.Windows.Forms.TextBox();
            this.ErrPrvdrTipoRg = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.tbControlTipoRg.SuspendLayout();
            this.tbPageTipo.SuspendLayout();
            this.tbPageDescricao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrTipoRg)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 131);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(316, 22);
            this.sttstrUpdateForm.TabIndex = 7;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(316, 30);
            this.pnlUpdateFormTitle.TabIndex = 11;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(72, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Filtro Tipo RG";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(316, 25);
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
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(316, 76);
            this.grpBoxFields.TabIndex = 13;
            this.grpBoxFields.TabStop = false;
            // 
            // tbControlTipoRg
            // 
            this.tbControlTipoRg.Controls.Add(this.tbPageTipo);
            this.tbControlTipoRg.Controls.Add(this.tbPageDescricao);
            this.tbControlTipoRg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlTipoRg.Location = new System.Drawing.Point(0, 55);
            this.tbControlTipoRg.Name = "tbControlTipoRg";
            this.tbControlTipoRg.SelectedIndex = 0;
            this.tbControlTipoRg.Size = new System.Drawing.Size(316, 76);
            this.tbControlTipoRg.TabIndex = 14;
            // 
            // tbPageTipo
            // 
            this.tbPageTipo.Controls.Add(this.lblTipo);
            this.tbPageTipo.Controls.Add(this.txtBxTipo);
            this.tbPageTipo.Location = new System.Drawing.Point(4, 22);
            this.tbPageTipo.Name = "tbPageTipo";
            this.tbPageTipo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageTipo.Size = new System.Drawing.Size(311, 50);
            this.tbPageTipo.TabIndex = 0;
            this.tbPageTipo.Text = "Tipo";
            this.tbPageTipo.UseVisualStyleBackColor = true;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(6, 3);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo";
            // 
            // txtBxTipo
            // 
            this.txtBxTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxTipo.Location = new System.Drawing.Point(9, 19);
            this.txtBxTipo.MaxLength = 1;
            this.txtBxTipo.Name = "txtBxTipo";
            this.txtBxTipo.Size = new System.Drawing.Size(285, 20);
            this.txtBxTipo.TabIndex = 0;
            this.txtBxTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxTipo_KeyPress);
            // 
            // tbPageDescricao
            // 
            this.tbPageDescricao.Controls.Add(this.lblDescricao);
            this.tbPageDescricao.Controls.Add(this.txtBxDescricao);
            this.tbPageDescricao.Location = new System.Drawing.Point(4, 22);
            this.tbPageDescricao.Name = "tbPageDescricao";
            this.tbPageDescricao.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageDescricao.Size = new System.Drawing.Size(308, 50);
            this.tbPageDescricao.TabIndex = 1;
            this.tbPageDescricao.Text = "Descrição";
            this.tbPageDescricao.UseVisualStyleBackColor = true;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(6, 3);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtBxDescricao
            // 
            this.txtBxDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxDescricao.Location = new System.Drawing.Point(9, 19);
            this.txtBxDescricao.Name = "txtBxDescricao";
            this.txtBxDescricao.Size = new System.Drawing.Size(281, 20);
            this.txtBxDescricao.TabIndex = 0;
            this.txtBxDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxDescricao_KeyPress);
            // 
            // ErrPrvdrTipoRg
            // 
            this.ErrPrvdrTipoRg.ContainerControl = this;
            // 
            // FilterSearchFormTipoRg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 153);
            this.Controls.Add(this.tbControlTipoRg);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSearchFormTipoRg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.tbControlTipoRg.ResumeLayout(false);
            this.tbPageTipo.ResumeLayout(false);
            this.tbPageTipo.PerformLayout();
            this.tbPageDescricao.ResumeLayout(false);
            this.tbPageDescricao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrTipoRg)).EndInit();
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
        private System.Windows.Forms.TabControl tbControlTipoRg;
        private System.Windows.Forms.TabPage tbPageTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtBxTipo;
        private System.Windows.Forms.TabPage tbPageDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtBxDescricao;
        private System.Windows.Forms.ErrorProvider ErrPrvdrTipoRg;
    }
}

