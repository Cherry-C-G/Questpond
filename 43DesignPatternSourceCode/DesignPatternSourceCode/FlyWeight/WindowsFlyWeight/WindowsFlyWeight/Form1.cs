using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFlyWeight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsVariableAddress objVar1 = new clsVariableAddress();
            objVar1.strName = "Shiv";
            clsVariableAddress objVar2 = new clsVariableAddress();
            objVar2.strName = "Raju";
            lstAddress.Items.Add(objVar1.strName + " " + objVar1.Address().strAddress);
            lstAddress.Items.Add(objVar2.strName + " " + objVar2.Address().strAddress);

        }
    }
}