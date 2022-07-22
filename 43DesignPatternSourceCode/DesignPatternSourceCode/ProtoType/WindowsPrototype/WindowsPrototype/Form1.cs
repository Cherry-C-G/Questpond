using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProtoType;
namespace WindowsPrototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProtoType_Click(object sender, EventArgs e)
        {
            clsCustomer obj1 = new clsCustomer();
            
            obj1.strCustomerCode = "001";
            obj1.strCustomerName = "OldCustomer";

            clsCustomer obj2;
            obj2 = obj1.getClone();
            
        }
    }
}