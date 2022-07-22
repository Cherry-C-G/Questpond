using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        static  void Main(string[] args)
        {

            //Thread t1 = new Thread(new ThreadStart(Fun1));
            //Task t1 = new Task(Fun1); // do not have thread affinity
            //Thread t2 = new Thread(new ThreadStart(Fun2));
            //Task t2 = new Task(Fun2);
            //t1.Start(); // Start executing Fun1 parallely
            //t2.Start(); // Starts executing fun2 parallely
            Fun1();
            Fun2();
            Console.WriteLine("Hello World!"); // executing main paralley
            Console.ReadLine();
        }
        int num1 = 10;
        int num2 = 10;
         async void Divide()
        {
           
            int div = num1 / num2; // thread 2
            num2 = 0; // thread 1
        }
            static async void Fun1()
        {
            for (int i = 0; i < 100000; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine("Fun 1 :-  " + i);
            }
        }
        static async void Fun2()
        {
            for (int i = 0; i < 100000; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine("Fun 2 :-  " + i);
            }
        }
    }
}
