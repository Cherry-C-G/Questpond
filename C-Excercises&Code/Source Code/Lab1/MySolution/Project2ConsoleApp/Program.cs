using System;
using SomeCommonLogic;
namespace Project2ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 x = new Class1();
            Console.WriteLine("Hello World 2! " 
                + x.getCurrentDateandTime());
            Console.Read();
        }
    }
}
