using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NInjectExample
{
    public interface IDal
    {

    }
    public class SqlDal : IDal
    {

    }
    public class OracleDal : IDal
    {

    }

    public class MySupplier
    {
        public MySupplier(IDal d)
        {

        }
    }
}
