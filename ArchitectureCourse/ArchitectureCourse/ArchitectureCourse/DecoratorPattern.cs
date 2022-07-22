using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    public interface ICustomer
    {
        string CustomerName { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        void Validate();
    }
    public class CustomerBasic : ICustomer
    {
        // changgin this base class...
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public CustomerBasic()
        {
            CustomerName = "";
            PhoneNumber = "";
            Address = "";
        }
        public void Validate()
        {
            if (CustomerName.Length == 0)
            {
                throw new Exception("Name is needed");
            }
        }
    }

    // step 1 wrapper 
    public abstract class WrapperCustomer : ICustomer
    {
        protected ICustomer _customerNext = null;
        public WrapperCustomer(ICustomer _cust)
        {
            _customerNext = _cust;
        }
        // step 2 all calls are passed to the next custoer
        public string CustomerName
        {
            get { return _customerNext.CustomerName; }
            set { _customerNext.CustomerName = value; }
        }
        public string PhoneNumber
        {
            get { return _customerNext.PhoneNumber; }
            set { _customerNext.PhoneNumber = value; }
        }
        public string Address
        {
            get { return _customerNext.Address; }
            set { _customerNext.Address = value; }
        }

        public virtual void Validate()
        {
            this._customerNext.Validate();
        }
    }

    public class CustomerPhoneNumberLogic : WrapperCustomer
    {
        public CustomerPhoneNumberLogic(ICustomer cust) 
            : base(cust)
        {

        }
        public override void Validate()
        {
            _customerNext.Validate(); // base validation
            if (_customerNext.PhoneNumber.Length == 0)
            {
                throw new Exception("Phoner number is required");
            }
            
        }
    }

    public class CustomerAddressCheck : WrapperCustomer
    {
        public CustomerAddressCheck(ICustomer cust)
            : base(cust)
        {

        }
        public override void Validate()
        {
            _customerNext.Validate(); // base validation
            if (_customerNext.Address.Length == 0)
            {
                throw new Exception("Address is required");
            }

        }
    }
}

//ICustomer cust = new CustomerBasic();
//cust.Validate();

//            cust.CustomerName = "sss";
//            cust = new CustomerPhoneNumberLogic(
//                    new CustomerBasic());
//            cust.Validate();
//            cust = new CustomerAddressCheck(
//                new CustomerBasic());
//            cust.Validate();
//            cust = new CustomerAddressCheck(
//                    new CustomerPhoneNumberLogic(
//                        new CustomerBasic()));
//            cust.Validate();
