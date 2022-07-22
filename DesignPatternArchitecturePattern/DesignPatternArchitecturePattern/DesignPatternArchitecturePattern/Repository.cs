using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternArchitecturePattern
{
    public interface IRepository<T>
    {
        bool Add(T obj); // in memory
        bool Save(T obj); // physical commit
        IEnumerable<T> Search(int id);
    }
    public abstract class RepositoryBase<Anytype> : IRepository<Anytype>
    {
        List<Anytype> recs = new List<Anytype>();
        public bool Add(Anytype obj)
        {
            recs.Add(obj);
            return true;
        }

        public abstract bool Save(Anytype obj);

        public abstract IEnumerable<Anytype> Search(int id);
    }

    public class RepositoryCustomer : RepositoryBase<Customer>
    {
        public override bool Save(Customer obj)
        {
            // command.ExecuteNonQuery..
            // code of EF core to save to DB
            return true;
        }

        public override IEnumerable<Customer> Search(int id)
        {
            // LIst
            // Dictonary
            // ArrayList
            return null;
        }
    }

    public static class FactoryRepository<T>
    {
        
        
        public static IRepository<T> Create(int id)
        {
             
            if (id == 1)
            {
                return (IRepository<T>) new RepositoryCustomer();
            }
            return null;
        }
    }
}
