namespace DemoDataGridview
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPOS = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCategory,
            this.menuProduct,
            this.menuPOS});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1757, 65);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuCategory
            // 
            this.menuCategory.Name = "menuCategory";
            this.menuCategory.Size = new System.Drawing.Size(215, 61);
            this.menuCategory.Text = "Category";
            this.menuCategory.Click += new System.EventHandler(this.menuCategory_Click);
            // 
            // menuProduct
            // 
            this.menuProduct.Name = "menuProduct";
            this.menuProduct.Size = new System.Drawing.Size(193, 61);
            this.menuProduct.Text = "Product";
            this.menuProduct.Click += new System.EventHandler(this.menuProduct_Click);
            // 
            // menuPOS
            // 
            this.menuPOS.Name = "menuPOS";
            this.menuPOS.Size = new System.Drawing.Size(125, 61);
            this.menuPOS.Text = "POS";
            this.menuPOS.Click += new System.EventHandler(this.menuPOS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1757, 863);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCategory;
        private System.Windows.Forms.ToolStripMenuItem menuProduct;
        private System.Windows.Forms.ToolStripMenuItem menuPOS;
    }
}

