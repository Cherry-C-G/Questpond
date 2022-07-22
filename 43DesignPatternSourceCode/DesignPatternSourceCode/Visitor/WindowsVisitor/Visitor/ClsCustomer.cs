using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Visitor
{
    public class clsCustomer : ICustomerElements
    {
        public void accept(IVisitor objVisitor)
        {
            objVisitor.visit(this);

            foreach (clsAddress objAddress in objAddresses)
            {
                objAddress.accept(objVisitor);
            }
        }
        public string strCustomerName = "";
        public ArrayList objAddresses = new ArrayList();
    }

    public class clsAddress : ICustomerElements
    {
        public void accept(IVisitor objVisitor)
        {
            objVisitor.visit(this);
            foreach (clsPhone objPhone in objPhones)
            {
                objPhone.accept(objVisitor);
            }
        }
        public string strAddress1 = "";
        public string strAddress2 = "";
        public ArrayList objPhones = new ArrayList();
    }
    public class clsPhone : ICustomerElements
    {
        public void accept(IVisitor objVisitor)
        {
            objVisitor.visit(this);
        }
        public string strPhoneNumber = "";
    }
}
