using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqSample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> custs = new List<Customer>();

            custs.Add(new Customer() { name = "Shiv", address = "India" });
            custs.Add(new Customer() { name = "Raju", address = "Nepal" });
            custs.Add(new Customer() { name = "Shaam", address = "India" });
            custs.Add(new Customer() { name = "Khadak", address = "India" });
            custs.Add(new Customer() { name = "Guru", address = "India" });

            var custfiltered = (from temp in custs
                                where temp.address == "India"
                                select temp).ToList<Customer>();
            foreach (var item in custfiltered)
            {
                Console.WriteLine(item.name);
            }

            Console.ReadLine();
        }
    }
    public class Customer
    {
        public string name = "";
        public string address = "";
    }

}
