using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            clsDisplay objDisplay;
            objDisplay = new clsBoldDisplay();
            objDisplay.print();
            objDisplay = new clsItalicDisplay();
            objDisplay.print();
            Console.Read();
        }
    }
}
