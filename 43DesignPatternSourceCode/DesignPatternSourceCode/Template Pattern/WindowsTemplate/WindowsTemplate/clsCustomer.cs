using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsTemplate
{
    public abstract class clsCustomer
    {
        private string _CustomerCode;
        private string _CustomerName;
        public string CustomerName
        {
            set
            {
                _CustomerName = value;
            }
            get
            {
                return _CustomerName;
            }
        }
        public string CustomerCode
        {
            set
            {
                _CustomerCode = value;
            }
            get
            {
                return _CustomerCode;
            }
        }
    }
    public class clsCustomerAdd : clsCustomer
    {
        public void Add()
        {
            Console.WriteLine("Customer code : " + CustomerCode);
            Console.WriteLine("Customer Name : " + CustomerName);
            Console.WriteLine("Customer is added");
        }
    }
    public class clsCustomerUpdate : clsCustomer
    {
        public void Update()
        {
            Console.WriteLine("Customer code : " + CustomerCode);
            Console.WriteLine("Customer Name : " + CustomerName);
            Console.WriteLine("Customer is Updated");
        }
    }
}
