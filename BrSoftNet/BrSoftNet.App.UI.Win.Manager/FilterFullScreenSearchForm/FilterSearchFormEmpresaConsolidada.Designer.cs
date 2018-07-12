﻿namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    partial class FilterSearchFormEmpresaConsolidada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormEmpresaConsolidada));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.tbControlEmpresaConsolidada = new System.Windows.Forms.TabControl();
            this.tbPageCodEmpresa = new System.Windows.Forms.TabPage();
            this.lblCodEmpresa = new System.Windows.Forms.Label();
            this.txtBxCodEmpresa = new System.Windows.Forms.TextBox();
            this.tbPageDescricao = new System.Windows.Forms.TabPage();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtBxDescricao = new System.Windows.Forms.TextBox();
            this.tbPageAtivo = new System.Windows.Forms.TabPage();
            this.ckBxAtiva = new System.Windows.Forms.CheckBox();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.tbControlEmpresaConsolidada.SuspendLayout();
            this.tbPageCodEmpresa.SuspendLayout();
            this.tbPageDescricao.SuspendLayout();
            this.tbPageAtivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 130);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(314, 22);
            this.sttstrUpdateForm.TabIndex = 7;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(314, 30);
            this.pnlUpdateFormTitle.TabIndex = 11;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(134, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Filtro Empresa Consolidada";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(314, 25);
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
            this.grpBoxFields.Size = new System.Drawing.Size(314, 75);
            this.grpBoxFields.TabIndex = 13;
            this.grpBoxFields.TabStop = false;
            // 
            // tbControlEmpresaConsolidada
            // 
            this.tbControlEmpresaConsolidada.Controls.Add(this.tbPageCodEmpresa);
            this.tbControlEmpresaConsolidada.Controls.Add(this.tbPageDescricao);
            this.tbControlEmpresaConsolidada.Controls.Add(this.tbPageAtivo);
            this.tbControlEmpresaConsolidada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlEmpresaConsolidada.Location = new System.Drawing.Point(0, 55);
            this.tbControlEmpresaConsolidada.Name = "tbControlEmpresaConsolidada";
            this.tbControlEmpresaConsolidada.SelectedIndex = 0;
            this.tbControlEmpresaConsolidada.Size = new System.Drawing.Size(314, 75);
            this.tbControlEmpresaConsolidada.TabIndex = 14;
            // 
            // tbPageCodEmpresa
            // 
            this.tbPageCodEmpresa.Controls.Add(this.lblCodEmpresa);
            this.tbPageCodEmpresa.Controls.Add(this.txtBxCodEmpresa);
            this.tbPageCodEmpresa.Location = new System.Drawing.Point(4, 22);
            this.tbPageCodEmpresa.Name = "tbPageCodEmpresa";
            this.tbPageCodEmpresa.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageCodEmpresa.Size = new System.Drawing.Size(306, 49);
            this.tbPageCodEmpresa.TabIndex = 0;
            this.tbPageCodEmpresa.Text = "Empresa";
            this.tbPageCodEmpresa.UseVisualStyleBackColor = true;
            // 
            // lblCodEmpresa
            // 
            this.lblCodEmpresa.AutoSize = true;
            this.lblCodEmpresa.Location = new System.Drawing.Point(6, 3);
            this.lblCodEmpresa.Name = "lblCodEmpresa";
            this.lblCodEmpresa.Size = new System.Drawing.Size(40, 13);
            this.lblCodEmpresa.TabIndex = 1;
            this.lblCodEmpresa.Text = "Código";
            // 
            // txtBxCodEmpresa
            // 
            this.txtBxCodEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodEmpresa.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodEmpresa.Name = "txtBxCodEmpresa";
            this.txtBxCodEmpresa.Size = new System.Drawing.Size(289, 20);
            this.txtBxCodEmpresa.TabIndex = 0;
            // 
            // tbPageDescricao
            // 
            this.tbPageDescricao.Controls.Add(this.lblDescricao);
            this.tbPageDescricao.Controls.Add(this.txtBxDescricao);
            this.tbPageDescricao.Location = new System.Drawing.Point(4, 22);
            this.tbPageDescricao.Name = "tbPageDescricao";
            this.tbPageDescricao.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageDescricao.Size = new System.Drawing.Size(306, 49);
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
            this.txtBxDescricao.Size = new System.Drawing.Size(289, 20);
            this.txtBxDescricao.TabIndex = 0;
            // 
            // tbPageAtivo
            // 
            this.tbPageAtivo.Controls.Add(this.ckBxAtiva);
            this.tbPageAtivo.Location = new System.Drawing.Point(4, 22);
            this.tbPageAtivo.Name = "tbPageAtivo";
            this.tbPageAtivo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageAtivo.Size = new System.Drawing.Size(306, 49);
            this.tbPageAtivo.TabIndex = 2;
            this.tbPageAtivo.Text = "Ativo";
            this.tbPageAtivo.UseVisualStyleBackColor = true;
            // 
            // ckBxAtiva
            // 
            this.ckBxAtiva.AutoSize = true;
            this.ckBxAtiva.Location = new System.Drawing.Point(8, 6);
            this.ckBxAtiva.Name = "ckBxAtiva";
            this.ckBxAtiva.Size = new System.Drawing.Size(50, 17);
            this.ckBxAtiva.TabIndex = 23;
            this.ckBxAtiva.Text = "Ativa";
            this.ckBxAtiva.UseVisualStyleBackColor = true;
            // 
            // FilterSearchFormEmpresaConsolidada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 152);
            this.Controls.Add(this.tbControlEmpresaConsolidada);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSearchFormEmpresaConsolidada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.tbControlEmpresaConsolidada.ResumeLayout(false);
            this.tbPageCodEmpresa.ResumeLayout(false);
            this.tbPageCodEmpresa.PerformLayout();
            this.tbPageDescricao.ResumeLayout(false);
            this.tbPageDescricao.PerformLayout();
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
        private System.Windows.Forms.TabControl tbControlEmpresaConsolidada;
        private System.Windows.Forms.TabPage tbPageCodEmpresa;
        private System.Windows.Forms.Label lblCodEmpresa;
        private System.Windows.Forms.TextBox txtBxCodEmpresa;
        private System.Windows.Forms.TabPage tbPageDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtBxDescricao;
        private System.Windows.Forms.TabPage tbPageAtivo;
        private System.Windows.Forms.CheckBox ckBxAtiva;
    }
}

