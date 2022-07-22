namespace WindowsMVPStock
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
            this.btnInCreaseStock = new System.Windows.Forms.Button();
            this.btnDecreaseStock = new System.Windows.Forms.Button();
            this.txtStockValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnInCreaseStock
            // 
            this.btnInCreaseStock.Location = new System.Drawing.Point(30, 13);
            this.btnInCreaseStock.Name = "btnInCreaseStock";
            this.btnInCreaseStock.Size = new System.Drawing.Size(141, 35);
            this.btnInCreaseStock.TabIndex = 0;
            this.btnInCreaseStock.Text = "Increase Stock";
            this.btnInCreaseStock.UseVisualStyleBackColor = true;
            this.btnInCreaseStock.Click += new System.EventHandler(this.btnInCreaseStock_Click);
            // 
            // btnDecreaseStock
            // 
            this.btnDecreaseStock.Location = new System.Drawing.Point(30, 80);
            this.btnDecreaseStock.Name = "btnDecreaseStock";
            this.btnDecreaseStock.Size = new System.Drawing.Size(141, 34);
            this.btnDecreaseStock.TabIndex = 1;
            this.btnDecreaseStock.Text = "Decrease Stock";
            this.btnDecreaseStock.UseVisualStyleBackColor = true;
            this.btnDecreaseStock.Click += new System.EventHandler(this.btnDecreaseStock_Click);
            // 
            // txtStockValue
            // 
            this.txtStockValue.Location = new System.Drawing.Point(30, 55);
            this.txtStockValue.Name = "txtStockValue";
            this.txtStockValue.Size = new System.Drawing.Size(141, 20);
            this.txtStockValue.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.txtStockValue);
            this.Controls.Add(this.btnDecreaseStock);
            this.Controls.Add(this.btnInCreaseStock);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInCreaseStock;
        private System.Windows.Forms.Button btnDecreaseStock;
        private System.Windows.Forms.TextBox txtStockValue;
    }
}

