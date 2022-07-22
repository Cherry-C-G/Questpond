using System;
using System.Collections;
using System.Collections.Generic;
namespace Collections
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // arrays are strong typed , array list any type
            // arrays are fixed , arraylist has no fixed size
            // arrays are btter in terms of performance 
            //, arraylist performance can degarde
            int[] arrint = new int[5];
            arrint[0] = 1; // Zero indexed 
            arrint[1] = 2;
            string[] arrstring = new string[5];
            arrstring[0] = "Shiv";

            ArrayList arraylist = new ArrayList();
            arraylist.Add(1);
            arraylist.Add("Shiv");

            List<int> lst1 = new List<int>(); // define the data type during declaration
            lst1.Add(1);

            List<string> lststring = new List<string>();
            lststring.Add("test");

            foreach(int temp in arrint)
            {
                Console.WriteLine(temp);
            }

            for (int i = 0; i <= arrint.Length; i++)
            {
                if (i > 10)
                {
                    Console.WriteLine(i);
                }
                else
                {

                }

            }

            for (int i = 0; i < arrint.Length; i++)
            {

            }
            foreach (int temp in arrint)
            {

            }
            
            Console.WriteLine("Hello World!");
        }
    }
}
