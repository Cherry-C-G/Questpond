using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsIterator
{
    public partial class frmCustomer : Form
    {
        private clsIterator objIterator = new clsIterator();
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            objIterator.FillObjects();
            displayUI(objIterator.getFirst());
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                displayUI(objIterator.Prev());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void displayUI(clsCustomer objCustomer)
        {
           
            txtCustomerCode.Text = objCustomer.strCode;
            txtCustomerName.Text = objCustomer.strCustomer;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                displayUI(objIterator.Next());
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                displayUI(objIterator.getLast());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                displayUI(objIterator.getFirst());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGetByIndex_Click(object sender, EventArgs e)
        {
            try
            {
                displayUI(objIterator.getByIndex(Convert.ToInt16(txtIndex.Text)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}