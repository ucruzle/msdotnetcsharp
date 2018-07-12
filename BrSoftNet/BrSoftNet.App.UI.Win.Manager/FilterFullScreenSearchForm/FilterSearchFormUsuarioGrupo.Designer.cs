namespace BrSoftNet.App.UI.Win.Manager.FilterFullScreenSearchForm
{
    partial class FilterSearchFormUsuarioGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormUsuarioGrupo));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.tbControlUsuarioGrupo = new System.Windows.Forms.TabControl();
            this.tbPageCodigoEmpresa = new System.Windows.Forms.TabPage();
            this.lblCodigoEmpresa = new System.Windows.Forms.Label();
            this.txtBxCodigoEmpresa = new System.Windows.Forms.TextBox();
            this.tbPageUsuario = new System.Windows.Forms.TabPage();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtBxUsuario = new System.Windows.Forms.TextBox();
            this.tbPageCodigoGrupo = new System.Windows.Forms.TabPage();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.txtBxCodigoGrupo = new System.Windows.Forms.TextBox();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            this.tbControlUsuarioGrupo.SuspendLayout();
            this.tbPageCodigoEmpresa.SuspendLayout();
            this.tbPageUsuario.SuspendLayout();
            this.tbPageCodigoGrupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 153);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(320, 22);
            this.sttstrUpdateForm.TabIndex = 7;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(320, 30);
            this.pnlUpdateFormTitle.TabIndex = 11;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(100, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Filtro Usuário Grupo";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(320, 25);
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
            this.grpBoxFields.Controls.Add(this.tbControlUsuarioGrupo);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(320, 98);
            this.grpBoxFields.TabIndex = 13;
            this.grpBoxFields.TabStop = false;
            // 
            // tbControlUsuarioGrupo
            // 
            this.tbControlUsuarioGrupo.Controls.Add(this.tbPageCodigoEmpresa);
            this.tbControlUsuarioGrupo.Controls.Add(this.tbPageUsuario);
            this.tbControlUsuarioGrupo.Controls.Add(this.tbPageCodigoGrupo);
            this.tbControlUsuarioGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlUsuarioGrupo.Location = new System.Drawing.Point(3, 16);
            this.tbControlUsuarioGrupo.Name = "tbControlUsuarioGrupo";
            this.tbControlUsuarioGrupo.SelectedIndex = 0;
            this.tbControlUsuarioGrupo.Size = new System.Drawing.Size(314, 79);
            this.tbControlUsuarioGrupo.TabIndex = 16;
            // 
            // tbPageCodigoEmpresa
            // 
            this.tbPageCodigoEmpresa.Controls.Add(this.lblCodigoEmpresa);
            this.tbPageCodigoEmpresa.Controls.Add(this.txtBxCodigoEmpresa);
            this.tbPageCodigoEmpresa.Location = new System.Drawing.Point(4, 22);
            this.tbPageCodigoEmpresa.Name = "tbPageCodigoEmpresa";
            this.tbPageCodigoEmpresa.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageCodigoEmpresa.Size = new System.Drawing.Size(306, 53);
            this.tbPageCodigoEmpresa.TabIndex = 0;
            this.tbPageCodigoEmpresa.Text = "Empresa";
            this.tbPageCodigoEmpresa.UseVisualStyleBackColor = true;
            // 
            // lblCodigoEmpresa
            // 
            this.lblCodigoEmpresa.AutoSize = true;
            this.lblCodigoEmpresa.Location = new System.Drawing.Point(6, 3);
            this.lblCodigoEmpresa.Name = "lblCodigoEmpresa";
            this.lblCodigoEmpresa.Size = new System.Drawing.Size(48, 13);
            this.lblCodigoEmpresa.TabIndex = 1;
            this.lblCodigoEmpresa.Text = "Empresa";
            // 
            // txtBxCodigoEmpresa
            // 
            this.txtBxCodigoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodigoEmpresa.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodigoEmpresa.Name = "txtBxCodigoEmpresa";
            this.txtBxCodigoEmpresa.Size = new System.Drawing.Size(291, 20);
            this.txtBxCodigoEmpresa.TabIndex = 0;
            // 
            // tbPageUsuario
            // 
            this.tbPageUsuario.Controls.Add(this.lblUsuario);
            this.tbPageUsuario.Controls.Add(this.txtBxUsuario);
            this.tbPageUsuario.Location = new System.Drawing.Point(4, 22);
            this.tbPageUsuario.Name = "tbPageUsuario";
            this.tbPageUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageUsuario.Size = new System.Drawing.Size(306, 53);
            this.tbPageUsuario.TabIndex = 1;
            this.tbPageUsuario.Text = "Usuário";
            this.tbPageUsuario.UseVisualStyleBackColor = true;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(6, 3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuário";
            // 
            // txtBxUsuario
            // 
            this.txtBxUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxUsuario.Location = new System.Drawing.Point(9, 19);
            this.txtBxUsuario.Name = "txtBxUsuario";
            this.txtBxUsuario.Size = new System.Drawing.Size(291, 20);
            this.txtBxUsuario.TabIndex = 0;
            // 
            // tbPageCodigoGrupo
            // 
            this.tbPageCodigoGrupo.Controls.Add(this.lblGrupo);
            this.tbPageCodigoGrupo.Controls.Add(this.txtBxCodigoGrupo);
            this.tbPageCodigoGrupo.Location = new System.Drawing.Point(4, 22);
            this.tbPageCodigoGrupo.Name = "tbPageCodigoGrupo";
            this.tbPageCodigoGrupo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageCodigoGrupo.Size = new System.Drawing.Size(306, 53);
            this.tbPageCodigoGrupo.TabIndex = 2;
            this.tbPageCodigoGrupo.Text = "Grupo";
            this.tbPageCodigoGrupo.UseVisualStyleBackColor = true;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(6, 3);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(36, 13);
            this.lblGrupo.TabIndex = 3;
            this.lblGrupo.Text = "Grupo";
            // 
            // txtBxCodigoGrupo
            // 
            this.txtBxCodigoGrupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodigoGrupo.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodigoGrupo.Name = "txtBxCodigoGrupo";
            this.txtBxCodigoGrupo.Size = new System.Drawing.Size(291, 20);
            this.txtBxCodigoGrupo.TabIndex = 2;
            // 
            // FilterSearchFormUsuarioGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 175);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSearchFormUsuarioGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.tbControlUsuarioGrupo.ResumeLayout(false);
            this.tbPageCodigoEmpresa.ResumeLayout(false);
            this.tbPageCodigoEmpresa.PerformLayout();
            this.tbPageUsuario.ResumeLayout(false);
            this.tbPageUsuario.PerformLayout();
            this.tbPageCodigoGrupo.ResumeLayout(false);
            this.tbPageCodigoGrupo.PerformLayout();
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
        private System.Windows.Forms.TabControl tbControlUsuarioGrupo;
        private System.Windows.Forms.TabPage tbPageCodigoEmpresa;
        private System.Windows.Forms.Label lblCodigoEmpresa;
        private System.Windows.Forms.TextBox txtBxCodigoEmpresa;
        private System.Windows.Forms.TabPage tbPageUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtBxUsuario;
        private System.Windows.Forms.TabPage tbPageCodigoGrupo;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.TextBox txtBxCodigoGrupo;
    }
}

