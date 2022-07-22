using System;
using System.Collections.Generic;
using System.Text;
using InvoiceInterface;
using Invoice;
namespace FactoryInvoice
{
    public class clsFactoryInvoice
    {
        static public IInvoice getInvoice(int intInvoiceType)
        {
            IInvoice objinv;
            if (intInvoiceType == 1)
            {
               objinv = new clsInvoiceWithHeader();
            }
            else if (intInvoiceType == 2)
            {
                objinv = new clsInvoiceWithOutHeaders();
            }
            else
            {
                return null;
            }
            return objinv;
        }
    }
}
