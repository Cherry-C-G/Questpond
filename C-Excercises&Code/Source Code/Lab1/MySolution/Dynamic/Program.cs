using System;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic cust = new Customer();
            
            cust.name = "Shiv"; // this execute fine
            cust.Add(); // throw a new exception
            Console.WriteLine("Hello World!");
        }
    }
    class Customer
    {
        public string name = "";
    }
}
