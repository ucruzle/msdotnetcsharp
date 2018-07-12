namespace BrSoftNet.App.UI.Win.OverallRecord.DialogUpdateForm.UpdateFormRegistroGeralHelperScreen
{
    partial class HelperFormRegistroGeralContatoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelperFormRegistroGeralContatoView));
            this.sttsStrpFormHelper = new System.Windows.Forms.StatusStrip();
            this.dtGrdVwHelperForm = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwHelperForm)).BeginInit();
            this.SuspendLayout();
            // 
            // sttsStrpFormHelper
            // 
            this.sttsStrpFormHelper.Location = new System.Drawing.Point(0, 394);
            this.sttsStrpFormHelper.Name = "sttsStrpFormHelper";
            this.sttsStrpFormHelper.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttsStrpFormHelper.Size = new System.Drawing.Size(534, 22);
            this.sttsStrpFormHelper.TabIndex = 0;
            // 
            // dtGrdVwHelperForm
            // 
            this.dtGrdVwHelperForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVwHelperForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrdVwHelperForm.Location = new System.Drawing.Point(0, 0);
            this.dtGrdVwHelperForm.Name = "dtGrdVwHelperForm";
            this.dtGrdVwHelperForm.Size = new System.Drawing.Size(534, 394);
            this.dtGrdVwHelperForm.TabIndex = 1;
            // 
            // HelperFormRegistroGeralContatoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 416);
            this.Controls.Add(this.dtGrdVwHelperForm);
            this.Controls.Add(this.sttsStrpFormHelper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelperFormRegistroGeralContatoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HelperFormRegistroGeralContatoView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVwHelperForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sttsStrpFormHelper;
        private System.Windows.Forms.DataGridView dtGrdVwHelperForm;
    }
}