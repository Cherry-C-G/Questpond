using System;
using System.Collections.Generic;
using System.Text;

namespace StockBO
{
    
    public class Stock
    {
        public static int intStockValue;
        
        public static void IncrementStock()
        {
            intStockValue++;
        }
        public static void DecrementStock()
        {
            intStockValue--;
        }
        public static int getStatus()
        {
            // if less than zero then -1
            // if more than 5 then 1
            // if in between 0
            if (intStockValue > 5)
            {
                return 1;
            }
            else if (intStockValue < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }
    }
}
