using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsProxyPattern
{
    interface IImageProxy
    {
        void loadImage();
        void printImage();
    }

    class clsActualImage : IImageProxy
    {
        string strImage = "c:\\shiv.jpg";
        public void loadImage()
        {
            Console.WriteLine("Load image... " + strImage );
        }
        public void printImage()
        {
            Console.WriteLine("Printing image... " + strImage);
        }
    }
}
