using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsMemento
{
    public partial class frmMemento : Form
    {
        public frmMemento()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayCustomer();
        }
        
        clsCustomer objCustomer = new clsCustomer();
       
        private void DisplayCustomer()
        {
            txtCustomerCode.Text=objCustomer.CustomerCode;
            txtCustomerName.Text = objCustomer.CustomerName;
            txtAddress.Text = objCustomer.Address;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            objCustomer.CustomerCode = txtCustomerCode.Text;
            objCustomer.CustomerName = txtCustomerName.Text;
            objCustomer.Address = txtAddress.Text;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            objCustomer.Revert();
            DisplayCustomer();
        }
    }
}