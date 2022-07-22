using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 0;
            Console.WriteLine("Enter num1");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter num2");
            num2 = Convert.ToInt32(Console.ReadLine());
            try
            {
                int output = num1 / num2;
                Console.WriteLine(output);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error has happened please contact support");
            }
            

        }
    }
}
