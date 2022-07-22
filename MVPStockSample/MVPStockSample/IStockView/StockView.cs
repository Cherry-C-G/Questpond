using System;
using System.Collections.Generic;
using System.Text;
namespace IStockView
{
   public interface StockView
    {
        void setStockValue(int intStockValue);
        void setColor(System.Drawing.Color objColor);
    }
}
