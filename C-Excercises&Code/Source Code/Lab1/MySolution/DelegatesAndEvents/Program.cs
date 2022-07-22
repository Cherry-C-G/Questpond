using System;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class Program
    {
        static void IamListener(int i)
        {
            Console.WriteLine(i);
        }
        static void Main(string[] args)
        {
            MyClass x = new MyClass();
            x.streamObj = IamListener;
            Task t = new Task(x.Task);
            t.Start();
            Console.ReadLine();
        }
      
    }
    class MyClass
    {
        public delegate void Stream(int i); // declaration of the delegate
        public Stream streamObj; // create a instance
        public void Task()
        {
            for (int i = 0; i < 100000; i++)
            {
                Thread.Sleep(1000);
                streamObj(i);
            }
        }
    }
}
