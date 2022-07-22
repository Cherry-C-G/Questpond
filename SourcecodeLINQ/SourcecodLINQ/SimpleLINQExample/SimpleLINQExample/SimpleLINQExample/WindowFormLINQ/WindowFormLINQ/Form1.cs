using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace WindowFormLINQ
{
    
    public partial class frmSimpleLINQExample : Form
    {
        public frmSimpleLINQExample()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLoadFromCustomObject_Click(object sender, EventArgs e)
        {
           

           clsCustomer[] Customers = new clsCustomer[] { new clsCustomer { CustomerName = "Raju", CustomerCode = "001" }, new clsCustomer { CustomerName = "Shiv", CustomerCode = "002" } };

            var query = from c in Customers
                        where c.CustomerCode == txtCustomerCode.Text
                        select new { c.CustomerCode, c.CustomerName };

            var enumerator = query.GetEnumerator();
            
            lstCountry.Items.Clear();
            
            if (enumerator.MoveNext())
            {
                var customer = enumerator.Current;
                lstCountry.Items.Add(customer.CustomerName);
            }
        }

        private void btnLoadFromDatabase_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\SimpleLINQExample\WindowFormLINQ\Country.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            Table<clsCustomer> Customers = db.GetTable<clsCustomer>();

            var query = from c in Customers
                        where c.CustomerCode == txtCustomerCode.Text
                        select new { c.CustomerCode, c.CustomerName };

            var enumerator = query.GetEnumerator();
            lstCountry.Items.Clear();
            if (enumerator.MoveNext())
            {
                var customer = enumerator.Current;
                lstCountry.Items.Add(customer.CustomerName);
            }
        }
    }
    [Table(Name="Customer")]
    public class clsCustomer
    {
        private string _strCustomerName;
        private string _strCustomerCode;
        [Column(Name="CustomerName")]
        public string CustomerName
        {
            set
            {
                _strCustomerName = value;
            }
            get
            {
                return _strCustomerName;
            }
        }
        [Column(Name = "CustomerCode")]
        public string CustomerCode
        {
            set
            {
                _strCustomerCode = value;
            }
            get
            {
                return _strCustomerCode;
            }
        }
    }
}