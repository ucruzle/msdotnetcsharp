namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    partial class FilterSearchFormAplicacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormAplicacao));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.tbControlAplicacao = new System.Windows.Forms.TabControl();
            this.tbPageCodigo = new System.Windows.Forms.TabPage();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtBxCodigo = new System.Windows.Forms.TextBox();
            this.tbPageDescricao = new System.Windows.Forms.TabPage();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtBxDescricao = new System.Windows.Forms.TextBox();
            this.tbPageSigla = new System.Windows.Forms.TabPage();
            this.lblSigla = new System.Windows.Forms.Label();
            this.txtBxSigla = new System.Windows.Forms.TextBox();
            this.tbPageSequencia = new System.Windows.Forms.TabPage();
            this.lblSequencia = new System.Windows.Forms.Label();
            this.txtBxSequencia = new System.Windows.Forms.TextBox();
            this.tbPageForm = new System.Windows.Forms.TabPage();
            this.lblForm = new System.Windows.Forms.Label();
            this.txtBxForm = new System.Windows.Forms.TextBox();
            this.tbPageAtivo = new System.Windows.Forms.TabPage();
            this.ckBxAtiva = new System.Windows.Forms.CheckBox();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            this.tbControlAplicacao.SuspendLayout();
            this.tbPageCodigo.SuspendLayout();
            this.tbPageDescricao.SuspendLayout();
            this.tbPageSigla.SuspendLayout();
            this.tbPageSequencia.SuspendLayout();
            this.tbPageForm.SuspendLayout();
            this.tbPageAtivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 150);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(337, 22);
            this.sttstrUpdateForm.TabIndex = 7;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(337, 30);
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
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(337, 25);
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
            this.grpBoxFields.Controls.Add(this.tbControlAplicacao);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(337, 95);
            this.grpBoxFields.TabIndex = 13;
            this.grpBoxFields.TabStop = false;
            // 
            // tbControlAplicacao
            // 
            this.tbControlAplicacao.Controls.Add(this.tbPageCodigo);
            this.tbControlAplicacao.Controls.Add(this.tbPageDescricao);
            this.tbControlAplicacao.Controls.Add(this.tbPageSigla);
            this.tbControlAplicacao.Controls.Add(this.tbPageSequencia);
            this.tbControlAplicacao.Controls.Add(this.tbPageForm);
            this.tbControlAplicacao.Controls.Add(this.tbPageAtivo);
            this.tbControlAplicacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlAplicacao.Location = new System.Drawing.Point(3, 16);
            this.tbControlAplicacao.Name = "tbControlAplicacao";
            this.tbControlAplicacao.SelectedIndex = 0;
            this.tbControlAplicacao.Size = new System.Drawing.Size(331, 76);
            this.tbControlAplicacao.TabIndex = 16;
            // 
            // tbPageCodigo
            // 
            this.tbPageCodigo.Controls.Add(this.lblCodigo);
            this.tbPageCodigo.Controls.Add(this.txtBxCodigo);
            this.tbPageCodigo.Location = new System.Drawing.Point(4, 22);
            this.tbPageCodigo.Name = "tbPageCodigo";
            this.tbPageCodigo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageCodigo.Size = new System.Drawing.Size(323, 50);
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
            // txtBxCodigo
            // 
            this.txtBxCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodigo.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodigo.Name = "txtBxCodigo";
            this.txtBxCodigo.Size = new System.Drawing.Size(308, 20);
            this.txtBxCodigo.TabIndex = 0;
            // 
            // tbPageDescricao
            // 
            this.tbPageDescricao.Controls.Add(this.lblDescricao);
            this.tbPageDescricao.Controls.Add(this.txtBxDescricao);
            this.tbPageDescricao.Location = new System.Drawing.Point(4, 22);
            this.tbPageDescricao.Name = "tbPageDescricao";
            this.tbPageDescricao.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageDescricao.Size = new System.Drawing.Size(323, 50);
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
            this.txtBxDescricao.Size = new System.Drawing.Size(308, 20);
            this.txtBxDescricao.TabIndex = 0;
            // 
            // tbPageSigla
            // 
            this.tbPageSigla.Controls.Add(this.lblSigla);
            this.tbPageSigla.Controls.Add(this.txtBxSigla);
            this.tbPageSigla.Location = new System.Drawing.Point(4, 22);
            this.tbPageSigla.Name = "tbPageSigla";
            this.tbPageSigla.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageSigla.Size = new System.Drawing.Size(323, 50);
            this.tbPageSigla.TabIndex = 2;
            this.tbPageSigla.Text = "Sigla";
            this.tbPageSigla.UseVisualStyleBackColor = true;
            // 
            // lblSigla
            // 
            this.lblSigla.AutoSize = true;
            this.lblSigla.Location = new System.Drawing.Point(6, 3);
            this.lblSigla.Name = "lblSigla";
            this.lblSigla.Size = new System.Drawing.Size(30, 13);
            this.lblSigla.TabIndex = 3;
            this.lblSigla.Text = "Sigla";
            // 
            // txtBxSigla
            // 
            this.txtBxSigla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSigla.Location = new System.Drawing.Point(9, 19);
            this.txtBxSigla.Name = "txtBxSigla";
            this.txtBxSigla.Size = new System.Drawing.Size(308, 20);
            this.txtBxSigla.TabIndex = 2;
            // 
            // tbPageSequencia
            // 
            this.tbPageSequencia.Controls.Add(this.lblSequencia);
            this.tbPageSequencia.Controls.Add(this.txtBxSequencia);
            this.tbPageSequencia.Location = new System.Drawing.Point(4, 22);
            this.tbPageSequencia.Name = "tbPageSequencia";
            this.tbPageSequencia.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageSequencia.Size = new System.Drawing.Size(323, 50);
            this.tbPageSequencia.TabIndex = 3;
            this.tbPageSequencia.Text = "Sequência";
            this.tbPageSequencia.UseVisualStyleBackColor = true;
            // 
            // lblSequencia
            // 
            this.lblSequencia.AutoSize = true;
            this.lblSequencia.Location = new System.Drawing.Point(6, 3);
            this.lblSequencia.Name = "lblSequencia";
            this.lblSequencia.Size = new System.Drawing.Size(58, 13);
            this.lblSequencia.TabIndex = 3;
            this.lblSequencia.Text = "Sequência";
            // 
            // txtBxSequencia
            // 
            this.txtBxSequencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSequencia.Location = new System.Drawing.Point(9, 19);
            this.txtBxSequencia.Name = "txtBxSequencia";
            this.txtBxSequencia.Size = new System.Drawing.Size(308, 20);
            this.txtBxSequencia.TabIndex = 2;
            // 
            // tbPageForm
            // 
            this.tbPageForm.Controls.Add(this.lblForm);
            this.tbPageForm.Controls.Add(this.txtBxForm);
            this.tbPageForm.Location = new System.Drawing.Point(4, 22);
            this.tbPageForm.Name = "tbPageForm";
            this.tbPageForm.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageForm.Size = new System.Drawing.Size(323, 50);
            this.tbPageForm.TabIndex = 4;
            this.tbPageForm.Text = "Formulário";
            this.tbPageForm.UseVisualStyleBackColor = true;
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Location = new System.Drawing.Point(6, 3);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(55, 13);
            this.lblForm.TabIndex = 3;
            this.lblForm.Text = "Formulário";
            // 
            // txtBxForm
            // 
            this.txtBxForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxForm.Location = new System.Drawing.Point(9, 19);
            this.txtBxForm.Name = "txtBxForm";
            this.txtBxForm.Size = new System.Drawing.Size(308, 20);
            this.txtBxForm.TabIndex = 2;
            // 
            // tbPageAtivo
            // 
            this.tbPageAtivo.Controls.Add(this.ckBxAtiva);
            this.tbPageAtivo.Location = new System.Drawing.Point(4, 22);
            this.tbPageAtivo.Name = "tbPageAtivo";
            this.tbPageAtivo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageAtivo.Size = new System.Drawing.Size(323, 50);
            this.tbPageAtivo.TabIndex = 5;
            this.tbPageAtivo.Text = "Ativo";
            this.tbPageAtivo.UseVisualStyleBackColor = true;
            // 
            // ckBxAtiva
            // 
            this.ckBxAtiva.AutoSize = true;
            this.ckBxAtiva.Location = new System.Drawing.Point(6, 6);
            this.ckBxAtiva.Name = "ckBxAtiva";
            this.ckBxAtiva.Size = new System.Drawing.Size(50, 17);
            this.ckBxAtiva.TabIndex = 24;
            this.ckBxAtiva.Text = "Ativa";
            this.ckBxAtiva.UseVisualStyleBackColor = true;
            // 
            // FilterSearchFormAplicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 172);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSearchFormAplicacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.tbControlAplicacao.ResumeLayout(false);
            this.tbPageCodigo.ResumeLayout(false);
            this.tbPageCodigo.PerformLayout();
            this.tbPageDescricao.ResumeLayout(false);
            this.tbPageDescricao.PerformLayout();
            this.tbPageSigla.ResumeLayout(false);
            this.tbPageSigla.PerformLayout();
            this.tbPageSequencia.ResumeLayout(false);
            this.tbPageSequencia.PerformLayout();
            this.tbPageForm.ResumeLayout(false);
            this.tbPageForm.PerformLayout();
            this.tbPageAtivo.ResumeLayout(false);
            this.tbPageAtivo.PerformLayout();
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
        private System.Windows.Forms.TabControl tbControlAplicacao;
        private System.Windows.Forms.TabPage tbPageCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtBxCodigo;
        private System.Windows.Forms.TabPage tbPageDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtBxDescricao;
        private System.Windows.Forms.TabPage tbPageSigla;
        private System.Windows.Forms.Label lblSigla;
        private System.Windows.Forms.TextBox txtBxSigla;
        private System.Windows.Forms.TabPage tbPageSequencia;
        private System.Windows.Forms.Label lblSequencia;
        private System.Windows.Forms.TextBox txtBxSequencia;
        private System.Windows.Forms.TabPage tbPageForm;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.TextBox txtBxForm;
        private System.Windows.Forms.TabPage tbPageAtivo;
        private System.Windows.Forms.CheckBox ckBxAtiva;
    }
}

