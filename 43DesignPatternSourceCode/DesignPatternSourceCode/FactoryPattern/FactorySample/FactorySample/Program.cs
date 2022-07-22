using System;
using System.Collections.Generic;
using System.Text;
using FactoryInvoice;
using InvoiceInterface;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int intInvoiceType = 0;

            IInvoice objInvoice;

            Console.WriteLine("Enter the invoice type");

            intInvoiceType = Convert.ToInt16(Console.ReadLine());

            objInvoice = clsFactoryInvoice.getInvoice(intInvoiceType);

            objInvoice.print();

            Console.ReadLine();
        }
    }
}
