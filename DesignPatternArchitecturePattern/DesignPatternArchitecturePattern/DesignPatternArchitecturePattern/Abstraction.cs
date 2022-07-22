using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternArchitecturePattern
{
    //public interface IRepositoryRead
    //{
    //    void Read();
    //}
    //public interface IRepository : IRepositoryRead
    //{
    //    void Add();
    //    void Update();
       
    //}
    public interface IEnquiry
    {
        string Name { get; set; }
        string Age { get; set; }
    }
    public interface ISupplier
    {
        List<IAddress> Addresses { get; set; }
    }
    public class Supplier : ISupplier
    {
        //
        public List<IAddress> Addresses { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    public class NewSupplier : Supplier
    {
        // new 
    }
    public interface IAddress
    {
         string Address { get; set; }
    }
    
    
    public interface ICustomer
    {
         
        string Name { get; set; }
        int Age { get; set; }
        decimal Amount { get; set; }
        decimal Rating { get; set; }
        void Add(IAddress add);

       

    }
    public interface IValidateCustomer
    {
        bool Validate(ICustomer cust);
    } 
    public interface IRating
    {
        decimal getRating(ICustomer c);
    }
    interface IProduct
    {

    }
    public interface IDiscount
    {
     
        decimal Calculate(ICustomer cust);
    }

    public class CustomerInert
    {
        public string Name { get; set; }

        public int Id { get; set; }
       

    }
    public class Customerread
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }
    }


}
