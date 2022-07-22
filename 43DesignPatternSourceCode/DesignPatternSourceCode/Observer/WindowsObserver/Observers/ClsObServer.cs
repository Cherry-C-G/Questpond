using System;
using System.Collections.Generic;
using System.Text;

namespace Observers
{
    public interface INotification
    {
         void Notify();
    }
    public class clsEmailNotification : INotification
    {
        public void Notify()
        {
            System.Console.WriteLine("Email notification code executed");
        }
    }
    public class clsEventNotifcation : INotification
    {
        public void Notify()
        {
            System.Console.WriteLine("Event log notification code executed");
        }
    }
    public class clsSMSNotification : INotification
    {
        public void Notify()
        {
            System.Console.WriteLine("SMS notification code executed");
        }
    }
}
