using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoType
{
    public class clsCustomer
    {

        public clsAddress objAddress = new clsAddress();
        public string strCustomerCode = "";
        public string strCustomerName = "";
        public clsCustomer getClone()
        {
            clsCustomer objCustomer;
            objCustomer = (clsCustomer) this.MemberwiseClone();
            objCustomer.objAddress = (clsAddress)objAddress.getClone();
            return objCustomer;
        }
    }
    public class clsAddress
    {
        public string strAddress = "";
        public clsAddress getClone()
        {
            return (clsAddress)this.MemberwiseClone();
        }
    }
}
