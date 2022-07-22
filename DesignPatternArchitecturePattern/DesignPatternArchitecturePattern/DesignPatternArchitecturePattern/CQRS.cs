using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternArchitecturePattern
{
    // starte of  Bulilding block
    public interface ICommand
    {
         Guid guid { get; set; }
    }
    public interface ICommandHandler<T> where T : ICommand
    {
        bool Execute(T Command);
    }
    public interface IEvent
    {
        Guid guid { get; set; }
    }
    public interface IQuery
    {

    }
    public class ReportCustomerQuery : IQuery
    {

    }
    // end of  Bulilding block

    // starte of  concrete class
    public abstract class BaseCommand : ICommand
    {
        public Guid guid { get; set; }
        public BaseCommand()
        {
            guid = new Guid();
        }
    }
    public  class CreateCustomerCommand : BaseCommand
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool ButtonClick { get; set; }
    }
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        IRepository<Customer> CustRep = new RepositoryCustomer();
        IRepository<AuditCustomer> AuditRep = null;
        EventSource eventSource = new EventSource();
        public bool Execute(CreateCustomerCommand Command)
        {
            
            // Mapping the commands to the model
            var Aggregate = new AggregateCustomer(Command.Name, 100);

            // Begin trans
            // Uow.Set(CustRep)
            // Uow.Set(AuditRep)
            // Uow.Being()
            CustRep.Save(Aggregate.GetCustomer()); // local
            AuditRep.Save(Aggregate.GetAudit());
            eventSource.Events.Add(new CustomerCreated() { Name = Command.Name }); // event
            // Projections.
           // eventSource.Events.Add(new CreateDebit() { Name = Command.Name } , "A");

            // Uow.CommitTrans()
            // Commit trans
            return true;
        }
    }
    public class DeleteCustomerCommand : BaseCommand
    {
        public int Id { get; set; }
    }
    // end  of  concrete class
}
