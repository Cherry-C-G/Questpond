using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Reflection;

namespace LINQtoSQLStoredProc
{
    [Table(Name = "Customer")]
    public class clsCustomerEntity
    {
        private int _CustomerId;
        private string _CustomerCode;
        private string _CustomerName;

        [Column(DbType = "nvarchar(50)")]
        public string CustomerCode
        {
            set
            {
                _CustomerCode = value;
            }
            get
            {
                return _CustomerCode;
            }
        }

        [Column(DbType = "nvarchar(50)")]
        public string CustomerName
        {
            set
            {
                _CustomerName = value;
            }
            get
            {
                return _CustomerName;
            }
        }

        [Column(DbType = "int", IsPrimaryKey = true)]
        public int CustomerId
        {
            set
            {
                _CustomerId = value;
            }
            get
            {
                return _CustomerId;
            }
        }
    }

    public class clsMyContext : DataContext
    {
        public clsMyContext(string connection)
            : base(connection)
        {
        }
        [Function(Name = "usp_SelectCustomer", IsComposable = false)]
        public ISingleResult<clsCustomerEntity> getCustomerAll()
        {
            
            IExecuteResult objResult = this.ExecuteMethodCall(this,(MethodInfo)(MethodInfo.GetCurrentMethod()));
            ISingleResult<clsCustomerEntity> objresults = (ISingleResult<clsCustomerEntity>) objResult.ReturnValue;
            return objresults;
        }
    }
}
