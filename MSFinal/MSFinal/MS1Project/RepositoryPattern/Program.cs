using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Customer obj = new Customer();
            //IRepository<Customer> repo = 
            //    new MyEfContext<Customer>(new EfCustomerContext());
            //repo.Add(obj);

            //Supplier obj1 = new Supplier();
            //IRepository<Supplier> repo1 = 
            //    new MyEfContext<Supplier>(new EfSupplierContext()); ;
            //repo1.Add(obj1);
        }
    }
    public class Customer
    {
        public string name { get; set; }
    }
    public class DisCountedCustomer : Customer
    {

    }
    public class Supplier
    {
        public string name { get; set; }
    }
    interface IRepository<T>
    {
        bool Add(T obj);
        bool Update(T obj);
        List<T> Query(int it);
        List<T> Query(string name);

    }

    public abstract class EfCommon<T> :DbContext, IRepository<T>
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
            modelBuilder.Entity<DisCountedCustomer>().ToTable("tblCustomer");

        }
    }
  
    public class EfSupplierContext : EfCommon<Supplier>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("tblSupplier");
        }
    }
  
}
