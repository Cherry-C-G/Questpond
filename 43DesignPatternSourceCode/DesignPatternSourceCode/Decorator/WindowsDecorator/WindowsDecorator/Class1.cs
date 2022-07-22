using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsDecorator
{
    class Class1
    {
        public void someFunction()
        {
            Console.WriteLine("Some function");
        }
    }
    class Class2 : Class1
    {
        public void someMoreFunction()
        {
            Console.WriteLine("Some more function");
        }
    }
}
