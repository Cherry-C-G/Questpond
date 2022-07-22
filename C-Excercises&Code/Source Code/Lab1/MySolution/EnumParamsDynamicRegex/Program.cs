using System;

namespace EnumsAndConstants
{
    enum CustomErrors
    {
        FileNotFound = 1001,
        SocketError = 1002,
        Unknown = 1003

    }
    class Program
    {
        public  const  double PI = 3.14;
        
        static void Main(string[] args)
        {

            //double d = Convert.ToDouble(Console.ReadLine());
            //if (d == PI)
            //{
            //    Console.WriteLine("this is value of pie");
            //}

            CustomErrors errorvalue = (CustomErrors) 1001;
            if (errorvalue == CustomErrors.FileNotFound)
            {
                // file not found
            }
            else if (errorvalue == CustomErrors.SocketError)
            {
                // socket exception
            }
            else if (errorvalue == CustomErrors.Unknown)
            {
                // unknown exception
            }

        }
    }
}
