using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
//using DecoratorNameSpace;
using NInjectExample;
namespace DesignpatternClient
{
    class Program
    {
        public Program()
        {

        }
        static void Main(string[] args)
        {
            IKernel _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
            MySupplier supp = _kernel.Get<MySupplier>(x=>x.Name=="O");
            //ICustomer c = new Customer();
            //IValidate v = new BillAmountCheckValidation(
            //                            new PhoneCheckValidation(
            //                                    new BasicValidation()));

            //v = new PhoneCheckValidation(
            //                new BasicValidation());
            //v = new BasicValidation();

            //c.Name = "Shiv";
            //c.Phone = "10019898";
            //c.BillAmount = 100;
            //v.Validate(c);

        }
    }
    public class DalBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDal>().To<SqlDal>().Named("S");
            Bind<IDal>().To<OracleDal>().Named("O");
            Bind<MySupplier>().ToSelf();
        }
    }
}
