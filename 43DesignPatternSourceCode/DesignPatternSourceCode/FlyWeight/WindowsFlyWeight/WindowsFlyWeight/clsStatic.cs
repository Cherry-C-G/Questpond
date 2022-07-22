using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFlyWeight
{
    class clsStaticAddress
    {
        public string strAddress = "Vasant Oscar";
        public string strStreet = "Mulund";
        public string strPin = "81";
        public string strCountry = "India";
    }
    class clsStatic
    {
        public static clsStaticAddress objAddress = new clsStaticAddress();
    }
    class clsVariableAddress
    {
       
        public clsStaticAddress Address()
        {
            return clsStatic.objAddress;
        }
        public string strName = "";
    }
}
