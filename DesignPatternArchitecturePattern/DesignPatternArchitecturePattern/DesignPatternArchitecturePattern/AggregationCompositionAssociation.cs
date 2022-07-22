using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternArchitecturePattern
{
    // Shiv has shirt -- Aggregation
    // Shiv has heart -- Composition
    
    public class Company
    {
        public List<Employee> Employees { get; set; }
        public Address add { get; set; }
        public decimal StockValue { get; set; }
        public Company(StockTicker s)
        {
            this.StockValue = s.GetValue("sss");
        }
    }
   public class StockTicker
    {
        public decimal GetValue(string sname)
        {
            return 0;
        }
    }
    public class Employee
    {
        private Company c;
        public List<Address> Addresses { get; set; }
        public Employee(Company _c)
        {
            c = _c;
        }
    }
    public class Address
    {

    }
}
