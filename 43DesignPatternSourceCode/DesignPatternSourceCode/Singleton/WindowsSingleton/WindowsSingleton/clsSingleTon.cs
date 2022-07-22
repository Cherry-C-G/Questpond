using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsSingleton
{
    public class clsSingleTon
    {
        public static int intCounter;
        private clsSingleTon() 
        {
	        // This is a private constructor
        }
        public static void Hit()
        {
            intCounter++;
        }
        public static int getTotalHits()
        {
            return intCounter;
        }
    }
}
