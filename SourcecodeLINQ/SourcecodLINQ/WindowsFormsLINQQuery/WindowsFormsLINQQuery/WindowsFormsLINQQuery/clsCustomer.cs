using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace WindowsFormsLINQQuery
{
    class clsCustomer
    {
        private string strCustomerName="";
        private string strCustomerCode="";
        private string strCity = "";
        public  string CustomerName
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
        public string customerCode
        {
            set
            { strCustomerCode = value; }
            get
            { return strCustomerCode; }
        }
        public string City
        {
            set
            {
                strCity = value;
            }
            get
            {
                return strCity;
            }
        }
        public clsOrder[] Orders=null;
    }
    class clsOrder
    {
        private string strProductName;
        public string ProductName
        {
            set
            {
                strProductName = value;
            }
            get
            {
                return strProductName;
            }
        }
    }
    class clsLINQ
    {
         clsCustomer[] objCustomer = new clsCustomer[]
         {
            new clsCustomer{CustomerName="Khadak",customerCode="001",City="Mumbai",Orders = new clsOrder[]
                                            {new clsOrder{ProductName="Shirt"},
                                            new clsOrder{ProductName="Socks"}}},
            new clsCustomer{CustomerName="Shiv",customerCode="002",City="Delhi",Orders = new clsOrder[]{new clsOrder{ProductName="Pants"}}},
            new clsCustomer{CustomerName="Raju",customerCode="003",City="Mumbai",Orders = new clsOrder[]{new clsOrder{ProductName="Socks"}}},
            new clsCustomer{CustomerName="Shaam",customerCode="004",City="Delhi",Orders = new clsOrder[]{new clsOrder{ProductName="Shoes"}}}
         };
        
        public IEnumerable<clsCustomer> FireSimpleQuery()
        {
            return from clsCustomer Obj in objCustomer select Obj;
        }
        public IEnumerable<clsCustomer> FireQueryWithWhere(string strCustomerCode)
        {
            return from clsCustomer Obj in objCustomer  where Obj.customerCode == strCustomerCode select Obj;
        }
        public IEnumerable<clsCustomer> FireQueryWithJoin()
        {
            return from clsCustomer ObjCust in objCustomer 
                   from clsOrder ObjOrder in ObjCust.Orders
                   select ObjCust;
        }
        public IEnumerable<clsCustomer> FireQueryWithOrderBy()
        {
            return from clsCustomer ObjCust in objCustomer
                   orderby ObjCust.City
                   select ObjCust;
        }
        public void FireQueryWithGroupBy(ListBox Obj)
        {
            var GroupCustomers = from ObjCust in objCustomer
                        group ObjCust by ObjCust.City into GroupTemp
                   select new {GroupTemp.Key,GroupTemp};
            foreach (var MyTempGroup in GroupCustomers)
            {
                Obj.Items.Add(MyTempGroup.Key);
                foreach (var MyCustomer in MyTempGroup.GroupTemp)
                {
                    Obj.Items.Add(">>>" + MyCustomer.CustomerName + "  " + MyCustomer.customerCode);
                }
            }

        }
    }
}
