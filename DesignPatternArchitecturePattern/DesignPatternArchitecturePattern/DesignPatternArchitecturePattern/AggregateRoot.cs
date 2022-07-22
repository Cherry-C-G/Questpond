using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternArchitecturePattern
{
    public class CustomerRoot
    {
        private List<Address> Addrsses { get; set; }

        public IEnumerator<Address> GetAddresses()
        {
            return Addrsses.ToList<Address>().GetEnumerator();
        }

        public void Add(Address a)
        {
            if (Addrsses.Count == 2)
            {
                return;
            }
            Addrsses.Add(a);
        }
    }
    public class Address
    {

    }
    public class AggregateCustomer
    {
        private AuditCustomer Audit { get; set; }

        private Customer Customer { get; set; }
        public Customer GetCustomer()
        {
            return Customer;
        }
        public AuditCustomer GetAudit()
        {
            return Audit;
        }
        public AggregateCustomer(string name,decimal amount)
        {
            Customer = new Customer(); // model
            Customer.Name = name; //maps
            Customer.Amount = amount; // projections
            
            Audit = new AuditCustomer();

        }
    }
}
