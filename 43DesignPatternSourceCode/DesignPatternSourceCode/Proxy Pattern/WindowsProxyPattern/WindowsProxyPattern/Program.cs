using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsProxyPattern
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IImageProxy iobjImageProxy = new clsActualImage();

            iobjImageProxy.loadImage();
            
            iobjImageProxy.printImage();
            
            Console.ReadLine();
        }
    }
}