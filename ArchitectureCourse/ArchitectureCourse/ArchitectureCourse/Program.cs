using System;
using System.Collections.Generic;
using System.Reflection;
using CQRSArchitecture;
using Ninject;
using Ninject.Modules;

namespace ArchitectureCourse
{
    class Program
    {
        static public IKernel kernel = new StandardKernel(); // ninject
        static void Main(string[] args)
        {
            kernel.Load(Assembly.GetExecutingAssembly()); // lookups

            //CustomerQuery1 x = new CustomerQuery1();
            //x.customerId = 1009;
            //var qd = new QueryDisptacher();
            //var res =  qd.Dispatch<CustomerQuery1, CustomerResult1>(x);

            CustomerCreate insertcustomer = new CustomerCreate();// factory
            insertcustomer.name = "shiv";

            var dispatcher = new CommandDispatcher();
            dispatcher.Send(insertcustomer);

            insertcustomer = new CustomerCreate();// factory
            insertcustomer.name = "shiv1";

            
            dispatcher.Send(insertcustomer);

            var events = dispatcher.GetEvents();

        }
    }
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            // command
            Bind(typeof(ICommandHandler<CustomerCreate>)).
                To(typeof(CustomerCreateHandler));

            // query
            Bind(typeof(IQueryHandler<CustomerQuery1,CustomerResult1>)).
                To(typeof(CustomerQueryHandler1));

            // events
            Bind(typeof(IEventHandler<CustomerCreated>)).
                To(typeof(CustomerCreatedCreatedEventHandler));

        }
    }
}
