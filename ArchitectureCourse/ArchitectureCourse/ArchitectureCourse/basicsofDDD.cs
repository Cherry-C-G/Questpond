using System;
using System.Collections.Generic;
using System.Text;


namespace BasicofDDD
{
    class Customer
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public List<Address> Addresses { get; set; }
    }
    class Address
    {

    }
    class Lead : Customer
    {

    }
}
