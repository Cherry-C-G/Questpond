using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace WindowsAdapterObject
{
    class clsCollection : CollectionBase
    {
        
        public virtual void Add(string str)
        {
            List.Add(str);
        }
        
    }
    class clsStack : Stack
    {
        public void push(string str)
        {
            this.push(str);   
        }
        
    }
    class clsCollectionAdapter : clsCollection
    {
        private clsStack objStack = new clsStack();

        public override void Add(string str)
        {
            objStack.push(str);
        }
        
    }
}
