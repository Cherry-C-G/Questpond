using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameSpaceCountryEntity;
using NameSpaceCountryDAL;
using System.Data.Linq;
using System.Collections;
using System.Data;
namespace NameSpaceCountryBO
{
    public class CountryBO
    {
        public IEnumerable<CountryEntity> getCountries()
        {
            clsCountryDAL objCountryDal = new clsCountryDAL();
            return from c in objCountryDal.getCountries() select c;
        }
        public IEnumerable<CountryEntity> getCountries(int id)
        {
            clsCountryDAL objCountryDal = new clsCountryDAL();
            return from c in objCountryDal.getCountries() where c.CountryId==id select c;
        }
    }

    public class CountriesNormalBO : CollectionBase
    {
        public CountriesNormalBO()
        {
            clsCountryDAL objCountryDal = new clsCountryDAL();
            DataSet  obj = objCountryDal.getCountriesByDataset();
            foreach (DataRow objRow in obj.Tables[0].Rows)
            {
                CountryEntity objCountry = new CountryEntity();
                objCountry.CountryId = Convert.ToInt16(objRow[0]);
                objCountry.CountryCode = Convert.ToString(objRow[1]);
                List.Add(objCountry);
            }
        }

        public CountryEntity getCountry(int id)
        {
            foreach (CountryEntity obj in List)
            {
                if (obj.CountryId == id)
                {
                    return obj;
                }
            }
            return null;
        }
    }
}
