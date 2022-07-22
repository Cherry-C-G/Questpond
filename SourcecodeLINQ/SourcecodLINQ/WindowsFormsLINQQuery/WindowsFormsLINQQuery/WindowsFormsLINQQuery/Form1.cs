using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsLINQQuery
{
    public partial class frmLINQQuery : Form
    {
        public frmLINQQuery()
        {
            InitializeComponent();
        }

        private void btnFireQuery_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbFireQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFireQuery.SelectedIndex == 0)
            {
                SimpleQuery();
            }
            else if (cmbFireQuery.SelectedIndex == 1)
            {
                FireQueryWithWhere(txtCustomerCode.Text);
            }
            else if (cmbFireQuery.SelectedIndex == 2)
            {
                FireWithJoin();
            }
            else if (cmbFireQuery.SelectedIndex == 3)
            {
                FireWithGroupBy();
            }
            else if (cmbFireQuery.SelectedIndex == 4)
            {
                FireWithOrderBy();
            }
        }
        private void SimpleQuery()
        {
            clsLINQ objLinq = new clsLINQ();
            lstResults.Items.Clear();
            LoadCustomersinList(objLinq.FireSimpleQuery());
        }
        private void FireQueryWithWhere(string strCustomerCode)
        {
            clsLINQ objLinq = new clsLINQ();
            lstResults.Items.Clear();
            LoadCustomersinList(objLinq.FireQueryWithWhere(strCustomerCode));
        }
        private void FireWithJoin()
        {
            clsLINQ objLinq = new clsLINQ();
            lstResults.Items.Clear();
            LoadCustomersinList(objLinq.FireQueryWithJoin());
        }
        private void FireWithGroupBy()
        {
            clsLINQ objLinq = new clsLINQ();
            lstResults.Items.Clear();
            objLinq.FireQueryWithGroupBy(lstResults);
        }
        private void FireWithOrderBy()
        {
            clsLINQ objLinq = new clsLINQ();
            lstResults.Items.Clear();
            LoadCustomersinList(objLinq.FireQueryWithOrderBy());
        }
        private void LoadCustomersinList(IEnumerable<clsCustomer> objCollection)
        {
            foreach (clsCustomer obj in objCollection)
            {
                lstResults.Items.Add(" Name :-"  + obj.CustomerName + " Code  :-" + obj.customerCode + " City  :-" + obj.City);
                foreach (clsOrder objOrder in obj.Orders)
                {
                    lstResults.Items.Add("-->" + objOrder.ProductName);
                }
            }
        }

        private void frmLINQQuery_Load(object sender, EventArgs e)
        {

        }

    }
}
