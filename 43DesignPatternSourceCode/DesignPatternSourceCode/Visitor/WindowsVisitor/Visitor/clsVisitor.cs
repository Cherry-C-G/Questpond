using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public interface IVisitor
    {
         void visit(clsCustomer obj);
         void visit(clsAddress obj);
         void visit(clsPhone obj);
    }
    public interface ICustomerElements
    {
         void accept(IVisitor objVisitor);
    }
    public class clsVisitorString : IVisitor
    {
        public string strData;
        public void visit(clsCustomer obj)
        {
            strData = "Customer Name :- " + obj.strCustomerName + "\r\n";
        }
        public void visit(clsAddress obj)
        {
            strData = strData + "Address 1 :- " + obj.strAddress1 + "\r\n";
            strData = strData + "Address 2 :- " + obj.strAddress2 + "\r\n";
        }
        public void visit(clsPhone obj) 
        {
            strData = strData + "Phone :- " + obj.strPhoneNumber + "\r\n";
        }
    }
    public class clsXML : IVisitor
    {
        public string strData;
        public void visit(clsCustomer obj)
        {
            strData = "<customername>" + obj.strCustomerName;
        }
        public void visit(clsAddress obj)
        {
            strData = strData + "<Address1>" + obj.strAddress1 + "</Address1>";
            strData = strData + "<Address2>" + obj.strAddress2 + "</Address2>";
        }
        public void visit(clsPhone obj)
        {
            strData = strData + "<Phone>" + obj.strPhoneNumber + "</Phone></customername>";
        }
    }
}
