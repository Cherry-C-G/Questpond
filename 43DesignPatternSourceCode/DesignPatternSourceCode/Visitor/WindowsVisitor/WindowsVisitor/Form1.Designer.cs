namespace WindowsVisitor
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
            this.btnDisplayString = new System.Windows.Forms.Button();
            this.btnDisplayXML = new System.Windows.Forms.Button();
            this.txtDataDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDisplayString
            // 
            this.btnDisplayString.Location = new System.Drawing.Point(22, 122);
            this.btnDisplayString.Name = "btnDisplayString";
            this.btnDisplayString.Size = new System.Drawing.Size(107, 23);
            this.btnDisplayString.TabIndex = 0;
            this.btnDisplayString.Text = "Display string";
            this.btnDisplayString.UseVisualStyleBackColor = true;
            this.btnDisplayString.Click += new System.EventHandler(this.btnDisplayString_Click);
            // 
            // btnDisplayXML
            // 
            this.btnDisplayXML.Location = new System.Drawing.Point(148, 122);
            this.btnDisplayXML.Name = "btnDisplayXML";
            this.btnDisplayXML.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayXML.TabIndex = 1;
            this.btnDisplayXML.Text = "Display XML";
            this.btnDisplayXML.UseVisualStyleBackColor = true;
            this.btnDisplayXML.Click += new System.EventHandler(this.btnDisplayXML_Click);
            // 
            // txtDataDisplay
            // 
            this.txtDataDisplay.Location = new System.Drawing.Point(22, 13);
            this.txtDataDisplay.Multiline = true;
            this.txtDataDisplay.Name = "txtDataDisplay";
            this.txtDataDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDataDisplay.Size = new System.Drawing.Size(497, 103);
            this.txtDataDisplay.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 157);
            this.Controls.Add(this.txtDataDisplay);
            this.Controls.Add(this.btnDisplayXML);
            this.Controls.Add(this.btnDisplayString);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisplayString;
        private System.Windows.Forms.Button btnDisplayXML;
        private System.Windows.Forms.TextBox txtDataDisplay;
    }
}

