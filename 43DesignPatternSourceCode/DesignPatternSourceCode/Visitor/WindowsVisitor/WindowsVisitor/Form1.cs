using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Visitor;
namespace WindowsVisitor
{
    public partial class Form1 : Form
    {
        public clsCustomer objCustomer;
        public Form1()
        {
            InitializeComponent();
            setTestdata();
        }
        private void setTestdata()
        {
            objCustomer = new clsCustomer();
            clsAddress objAddress = new clsAddress();
            clsPhone objPhone = new clsPhone();
            objCustomer.strCustomerName="Shivprasad Koirala";
            objAddress.strAddress1="Mumbai";
            objAddress.strAddress2="Mulund";
            objPhone.strPhoneNumber = "99881";
            objAddress.objPhones.Add(objPhone);
            objCustomer.objAddresses.Add(objAddress);
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void btnDisplayString_Click(object sender, EventArgs e)
        {
            
            clsVisitorString objVisitorString = new clsVisitorString();
            objCustomer.accept(objVisitorString);
            txtDataDisplay.Text = objVisitorString.strData;
        }
        private void btnDisplayXML_Click(object sender, EventArgs e)
        {
            clsXML objVisitorXML = new clsXML();
            objCustomer.accept(objVisitorXML);
            txtDataDisplay.Text = objVisitorXML.strData;
        }
    }
}