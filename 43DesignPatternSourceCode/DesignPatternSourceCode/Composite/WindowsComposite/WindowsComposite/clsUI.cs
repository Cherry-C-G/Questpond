using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsComposite
{
    interface IUserInterface
    {
        void Draw();
    }
    class clsCircle : IUserInterface
    {
        public void Draw()
        {
            Console.WriteLine("Draw Circle");
        }
    }
    class clsLine : IUserInterface
    {
        public void Draw()
        {
            Console.WriteLine("Draw Circle");
        }
    }
    class clsSquare : IUserInterface
    {
        public void Draw()
        {
            Console.WriteLine("Square is drawn");
        }
    }
    class clsRectangle : IUserInterface
    {
        public void Draw()
        {
            Console.WriteLine("Draw a rectangle");
        }
    }
}
