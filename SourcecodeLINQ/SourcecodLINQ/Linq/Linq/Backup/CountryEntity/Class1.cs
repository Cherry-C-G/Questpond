using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
namespace NameSpaceCountryEntity
{
    [Table(Name="tbl_country")]
    public class CountryEntity
    {
        private int _intCountryId;
        private string _strCountryCode;
        [Column]
        public string CountryCode
        {
            set
            {
                _strCountryCode = value;
            }
            get
            {
                return _strCountryCode;
            }
        }
        [Column]
        public int CountryId
        {
            set
            {
                _intCountryId = value;
            }
            get
            {
                return _intCountryId;
            }
        }
    }
}
