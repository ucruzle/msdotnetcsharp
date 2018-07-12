﻿namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm
{
    partial class UpdateFormLiberacaoUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFormLiberacaoUsuario));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblTitleModule = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBxDadosCabecalho = new System.Windows.Forms.GroupBox();
            this.chckBxExibirTodosOsProcessos = new System.Windows.Forms.CheckBox();
            this.cmbBxUsuario = new System.Windows.Forms.ComboBox();
            this.cmbBxAplicacao = new System.Windows.Forms.ComboBox();
            this.cmbBxEmpresa = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblAplicacao = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.grpBxDadosLiberacao = new System.Windows.Forms.GroupBox();
            this.dtGridDadosLiberacao = new System.Windows.Forms.DataGridView();
            this.tlStrpDadosLiberacao = new System.Windows.Forms.ToolStrip();
            this.tlStrpBtnFindProcesses = new System.Windows.Forms.ToolStripButton();
            this.tlStrpCmbBxFindProcesses = new System.Windows.Forms.ToolStripComboBox();
            this.tlStrpBtnClearAllProcesses = new System.Windows.Forms.ToolStripButton();
            this.tlStrpBtnSelectAllProcesses = new System.Windows.Forms.ToolStripButton();
            this.bsLiberacaoUsuario = new System.Windows.Forms.BindingSource(this.components);
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBxDadosCabecalho.SuspendLayout();
            this.grpBxDadosLiberacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDadosLiberacao)).BeginInit();
            this.tlStrpDadosLiberacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLiberacaoUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 494);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(815, 22);
            this.sttstrUpdateForm.TabIndex = 4;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblTitleModule);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(815, 30);
            this.pnlUpdateFormTitle.TabIndex = 5;
            // 
            // lblTitleModule
            // 
            this.lblTitleModule.AutoSize = true;
            this.lblTitleModule.Location = new System.Drawing.Point(6, 9);
            this.lblTitleModule.Name = "lblTitleModule";
            this.lblTitleModule.Size = new System.Drawing.Size(146, 13);
            this.lblTitleModule.TabIndex = 0;
            this.lblTitleModule.Text = "Alterar Liberação de Usuários";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(815, 25);
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
            // grpBxDadosCabecalho
            // 
            this.grpBxDadosCabecalho.Controls.Add(this.chckBxExibirTodosOsProcessos);
            this.grpBxDadosCabecalho.Controls.Add(this.cmbBxUsuario);
            this.grpBxDadosCabecalho.Controls.Add(this.cmbBxAplicacao);
            this.grpBxDadosCabecalho.Controls.Add(this.cmbBxEmpresa);
            this.grpBxDadosCabecalho.Controls.Add(this.lblUsuario);
            this.grpBxDadosCabecalho.Controls.Add(this.lblAplicacao);
            this.grpBxDadosCabecalho.Controls.Add(this.lblEmpresa);
            this.grpBxDadosCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBxDadosCabecalho.Location = new System.Drawing.Point(0, 55);
            this.grpBxDadosCabecalho.Name = "grpBxDadosCabecalho";
            this.grpBxDadosCabecalho.Size = new System.Drawing.Size(815, 100);
            this.grpBxDadosCabecalho.TabIndex = 7;
            this.grpBxDadosCabecalho.TabStop = false;
            // 
            // chckBxExibirTodosOsProcessos
            // 
            this.chckBxExibirTodosOsProcessos.AutoSize = true;
            this.chckBxExibirTodosOsProcessos.Location = new System.Drawing.Point(660, 68);
            this.chckBxExibirTodosOsProcessos.Name = "chckBxExibirTodosOsProcessos";
            this.chckBxExibirTodosOsProcessos.Size = new System.Drawing.Size(150, 17);
            this.chckBxExibirTodosOsProcessos.TabIndex = 13;
            this.chckBxExibirTodosOsProcessos.Text = "Exibir Todos os Processos";
            this.chckBxExibirTodosOsProcessos.UseVisualStyleBackColor = true;
            this.chckBxExibirTodosOsProcessos.Click += new System.EventHandler(this.chckBxExibirTodosOsProcessos_Click);
            // 
            // cmbBxUsuario
            // 
            this.cmbBxUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxUsuario.FormattingEnabled = true;
            this.cmbBxUsuario.Location = new System.Drawing.Point(69, 66);
            this.cmbBxUsuario.Name = "cmbBxUsuario";
            this.cmbBxUsuario.Size = new System.Drawing.Size(577, 21);
            this.cmbBxUsuario.TabIndex = 12;
            // 
            // cmbBxAplicacao
            // 
            this.cmbBxAplicacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxAplicacao.FormattingEnabled = true;
            this.cmbBxAplicacao.Location = new System.Drawing.Point(69, 39);
            this.cmbBxAplicacao.Name = "cmbBxAplicacao";
            this.cmbBxAplicacao.Size = new System.Drawing.Size(736, 21);
            this.cmbBxAplicacao.TabIndex = 11;
            // 
            // cmbBxEmpresa
            // 
            this.cmbBxEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxEmpresa.FormattingEnabled = true;
            this.cmbBxEmpresa.Location = new System.Drawing.Point(69, 13);
            this.cmbBxEmpresa.Name = "cmbBxEmpresa";
            this.cmbBxEmpresa.Size = new System.Drawing.Size(736, 21);
            this.cmbBxEmpresa.TabIndex = 10;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(17, 68);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuário:";
            // 
            // lblAplicacao
            // 
            this.lblAplicacao.AutoSize = true;
            this.lblAplicacao.Location = new System.Drawing.Point(6, 42);
            this.lblAplicacao.Name = "lblAplicacao";
            this.lblAplicacao.Size = new System.Drawing.Size(57, 13);
            this.lblAplicacao.TabIndex = 1;
            this.lblAplicacao.Text = "Aplicação:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(12, 16);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(51, 13);
            this.lblEmpresa.TabIndex = 0;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // grpBxDadosLiberacao
            // 
            this.grpBxDadosLiberacao.Controls.Add(this.dtGridDadosLiberacao);
            this.grpBxDadosLiberacao.Controls.Add(this.tlStrpDadosLiberacao);
            this.grpBxDadosLiberacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBxDadosLiberacao.Location = new System.Drawing.Point(0, 155);
            this.grpBxDadosLiberacao.Name = "grpBxDadosLiberacao";
            this.grpBxDadosLiberacao.Size = new System.Drawing.Size(815, 339);
            this.grpBxDadosLiberacao.TabIndex = 8;
            this.grpBxDadosLiberacao.TabStop = false;
            // 
            // dtGridDadosLiberacao
            // 
            this.dtGridDadosLiberacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridDadosLiberacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridDadosLiberacao.Location = new System.Drawing.Point(3, 41);
            this.dtGridDadosLiberacao.Name = "dtGridDadosLiberacao";
            this.dtGridDadosLiberacao.Size = new System.Drawing.Size(809, 295);
            this.dtGridDadosLiberacao.TabIndex = 6;
            // 
            // tlStrpDadosLiberacao
            // 
            this.tlStrpDadosLiberacao.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlStrpDadosLiberacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlStrpBtnFindProcesses,
            this.tlStrpCmbBxFindProcesses,
            this.tlStrpBtnClearAllProcesses,
            this.tlStrpBtnSelectAllProcesses});
            this.tlStrpDadosLiberacao.Location = new System.Drawing.Point(3, 16);
            this.tlStrpDadosLiberacao.Name = "tlStrpDadosLiberacao";
            this.tlStrpDadosLiberacao.Size = new System.Drawing.Size(809, 25);
            this.tlStrpDadosLiberacao.TabIndex = 5;
            this.tlStrpDadosLiberacao.Text = "toolStrip1";
            // 
            // tlStrpBtnFindProcesses
            // 
            this.tlStrpBtnFindProcesses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStrpBtnFindProcesses.Image = ((System.Drawing.Image)(resources.GetObject("tlStrpBtnFindProcesses.Image")));
            this.tlStrpBtnFindProcesses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStrpBtnFindProcesses.Name = "tlStrpBtnFindProcesses";
            this.tlStrpBtnFindProcesses.Size = new System.Drawing.Size(23, 22);
            this.tlStrpBtnFindProcesses.ToolTipText = "Listar Processos";
            this.tlStrpBtnFindProcesses.Click += new System.EventHandler(this.tlStrpBtnFindProcesses_Click);
            // 
            // tlStrpCmbBxFindProcesses
            // 
            this.tlStrpCmbBxFindProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tlStrpCmbBxFindProcesses.Name = "tlStrpCmbBxFindProcesses";
            this.tlStrpCmbBxFindProcesses.Size = new System.Drawing.Size(250, 25);
            // 
            // tlStrpBtnClearAllProcesses
            // 
            this.tlStrpBtnClearAllProcesses.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tlStrpBtnClearAllProcesses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStrpBtnClearAllProcesses.Image = ((System.Drawing.Image)(resources.GetObject("tlStrpBtnClearAllProcesses.Image")));
            this.tlStrpBtnClearAllProcesses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStrpBtnClearAllProcesses.Name = "tlStrpBtnClearAllProcesses";
            this.tlStrpBtnClearAllProcesses.Size = new System.Drawing.Size(23, 22);
            this.tlStrpBtnClearAllProcesses.Text = "Desmarcar Todos";
            this.tlStrpBtnClearAllProcesses.Click += new System.EventHandler(this.tlStrpBtnClearAllProcesses_Click);
            // 
            // tlStrpBtnSelectAllProcesses
            // 
            this.tlStrpBtnSelectAllProcesses.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tlStrpBtnSelectAllProcesses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlStrpBtnSelectAllProcesses.Image = ((System.Drawing.Image)(resources.GetObject("tlStrpBtnSelectAllProcesses.Image")));
            this.tlStrpBtnSelectAllProcesses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlStrpBtnSelectAllProcesses.Name = "tlStrpBtnSelectAllProcesses";
            this.tlStrpBtnSelectAllProcesses.Size = new System.Drawing.Size(23, 22);
            this.tlStrpBtnSelectAllProcesses.Text = "Marcar Todos";
            this.tlStrpBtnSelectAllProcesses.Click += new System.EventHandler(this.tlStrpBtnSelectAllProcesses_Click);
            // 
            // UpdateFormLiberacaoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 516);
            this.Controls.Add(this.grpBxDadosLiberacao);
            this.Controls.Add(this.grpBxDadosCabecalho);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateFormLiberacaoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UpdateFormLiberacaoUsuario_Load);
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBxDadosCabecalho.ResumeLayout(false);
            this.grpBxDadosCabecalho.PerformLayout();
            this.grpBxDadosLiberacao.ResumeLayout(false);
            this.grpBxDadosLiberacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDadosLiberacao)).EndInit();
            this.tlStrpDadosLiberacao.ResumeLayout(false);
            this.tlStrpDadosLiberacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLiberacaoUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sttstrUpdateForm;
        private System.Windows.Forms.Panel pnlUpdateFormTitle;
        private System.Windows.Forms.Label lblTitleModule;
        private System.Windows.Forms.ToolStrip tlstrpActionMenuUpdateForm;
        private System.Windows.Forms.ToolStripButton tlstrpActionMenuBtnConfirm;
        private System.Windows.Forms.ToolStripButton tlstrpActionMenuBtnCancel;
        private System.Windows.Forms.GroupBox grpBxDadosCabecalho;
        private System.Windows.Forms.GroupBox grpBxDadosLiberacao;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblAplicacao;
        private System.Windows.Forms.ComboBox cmbBxUsuario;
        private System.Windows.Forms.ComboBox cmbBxAplicacao;
        private System.Windows.Forms.ComboBox cmbBxEmpresa;
        private System.Windows.Forms.BindingSource bsLiberacaoUsuario;
        private System.Windows.Forms.CheckBox chckBxExibirTodosOsProcessos;
        private System.Windows.Forms.DataGridView dtGridDadosLiberacao;
        private System.Windows.Forms.ToolStrip tlStrpDadosLiberacao;
        private System.Windows.Forms.ToolStripButton tlStrpBtnFindProcesses;
        private System.Windows.Forms.ToolStripComboBox tlStrpCmbBxFindProcesses;
        private System.Windows.Forms.ToolStripButton tlStrpBtnClearAllProcesses;
        private System.Windows.Forms.ToolStripButton tlStrpBtnSelectAllProcesses;

    }
}

