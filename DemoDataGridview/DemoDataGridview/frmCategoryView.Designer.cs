namespace DemoDataGridview
{
    partial class frmCategoryView
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
            this.dgCategory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCategory
            // 
            this.dgCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCategory.Location = new System.Drawing.Point(0, 0);
            this.dgCategory.Name = "dgCategory";
            this.dgCategory.RowHeadersWidth = 92;
            this.dgCategory.RowTemplate.Height = 37;
            this.dgCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCategory.Size = new System.Drawing.Size(1735, 1211);
            this.dgCategory.TabIndex = 0;
            this.dgCategory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgCategory_MouseDoubleClick);
            // 
            // frmCategoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1735, 1211);
            this.Controls.Add(this.dgCategory);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmCategoryView";
            this.Text = "CategoryView";
            this.Load += new System.EventHandler(this.frmCategoryView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCategory;
    }
}