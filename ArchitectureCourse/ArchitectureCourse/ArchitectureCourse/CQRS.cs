using ArchitectureCourse;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using Ninject;

namespace CQRSArchitecture
{

    public interface IQuery<TResult>
    {

    }
    public class CustomerQuery1 : IQuery<CustomerResult1>
    {
        public int customerId { get; set; }
    }
   
    public class CustomerResult
    {
        public string Name { get; set; }
    }
    public class CustomerResult1 : CustomerResult
    {
        public string Address { get; set; }
    }
    public interface IQueryDisptacher
    {
        TResult Dispatch<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>;
    }
    public class QueryDisptacher : IQueryDisptacher
    {
        public TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = Program.kernel.Get<IQueryHandler<TQuery, TResult>>();
             return handler.Handle(query);
        }
    }
    public interface IQueryHandler<TQuery, TResult> 
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query); 
    }
    public class CustomerQueryHandler1 : IQueryHandler<CustomerQuery1, CustomerResult1>
    {
        public CustomerResult1 Handle(CustomerQuery1 query)
        {
            return new CustomerResult1();
        }
    }

    //public class CustomerQueryHandler2 : IQueryHandler<Custom, CustomerResult1>
    //{
    //    public CustomerResult1 Handle(CustomerQuery1 query)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //#region event
    public interface IEvent
    {
    }
    public interface IEventHandler
    {
    }
    public interface IEventHandler<TEvent> : IEventHandler
        where TEvent : IEvent
    {
        void Handle(TEvent tevent);
    }
    public interface IEventsBus
    {
        void Publish<T>(Guid guid, T @event) where T : IEvent;
        List<IEvent> GetEvents(Guid aggregateId);
    }
    public class CustomerCreated : IEvent
    {
        public string Name { get; }

    }
    public class CustomerCreatedCreatedEventHandler : IEventHandler<CustomerCreated>
    {

        public void Handle(CustomerCreated command)
        {
            System.Console.WriteLine($"User was created {command.Name} - event");
        }
    }


    public class EventsBus : IEventsBus
    {
        IEventStore eventsrc = new EventStore();
        public void Publish<T>(Guid g, T @event) where T : IEvent
        {
            var handler = Program.kernel.Get<IEventHandler<T>>();
            handler.Handle(@event);
            this.eventsrc.SaveEvents(g, @event);
        }
        public List<IEvent> GetEvents(Guid aggregateId)
        {
            return eventsrc.GetEvents(aggregateId);
        }
    }

    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEvent e);
        List<IEvent> GetEvents(Guid aggregateId);
    }
    public class EventStore : IEventStore
    {
        private readonly Dictionary<Guid, List<IEvent>> _eventstore = new Dictionary<Guid, List<IEvent>>();

        public List<IEvent> GetEvents(Guid aggregateId)
        {
            return _eventstore[aggregateId];
        }

        public void SaveEvents(Guid aggregateId, IEvent e)
        {
            List<IEvent> events = null;
            if (!_eventstore.ContainsKey(aggregateId))
            {
                events = new List<IEvent>();
                _eventstore.Add(aggregateId, events);
            }
            else
            {
                events = _eventstore[aggregateId];
            }
            events.Add(e);
        }
    }


    //#region query
    //public interface IQuery<TResult>
    //{
    //}
    //public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    //{
    //    TResult Handle(TQuery query);
    //}

    //public interface IQueryDispatcher
    //{
    //    TResult Handle<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    //}

    //public class QueryDisptacher : IQueryDispatcher
    //{
    //    public TResult Handle<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
    //    {
    //        var handler = Program.kernel.Get<IQueryHandler<TQuery, TResult>>();
    //        return handler.Handle(query);
    //    }
    //}
    //public class QueryHandler : IQueryHandler<MyQuery, MyResult>
    //{
    //    public MyResult Handle(MyQuery query)
    //    {
    //        return new MyResult();
    //    }
    //}

    //public class MyQuery : IQuery<MyResult>
    //{

    //}
    //public class MyResult
    //{

    //}
    //#endregion query
    #region command 
    // intial thought
    public interface ICommand
    {

    }
    public class CustomerCreate : Customer, ICommand
    {

        public bool isActive { get; set; }
        public string updatedby { get; set; }
    }
    public interface IDispatcher
    {
        void Send<T>(T Command) where T : ICommand ;
    }
    public interface ICommandHandler<T>
        where T : ICommand
    {
        void Handle(T command);
    }

    public class CommandDispatcher : IDispatcher  
    {
        public Guid guid { get; set; }
        public CommandDispatcher()
        {
            this.guid = Guid.NewGuid();
        }
        private readonly IEventsBus _eventPublisher = new EventsBus();
        public void Send<T>(T Command) where T : ICommand
        {
            var handler = Program.kernel.Get<ICommandHandler<T>>();
            handler.Handle(Command);
            _eventPublisher.Publish(this.guid, new CustomerCreated());
           
        }
        public List<IEvent> GetEvents()
        {
            return _eventPublisher.GetEvents(this.guid);
        }
    }

    // customer
    public class Customer // Entity
    {
        public string name { get; set; }
        public string address { get; set; }
    }

    

    public class CustomerCreateHandler : ICommandHandler<CustomerCreate>
    {
        public void Handle(CustomerCreate command)
        {
            Console.WriteLine("insert of ADO or EF");
            Console.WriteLine(command.name + " == " + command.address);
        }
    }

    public class CustomerEdit :  ICommand
    {
        public string address { get; set; }
        public bool isActive { get; set; }
        public string updatedby { get; set; }
    }
    #endregion command 

}
