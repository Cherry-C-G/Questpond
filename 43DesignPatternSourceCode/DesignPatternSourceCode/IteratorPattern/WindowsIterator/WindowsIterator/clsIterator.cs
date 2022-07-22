using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace WindowsIterator
{
    class clsCustomer
    {
        public string strCustomer = "";
        public string strCode = "";
    }
    class clsIterator
    {
        private int intCurrentIndex = 0;
        private ArrayList objArray = new ArrayList();
        public void FillObjects()
        {
            clsCustomer objCustomer = new clsCustomer();
            objCustomer.strCustomer = "Shiv pvt ltd";
            objCustomer.strCode = "Cust001";
            objArray.Add(objCustomer);
            
            objCustomer = new clsCustomer();
            objCustomer.strCustomer = "Raju pvt ltd";
            objCustomer.strCode = "Cust002";
            objArray.Add(objCustomer);
        }
        public clsCustomer getByIndex(int intIndex)
        {
            if ((intIndex >= objArray.Count) || (intIndex == -1))
            {
                throw new Exception("End or Begin");
            }
            intCurrentIndex = intIndex;
            return (clsCustomer)objArray[intCurrentIndex];
        }
        public clsCustomer Prev()
        {
            int intTemp = intCurrentIndex;
            intTemp--;
            return (clsCustomer)getByIndex(intTemp);
        }
        public clsCustomer Next()
        {
            int intTemp = intCurrentIndex;
            intTemp++;
            return (clsCustomer)getByIndex(intTemp);
        }
        public clsCustomer getFirst()
        {
            return getByIndex(0);
        }
        public clsCustomer getLast()
        {
            return (clsCustomer)getByIndex(objArray.Count);
        }
    }
}
