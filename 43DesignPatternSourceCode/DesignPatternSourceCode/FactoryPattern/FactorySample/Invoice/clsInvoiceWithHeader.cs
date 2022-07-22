using System;
using System.Collections.Generic;
using System.Text;
using InvoiceInterface;
namespace Invoice
{
    public class clsInvoiceWithHeader : IInvoice
    {
        public void print()
        {
            Console.WriteLine("Invoice will be printed with  headers");
        }
    }
}
