namespace BrSoftNet.App.UI.Win.OverallRecord.FilterFullScreenSearchForm
{
    partial class FilterSearchFormMunicipio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSearchFormMunicipio));
            this.sttstrUpdateForm = new System.Windows.Forms.StatusStrip();
            this.pnlUpdateFormTitle = new System.Windows.Forms.Panel();
            this.lblActionModuleTitle = new System.Windows.Forms.Label();
            this.tlstrpActionMenuUpdateForm = new System.Windows.Forms.ToolStrip();
            this.tlstrpActionMenuBtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.tlstrpActionMenuBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFields = new System.Windows.Forms.GroupBox();
            this.tbControlMunicipio = new System.Windows.Forms.TabControl();
            this.tbPageCodigo = new System.Windows.Forms.TabPage();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.txtBxCodigoMunicipio = new System.Windows.Forms.TextBox();
            this.tbPageDescricao = new System.Windows.Forms.TabPage();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtBxDescricao = new System.Windows.Forms.TextBox();
            this.tbPageEstado = new System.Windows.Forms.TabPage();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtBxEstado = new System.Windows.Forms.TextBox();
            this.ErrPrvdrMunicipio = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlUpdateFormTitle.SuspendLayout();
            this.tlstrpActionMenuUpdateForm.SuspendLayout();
            this.grpBoxFields.SuspendLayout();
            this.tbControlMunicipio.SuspendLayout();
            this.tbPageCodigo.SuspendLayout();
            this.tbPageDescricao.SuspendLayout();
            this.tbPageEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrMunicipio)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrUpdateForm
            // 
            this.sttstrUpdateForm.Location = new System.Drawing.Point(0, 151);
            this.sttstrUpdateForm.Name = "sttstrUpdateForm";
            this.sttstrUpdateForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttstrUpdateForm.Size = new System.Drawing.Size(323, 22);
            this.sttstrUpdateForm.TabIndex = 7;
            // 
            // pnlUpdateFormTitle
            // 
            this.pnlUpdateFormTitle.Controls.Add(this.lblActionModuleTitle);
            this.pnlUpdateFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpdateFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdateFormTitle.Name = "pnlUpdateFormTitle";
            this.pnlUpdateFormTitle.Size = new System.Drawing.Size(323, 30);
            this.pnlUpdateFormTitle.TabIndex = 11;
            // 
            // lblActionModuleTitle
            // 
            this.lblActionModuleTitle.AutoSize = true;
            this.lblActionModuleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblActionModuleTitle.Name = "lblActionModuleTitle";
            this.lblActionModuleTitle.Size = new System.Drawing.Size(79, 13);
            this.lblActionModuleTitle.TabIndex = 0;
            this.lblActionModuleTitle.Text = "Filtro Município";
            // 
            // tlstrpActionMenuUpdateForm
            // 
            this.tlstrpActionMenuUpdateForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpActionMenuUpdateForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpActionMenuBtnConfirm,
            this.tlstrpActionMenuBtnCancel});
            this.tlstrpActionMenuUpdateForm.Location = new System.Drawing.Point(0, 30);
            this.tlstrpActionMenuUpdateForm.Name = "tlstrpActionMenuUpdateForm";
            this.tlstrpActionMenuUpdateForm.Size = new System.Drawing.Size(323, 25);
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
            this.grpBoxFields.Controls.Add(this.tbControlMunicipio);
            this.grpBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFields.Location = new System.Drawing.Point(0, 55);
            this.grpBoxFields.Name = "grpBoxFields";
            this.grpBoxFields.Size = new System.Drawing.Size(323, 96);
            this.grpBoxFields.TabIndex = 13;
            this.grpBoxFields.TabStop = false;
            this.grpBoxFields.Text = "Munícipio";
            // 
            // tbControlMunicipio
            // 
            this.tbControlMunicipio.Controls.Add(this.tbPageCodigo);
            this.tbControlMunicipio.Controls.Add(this.tbPageDescricao);
            this.tbControlMunicipio.Controls.Add(this.tbPageEstado);
            this.tbControlMunicipio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlMunicipio.Location = new System.Drawing.Point(3, 16);
            this.tbControlMunicipio.Name = "tbControlMunicipio";
            this.tbControlMunicipio.SelectedIndex = 0;
            this.tbControlMunicipio.Size = new System.Drawing.Size(317, 77);
            this.tbControlMunicipio.TabIndex = 15;
            // 
            // tbPageCodigo
            // 
            this.tbPageCodigo.Controls.Add(this.lblMunicipio);
            this.tbPageCodigo.Controls.Add(this.txtBxCodigoMunicipio);
            this.tbPageCodigo.Location = new System.Drawing.Point(4, 22);
            this.tbPageCodigo.Name = "tbPageCodigo";
            this.tbPageCodigo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageCodigo.Size = new System.Drawing.Size(309, 51);
            this.tbPageCodigo.TabIndex = 0;
            this.tbPageCodigo.Text = "Código";
            this.tbPageCodigo.UseVisualStyleBackColor = true;
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(6, 3);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(40, 13);
            this.lblMunicipio.TabIndex = 1;
            this.lblMunicipio.Text = "Código";
            // 
            // txtBxCodigoMunicipio
            // 
            this.txtBxCodigoMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxCodigoMunicipio.Location = new System.Drawing.Point(9, 19);
            this.txtBxCodigoMunicipio.Name = "txtBxCodigoMunicipio";
            this.txtBxCodigoMunicipio.Size = new System.Drawing.Size(283, 20);
            this.txtBxCodigoMunicipio.TabIndex = 0;
            this.txtBxCodigoMunicipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxCodigoMunicipio_KeyPress);
            // 
            // tbPageDescricao
            // 
            this.tbPageDescricao.Controls.Add(this.lblDescricao);
            this.tbPageDescricao.Controls.Add(this.txtBxDescricao);
            this.tbPageDescricao.Location = new System.Drawing.Point(4, 22);
            this.tbPageDescricao.Name = "tbPageDescricao";
            this.tbPageDescricao.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageDescricao.Size = new System.Drawing.Size(298, 51);
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
            this.txtBxDescricao.Size = new System.Drawing.Size(283, 20);
            this.txtBxDescricao.TabIndex = 0;
            this.txtBxDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxDescricao_KeyPress);
            // 
            // tbPageEstado
            // 
            this.tbPageEstado.Controls.Add(this.lblEstado);
            this.tbPageEstado.Controls.Add(this.txtBxEstado);
            this.tbPageEstado.Location = new System.Drawing.Point(4, 22);
            this.tbPageEstado.Name = "tbPageEstado";
            this.tbPageEstado.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageEstado.Size = new System.Drawing.Size(298, 51);
            this.tbPageEstado.TabIndex = 2;
            this.tbPageEstado.Text = "Sigla Região";
            this.tbPageEstado.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(6, 3);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado";
            // 
            // txtBxEstado
            // 
            this.txtBxEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxEstado.Location = new System.Drawing.Point(9, 19);
            this.txtBxEstado.Name = "txtBxEstado";
            this.txtBxEstado.Size = new System.Drawing.Size(283, 20);
            this.txtBxEstado.TabIndex = 2;
            this.txtBxEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxEstado_KeyPress);
            // 
            // ErrPrvdrMunicipio
            // 
            this.ErrPrvdrMunicipio.ContainerControl = this;
            // 
            // FilterSearchFormMunicipio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 173);
            this.Controls.Add(this.grpBoxFields);
            this.Controls.Add(this.tlstrpActionMenuUpdateForm);
            this.Controls.Add(this.pnlUpdateFormTitle);
            this.Controls.Add(this.sttstrUpdateForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSearchFormMunicipio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUpdateFormTitle.ResumeLayout(false);
            this.pnlUpdateFormTitle.PerformLayout();
            this.tlstrpActionMenuUpdateForm.ResumeLayout(false);
            this.tlstrpActionMenuUpdateForm.PerformLayout();
            this.grpBoxFields.ResumeLayout(false);
            this.tbControlMunicipio.ResumeLayout(false);
            this.tbPageCodigo.ResumeLayout(false);
            this.tbPageCodigo.PerformLayout();
            this.tbPageDescricao.ResumeLayout(false);
            this.tbPageDescricao.PerformLayout();
            this.tbPageEstado.ResumeLayout(false);
            this.tbPageEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrvdrMunicipio)).EndInit();
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
        private System.Windows.Forms.TabControl tbControlMunicipio;
        private System.Windows.Forms.TabPage tbPageCodigo;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.TextBox txtBxCodigoMunicipio;
        private System.Windows.Forms.TabPage tbPageDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtBxDescricao;
        private System.Windows.Forms.TabPage tbPageEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtBxEstado;
        private System.Windows.Forms.ErrorProvider ErrPrvdrMunicipio;
    }
}

