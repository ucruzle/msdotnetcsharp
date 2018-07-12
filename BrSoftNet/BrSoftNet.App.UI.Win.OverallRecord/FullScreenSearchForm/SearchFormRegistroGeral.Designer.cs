namespace BrSoftNet.App.UI.Win.OverallRecord.FullScreenSearchForm
{
    partial class SearchFormRegistroGeral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchFormRegistroGeral));
            this.pnlFormSearchMenuLabel = new System.Windows.Forms.Panel();
            this.lblTitleModule = new System.Windows.Forms.Label();
            this.tlstrpFormSearchMenu = new System.Windows.Forms.ToolStrip();
            this.tlstrpBtnSearchCriteria = new System.Windows.Forms.ToolStripButton();
            this.tlstrpBtnClearSearchCriteria = new System.Windows.Forms.ToolStripButton();
            this.tlstrpSeparatorCriteriaExit = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tlstrpBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tlstrpBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tlstrpSeparatorCriteriaCrud = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpBtnFirst = new System.Windows.Forms.ToolStripButton();
            this.tlstrpBtnPreview = new System.Windows.Forms.ToolStripButton();
            this.tlstrpBtnNext = new System.Windows.Forms.ToolStripButton();
            this.tlstrpBtnLast = new System.Windows.Forms.ToolStripButton();
            this.tlstrpSeparatorCrudNavigator = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpBtnExit = new System.Windows.Forms.ToolStripButton();
            this.sttsFormSearchMenu = new System.Windows.Forms.StatusStrip();
            this.dataGridSearchModule = new System.Windows.Forms.DataGridView();
            this.bsRgRegistroGeral = new System.Windows.Forms.BindingSource(this.components);
            this.pnlFormSearchMenuLabel.SuspendLayout();
            this.tlstrpFormSearchMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearchModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRgRegistroGeral)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFormSearchMenuLabel
            // 
            this.pnlFormSearchMenuLabel.Controls.Add(this.lblTitleModule);
            this.pnlFormSearchMenuLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormSearchMenuLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlFormSearchMenuLabel.Name = "pnlFormSearchMenuLabel";
            this.pnlFormSearchMenuLabel.Size = new System.Drawing.Size(634, 30);
            this.pnlFormSearchMenuLabel.TabIndex = 0;
            // 
            // lblTitleModule
            // 
            this.lblTitleModule.AutoSize = true;
            this.lblTitleModule.Location = new System.Drawing.Point(5, 9);
            this.lblTitleModule.Name = "lblTitleModule";
            this.lblTitleModule.Size = new System.Drawing.Size(74, 13);
            this.lblTitleModule.TabIndex = 0;
            this.lblTitleModule.Text = "Registro Geral";
            // 
            // tlstrpFormSearchMenu
            // 
            this.tlstrpFormSearchMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlstrpFormSearchMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpBtnSearchCriteria,
            this.tlstrpBtnClearSearchCriteria,
            this.tlstrpSeparatorCriteriaExit,
            this.tlstrpBtnAdd,
            this.tlstrpBtnUpdate,
            this.tlstrpBtnDelete,
            this.tlstrpSeparatorCriteriaCrud,
            this.tlstrpBtnFirst,
            this.tlstrpBtnPreview,
            this.tlstrpBtnNext,
            this.tlstrpBtnLast,
            this.tlstrpSeparatorCrudNavigator,
            this.tlstrpBtnExit});
            this.tlstrpFormSearchMenu.Location = new System.Drawing.Point(0, 30);
            this.tlstrpFormSearchMenu.Name = "tlstrpFormSearchMenu";
            this.tlstrpFormSearchMenu.Size = new System.Drawing.Size(634, 25);
            this.tlstrpFormSearchMenu.TabIndex = 1;
            this.tlstrpFormSearchMenu.Text = "toolStrip1";
            // 
            // tlstrpBtnSearchCriteria
            // 
            this.tlstrpBtnSearchCriteria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpBtnSearchCriteria.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpBtnSearchCriteria.Image")));
            this.tlstrpBtnSearchCriteria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpBtnSearchCriteria.Name = "tlstrpBtnSearchCriteria";
            this.tlstrpBtnSearchCriteria.Size = new System.Drawing.Size(23, 22);
            this.tlstrpBtnSearchCriteria.ToolTipText = "Filtro de Consulta";
            this.tlstrpBtnSearchCriteria.Click += new System.EventHandler(this.tlstrpBtnSearchCriteria_Click);
            // 
            // tlstrpBtnClearSearchCriteria
            // 
            this.tlstrpBtnClearSearchCriteria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpBtnClearSearchCriteria.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpBtnClearSearchCriteria.Image")));
            this.tlstrpBtnClearSearchCriteria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpBtnClearSearchCriteria.Name = "tlstrpBtnClearSearchCriteria";
            this.tlstrpBtnClearSearchCriteria.Size = new System.Drawing.Size(23, 22);
            this.tlstrpBtnClearSearchCriteria.ToolTipText = "Limpar Filtro de Consulta";
            this.tlstrpBtnClearSearchCriteria.Click += new System.EventHandler(this.tlstrpBtnClearSearchCriteria_Click);
            // 
            // tlstrpSeparatorCriteriaExit
            // 
            this.tlstrpSeparatorCriteriaExit.Name = "tlstrpSeparatorCriteriaExit";
            this.tlstrpSeparatorCriteriaExit.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpBtnAdd
            // 
            this.tlstrpBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpBtnAdd.Image")));
            this.tlstrpBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpBtnAdd.Name = "tlstrpBtnAdd";
            this.tlstrpBtnAdd.Size = new System.Drawing.Size(23, 22);
            this.tlstrpBtnAdd.ToolTipText = "Novo Registro";
            this.tlstrpBtnAdd.Click += new System.EventHandler(this.tlstrpBtnAdd_Click);
            // 
            // tlstrpBtnUpdate
            // 
            this.tlstrpBtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpBtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpBtnUpdate.Image")));
            this.tlstrpBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpBtnUpdate.Name = "tlstrpBtnUpdate";
            this.tlstrpBtnUpdate.Size = new System.Drawing.Size(23, 22);
            this.tlstrpBtnUpdate.ToolTipText = "Alterar Registro";
            this.tlstrpBtnUpdate.Click += new System.EventHandler(this.tlstrpBtnUpdate_Click);
            // 
            // tlstrpBtnDelete
            // 
            this.tlstrpBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpBtnDelete.Image")));
            this.tlstrpBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpBtnDelete.Name = "tlstrpBtnDelete";
            this.tlstrpBtnDelete.Size = new System.Drawing.Size(23, 22);
            this.tlstrpBtnDelete.ToolTipText = "Excluir Registro";
            this.tlstrpBtnDelete.Click += new System.EventHandler(this.tlstrpBtnDelete_Click);
            // 
            // tlstrpSeparatorCriteriaCrud
            // 
            this.tlstrpSeparatorCriteriaCrud.Name = "tlstrpSeparatorCriteriaCrud";
            this.tlstrpSeparatorCriteriaCrud.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpBtnFirst
            // 
            this.tlstrpBtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpBtnFirst.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpBtnFirst.Image")));
            this.tlstrpBtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpBtnFirst.Name = "tlstrpBtnFirst";
            this.tlstrpBtnFirst.Size = new System.Drawing.Size(23, 22);
            this.tlstrpBtnFirst.ToolTipText = "Primeiro Registro";
            this.tlstrpBtnFirst.Click += new System.EventHandler(this.tlstrpBtnFirst_Click);
            // 
            // tlstrpBtnPreview
            // 
            this.tlstrpBtnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpBtnPreview.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpBtnPreview.Image")));
            this.tlstrpBtnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpBtnPreview.Name = "tlstrpBtnPreview";
            this.tlstrpBtnPreview.Size = new System.Drawing.Size(23, 22);
            this.tlstrpBtnPreview.ToolTipText = "Registro Anterior";
            this.tlstrpBtnPreview.Click += new System.EventHandler(this.tlstrpBtnPreview_Click);
            // 
            // tlstrpBtnNext
            // 
            this.tlstrpBtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpBtnNext.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpBtnNext.Image")));
            this.tlstrpBtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpBtnNext.Name = "tlstrpBtnNext";
            this.tlstrpBtnNext.Size = new System.Drawing.Size(23, 22);
            this.tlstrpBtnNext.ToolTipText = "Próximo Registro";
            this.tlstrpBtnNext.Click += new System.EventHandler(this.tlstrpBtnNext_Click);
            // 
            // tlstrpBtnLast
            // 
            this.tlstrpBtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpBtnLast.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpBtnLast.Image")));
            this.tlstrpBtnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpBtnLast.Name = "tlstrpBtnLast";
            this.tlstrpBtnLast.Size = new System.Drawing.Size(23, 22);
            this.tlstrpBtnLast.ToolTipText = "Último Registro";
            this.tlstrpBtnLast.Click += new System.EventHandler(this.tlstrpBtnLast_Click);
            // 
            // tlstrpSeparatorCrudNavigator
            // 
            this.tlstrpSeparatorCrudNavigator.Name = "tlstrpSeparatorCrudNavigator";
            this.tlstrpSeparatorCrudNavigator.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstrpBtnExit
            // 
            this.tlstrpBtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstrpBtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tlstrpBtnExit.Image")));
            this.tlstrpBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstrpBtnExit.Name = "tlstrpBtnExit";
            this.tlstrpBtnExit.Size = new System.Drawing.Size(23, 22);
            this.tlstrpBtnExit.ToolTipText = "Sair do Módulo";
            this.tlstrpBtnExit.Click += new System.EventHandler(this.tlstrpBtnExit_Click);
            // 
            // sttsFormSearchMenu
            // 
            this.sttsFormSearchMenu.Location = new System.Drawing.Point(0, 390);
            this.sttsFormSearchMenu.Name = "sttsFormSearchMenu";
            this.sttsFormSearchMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.sttsFormSearchMenu.Size = new System.Drawing.Size(634, 22);
            this.sttsFormSearchMenu.TabIndex = 2;
            // 
            // dataGridSearchModule
            // 
            this.dataGridSearchModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSearchModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridSearchModule.Location = new System.Drawing.Point(0, 55);
            this.dataGridSearchModule.Name = "dataGridSearchModule";
            this.dataGridSearchModule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSearchModule.Size = new System.Drawing.Size(634, 335);
            this.dataGridSearchModule.TabIndex = 3;
            this.dataGridSearchModule.DoubleClick += new System.EventHandler(this.dataGridSearchModule_DoubleClick);
            // 
            // SearchFormRegistroGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 412);
            this.Controls.Add(this.dataGridSearchModule);
            this.Controls.Add(this.sttsFormSearchMenu);
            this.Controls.Add(this.tlstrpFormSearchMenu);
            this.Controls.Add(this.pnlFormSearchMenuLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchFormRegistroGeral";
            this.Load += new System.EventHandler(this.SearchFormRegistroGeral_Load);
            this.pnlFormSearchMenuLabel.ResumeLayout(false);
            this.pnlFormSearchMenuLabel.PerformLayout();
            this.tlstrpFormSearchMenu.ResumeLayout(false);
            this.tlstrpFormSearchMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearchModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRgRegistroGeral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFormSearchMenuLabel;
        private System.Windows.Forms.ToolStrip tlstrpFormSearchMenu;
        private System.Windows.Forms.StatusStrip sttsFormSearchMenu;
        private System.Windows.Forms.ToolStripButton tlstrpBtnSearchCriteria;
        private System.Windows.Forms.ToolStripSeparator tlstrpSeparatorCriteriaExit;
        private System.Windows.Forms.ToolStripButton tlstrpBtnExit;
        private System.Windows.Forms.DataGridView dataGridSearchModule;
        private System.Windows.Forms.ToolStripButton tlstrpBtnAdd;
        private System.Windows.Forms.ToolStripButton tlstrpBtnUpdate;
        private System.Windows.Forms.ToolStripButton tlstrpBtnDelete;
        private System.Windows.Forms.ToolStripSeparator tlstrpSeparatorCriteriaCrud;
        private System.Windows.Forms.ToolStripButton tlstrpBtnFirst;
        private System.Windows.Forms.ToolStripButton tlstrpBtnPreview;
        private System.Windows.Forms.ToolStripButton tlstrpBtnNext;
        private System.Windows.Forms.ToolStripButton tlstrpBtnLast;
        private System.Windows.Forms.ToolStripSeparator tlstrpSeparatorCrudNavigator;
        private System.Windows.Forms.Label lblTitleModule;
        private System.Windows.Forms.ToolStripButton tlstrpBtnClearSearchCriteria;
        private System.Windows.Forms.BindingSource bsRgRegistroGeral;

    }
}

