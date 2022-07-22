using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterfaces
{
    public interface IDatabase
    {
         void Update();
    }
    public class clsCustomer : IDatabase
    {
        public void Update()
        {
            // Update code goes over here
        }
    }
    public class clsSupplier : IDatabase
    {
        public void Update()
        {
            // Update code goes over here
        }
    }
}
