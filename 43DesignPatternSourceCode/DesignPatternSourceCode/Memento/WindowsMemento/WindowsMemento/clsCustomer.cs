using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsMemento
{
   
    class clsCustomer
    {
        private string strCustomerName = "";
        private string strCustomerCode = "";
        private string strAddress = "";
        private clsCustomerMemento objMemento = new clsCustomerMemento();
        public string CustomerCode
        {
            set
            {
                strCustomerCode = value;
            }
            get
            {
                return strCustomerCode;
            }
        }
        public string CustomerName
        {
            set
            {
                strCustomerName = value;
            }
            get
            {
                return strCustomerName;
            }
        }
        public string Address
        {
            set
            {
                strAddress = value;
            }
            get
            {
                return strAddress;
            }
        }
        public  clsCustomer()
        {
            strCustomerName = "Shiv";
            strCustomerCode = "Cust001";
            strAddress = "Mumbai";
            objMemento = new clsCustomerMemento(strCustomerName, strCustomerCode, strAddress);
        }
        public void Revert()
        {
            strCustomerName = objMemento.strCustomerName;
            strCustomerCode = objMemento.strCustomerCode;
            strAddress = objMemento.strAddress;
        }
    }
    
    class clsCustomerMemento 
    {
        public string strCustomerName = "";
        public string strCustomerCode = "";
        public string strAddress = "";
        public clsCustomerMemento()
        {
            
        }
        public  clsCustomerMemento(string strCustName, string strCustCode, string strAdd)
        {
            strCustomerName = strCustName;
            strCustomerCode = strCustCode;
            strAddress = strAdd;
        }
        
    }
}
