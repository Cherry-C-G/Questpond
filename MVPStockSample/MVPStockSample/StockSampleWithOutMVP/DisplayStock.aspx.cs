using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using StockBO;
using System.Drawing;
public partial class DisplayStock : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnIncreaseStock_Click(object sender, EventArgs e)
    {
        Stock.IncrementStock();
        txtStockValue.Text = Stock.intStockValue.ToString();
        ChangeColor();
    }
    protected void btnDecreaseStock_Click(object sender, EventArgs e)
    {
        Stock.DecrementStock();
        txtStockValue.Text = Stock.intStockValue.ToString();
        ChangeColor();
    }
    private void ChangeColor()
    {
        if (Stock.getStatus() == -1)
        {
            txtStockValue.BackColor =  Color.Red;
        }
        else if (Stock.getStatus() == 1)
        {
           txtStockValue.BackColor =  Color.Blue;
        }
        else
        {
            txtStockValue.BackColor =  Color.Green;
        }
    }
}
