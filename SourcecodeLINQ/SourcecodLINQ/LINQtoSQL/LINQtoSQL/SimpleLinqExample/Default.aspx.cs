using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
namespace SimpleLinqExample
{
    public partial class _Default : System.Web.UI.Page
    {
        string strConnectionString = @"Data Source=localhost;Initial Catalog=Sales;Integrated Security=True";
        //string strConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Sales.mdf;Integrated Security=True;User Instance=True";
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void cmdSimpleLINQtoSQL_Click(object sender, EventArgs e)
        {
            DataContext objContext = new DataContext(strConnectionString);
            Table<clsCustomerEntity> objTable = objContext.GetTable<clsCustomerEntity>();

            foreach (clsCustomerEntity objCustomer in objTable)
            {
                Response.Write(objCustomer.CustomerName + "<br>");
            }
        }

        protected void SimpleLINQtoSQlWithQuery_Click(object sender, EventArgs e)
        {
            DataContext objContext = new DataContext(strConnectionString);
            var MyQuery = from objCustomer in objContext.GetTable<clsCustomerEntityWithProperties>()
                          where objCustomer.CustomerCode == txtCustomerCode.Text
                          select objCustomer;
            foreach (clsCustomerEntityWithProperties objCustomer in MyQuery)
            {
                Response.Write(objCustomer.CustomerName + "<br>");
            }
        }

        protected void SimpleLINQtoSQlWithSetGet_Click(object sender, EventArgs e)
        {
            DataContext objContext = new DataContext(strConnectionString);
            var MyQuery = from objCustomer in objContext.GetTable<clsCustomerEntityWithProperties>()
                          select objCustomer;
            foreach (clsCustomerEntityWithProperties objCustomer in MyQuery)
            {
                Response.Write(objCustomer.CustomerName + "<br>");
            }
        }

        protected void LINQtoSQLrelationShip_Click(object sender, EventArgs e)
        {
            DataContext objContext = new DataContext(strConnectionString);

            var MyQuery = from objCustomer in objContext.GetTable<clsCustomerWithAddresses>()
                          select objCustomer;
                   
            foreach (clsCustomerWithAddresses objCustomer in MyQuery)
            {
               
                Response.Write(objCustomer.CustomerName + "<br>");
                
                foreach (clsAddresses objAddress in objCustomer.Addresses)
                {
                    Response.Write("===Address:- " + objAddress.Address1 + "<br>");
                    Response.Write("========Mobile:- " + objAddress.Phone.MobilePhone + "<br>");
                    Response.Write("========LandLine:- " + objAddress.Phone.LandLine + "<br>");
                }
            }

           
        }

        protected void LINQtoSQLusingDataLoadOption_Click(object sender, EventArgs e)
        {
            DataContext objContext = new DataContext(strConnectionString);
            DataLoadOptions objDataLoadOption = new DataLoadOptions();
            objDataLoadOption.LoadWith<clsCustomerWithAddresses>(clsCustomerWithAddresses => clsCustomerWithAddresses.Addresses);
            objDataLoadOption.LoadWith<clsAddresses>(clsAddresses => clsAddresses.Phone);
            objContext.LoadOptions = objDataLoadOption;
            var MyQuery = from objCustomer in objContext.GetTable<clsCustomerWithAddresses>()
                          select objCustomer;

            foreach (clsCustomerWithAddresses objCustomer in MyQuery)
            {

                Response.Write(objCustomer.CustomerName + "<br>");

                foreach (clsAddresses objAddress in objCustomer.Addresses)
                {
                    Response.Write("===Address:- " + objAddress.Address1 + "<br>");
                    Response.Write("========Mobile:- " + objAddress.Phone.MobilePhone + "<br>");
                    Response.Write("========LandLine:- " + objAddress.Phone.LandLine + "<br>");
                }
            }
        }

       
    }
}
