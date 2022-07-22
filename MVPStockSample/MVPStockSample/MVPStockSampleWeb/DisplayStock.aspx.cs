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
using IStockView;
using Presenter;
public partial class DisplayStock : System.Web.UI.Page,StockView
{
    private clsPresenter objPresenter = new clsPresenter();
    protected void Page_Load(object sender, EventArgs e)
    {
        objPresenter.add(this);
    }
    public void setStockValue(int intStockValue)
    {
        txtStockValue.Text = intStockValue.ToString();
    }
    public void setColor(System.Drawing.Color objColor)
    {
        txtStockValue.BackColor = objColor;
    }
    protected void btnIncreaseStock_Click(object sender, EventArgs e)
    {
        objPresenter.increaseStock();
    }
    protected void btnDecreaseStock_Click(object sender, EventArgs e)
    {
        objPresenter.decreaseStock();
    }
}
