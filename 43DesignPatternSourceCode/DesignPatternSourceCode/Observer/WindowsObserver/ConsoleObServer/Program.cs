using System;
using System.Collections.Generic;
using System.Text;
using Observers;

namespace ConsoleObServer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // This application takes customer code and if
            // the customer code length is above 20 it notifies
            // the error to all the subscribers
            string strCustomerCode = "";
            
            // Notifier/Subject to notify all the observers
            clsNotifier objNotifier = new clsNotifier();
            
            // Add subjects/subscribers which needs to be notified
            clsEmailNotification objEmailNotification = new clsEmailNotification();
            clsEventNotifcation objEventNotification = new clsEventNotifcation();
            objNotifier.addNotification(objEmailNotification);
            objNotifier.addNotification(objEventNotification);

            // create a error by entering length more than 10 characters
            Console.WriteLine("Enter Customer Code");
            strCustomerCode = Console.ReadLine();
            
            // if the length is more than 10 characters notify all subjects/subscribers
            if (strCustomerCode.Length > 10)
            {
                objNotifier.NotifyAll();    
            }
            
            Console.ReadLine();
        }
    }
}
