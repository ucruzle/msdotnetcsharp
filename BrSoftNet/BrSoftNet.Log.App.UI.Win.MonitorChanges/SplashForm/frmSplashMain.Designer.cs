namespace BrSoftNet.App.UI.Win.Security.SplashForm
{
    partial class frmSplashMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplashMain));
            this.prgBarFormSplash = new System.Windows.Forms.ProgressBar();
            this.pctrBoxFormSplash = new System.Windows.Forms.PictureBox();
            this.tmrFormSplash = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pctrBoxFormSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // prgBarFormSplash
            // 
            this.prgBarFormSplash.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prgBarFormSplash.Location = new System.Drawing.Point(0, 307);
            this.prgBarFormSplash.Name = "prgBarFormSplash";
            this.prgBarFormSplash.Size = new System.Drawing.Size(490, 23);
            this.prgBarFormSplash.TabIndex = 0;
            // 
            // pctrBoxFormSplash
            // 
            this.pctrBoxFormSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctrBoxFormSplash.Image = ((System.Drawing.Image)(resources.GetObject("pctrBoxFormSplash.Image")));
            this.pctrBoxFormSplash.Location = new System.Drawing.Point(0, 0);
            this.pctrBoxFormSplash.Name = "pctrBoxFormSplash";
            this.pctrBoxFormSplash.Size = new System.Drawing.Size(490, 307);
            this.pctrBoxFormSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctrBoxFormSplash.TabIndex = 1;
            this.pctrBoxFormSplash.TabStop = false;
            // 
            // tmrFormSplash
            // 
            this.tmrFormSplash.Enabled = true;
            this.tmrFormSplash.Tick += new System.EventHandler(this.tmrFormSplash_Tick);
            // 
            // frmSplashMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 330);
            this.Controls.Add(this.pctrBoxFormSplash);
            this.Controls.Add(this.prgBarFormSplash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplashMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pctrBoxFormSplash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgBarFormSplash;
        private System.Windows.Forms.PictureBox pctrBoxFormSplash;
        private System.Windows.Forms.Timer tmrFormSplash;
    }
}