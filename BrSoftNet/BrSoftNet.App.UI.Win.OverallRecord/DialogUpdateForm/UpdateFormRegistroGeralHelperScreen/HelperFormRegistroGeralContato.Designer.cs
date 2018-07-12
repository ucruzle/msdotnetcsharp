namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm.UpdateFormRegistroGeralHelperScreen
{
    partial class HelperFormRegistroGeralContato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelperFormRegistroGeralContato));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.chckBxPrincipal = new System.Windows.Forms.CheckBox();
            this.txtNro = new System.Windows.Forms.TextBox();
            this.lblNro = new System.Windows.Forms.Label();
            this.cmBxTipo = new System.Windows.Forms.ComboBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.txtddd = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.lblEMail = new System.Windows.Forms.Label();
            this.lblContato = new System.Windows.Forms.Label();
            this.lblddd = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.ErrPrvdrContato = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlstrpLblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttstrUpdateForm.SuspendLayout();
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrContato)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpLblError});
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 234);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(322, 22);
            this.sttstrUpdateForm.TabIndex = 10;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(322, 30);
            this.pnlUpdateFormTitle.TabIndex = 1;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(89, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Atualiza Contatos";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(322, 25);
            this.tlstrpActionMenuUpdateForm.TabIndex = 2;
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
            this.grpBoxFields.Controls.Add(this.chckBxPrincipal);
            this.grpBoxFields.Controls.Add(this.txtNro);
            this.grpBoxFields.Controls.Add(this.lblNro);
            this.grpBoxFields.Controls.Add(this.cmBxTipo);
            this.grpBoxFields.Controls.Add(this.txtEMail);
            this.grpBoxFields.Controls.Add(this.txtContato);
            this.grpBoxFields.Controls.Add(this.txtddd);
            this.grpBoxFields.Controls.Add(this.txtItem);
            this.grpBoxFields.Controls.Add(this.lblEMail);
            this.grpBoxFields.Controls.Add(this.lblContato);
            this.grpBoxFields.Controls.Add(this.lblddd);
            this.grpBoxFields.Controls.Add(this.lblTipo);
            this.grpBoxFields.Controls.Add(this.lblItem);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(322, 179);
            this.grpBoxFields.TabIndex = 2;
            this.grpBoxFields.TabStop = false;
            // 
            // chckBxPrincipal
            // 
            this.chckBxPrincipal.AutoSize = true;
            this.chckBxPrincipal.Location = new System.Drawing.Point(202, 148);
            this.chckBxPrincipal.Name = "chckBxPrincipal";
            this.chckBxPrincipal.Size = new System.Drawing.Size(106, 17);
            this.chckBxPrincipal.TabIndex = 9;
            this.chckBxPrincipal.Text = "Contato Principal";
            this.chckBxPrincipal.UseVisualStyleBackColor = true;
            // 
            // txtNro
            // 
            this.txtNro.Location = new System.Drawing.Point(74, 146);
            this.txtNro.MaxLength = 30;
            this.txtNro.Name = "txtNro";
            this.txtNro.Size = new System.Drawing.Size(123, 20);
            this.txtNro.TabIndex = 8;
            this.txtNro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNro_KeyPress);
            this.txtNro.Validating += new System.ComponentModel.CancelEventHandler(this.txtNro_Validating);
            // 
            // lblNro
            // 
            this.lblNro.AutoSize = true;
            this.lblNro.Location = new System.Drawing.Point(74, 131);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(27, 13);
            this.lblNro.TabIndex = 13;
            this.lblNro.Text = "Nro:";
            // 
            // cmBxTipo
            // 
            this.cmBxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxTipo.FormattingEnabled = true;
            this.cmBxTipo.Location = new System.Drawing.Point(60, 27);
            this.cmBxTipo.Name = "cmBxTipo";
            this.cmBxTipo.Size = new System.Drawing.Size(240, 21);
            this.cmBxTipo.TabIndex = 4;
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(5, 108);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(300, 20);
            this.txtEMail.TabIndex = 6;
            this.txtEMail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEMail_Validating);
            // 
            // txtContato
            // 
            this.txtContato.Location = new System.Drawing.Point(5, 68);
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(300, 20);
            this.txtContato.TabIndex = 5;
            // 
            // txtddd
            // 
            this.txtddd.Location = new System.Drawing.Point(6, 146);
            this.txtddd.MaxLength = 4;
            this.txtddd.Name = "txtddd";
            this.txtddd.Size = new System.Drawing.Size(50, 20);
            this.txtddd.TabIndex = 7;
            this.txtddd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtddd_KeyPress);
            this.txtddd.Validating += new System.ComponentModel.CancelEventHandler(this.txtddd_Validating);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(6, 28);
            this.txtItem.Name = "txtItem";
            this.txtItem.ReadOnly = true;
            this.txtItem.Size = new System.Drawing.Size(50, 20);
            this.txtItem.TabIndex = 3;
            // 
            // lblEMail
            // 
            this.lblEMail.AutoSize = true;
            this.lblEMail.Location = new System.Drawing.Point(6, 92);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(39, 13);
            this.lblEMail.TabIndex = 5;
            this.lblEMail.Text = "E-Mail:";
            // 
            // lblContato
            // 
            this.lblContato.AutoSize = true;
            this.lblContato.Location = new System.Drawing.Point(6, 53);
            this.lblContato.Name = "lblContato";
            this.lblContato.Size = new System.Drawing.Size(47, 13);
            this.lblContato.TabIndex = 4;
            this.lblContato.Text = "Contato:";
            // 
            // lblddd
            // 
            this.lblddd.AutoSize = true;
            this.lblddd.Location = new System.Drawing.Point(6, 131);
            this.lblddd.Name = "lblddd";
            this.lblddd.Size = new System.Drawing.Size(34, 13);
            this.lblddd.TabIndex = 3;
            this.lblddd.Text = "DDD:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(60, 11);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(71, 13);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo Contato:";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(6, 12);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(30, 13);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Item:";
            // 
            // ErrPrvdrContato
            // 
            this.ErrPrvdrContato.ContainerControl = this;
            // 
            // tlstrpLblError
            // 
            this.tlstrpLblError.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.tlstrpLblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tlstrpLblError.Name = "tlstrpLblError";
            this.tlstrpLblError.Size = new System.Drawing.Size(202, 17);
            this.tlstrpLblError.Text = "Campo de preenchimento obrigatório";
            this.tlstrpLblError.Visible = false;
            // 
            // HelperFormRegistroGeralContato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 256);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelperFormRegistroGeralContato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HelperFormRegistroGeralContato_Load);
            this.sttstrUpdateForm.ResumeLayout(false);
            this.sttstrUpdateForm.PerformLayout();
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.grpBoxFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrContato)).EndInit();
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
        private System.Windows.Forms.Label lblEMail;
        private System.Windows.Forms.Label lblContato;
        private System.Windows.Forms.Label lblddd;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.TextBox txtddd;
        private System.Windows.Forms.ComboBox cmBxTipo;
        private System.Windows.Forms.TextBox txtNro;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.CheckBox chckBxPrincipal;
        private System.Windows.Forms.ErrorProvider ErrPrvdrContato;
        private System.Windows.Forms.ToolStripStatusLabel tlstrpLblError;
    }
}

