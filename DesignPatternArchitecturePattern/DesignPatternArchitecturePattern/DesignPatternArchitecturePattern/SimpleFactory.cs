using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternArchitecturePattern
{
    public static class SimpleFactory
    {
        public static IDiscount CreateDisCount(int i)
        {
            if (i == 1)
            {
                return new DisCountByAmount();
            }
            if (i == 2)
            {
                return new DiscountRegion();
            }
            return new DiscountAge();
        }
        public static ICustomer CreateCustomer(int type)
        {
            if (type == 1)
            {
                //Customer cust = new Customer(new HomeAddress());
                

            }
            if (type == 2)
            {
                Customer cust = new Customer();
                //cust.Address = new OfficeAddress();

            }
            if (type == 3)
            {
                CustomerVIP cust = new CustomerVIP();
                //cust.Address = new OfficeAddress();

            }
            return null;

        }
    }
}
