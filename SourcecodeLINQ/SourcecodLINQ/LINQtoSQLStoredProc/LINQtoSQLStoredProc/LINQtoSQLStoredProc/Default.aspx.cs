using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace LINQtoSQLStoredProc
{
    public partial class _Default : System.Web.UI.Page
    {
        string strConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Sales.mdf;Integrated Security=True;User Instance=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            clsMyContext objContext = new clsMyContext(strConnectionString);
            foreach(var row in objContext.getCustomerAll())
            {
                Response.Write(row.CustomerCode);
            }
        }
    }
}
