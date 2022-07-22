using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
namespace WindowsComposite
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ArrayList objArrayList = new ArrayList();

            clsCircle objCircle = new clsCircle();
            clsLine objLine = new clsLine();
            clsRectangle objRect = new clsRectangle();
            clsSquare objSquare = new clsSquare();

            objArrayList.Add(objCircle);
            objArrayList.Add(objLine);
            objArrayList.Add(objRect);
            objArrayList.Add(objSquare);

            foreach (IUserInterface Iobj in objArrayList)
            {
                Iobj.Draw();
            }

            Console.ReadLine();

        }
    }
}