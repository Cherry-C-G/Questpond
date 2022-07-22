using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
namespace CustomerUI
{
    // UI layer
    class Program
    {
        
        static void Main(string[] args)
        {
            IUnityContainer objContainer = new UnityContainer();
            objContainer.LoadConfiguration(); // loads from app.config
            //objContainer.RegisterType<IDal, OracleDal>("oracle");
            //objContainer.RegisterType<IDal, SQlServerDal>("sqlserver");
            //objContainer.RegisterType<Customer>("custora",
            //                    new InjectionConstructor(
            //                        new ResolvedParameter<IDal>("oracle")));
            //objContainer.RegisterType<Customer>("custsql",
            //                    new InjectionConstructor(
            //                        new ResolvedParameter<IDal>("sqlserver")));
            Customer obj = objContainer.Resolve<Customer>();
            obj.CustomerName = "test1";
            obj.Add();
        }
    }
    
    // Middle layer
    public class Customer
    {
        private IDal Odal;// <<<-- Unity Decoupled architecture
        public string CustomerName { get; set; }
        public Customer(IDal iobj)
        {
            Odal = iobj;
        }
        public void Add()
        {

            Odal.Add();
        }
    }

    // Dal
    public interface IDal
    {
        void Add();
    }
    public class SQlServerDal : IDal
    {
        public void Add()
        {
            Console.WriteLine("Sql Server inserted");
        }
    }

    // Oracle
    public class OracleDal : IDal
    {
        public void Add()
        {
            Console.WriteLine("Added by oracle");
        }
    }
   
}
