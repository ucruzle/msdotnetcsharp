namespace BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm
{
    partial class FilterSearchFormEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormEstado));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.tbControlEstado = new System.Windows.Forms.TabControl();
            this.tbPageSiglaEstado = new System.Windows.Forms.TabPage();
            this.lblSiglaEstado = new System.Windows.Forms.Label();
            this.txtBxSiglaEstado = new System.Windows.Forms.TextBox();
            this.tbPageDescricao = new System.Windows.Forms.TabPage();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtBxDescricao = new System.Windows.Forms.TextBox();
            this.tbPageSiglaRegiao = new System.Windows.Forms.TabPage();
            this.lblSiglaRegiao = new System.Windows.Forms.Label();
            this.txtBxSiglaRegiao = new System.Windows.Forms.TextBox();
            this.ErrPrvdrSiglaUf = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.tbControlEstado.SuspendLayout();
            this.tbPageSiglaEstado.SuspendLayout();
            this.tbPageDescricao.SuspendLayout();
            this.tbPageSiglaRegiao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrSiglaUf)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 132);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(312, 22);
            this.sttstrUpdateForm.TabIndex = 7;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(312, 30);
            this.pnlUpdateFormTitle.TabIndex = 11;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(65, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Filtro Estado";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(312, 25);
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
            this.grpBoxFields.Size = new System.Drawing.Size(312, 77);
            this.grpBoxFields.TabIndex = 13;
            this.grpBoxFields.TabStop = false;
            // 
            // tbControlEstado
            // 
            this.tbControlEstado.Controls.Add(this.tbPageSiglaEstado);
            this.tbControlEstado.Controls.Add(this.tbPageDescricao);
            this.tbControlEstado.Controls.Add(this.tbPageSiglaRegiao);
            this.tbControlEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlEstado.Location = new System.Drawing.Point(0, 55);
            this.tbControlEstado.Name = "tbControlEstado";
            this.tbControlEstado.SelectedIndex = 0;
            this.tbControlEstado.Size = new System.Drawing.Size(312, 77);
            this.tbControlEstado.TabIndex = 14;
            // 
            // tbPageSiglaEstado
            // 
            this.tbPageSiglaEstado.Controls.Add(this.lblSiglaEstado);
            this.tbPageSiglaEstado.Controls.Add(this.txtBxSiglaEstado);
            this.tbPageSiglaEstado.Location = new System.Drawing.Point(4, 22);
            this.tbPageSiglaEstado.Name = "tbPageSiglaEstado";
            this.tbPageSiglaEstado.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageSiglaEstado.Size = new System.Drawing.Size(304, 51);
            this.tbPageSiglaEstado.TabIndex = 0;
            this.tbPageSiglaEstado.Text = "Sigla Estado";
            this.tbPageSiglaEstado.UseVisualStyleBackColor = true;
            // 
            // lblSiglaEstado
            // 
            this.lblSiglaEstado.AutoSize = true;
            this.lblSiglaEstado.Location = new System.Drawing.Point(6, 3);
            this.lblSiglaEstado.Name = "lblSiglaEstado";
            this.lblSiglaEstado.Size = new System.Drawing.Size(30, 13);
            this.lblSiglaEstado.TabIndex = 1;
            this.lblSiglaEstado.Text = "Sigla";
            // 
            // txtBxSiglaEstado
            // 
            this.txtBxSiglaEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSiglaEstado.Location = new System.Drawing.Point(9, 19);
            this.txtBxSiglaEstado.MaxLength = 2;
            this.txtBxSiglaEstado.Name = "txtBxSiglaEstado";
            this.txtBxSiglaEstado.Size = new System.Drawing.Size(278, 20);
            this.txtBxSiglaEstado.TabIndex = 0;
            this.txtBxSiglaEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxSiglaEstado_KeyPress);
            // 
            // tbPageDescricao
            // 
            this.tbPageDescricao.Controls.Add(this.lblDescricao);
            this.tbPageDescricao.Controls.Add(this.txtBxDescricao);
            this.tbPageDescricao.Location = new System.Drawing.Point(4, 22);
            this.tbPageDescricao.Name = "tbPageDescricao";
            this.tbPageDescricao.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageDescricao.Size = new System.Drawing.Size(304, 51);
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
            this.txtBxDescricao.MaxLength = 30;
            this.txtBxDescricao.Name = "txtBxDescricao";
            this.txtBxDescricao.Size = new System.Drawing.Size(278, 20);
            this.txtBxDescricao.TabIndex = 0;
            // 
            // tbPageSiglaRegiao
            // 
            this.tbPageSiglaRegiao.Controls.Add(this.lblSiglaRegiao);
            this.tbPageSiglaRegiao.Controls.Add(this.txtBxSiglaRegiao);
            this.tbPageSiglaRegiao.Location = new System.Drawing.Point(4, 22);
            this.tbPageSiglaRegiao.Name = "tbPageSiglaRegiao";
            this.tbPageSiglaRegiao.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageSiglaRegiao.Size = new System.Drawing.Size(304, 51);
            this.tbPageSiglaRegiao.TabIndex = 2;
            this.tbPageSiglaRegiao.Text = "Sigla Região";
            this.tbPageSiglaRegiao.UseVisualStyleBackColor = true;
            // 
            // lblSiglaRegiao
            // 
            this.lblSiglaRegiao.AutoSize = true;
            this.lblSiglaRegiao.Location = new System.Drawing.Point(6, 3);
            this.lblSiglaRegiao.Name = "lblSiglaRegiao";
            this.lblSiglaRegiao.Size = new System.Drawing.Size(30, 13);
            this.lblSiglaRegiao.TabIndex = 3;
            this.lblSiglaRegiao.Text = "Sigla";
            // 
            // txtBxSiglaRegiao
            // 
            this.txtBxSiglaRegiao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSiglaRegiao.Location = new System.Drawing.Point(9, 19);
            this.txtBxSiglaRegiao.MaxLength = 2;
            this.txtBxSiglaRegiao.Name = "txtBxSiglaRegiao";
            this.txtBxSiglaRegiao.Size = new System.Drawing.Size(278, 20);
            this.txtBxSiglaRegiao.TabIndex = 2;
            this.txtBxSiglaRegiao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxSiglaRegiao_KeyPress);
            // 
            // ErrPrvdrSiglaUf
            // 
            this.ErrPrvdrSiglaUf.ContainerControl = this;
            // 
            // FilterSearchFormEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 154);
            this.Controls.Add(this.tbControlEstado);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSearchFormEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.tbControlEstado.ResumeLayout(false);
            this.tbPageSiglaEstado.ResumeLayout(false);
            this.tbPageSiglaEstado.PerformLayout();
            this.tbPageDescricao.ResumeLayout(false);
            this.tbPageDescricao.PerformLayout();
            this.tbPageSiglaRegiao.ResumeLayout(false);
            this.tbPageSiglaRegiao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrSiglaUf)).EndInit();
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
        private System.Windows.Forms.TabControl tbControlEstado;
        private System.Windows.Forms.TabPage tbPageSiglaEstado;
        private System.Windows.Forms.Label lblSiglaEstado;
        private System.Windows.Forms.TextBox txtBxSiglaEstado;
        private System.Windows.Forms.TabPage tbPageDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtBxDescricao;
        private System.Windows.Forms.TabPage tbPageSiglaRegiao;
        private System.Windows.Forms.Label lblSiglaRegiao;
        private System.Windows.Forms.TextBox txtBxSiglaRegiao;
        private System.Windows.Forms.ErrorProvider ErrPrvdrSiglaUf;
    }
}

