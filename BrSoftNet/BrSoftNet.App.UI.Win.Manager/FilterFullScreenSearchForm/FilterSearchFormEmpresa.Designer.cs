namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    partial class FilterSearchFormEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormEmpresa));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.tbControlEmpresa = new System.Windows.Forms.TabControl();
            this.tbPageCodigo = new System.Windows.Forms.TabPage();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtBxCodigoEmpresa = new System.Windows.Forms.TextBox();
            this.tbPageDescricao = new System.Windows.Forms.TabPage();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtBxDescricao = new System.Windows.Forms.TextBox();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.tbControlEmpresa.SuspendLayout();
            this.tbPageCodigo.SuspendLayout();
            this.tbPageDescricao.SuspendLayout();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 133);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(318, 22);
            this.sttstrUpdateForm.TabIndex = 7;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(318, 30);
            this.pnlUpdateFormTitle.TabIndex = 11;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(73, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Filtro Empresa";
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
            // grpBoxFields
            // 
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(318, 78);
            this.grpBoxFields.TabIndex = 13;
            this.grpBoxFields.TabStop = false;
            // 
            // tbControlEmpresa
            // 
            this.tbControlEmpresa.Controls.Add(this.tbPageCodigo);
            this.tbControlEmpresa.Controls.Add(this.tbPageDescricao);
            this.tbControlEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlEmpresa.Location = new System.Drawing.Point(0, 55);
            this.tbControlEmpresa.Name = "tbControlEmpresa";
            this.tbControlEmpresa.SelectedIndex = 0;
            this.tbControlEmpresa.Size = new System.Drawing.Size(318, 78);
            this.tbControlEmpresa.TabIndex = 16;
            // 
            // tbPageCodigo
            // 
            this.tbPageCodigo.Controls.Add(this.lblCodigo);
            this.tbPageCodigo.Controls.Add(this.txtBxCodigoEmpresa);
            this.tbPageCodigo.Location = new System.Drawing.Point(4, 22);
            this.tbPageCodigo.Name = "tbPageCodigo";
            this.tbPageCodigo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageCodigo.Size = new System.Drawing.Size(310, 52);
            this.tbPageCodigo.TabIndex = 0;
            this.tbPageCodigo.Text = "Código";
            this.tbPageCodigo.UseVisualStyleBackColor = true;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 3);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Código";
            // 
            // txtBxCodigoEmpresa
            // 
            this.txtBxCodigoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodigoEmpresa.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodigoEmpresa.Name = "txtBxCodigoEmpresa";
            this.txtBxCodigoEmpresa.Size = new System.Drawing.Size(293, 20);
            this.txtBxCodigoEmpresa.TabIndex = 0;
            // 
            // tbPageDescricao
            // 
            this.tbPageDescricao.Controls.Add(this.lblDescricao);
            this.tbPageDescricao.Controls.Add(this.txtBxDescricao);
            this.tbPageDescricao.Location = new System.Drawing.Point(4, 22);
            this.tbPageDescricao.Name = "tbPageDescricao";
            this.tbPageDescricao.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageDescricao.Size = new System.Drawing.Size(310, 52);
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
            this.txtBxDescricao.Size = new System.Drawing.Size(293, 20);
            this.txtBxDescricao.TabIndex = 0;
            // 
            // FilterSearchFormEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 155);
            this.Controls.Add(this.tbControlEmpresa);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSearchFormEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.tbControlEmpresa.ResumeLayout(false);
            this.tbPageCodigo.ResumeLayout(false);
            this.tbPageCodigo.PerformLayout();
            this.tbPageDescricao.ResumeLayout(false);
            this.tbPageDescricao.PerformLayout();
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
        private System.Windows.Forms.TabControl tbControlEmpresa;
        private System.Windows.Forms.TabPage tbPageCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtBxCodigoEmpresa;
        private System.Windows.Forms.TabPage tbPageDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtBxDescricao;
    }
}

