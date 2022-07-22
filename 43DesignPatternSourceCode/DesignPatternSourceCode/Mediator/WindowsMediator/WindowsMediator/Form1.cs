using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsMediator
{
    public partial class Form1 : Form
    {
        private clsMediator objMediator = new clsMediator();
        public Form1()
        {
            InitializeComponent();
            objMediator.Register(txtName);
            objMediator.Register(btnAdd);
            objMediator.Register(btnClear);
            objMediator.Register(lstName);

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            objMediator.TextChange();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            objMediator.ClickAddButton();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            objMediator.ClickClearButton();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}