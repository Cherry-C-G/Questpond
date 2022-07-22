namespace WindowFormLINQ
{
    partial class frmSimpleLINQExample
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
            this.btnLoadFromDatabase = new System.Windows.Forms.Button();
            this.btnLoadFromCustomObject = new System.Windows.Forms.Button();
            this.lstCountry = new System.Windows.Forms.ListBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoadFromDatabase
            // 
            this.btnLoadFromDatabase.Location = new System.Drawing.Point(20, 158);
            this.btnLoadFromDatabase.Name = "btnLoadFromDatabase";
            this.btnLoadFromDatabase.Size = new System.Drawing.Size(120, 23);
            this.btnLoadFromDatabase.TabIndex = 0;
            this.btnLoadFromDatabase.Text = "Load from Database";
            this.btnLoadFromDatabase.UseVisualStyleBackColor = true;
            this.btnLoadFromDatabase.Click += new System.EventHandler(this.btnLoadFromDatabase_Click);
            // 
            // btnLoadFromCustomObject
            // 
            this.btnLoadFromCustomObject.Location = new System.Drawing.Point(20, 187);
            this.btnLoadFromCustomObject.Name = "btnLoadFromCustomObject";
            this.btnLoadFromCustomObject.Size = new System.Drawing.Size(120, 23);
            this.btnLoadFromCustomObject.TabIndex = 1;
            this.btnLoadFromCustomObject.Text = "Load From Object";
            this.btnLoadFromCustomObject.UseVisualStyleBackColor = true;
            this.btnLoadFromCustomObject.Click += new System.EventHandler(this.btnLoadFromCustomObject_Click);
            // 
            // lstCountry
            // 
            this.lstCountry.FormattingEnabled = true;
            this.lstCountry.Location = new System.Drawing.Point(20, 12);
            this.lstCountry.Name = "lstCountry";
            this.lstCountry.Size = new System.Drawing.Size(120, 108);
            this.lstCountry.TabIndex = 2;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(20, 126);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(120, 20);
            this.txtCustomerCode.TabIndex = 3;
            // 
            // frmSimpleLINQExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(158, 222);
            this.Controls.Add(this.txtCustomerCode);
            this.Controls.Add(this.lstCountry);
            this.Controls.Add(this.btnLoadFromCustomObject);
            this.Controls.Add(this.btnLoadFromDatabase);
            this.Name = "frmSimpleLINQExample";
            this.Text = "Simplest LINQ Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFromDatabase;
        private System.Windows.Forms.Button btnLoadFromCustomObject;
        private System.Windows.Forms.ListBox lstCountry;
        private System.Windows.Forms.TextBox txtCustomerCode;
    }
}

