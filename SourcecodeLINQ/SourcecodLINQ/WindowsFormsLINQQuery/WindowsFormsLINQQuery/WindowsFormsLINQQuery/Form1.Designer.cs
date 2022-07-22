namespace WindowsFormsLINQQuery
{
    partial class frmLINQQuery
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
            this.lstResults = new System.Windows.Forms.ListBox();
            this.cmbFireQuery = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(12, 55);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(229, 368);
            this.lstResults.TabIndex = 2;
            // 
            // cmbFireQuery
            // 
            this.cmbFireQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbFireQuery.FormattingEnabled = true;
            this.cmbFireQuery.Items.AddRange(new object[] {
            "Simple Query",
            "Query With Where clause",
            "Join  Query",
            "Group By",
            "Order By"});
            this.cmbFireQuery.Location = new System.Drawing.Point(246, 12);
            this.cmbFireQuery.Name = "cmbFireQuery";
            this.cmbFireQuery.Size = new System.Drawing.Size(153, 150);
            this.cmbFireQuery.TabIndex = 3;
            this.cmbFireQuery.SelectedIndexChanged += new System.EventHandler(this.cmbFireQuery_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Customer Code";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(125, 12);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerCode.TabIndex = 5;
            // 
            // frmLINQQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 435);
            this.Controls.Add(this.txtCustomerCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFireQuery);
            this.Controls.Add(this.lstResults);
            this.Name = "frmLINQQuery";
            this.Text = "Let\'s Learn LINQ Query";
            this.Load += new System.EventHandler(this.frmLINQQuery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.ComboBox cmbFireQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerCode;
    }
}

