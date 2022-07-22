using System;
using MathsNs;
namespace ClassObjectsandNameSpaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Maths x = new Maths(); // New and create a instance(object(
            int addres = x.Add(10, 10);
            Console.WriteLine(addres);
            
            Maths x1 = new Maths(); // New and create a instance(object(
            int subres = x.Sub(10, 10);
            Console.WriteLine(subres);

            Console.WriteLine("Hello World!");
        }
    }

  

    class Biology // Template ==> Object by using new keyword
    {
        public string About = "This is made by Questpond";
        void WhatIsthis()
        {
            Console.WriteLine("This is a simple calculator which does Add and Sub");
        }
        public int Add(int num1, int num2)
        {
            //
            return num1 + num2;
        }
        public int Sub(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}

namespace MathsNs
{
    class Maths // Template ==> Object by using new keyword
    {
        public string About = "This is made by Questpond";
        void WhatIsthis()
        {
            Console.WriteLine("This is a simple calculator which does Add and Sub");
        }
        public int Add(int num1, int num2)
        {
            
            return num1 + num2;
        }
        public int Sub(int num1, int num2)
        {
            return num1 - num2;
        }
    }
    class AdvMaths // Template ==> Object by using new keyword
    {
        public string About = "This is made by Questpond";
        void WhatIsthis()
        {
            Console.WriteLine("This is a simple calculator which does Add and Sub");
        }
        public int Add(int num1, int num2)
        {
            //
            return num1 + num2;
        }
        public int Sub(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
