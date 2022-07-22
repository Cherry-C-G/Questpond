using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace WindowsAdapterClass
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
    
    class clsCollectionAdapter : clsStack
    {
        public  void Add(string str)
        {
            this.push(str);
        }
    }
}
