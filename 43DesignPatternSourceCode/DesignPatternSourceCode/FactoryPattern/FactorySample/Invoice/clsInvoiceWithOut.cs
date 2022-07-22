using System;
using System.Collections.Generic;
using System.Text;
using InvoiceInterface;
namespace Invoice
{
    public class clsInvoiceWithOutHeaders : IInvoice
    {
        public void print()
        {
            Console.WriteLine("Invoice will be printed with out headers");
        }
    }
}
