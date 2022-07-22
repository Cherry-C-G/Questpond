using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using NameSpaceCountryEntity;
using System.Data;
using System.Data.SqlClient;

namespace NameSpaceCountryDAL
{
    public class clsCountryDAL
    {
        string strConnectionString ="Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\Linq\\Linq\\Country.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public Table<CountryEntity> getCountries()
        {
            DataContext db = new DataContext(strConnectionString);
            Table<CountryEntity> Customers = db.GetTable<CountryEntity>();
            return Customers;
        }
        public DataSet getCountriesByDataset()
        {
            SqlConnection objConnection = new SqlConnection(strConnectionString);
            DataSet objDataset = new DataSet();
            objConnection.Open();
            SqlDataAdapter objAdapter = new SqlDataAdapter("Select * from tbl_country", objConnection);
            objAdapter.Fill(objDataset);
            objConnection.Close();
            return objDataset;
        }

    }
}
