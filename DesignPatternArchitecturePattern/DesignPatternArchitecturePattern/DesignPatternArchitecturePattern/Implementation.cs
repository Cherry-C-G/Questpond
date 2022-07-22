using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternArchitecturePattern
{
    public class ValidationwithName : IValidateCustomer
    {
        public bool Validate(ICustomer cust)
        {
            return true;
        }
    }
    public class AuditCustomer
    {
        public void Save(Customer obj)
        {

        }
    }
    public abstract class BaseCustomer : ICustomer
    {
       
        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                if (value.Length==0)
                {
                    return;
                }
                _name = value; 
            }
        }

        public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual decimal Amount { get; set; }
        public decimal Rating { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private List<IAddress> Addresses { get; set; }

        public BaseCustomer()
        {
            this.Addresses = new List<IAddress>();
        }
        public IEnumerable<IAddress> GetAddresses()
        {
            return this.Addresses.ToList<IAddress>();
        }
        public void Add(IAddress add)
        {
            foreach (var item in this.Addresses)
            {
                if (add.GetType() == typeof(HomeAddress))
                {
                    throw new Exception("Not allowed");
                }
            }
            this.Addresses.Add(add);

        }
    }
    
    public class Customer : BaseCustomer , ICustomer
    {
       
    }
    public class CustomerVIP : BaseCustomer, ICustomer
    {

    }
    public class Enquiry : IEnquiry
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    public class DiscountAge : IDiscount
    {
        public decimal Calculate(ICustomer cust)
        {
            throw new NotImplementedException();
        }
    }
    public class DiscountRegion : IDiscount
    {
        public decimal Calculate(ICustomer cust)
        {
            
            throw new NotImplementedException();
        }
    }
    public class Addresses
    {

    }
    public class DisCountByAmount : IDiscount
    {
        public decimal Calculate(ICustomer cust)
        {
            throw new NotImplementedException();
        }
    }
    public class HomeAddress : IAddress
    {
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    public class OfficeAddress : IAddress
    {
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class CustomerMoney
    {
        public string TypePayment { get; set; }
        public decimal Amount { get; set; }
        public static bool operator ==(CustomerMoney money1, CustomerMoney money2)
        {
            if (money1.Amount == money2.Amount)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(CustomerMoney money1, CustomerMoney money2)
        {
            if (money1.Amount != money2.Amount)
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            CustomerMoney m = (CustomerMoney)obj;
            if (m.Amount == this.Amount)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Amount.GetHashCode() + 10;
        }
    }
    public class CustomerRating
    {
        public int Rating { get; set; }
    }
}
