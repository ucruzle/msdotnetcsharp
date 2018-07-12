namespace MergeEfdPisCofins
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lnkLoadSAPTXTFile = new System.Windows.Forms.LinkLabel();
            this.txtLoadSAPTXTFile = new System.Windows.Forms.TextBox();
            this.btnCreateFileMerge = new System.Windows.Forms.Button();
            this.txtLoadSSATXTFile = new System.Windows.Forms.TextBox();
            this.dataGridViewAtTo = new System.Windows.Forms.DataGridView();
            this.grpAtTo = new System.Windows.Forms.GroupBox();
            this.lnkSaveFielMerge = new System.Windows.Forms.LinkLabel();
            this.txtSaveFileMerge = new System.Windows.Forms.TextBox();
            this.lnkLoadSSATXTFile = new System.Windows.Forms.LinkLabel();
            this.lblLoadDesc = new System.Windows.Forms.Label();
            this.progressMerge = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtTo)).BeginInit();
            this.grpAtTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnkLoadSAPTXTFile
            // 
            this.lnkLoadSAPTXTFile.AutoSize = true;
            this.lnkLoadSAPTXTFile.Image = global::MergeEfdPisCofins.Properties.Resources.Background;
            this.lnkLoadSAPTXTFile.Location = new System.Drawing.Point(8, 65);
            this.lnkLoadSAPTXTFile.Name = "lnkLoadSAPTXTFile";
            this.lnkLoadSAPTXTFile.Size = new System.Drawing.Size(163, 13);
            this.lnkLoadSAPTXTFile.TabIndex = 23;
            this.lnkLoadSAPTXTFile.TabStop = true;
            this.lnkLoadSAPTXTFile.Text = "Carregar arquivo Texto SAP de...";
            this.lnkLoadSAPTXTFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoadSAPTXTFile_LinkClicked);
            // 
            // txtLoadSAPTXTFile
            // 
            this.txtLoadSAPTXTFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLoadSAPTXTFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoadSAPTXTFile.Location = new System.Drawing.Point(8, 81);
            this.txtLoadSAPTXTFile.Name = "txtLoadSAPTXTFile";
            this.txtLoadSAPTXTFile.ReadOnly = true;
            this.txtLoadSAPTXTFile.Size = new System.Drawing.Size(370, 20);
            this.txtLoadSAPTXTFile.TabIndex = 22;
            // 
            // btnCreateFileMerge
            // 
            this.btnCreateFileMerge.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateFileMerge.Image")));
            this.btnCreateFileMerge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateFileMerge.Location = new System.Drawing.Point(8, 157);
            this.btnCreateFileMerge.Name = "btnCreateFileMerge";
            this.btnCreateFileMerge.Size = new System.Drawing.Size(130, 23);
            this.btnCreateFileMerge.TabIndex = 21;
            this.btnCreateFileMerge.Text = "Gerar Arquivo";
            this.btnCreateFileMerge.UseVisualStyleBackColor = true;
            this.btnCreateFileMerge.Click += new System.EventHandler(this.btnCreateFileMerge_Click);
            // 
            // txtLoadSSATXTFile
            // 
            this.txtLoadSSATXTFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLoadSSATXTFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoadSSATXTFile.Location = new System.Drawing.Point(8, 30);
            this.txtLoadSSATXTFile.Name = "txtLoadSSATXTFile";
            this.txtLoadSSATXTFile.ReadOnly = true;
            this.txtLoadSSATXTFile.Size = new System.Drawing.Size(370, 20);
            this.txtLoadSSATXTFile.TabIndex = 15;
            // 
            // dataGridViewAtTo
            // 
            this.dataGridViewAtTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAtTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAtTo.EnableHeadersVisualStyles = false;
            this.dataGridViewAtTo.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewAtTo.Name = "dataGridViewAtTo";
            this.dataGridViewAtTo.ReadOnly = true;
            this.dataGridViewAtTo.RowHeadersVisible = false;
            this.dataGridViewAtTo.Size = new System.Drawing.Size(224, 170);
            this.dataGridViewAtTo.TabIndex = 0;
            // 
            // grpAtTo
            // 
            this.grpAtTo.BackgroundImage = global::MergeEfdPisCofins.Properties.Resources.Background;
            this.grpAtTo.Controls.Add(this.dataGridViewAtTo);
            this.grpAtTo.Location = new System.Drawing.Point(389, 14);
            this.grpAtTo.Name = "grpAtTo";
            this.grpAtTo.Size = new System.Drawing.Size(230, 189);
            this.grpAtTo.TabIndex = 19;
            this.grpAtTo.TabStop = false;
            this.grpAtTo.Text = "Conta Contábeis:";
            // 
            // lnkSaveFielMerge
            // 
            this.lnkSaveFielMerge.AutoSize = true;
            this.lnkSaveFielMerge.Image = global::MergeEfdPisCofins.Properties.Resources.Background;
            this.lnkSaveFielMerge.Location = new System.Drawing.Point(8, 114);
            this.lnkSaveFielMerge.Name = "lnkSaveFielMerge";
            this.lnkSaveFielMerge.Size = new System.Drawing.Size(101, 13);
            this.lnkSaveFielMerge.TabIndex = 18;
            this.lnkSaveFielMerge.TabStop = true;
            this.lnkSaveFielMerge.Text = "Salvar arquivo em...";
            this.lnkSaveFielMerge.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSaveFielMerge_LinkClicked);
            // 
            // txtSaveFileMerge
            // 
            this.txtSaveFileMerge.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSaveFileMerge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaveFileMerge.Location = new System.Drawing.Point(8, 130);
            this.txtSaveFileMerge.Name = "txtSaveFileMerge";
            this.txtSaveFileMerge.ReadOnly = true;
            this.txtSaveFileMerge.Size = new System.Drawing.Size(370, 20);
            this.txtSaveFileMerge.TabIndex = 17;
            // 
            // lnkLoadSSATXTFile
            // 
            this.lnkLoadSSATXTFile.AutoSize = true;
            this.lnkLoadSSATXTFile.Image = global::MergeEfdPisCofins.Properties.Resources.Background;
            this.lnkLoadSSATXTFile.Location = new System.Drawing.Point(5, 14);
            this.lnkLoadSSATXTFile.Name = "lnkLoadSSATXTFile";
            this.lnkLoadSSATXTFile.Size = new System.Drawing.Size(163, 13);
            this.lnkLoadSSATXTFile.TabIndex = 16;
            this.lnkLoadSSATXTFile.TabStop = true;
            this.lnkLoadSSATXTFile.Text = "Carregar arquivo Texto SSA de...";
            this.lnkLoadSSATXTFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoadSSATXTFile_LinkClicked);
            // 
            // lblLoadDesc
            // 
            this.lblLoadDesc.AutoSize = true;
            this.lblLoadDesc.Image = global::MergeEfdPisCofins.Properties.Resources.Background;
            this.lblLoadDesc.Location = new System.Drawing.Point(8, 187);
            this.lblLoadDesc.Name = "lblLoadDesc";
            this.lblLoadDesc.Size = new System.Drawing.Size(0, 13);
            this.lblLoadDesc.TabIndex = 20;
            // 
            // progressMerge
            // 
            this.progressMerge.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressMerge.Location = new System.Drawing.Point(0, 209);
            this.progressMerge.Name = "progressMerge";
            this.progressMerge.Size = new System.Drawing.Size(624, 23);
            this.progressMerge.TabIndex = 24;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MergeEfdPisCofins.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(624, 232);
            this.Controls.Add(this.progressMerge);
            this.Controls.Add(this.lnkLoadSAPTXTFile);
            this.Controls.Add(this.txtLoadSAPTXTFile);
            this.Controls.Add(this.btnCreateFileMerge);
            this.Controls.Add(this.lblLoadDesc);
            this.Controls.Add(this.txtLoadSSATXTFile);
            this.Controls.Add(this.grpAtTo);
            this.Controls.Add(this.lnkSaveFielMerge);
            this.Controls.Add(this.txtSaveFileMerge);
            this.Controls.Add(this.lnkLoadSSATXTFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = ":::... EFD - PIS | COFIS ...:::";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtTo)).EndInit();
            this.grpAtTo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkLoadSAPTXTFile;
        private System.Windows.Forms.TextBox txtLoadSAPTXTFile;
        private System.Windows.Forms.Button btnCreateFileMerge;
        private System.Windows.Forms.TextBox txtLoadSSATXTFile;
        private System.Windows.Forms.DataGridView dataGridViewAtTo;
        private System.Windows.Forms.GroupBox grpAtTo;
        private System.Windows.Forms.LinkLabel lnkSaveFielMerge;
        private System.Windows.Forms.TextBox txtSaveFileMerge;
        private System.Windows.Forms.LinkLabel lnkLoadSSATXTFile;
        private System.Windows.Forms.Label lblLoadDesc;
        private System.Windows.Forms.ProgressBar progressMerge;
    }
}

