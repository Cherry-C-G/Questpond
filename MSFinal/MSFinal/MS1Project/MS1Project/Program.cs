using AutoMapper;
using EasyNetQ;
using EasyNetQ.Topology;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MS1Project
{
    class Program
    {
        static public IKernel kernel = new StandardKernel(); // ninject
        static public MapperConfiguration mappconfig = null;

        static void Main(string[] args)
        {
            mappconfig = new MapperConfiguration
                        (c => c.CreateMap<Customer, CreateCustomerCommand>());
            mappconfig = new MapperConfiguration
                       (c => c.CreateMap<CreateCustomerCommand, CustomerCreatedEvent>());
            kernel.Load(Assembly.GetExecutingAssembly()); // lookups
            IDispatcher disptacher = new CustomerDisptacher();

            CreateCustomerCommand newcustomer = new CreateCustomerCommand();
            newcustomer.name = "Shiv";
            disptacher.Send<CreateCustomerCommand>(newcustomer);

            CreateCustomerCommand newcustomer1 = new CreateCustomerCommand();
            newcustomer1.name = "Shiva";
            disptacher.Send<CreateCustomerCommand>(newcustomer1);
            

        }
    }

    public class Binding : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(ICommandHandler<CreateCustomerCommand>)).
               To(typeof(CreateCustomerHandler));
            Bind(typeof(IEventHandler<CustomerCreatedEvent>)).
            To(typeof(CustomerCreatedEventHandler));

          
        }
    }
   public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        // public List<Address>

    }
    public class CreateCustomerCommand : Customer, ICommand
    {
        public DateTime createdDate { get; set; }
    }
    public interface ICommand
    {
        // insert update and delete
    }
    public interface IQuery
    {

    }
    public interface IDispatcher
    {
        void Send<T>(T Command) where T : ICommand;
    }
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T Command);
    }
    
    public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
    {
        public void Handle(CreateCustomerCommand Command)
        {
            IRepository<Customer> repo = new EfCustomerContext();
            var mapper = new Mapper(Program.mappconfig);
            Customer x = mapper.Map<Customer>(Command);
            repo.Add(x);
            Console.WriteLine(Command.name + " inserted in to DB using EF");
            
        }
    }
    public class CustomerDisptacher : IDispatcher
    {
        public IEventsBus _eventPublisher { get; set; }

        public void Send<T>(T Command) where T : ICommand
        {
            var handler = Program.kernel.
                    Get<ICommandHandler<T>>();
            handler.Handle(Command); // calls the repository
            _eventPublisher = new EventsBus();
            Guid g = new Guid();
            string guid = g.ToString();
            var mapper = new Mapper(Program.mappconfig);
            var x1 = mapper.Map<CustomerCreatedEvent>(Command);
            _eventPublisher.Publish(g, x1); // published to external micros
        }
    }

    public interface IEvent
    {
        public string Guid { get; set; }
    }
    public class CustomerCreatedEvent : Customer, IEvent 
    {
        public string Guid { get; set; }
      
    }
    public interface IEventHandler
    {
    }
    public interface IEventHandler<TEvent> : IEventHandler
        where TEvent : IEvent
    {
        void Handle(TEvent tevent);
    }
    public class CustomerCreatedEventHandler : IEventHandler<CustomerCreatedEvent>
    {

        public void Handle(CustomerCreatedEvent event1)
        {
            var bus = RabbitHutch.CreateBus("host=localhost");
            bus.PubSub.Publish<CustomerCreatedEvent>(event1);
            System.Console.WriteLine($"User was created {event1.Guid} - event");
        }
    }
    public interface IEventsBus
    {
        void Publish<T>(Guid guid, T @event) where T : IEvent;
        List<IEvent> GetEvents(Guid guid);
        List<IEvent> GetEvents();

    }
    public class EventsBus : IEventsBus
    {
        IEventStore eventsrc = new EventStore();
        public void Publish<T>(Guid g, T @event) where T : IEvent
        {
            var handler = Program.kernel.Get<IEventHandler<T>>();
            handler.Handle(@event); // publish to extern Rabbit MQ
            this.eventsrc.SaveEvents(g, @event); // internally store
        }
        public List<IEvent> GetEvents(Guid aggregateId)
        {
            return eventsrc.GetEvents(aggregateId);
        }

        public List<IEvent> GetEvents()
        {
            return eventsrc.GetEvents();
        }
    }
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEvent e);
        List<IEvent> GetEvents(Guid aggregateId);
        List<IEvent> GetEvents();
    }
    public class EventStore : IEventStore
    {
        private readonly Dictionary<Guid, List<IEvent>> _eventstore = new Dictionary<Guid, List<IEvent>>();

        public List<IEvent> GetEvents(Guid aggregateId)
        {
            return _eventstore[aggregateId];
        }

        public List<IEvent> GetEvents()
        {
            return _eventstore.SelectMany(d => d.Value).ToList();

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
    public class UpdateCustomer : Customer
    {
        public string UpdateBy { get; set; }
    }
    #region Repository
    
    interface IRepository<T>
    {
        bool Add(T obj);
        bool Update(T obj);
        List<T> Query(int it);
        List<T> Query(string name);

    }

    public abstract class EfCommon<T> : DbContext, IRepository<T>
        where T : class
    {
        public bool Add(T obj)
        {
            Set<T>().Add(obj);
            return true;
        }

        public List<T> Query(int it)
        {
            throw new NotImplementedException();
        }

        public List<T> Query(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(T obj)
        {
            throw new NotImplementedException();
        }
    }


    public class EfCustomerContext : EfCommon<Customer>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("tblCustomer");

        }
    }

    #endregion Repository
    class Product
    {

    }
    class MyDate
    {
        public string month { get; set; }
        public string year { get; set; }
        public override bool Equals(object obj)
        {
           if(this.month == ((MyDate)obj).month)
            {
                return true;
            }
            return false;
        }
    }
    class Repository
    {

    }
    class Logger { }
}
