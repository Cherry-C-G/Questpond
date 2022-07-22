using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorNameSpace
{
    public interface ICustomer
    {
         string Name { get; set; }
         string Phone { get; set; }
         decimal BillAmount { get; set; }
       
    }
    public interface IValidate
    {
        
        void Validate(ICustomer obj);
    }
    public  class Customer : ICustomer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public decimal BillAmount { get; set; }
        public Customer()
        {
            this.Name = "";
            this.Phone = "";
            this.BillAmount = 0;
        }
        
    }
    public class ValidationLinker : IValidate
    {
        IValidate _next = null;
        public ValidationLinker(IValidate v)
        {
            _next = v;
        }
        public virtual void Validate(ICustomer obj)
        {
            _next.Validate(obj);
        }
    }
    public class BasicValidation : IValidate
    {
        public void Validate(ICustomer obj)
        {
            if (obj.Name.Length == 0)
            {
                throw new Exception("Name is required");
            }
        }
    }

    public class PhoneCheckValidation : ValidationLinker
    {
        public PhoneCheckValidation(IValidate v) : base(v)
        {

        }
        public override void Validate(ICustomer obj)
        {
            base.Validate(obj); // First call the base validation
            if (obj.Phone.Length == 0) // run your validation
            {
                throw new Exception("Phone number is comp");
            }
            
        }
    }

    public class BillAmountCheckValidation : ValidationLinker
    {
        public BillAmountCheckValidation(IValidate v) : base(v)
        {

        }
        public override void Validate(ICustomer obj)
        {
            base.Validate(obj); // First call the base validation
            if (obj.BillAmount == 0) // run your validation
            {
                throw new Exception("Bill Amount needed");
            }

        }
    }
    // V1 : Name check
    // // Name + Phone
    // Name + Phone + BillAmount
    // Name + BillAmount


}
