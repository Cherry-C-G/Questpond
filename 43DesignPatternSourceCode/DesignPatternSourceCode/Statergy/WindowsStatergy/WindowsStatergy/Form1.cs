using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Statergy;
namespace WindowsStatergy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // create the new maths object
            clsMaths objMaths = new clsMaths();
            // set number1 value and number2 value
            objMaths.intNumber1 = Convert.ToInt16(txtNumber1.Text);
            objMaths.intNumber2 = Convert.ToInt16(txtNumber2.Text);
            // set the statergy currently we have set it to add
            objMaths.setStatergy(new clsAddStatergy());
            // call the calculate method
            txtResults.Text = objMaths.Calculate().ToString();
        }

        private void btSubstract_Click(object sender, EventArgs e)
        {
            // create the new maths object
            clsMaths objMaths = new clsMaths();
            // set number1 and number2 value
            objMaths.intNumber1 = Convert.ToInt16(txtNumber1.Text);
            objMaths.intNumber2 = Convert.ToInt16(txtNumber2.Text);
            // we have set the statergy to subtract
            objMaths.setStatergy(new clsSubstractStatergy());
            // call the calculate method
            txtResults.Text = objMaths.Calculate().ToString();
        }
    }
}