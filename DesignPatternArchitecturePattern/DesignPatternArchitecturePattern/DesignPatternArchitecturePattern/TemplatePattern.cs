using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePatternNameSpace
{
    public interface IDb
    {
        void Execute();
        
    }
    public abstract class AbstractDb : IDb
    {
        public  void Execute()
        {
            Open();
            ExecuteQuery();
            Close();
        }
        protected virtual void Close()
        {
            // dispose..
        }



        protected abstract void ExecuteQuery();

        protected virtual void Open()
        {
           // mapping
        }
    }

    public class CustomerDb : AbstractDb
    {
        protected override void ExecuteQuery()
        {
            throw new NotImplementedException();
        }
    }
}
