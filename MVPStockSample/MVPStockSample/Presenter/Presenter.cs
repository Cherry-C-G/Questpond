using System;
using System.Collections.Generic;
using System.Text;
using IStockView;
using StockBO;
using System.Drawing;
namespace Presenter
{
    public class clsPresenter
    {   StockView iObjStockView;
        public void add(StockView ObjStockView)
        {
            iObjStockView = ObjStockView;
        }
        public void increaseStock()
        {
            Stock.IncrementStock();
            iObjStockView.setStockValue(Stock.intStockValue);
            ChangeColor();
        }
        public void decreaseStock()
        {
            Stock.DecrementStock();
            iObjStockView.setStockValue(Stock.intStockValue);
            ChangeColor();
        }
        public void ChangeColor()
        {
            if(Stock.getStatus()==-1)
            {
                iObjStockView.setColor(Color.Red);
            }
            else if (Stock.getStatus() == 1)
            {
                iObjStockView.setColor(Color.Blue);
            }
            else
            {
                iObjStockView.setColor(Color.Green);
            }
        }
    }
}
