using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsCOR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            clsProcess1 objProcess1 = new clsProcess1();
            clsProcess2 objProcess2 = new clsProcess2();
            clsProcess3 objProcess3 = new clsProcess3();

            objProcess1.setProcess(objProcess2);

            objProcess2.setProcess(objProcess3);

            objProcess1.runProcess();
            Console.ReadLine();
        }
    }
}