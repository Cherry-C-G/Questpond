using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsSingleton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            
            clsSingleTon.Hit();
            
            MessageBox.Show(clsSingleTon.getTotalHits().ToString());
            
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            clsSingleTon.Hit();
            MessageBox.Show(clsSingleTon.getTotalHits().ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}