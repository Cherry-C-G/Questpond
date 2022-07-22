using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading;

namespace GarbageCollector
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Console.WriteLine("Started blasting");
            for (double i = 0; i < 1000000; i++)
            {
                string x = DateTime.Now.ToString(); // heap
            }
            Console.Read();
        }
    }
    public class customer
    {
        public string name = "";
    }
    
}
