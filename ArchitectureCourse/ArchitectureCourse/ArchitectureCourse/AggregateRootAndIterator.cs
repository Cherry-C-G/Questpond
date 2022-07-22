using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace AggregateRootIterator
{
    // aggregate root
    public class Customer
    {
        public Customer()
        {
            this._Addresses = new List<Address>();
        }
        public Address CreateAddress()
        {
            Address x = new Address(this);
            return x;
        }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        private List<Address> _Addresses { get; set; }
        // on the root level
        public void Add(Address temp)
        {
            // 100 lines code
            if (this._Addresses.Count > 2)
            {
                throw new Exception("Not allowed");
            }
            this._Addresses.Add(temp);
        }
        public  IEnumerable<Address> getAddresses()
        {
            // by ref
            return  this._Addresses; // clone
        }
    }
    public class Address
    {
        private Customer _customer = null;
        public Address(Customer obj)
        {
            _customer = obj;
        }
        public string AddressName { get; set; }
    }
    public class Supplier
    {
        public List<Address> Address { get; set; }
    }
    public class CustomerDTO
    {
        // inner join
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string AddressName { get; set; }
    }
}
