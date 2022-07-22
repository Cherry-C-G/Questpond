using System;

namespace MyProjectConsoleApp1
{
    // Data types , Casting and Converstion
    class Program
    {
        
        int counter = 0; // different variable
        //int Counter = 0; // different variable
        static void Main(string[] args)
        {
            
            int i = 10000; //  numeric value with out decimal
            object g = i;
            double d = 100.23; // decimal
            g = d;
            string str = "198"; // any kind text, numeric
            bool b = true; // true and false
            // casting
            //d = i; // implicit casting
            i = Convert.ToInt32(str);
            //i = (int)d;// explicit casting
            Console.WriteLine("Value of i (explicit casting) " + i);
            Console.Read();
        }
        
    }
}
