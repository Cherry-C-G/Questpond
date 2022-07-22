using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace WindowsInterpreterClient
{
    public abstract class clsAbstractExpression
    {
        public abstract void Evaluate(clsContext objContext);
    }
    public class clsYearExpression : clsAbstractExpression
    {
        public override void Evaluate(clsContext objContext)
        {
            string strTemp = objContext.strExpression;
            objContext.strExpression = strTemp.Replace("YYYY", DateTime.Now.Year.ToString());
        }
    }
    public class clsMonthExpression : clsAbstractExpression
    {
        public override void Evaluate(clsContext objContext)
        {
            string strTemp = objContext.strExpression;
           objContext.strExpression =  strTemp.Replace("MM", DateTime.Now.Month.ToString()); 
        }
    }
    public class clsDayExpression : clsAbstractExpression
    {
        public override void Evaluate(clsContext objContext)
        {
            string strTemp = objContext.strExpression;
            objContext.strExpression = strTemp.Replace("DD", DateTime.Now.Day.ToString()); 
        }
    }
    public class clsSeperator : clsAbstractExpression
    {
        public override void Evaluate(clsContext objContext)
        {
            string strTemp = objContext.strExpression;
            objContext.strExpression= strTemp.Replace(" ", "-"); 
        }
    }
}
