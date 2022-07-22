using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase IObjdatabase;
            
            IObjdatabase = new clsCustomer();
            IObjdatabase.Update();

            IObjdatabase = new clsSupplier();
            IObjdatabase.Update();

        }
    }
}
