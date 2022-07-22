using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSpaceFactory
{
    public interface ICustomer
    {
        void Calculate();
    }
    public interface ITax
    {

    }
    public class Gst : ITax
    {

    }
    public class NormalTax : ITax
    {

    }
    public interface Idelivery
    {

    }
    public class Pickup : Idelivery
    {

    }
    public class Courier : Idelivery
    {

    }
    public abstract class BaseCustomer : ICustomer
    {
        ITax t = null;
        Idelivery d = null;
        public BaseCustomer(ITax _t , Idelivery _d)
        {
            t = _t;
            d = _d;
        }

        public abstract void Calculate(); // forcing the child class
    }
    public class Customer : BaseCustomer
    {

        public Customer(ITax t, Idelivery d) : base(t,d)
        {

        }

        public override void Calculate()
        {
            throw new NotImplementedException();
        }
    }
    public class GoldCustomer : BaseCustomer
    {

        public GoldCustomer(ITax t, Idelivery d) : base(t, d)
        {

        }

        public override void Calculate()
        {
            throw new NotImplementedException();
        }
    }
    public class DisCountedCustomer : BaseCustomer
    {

        public DisCountedCustomer(ITax t, Idelivery d) : base(t, d)
    {

    }

    public override void Calculate()
    {
        throw new NotImplementedException();
    }
}

    public interface IFactoryCustomer //Define an interface for creating an object
    {
        ICustomer Create();
        ITax CreateTax();
        Idelivery CreateDelivery();
    }
    public class FactoryCustomer : IFactoryCustomer
    {
        public virtual ICustomer Create()
        {
            return new Customer(CreateTax(), CreateDelivery());
        }

        public virtual Idelivery CreateDelivery()
        {
            var p = new Courier();
            // pick up current web ap
            // some more..
            return p;
        }

        public virtual ITax CreateTax()
        {
            return new Gst();
        }
    }

    public class FactoryCustomerPickup : FactoryCustomer
    {
        public override Idelivery CreateDelivery()
        {
            return new Courier(); // but let subclasses decide which class to instantiate
        }
    }
    public class FactoryCustomerNOrmalTax : FactoryCustomerPickup
    {
        //The Factory method lets a class defer instantiation it uses to subclasses.
        public override ITax CreateTax()
        {
            return new NormalTax(); 
        }
    }
    public static class SimpleFactory {
        // Container....
        static Dictionary<int, ICustomer> custs = new Dictionary<int, ICustomer>();
         static SimpleFactory()
        {
            //custs.Add(1,new DisCountedCustomer());
            //custs.Add(2, new GoldCustomer());
        }
            public static ICustomer Create(int i)
            {
            return custs[i]; // CLone it.
            }
    }

    public class FactorySupplier
    {
        public ITax Create()
        {
            return new Gst();
        }
    }
}
