using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternArchitecturePattern
{
   public abstract class EventBase : IEvent
    {
        public Guid guid { get; set; }
        public EventBase()
        {
            this.guid = new Guid();
        }

        

    }
    public class CustomerCreated : EventBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CustomerCancelled : EventBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
