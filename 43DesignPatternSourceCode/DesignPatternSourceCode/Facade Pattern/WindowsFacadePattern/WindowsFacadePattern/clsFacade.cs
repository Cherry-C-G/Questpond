using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFacadePattern
{
    class clsOrder
    {
        public void PlaceOrder()
        {
            clsProduct objProduct = new clsProduct();
           clsPayment objPayment = new clsPayment();
           clsInvoice objInvoice = new clsInvoice();
           
            objProduct.getDetails();
            objPayment.PayOnline();
            objInvoice.PrintInvoice();
        }
    }
    class clsProduct
    {
        public string getDetails()
        {
            return "Product information";
        }
    }
    class clsPayment
    {
        public void PayOnline()
        {
        }
    }
    class clsInvoice
    {
        public void PrintInvoice()
        {

        }
    }
}
