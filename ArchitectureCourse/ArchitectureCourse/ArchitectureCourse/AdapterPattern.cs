using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace AdapterNameSpace
{
    // CQRS , Event sourcing
    // Repository , Factory

    // Architecture pattern
    // Repositoru
    // Factory Pattern 
    //also looking forward DDD core concepts where 
    //we had started like Event sourcing, CQRS, Eventual consistency 

    // command

    //cloud design patterns


    // DI technique , IOC style
    // Iterator pattern ...,Repository Pattern / UOW
    // Facade , Startergy
    // Mediator pattern....
    // Adapter...Decorator / Factory pattern
    // Bridge pattern....
    // Onion architecture DDD..
    // Prototype  , COR , visitor
    //.....

    public interface IDAl
    {
        void Add(); // command.executenonquery
        void Update();
    }

    public class SqlServerDal : IDAl
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    public class OracleDal : IDAl
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }


    public abstract class AdoDal : IDAl
    {
        SqlConnection conn = null;
        protected SqlCommand comm = null;
        private void OpenConnection()
        {
            conn.Open();
        }
        //deferring some steps to subclasses. 
        public abstract void ExecuteQuery(); // no logic

        private void CloseConnection()
        {
            conn.Close();
        }
        public virtual void Add()
        {
            //Define the skeleton of an algorithm 
            //in an operation, 
            OpenConnection();
            ExecuteQuery();
            CloseConnection();
        }

        public void Update()
        {
            comm.CommandText = "update";
            comm.ExecuteNonQuery();
        }
    }
    public class CustomerAdoDal : AdoDal
    {
        //lets subclasses redefine certain steps of an algorithm 
        //without changing the algorithm's structure.
        public override void ExecuteQuery()
        {
            comm.CommandText = "insert....customer";
            comm.ExecuteNonQuery();
        }
    }
    public class MySqlAdapterI : MySqlTpDal, IDAl
    {
        // inheritance adapter
        public void Add()
        {
            this.Insert();
        }

        public void Update()
        {
            this.Edit();
        }
    }
    public class MySqlAdapter : IDAl
    {
        MySqlTpDal m = new MySqlTpDal();
        public void Add()
        {
            m.Insert();
        }

        public void Update()
        {
            m.Edit();
        }
    }

    public class MySqlTpDal
    {

        public void Insert()
        {
            // mysql
        }
        public void Edit()
        {

        }
    }
}
