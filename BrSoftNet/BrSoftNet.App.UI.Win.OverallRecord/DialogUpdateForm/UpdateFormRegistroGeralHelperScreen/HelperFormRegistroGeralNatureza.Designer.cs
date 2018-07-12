namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm.UpdateFormRegistroGeralHelperScreen
{
    partial class HelperFormRegistroGeralNatureza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelperFormRegistroGeralNatureza));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.cmBxNatureza = new System.Windows.Forms.ComboBox();
            this.lblNatureza = new System.Windows.Forms.Label();
            this.txtDtHr = new System.Windows.Forms.TextBox();
            this.lblDtNr = new System.Windows.Forms.Label();
            this.cmBxStatusNat = new System.Windows.Forms.ComboBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblStatusNatureza = new System.Windows.Forms.Label();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 199);
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
            this.pnlUpdateFormTitle.TabIndex = 1;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(90, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Atualiza Natureza";
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
            this.tlstrpActionMenuUpdateForm.TabIndex = 2;
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
            this.grpBoxFields.Controls.Add(this.cmBxNatureza);
            this.grpBoxFields.Controls.Add(this.lblNatureza);
            this.grpBoxFields.Controls.Add(this.txtDtHr);
            this.grpBoxFields.Controls.Add(this.lblDtNr);
            this.grpBoxFields.Controls.Add(this.cmBxStatusNat);
            this.grpBoxFields.Controls.Add(this.txtUsuario);
            this.grpBoxFields.Controls.Add(this.lblUsuario);
            this.grpBoxFields.Controls.Add(this.lblStatusNatureza);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(312, 144);
            this.grpBoxFields.TabIndex = 2;
            this.grpBoxFields.TabStop = false;
            // 
            // cmBxNatureza
            // 
            this.cmBxNatureza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxNatureza.FormattingEnabled = true;
            this.cmBxNatureza.Location = new System.Drawing.Point(6, 31);
            this.cmBxNatureza.Name = "cmBxNatureza";
            this.cmBxNatureza.Size = new System.Drawing.Size(299, 21);
            this.cmBxNatureza.TabIndex = 3;
            // 
            // lblNatureza
            // 
            this.lblNatureza.AutoSize = true;
            this.lblNatureza.Location = new System.Drawing.Point(3, 15);
            this.lblNatureza.Name = "lblNatureza";
            this.lblNatureza.Size = new System.Drawing.Size(53, 13);
            this.lblNatureza.TabIndex = 29;
            this.lblNatureza.Text = "Natureza:";
            // 
            // txtDtHr
            // 
            this.txtDtHr.Location = new System.Drawing.Point(6, 115);
            this.txtDtHr.Name = "txtDtHr";
            this.txtDtHr.ReadOnly = true;
            this.txtDtHr.Size = new System.Drawing.Size(299, 20);
            this.txtDtHr.TabIndex = 6;
            // 
            // lblDtNr
            // 
            this.lblDtNr.AutoSize = true;
            this.lblDtNr.Location = new System.Drawing.Point(6, 100);
            this.lblDtNr.Name = "lblDtNr";
            this.lblDtNr.Size = new System.Drawing.Size(67, 13);
            this.lblDtNr.TabIndex = 27;
            this.lblDtNr.Text = "Data / Hora:";
            // 
            // cmBxStatusNat
            // 
            this.cmBxStatusNat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxStatusNat.FormattingEnabled = true;
            this.cmBxStatusNat.Location = new System.Drawing.Point(165, 75);
            this.cmBxStatusNat.Name = "cmBxStatusNat";
            this.cmBxStatusNat.Size = new System.Drawing.Size(140, 21);
            this.cmBxStatusNat.TabIndex = 5;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(6, 75);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(154, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(3, 59);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 18;
            this.lblUsuario.Text = "Usuário:";
            // 
            // lblStatusNatureza
            // 
            this.lblStatusNatureza.AutoSize = true;
            this.lblStatusNatureza.Location = new System.Drawing.Point(164, 59);
            this.lblStatusNatureza.Name = "lblStatusNatureza";
            this.lblStatusNatureza.Size = new System.Drawing.Size(86, 13);
            this.lblStatusNatureza.TabIndex = 16;
            this.lblStatusNatureza.Text = "Status Natureza:";
            // 
            // HelperFormRegistroGeralNatureza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 221);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelperFormRegistroGeralNatureza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HelperFormRegistroGeralNatureza_Load);
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.grpBoxFields.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sttstrUpdateForm;
        private System.Windows.Forms.Panel pnlUpdateFormTitle;
        private System.Windows.Forms.ToolStrip tlstrpActionMenuUpdateForm;
        private System.Windows.Forms.ToolStripButton tlstrpActionMenuBtnConfirm;
        private System.Windows.Forms.ToolStripButton tlstrpActionMenuBtnCancel;
        private System.Windows.Forms.GroupBox grpBoxFields;
        private System.Windows.Forms.Label lblActionModuleTitle;
        private System.Windows.Forms.TextBox txtDtHr;
        private System.Windows.Forms.Label lblDtNr;
        private System.Windows.Forms.ComboBox cmBxStatusNat;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblStatusNatureza;
        private System.Windows.Forms.ComboBox cmBxNatureza;
        private System.Windows.Forms.Label lblNatureza;
    }
}

