using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsState
{
    public partial class Form1 : Form
    {
        public clsState objState = new clsState();
        public Form1()
        {
            InitializeComponent();
            txtState.Text = objState.getStatus();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            objState.PressSwitch();
            txtState.Text = objState.getStatus();
        }
    }
}