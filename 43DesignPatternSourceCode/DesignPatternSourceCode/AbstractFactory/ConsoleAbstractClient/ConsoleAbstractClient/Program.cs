using System;
using System.Collections.Generic;
using System.Text;
using InterfaceUI;
using FactoryProject;
namespace ConsoleAbstractClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int intObjectType;

            InterfaceRender ObjUiObject;

            Console.WriteLine("Enter which object you want to render?");

            intObjectType = Convert.ToInt16(Console.ReadLine());

            ObjUiObject = clsAbstractFactory.getUIObject(intObjectType);
            
            ObjUiObject.render();
            
            Console.ReadLine();
        }
    }
}
