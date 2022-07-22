using System;
using System.Collections.Generic;
using System.Text;

namespace Statergy
{
    public abstract class clsStatergy
    {
        public abstract 
            int Calculate(int intNumber1, int intNumber2);
    }
    public class clsAddStatergy : clsStatergy
    {
        public override int Calculate(int intNumber1, int intNumber2)
        {
            return intNumber1 + intNumber2;
        }
    }
    public class clsSubstractStatergy : clsStatergy
    {
        public override int Calculate(int intNumber1, int intNumber2)
        {
            return intNumber1 - intNumber2;
        }
    }
    public class clsMaths
    {
        public int intNumber1 = 0;
        public int intNumber2 = 0;
        private clsStatergy objStatergy;
        public void setStatergy(clsStatergy obj)
        {
            objStatergy = obj;
        }
        public int Calculate()
        {
            return objStatergy.Calculate(intNumber1, intNumber2);
        }
    }
}
