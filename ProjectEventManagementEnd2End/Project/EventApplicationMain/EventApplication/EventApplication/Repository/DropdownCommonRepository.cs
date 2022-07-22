using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Repository
{
    public class DropdownCommonRepository : IDropdownCommonRepository
    {
        EventDBEntities _db;
        public DropdownCommonRepository(EventDBEntities objcontext)
        {
            _db = objcontext;
        }

        public IEnumerable<Models.Country> GetCountry()
        {
            try
            {
                var data = _db.Countries.ToList();
                return data;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IEnumerable<Models.State> GetStatebyID(int ID)
        {
            try
            {
                var data = (from a in _db.States
                            where a.CountryID == ID
                            select a).ToList();
                return data;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IEnumerable<Models.City> GetCitybyID(int ID)
        {
            try
            {
                var data = (from a in _db.Cities
                            where a.StateID == ID
                            select a).ToList();
                return data;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}