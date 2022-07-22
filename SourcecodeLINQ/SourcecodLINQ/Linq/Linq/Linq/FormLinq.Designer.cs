namespace Linq
{
    partial class FormLinq
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
            this.lstCountry = new System.Windows.Forms.ListBox();
            this.btnLinq = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstCountry
            // 
            this.lstCountry.FormattingEnabled = true;
            this.lstCountry.Location = new System.Drawing.Point(12, 27);
            this.lstCountry.Name = "lstCountry";
            this.lstCountry.Size = new System.Drawing.Size(342, 95);
            this.lstCountry.TabIndex = 0;
            // 
            // btnLinq
            // 
            this.btnLinq.Location = new System.Drawing.Point(12, 128);
            this.btnLinq.Name = "btnLinq";
            this.btnLinq.Size = new System.Drawing.Size(141, 36);
            this.btnLinq.TabIndex = 1;
            this.btnLinq.Text = "Load by LINQ";
            this.btnLinq.UseVisualStyleBackColor = true;
            this.btnLinq.Click += new System.EventHandler(this.btnLinq_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(159, 128);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(195, 36);
            this.btnNormal.TabIndex = 2;
            this.btnNormal.Text = "Load by Normal Business object";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // FormLinq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 178);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.btnLinq);
            this.Controls.Add(this.lstCountry);
            this.Name = "FormLinq";
            this.Text = "Country LINQ Sample";
            this.Load += new System.EventHandler(this.FormLinq_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCountry;
        private System.Windows.Forms.Button btnLinq;
        private System.Windows.Forms.Button btnNormal;
    }
}

