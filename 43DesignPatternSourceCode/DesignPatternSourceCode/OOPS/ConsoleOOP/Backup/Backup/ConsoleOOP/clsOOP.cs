using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP
{
    public  abstract class clsDisplay
    {
        public virtual void print() { }
    }
    public class clsItalicDisplay : clsDisplay
    {
        public override void print()
        {
            Console.WriteLine("This displays in ITALIC");
        }
    }
    public class clsBoldDisplay : clsDisplay
    {
        public override void print()
        {
            Console.WriteLine("This displays in bold");
        }
    }
}
