using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Observers
{
    public class clsNotifier
    {
        private ArrayList objNotifications = new ArrayList();
        
        public void addNotification(INotification obj)
        {
            objNotifications.Add(obj);
        }
        public void removeNotification(INotification obj)
        {
            objNotifications.Remove(obj);
        }
        public void NotifyAll()
        {
            foreach (INotification objNotification in objNotifications)
            {
                objNotification.Notify();
            }
        }
    }
}
