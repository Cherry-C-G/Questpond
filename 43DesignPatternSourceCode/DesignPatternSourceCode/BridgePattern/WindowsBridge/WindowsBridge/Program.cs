using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsBridge
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            clsBulb objBulb = new clsBulb();
            clsRefrigerator objRefrig = new clsRefrigerator();
            Clsswitch objSwitch = new Clsswitch();

            objSwitch.setEquipMent(objBulb);
            objSwitch.On();
            objSwitch.Off();
            
            Console.WriteLine("-----");

            objSwitch.setEquipMent(objRefrig);
            objSwitch.On();
            objSwitch.Off();
            Console.ReadLine();
        }
    }
}