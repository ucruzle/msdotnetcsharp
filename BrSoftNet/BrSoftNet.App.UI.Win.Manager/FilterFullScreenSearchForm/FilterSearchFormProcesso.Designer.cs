namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    partial class FilterSearchFormProcesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormProcesso));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.tbControlProcesso = new System.Windows.Forms.TabControl();
            this.tbCodigoProcesso = new System.Windows.Forms.TabPage();
            this.lblCodigoProcesso = new System.Windows.Forms.Label();
            this.txtBxCodigoProcesso = new System.Windows.Forms.TextBox();
            this.tbPageDescricaoProcesso = new System.Windows.Forms.TabPage();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtBxDescricaoProcesso = new System.Windows.Forms.TextBox();
            this.tabPageCodigoTipoProcesso = new System.Windows.Forms.TabPage();
            this.lblTipoProcesso = new System.Windows.Forms.Label();
            this.txtBxCodigoTipoProcesso = new System.Windows.Forms.TextBox();
            this.tabPageCodigoAplicacao = new System.Windows.Forms.TabPage();
            this.lblAplicacao = new System.Windows.Forms.Label();
            this.txtBxCodigoAplicacao = new System.Windows.Forms.TextBox();
            this.tabPageAtivo = new System.Windows.Forms.TabPage();
            this.ckBxAtiva = new System.Windows.Forms.CheckBox();
            this.tabPageForm = new System.Windows.Forms.TabPage();
            this.lblForm = new System.Windows.Forms.Label();
            this.txtBxForm = new System.Windows.Forms.TextBox();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            this.tbControlProcesso.SuspendLayout();
            this.tbCodigoProcesso.SuspendLayout();
            this.tbPageDescricaoProcesso.SuspendLayout();
            this.tabPageCodigoTipoProcesso.SuspendLayout();
            this.tabPageCodigoAplicacao.SuspendLayout();
            this.tabPageAtivo.SuspendLayout();
            this.tabPageForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 151);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(362, 22);
            this.sttstrUpdateForm.TabIndex = 7;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(362, 30);
            this.pnlUpdateFormTitle.TabIndex = 11;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(76, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Filtro Processo";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(362, 25);
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
            this.grpBoxFields.Controls.Add(this.tbControlProcesso);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(362, 96);
            this.grpBoxFields.TabIndex = 13;
            this.grpBoxFields.TabStop = false;
            // 
            // tbControlProcesso
            // 
            this.tbControlProcesso.Controls.Add(this.tbCodigoProcesso);
            this.tbControlProcesso.Controls.Add(this.tbPageDescricaoProcesso);
            this.tbControlProcesso.Controls.Add(this.tabPageCodigoTipoProcesso);
            this.tbControlProcesso.Controls.Add(this.tabPageCodigoAplicacao);
            this.tbControlProcesso.Controls.Add(this.tabPageAtivo);
            this.tbControlProcesso.Controls.Add(this.tabPageForm);
            this.tbControlProcesso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlProcesso.Location = new System.Drawing.Point(3, 16);
            this.tbControlProcesso.Name = "tbControlProcesso";
            this.tbControlProcesso.SelectedIndex = 0;
            this.tbControlProcesso.Size = new System.Drawing.Size(356, 77);
            this.tbControlProcesso.TabIndex = 16;
            // 
            // tbCodigoProcesso
            // 
            this.tbCodigoProcesso.Controls.Add(this.lblCodigoProcesso);
            this.tbCodigoProcesso.Controls.Add(this.txtBxCodigoProcesso);
            this.tbCodigoProcesso.Location = new System.Drawing.Point(4, 22);
            this.tbCodigoProcesso.Name = "tbCodigoProcesso";
            this.tbCodigoProcesso.Padding = new System.Windows.Forms.Padding(3);
            this.tbCodigoProcesso.Size = new System.Drawing.Size(348, 51);
            this.tbCodigoProcesso.TabIndex = 0;
            this.tbCodigoProcesso.Text = "Processo";
            this.tbCodigoProcesso.UseVisualStyleBackColor = true;
            // 
            // lblCodigoProcesso
            // 
            this.lblCodigoProcesso.AutoSize = true;
            this.lblCodigoProcesso.Location = new System.Drawing.Point(6, 3);
            this.lblCodigoProcesso.Name = "lblCodigoProcesso";
            this.lblCodigoProcesso.Size = new System.Drawing.Size(40, 13);
            this.lblCodigoProcesso.TabIndex = 1;
            this.lblCodigoProcesso.Text = "Código";
            // 
            // txtBxCodigoProcesso
            // 
            this.txtBxCodigoProcesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodigoProcesso.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodigoProcesso.Name = "txtBxCodigoProcesso";
            this.txtBxCodigoProcesso.Size = new System.Drawing.Size(333, 20);
            this.txtBxCodigoProcesso.TabIndex = 0;
            // 
            // tbPageDescricaoProcesso
            // 
            this.tbPageDescricaoProcesso.Controls.Add(this.lblDescricao);
            this.tbPageDescricaoProcesso.Controls.Add(this.txtBxDescricaoProcesso);
            this.tbPageDescricaoProcesso.Location = new System.Drawing.Point(4, 22);
            this.tbPageDescricaoProcesso.Name = "tbPageDescricaoProcesso";
            this.tbPageDescricaoProcesso.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageDescricaoProcesso.Size = new System.Drawing.Size(348, 51);
            this.tbPageDescricaoProcesso.TabIndex = 1;
            this.tbPageDescricaoProcesso.Text = "Descrição";
            this.tbPageDescricaoProcesso.UseVisualStyleBackColor = true;
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
            // txtBxDescricaoProcesso
            // 
            this.txtBxDescricaoProcesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxDescricaoProcesso.Location = new System.Drawing.Point(9, 19);
            this.txtBxDescricaoProcesso.Name = "txtBxDescricaoProcesso";
            this.txtBxDescricaoProcesso.Size = new System.Drawing.Size(333, 20);
            this.txtBxDescricaoProcesso.TabIndex = 0;
            // 
            // tabPageCodigoTipoProcesso
            // 
            this.tabPageCodigoTipoProcesso.Controls.Add(this.lblTipoProcesso);
            this.tabPageCodigoTipoProcesso.Controls.Add(this.txtBxCodigoTipoProcesso);
            this.tabPageCodigoTipoProcesso.Location = new System.Drawing.Point(4, 22);
            this.tabPageCodigoTipoProcesso.Name = "tabPageCodigoTipoProcesso";
            this.tabPageCodigoTipoProcesso.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCodigoTipoProcesso.Size = new System.Drawing.Size(348, 51);
            this.tabPageCodigoTipoProcesso.TabIndex = 2;
            this.tabPageCodigoTipoProcesso.Text = "Tipo Processo";
            this.tabPageCodigoTipoProcesso.UseVisualStyleBackColor = true;
            // 
            // lblTipoProcesso
            // 
            this.lblTipoProcesso.AutoSize = true;
            this.lblTipoProcesso.Location = new System.Drawing.Point(6, 3);
            this.lblTipoProcesso.Name = "lblTipoProcesso";
            this.lblTipoProcesso.Size = new System.Drawing.Size(28, 13);
            this.lblTipoProcesso.TabIndex = 3;
            this.lblTipoProcesso.Text = "Tipo";
            // 
            // txtBxCodigoTipoProcesso
            // 
            this.txtBxCodigoTipoProcesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodigoTipoProcesso.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodigoTipoProcesso.Name = "txtBxCodigoTipoProcesso";
            this.txtBxCodigoTipoProcesso.Size = new System.Drawing.Size(333, 20);
            this.txtBxCodigoTipoProcesso.TabIndex = 2;
            // 
            // tabPageCodigoAplicacao
            // 
            this.tabPageCodigoAplicacao.Controls.Add(this.lblAplicacao);
            this.tabPageCodigoAplicacao.Controls.Add(this.txtBxCodigoAplicacao);
            this.tabPageCodigoAplicacao.Location = new System.Drawing.Point(4, 22);
            this.tabPageCodigoAplicacao.Name = "tabPageCodigoAplicacao";
            this.tabPageCodigoAplicacao.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCodigoAplicacao.Size = new System.Drawing.Size(348, 51);
            this.tabPageCodigoAplicacao.TabIndex = 3;
            this.tabPageCodigoAplicacao.Text = "Aplicação";
            this.tabPageCodigoAplicacao.UseVisualStyleBackColor = true;
            // 
            // lblAplicacao
            // 
            this.lblAplicacao.AutoSize = true;
            this.lblAplicacao.Location = new System.Drawing.Point(6, 3);
            this.lblAplicacao.Name = "lblAplicacao";
            this.lblAplicacao.Size = new System.Drawing.Size(40, 13);
            this.lblAplicacao.TabIndex = 3;
            this.lblAplicacao.Text = "Código";
            // 
            // txtBxCodigoAplicacao
            // 
            this.txtBxCodigoAplicacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodigoAplicacao.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodigoAplicacao.Name = "txtBxCodigoAplicacao";
            this.txtBxCodigoAplicacao.Size = new System.Drawing.Size(333, 20);
            this.txtBxCodigoAplicacao.TabIndex = 2;
            // 
            // tabPageAtivo
            // 
            this.tabPageAtivo.Controls.Add(this.ckBxAtiva);
            this.tabPageAtivo.Location = new System.Drawing.Point(4, 22);
            this.tabPageAtivo.Name = "tabPageAtivo";
            this.tabPageAtivo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAtivo.Size = new System.Drawing.Size(348, 51);
            this.tabPageAtivo.TabIndex = 4;
            this.tabPageAtivo.Text = "Ativo";
            this.tabPageAtivo.UseVisualStyleBackColor = true;
            // 
            // ckBxAtiva
            // 
            this.ckBxAtiva.AutoSize = true;
            this.ckBxAtiva.Location = new System.Drawing.Point(6, 6);
            this.ckBxAtiva.Name = "ckBxAtiva";
            this.ckBxAtiva.Size = new System.Drawing.Size(50, 17);
            this.ckBxAtiva.TabIndex = 25;
            this.ckBxAtiva.Text = "Ativa";
            this.ckBxAtiva.UseVisualStyleBackColor = true;
            // 
            // tabPageForm
            // 
            this.tabPageForm.Controls.Add(this.lblForm);
            this.tabPageForm.Controls.Add(this.txtBxForm);
            this.tabPageForm.Location = new System.Drawing.Point(4, 22);
            this.tabPageForm.Name = "tabPageForm";
            this.tabPageForm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageForm.Size = new System.Drawing.Size(348, 51);
            this.tabPageForm.TabIndex = 5;
            this.tabPageForm.Text = "Form";
            this.tabPageForm.UseVisualStyleBackColor = true;
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Location = new System.Drawing.Point(6, 3);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(30, 13);
            this.lblForm.TabIndex = 3;
            this.lblForm.Text = "Form";
            // 
            // txtBxForm
            // 
            this.txtBxForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxForm.Location = new System.Drawing.Point(9, 19);
            this.txtBxForm.Name = "txtBxForm";
            this.txtBxForm.Size = new System.Drawing.Size(333, 20);
            this.txtBxForm.TabIndex = 2;
            // 
            // FilterSearchFormProcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 173);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSearchFormProcesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.tbControlProcesso.ResumeLayout(false);
            this.tbCodigoProcesso.ResumeLayout(false);
            this.tbCodigoProcesso.PerformLayout();
            this.tbPageDescricaoProcesso.ResumeLayout(false);
            this.tbPageDescricaoProcesso.PerformLayout();
            this.tabPageCodigoTipoProcesso.ResumeLayout(false);
            this.tabPageCodigoTipoProcesso.PerformLayout();
            this.tabPageCodigoAplicacao.ResumeLayout(false);
            this.tabPageCodigoAplicacao.PerformLayout();
            this.tabPageAtivo.ResumeLayout(false);
            this.tabPageAtivo.PerformLayout();
            this.tabPageForm.ResumeLayout(false);
            this.tabPageForm.PerformLayout();
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
        private System.Windows.Forms.TabControl tbControlProcesso;
        private System.Windows.Forms.TabPage tbCodigoProcesso;
        private System.Windows.Forms.Label lblCodigoProcesso;
        private System.Windows.Forms.TextBox txtBxCodigoProcesso;
        private System.Windows.Forms.TabPage tbPageDescricaoProcesso;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtBxDescricaoProcesso;
        private System.Windows.Forms.TabPage tabPageCodigoTipoProcesso;
        private System.Windows.Forms.TabPage tabPageCodigoAplicacao;
        private System.Windows.Forms.TabPage tabPageAtivo;
        private System.Windows.Forms.TabPage tabPageForm;
        private System.Windows.Forms.Label lblTipoProcesso;
        private System.Windows.Forms.TextBox txtBxCodigoTipoProcesso;
        private System.Windows.Forms.Label lblAplicacao;
        private System.Windows.Forms.TextBox txtBxCodigoAplicacao;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.TextBox txtBxForm;
        private System.Windows.Forms.CheckBox ckBxAtiva;
    }
}

