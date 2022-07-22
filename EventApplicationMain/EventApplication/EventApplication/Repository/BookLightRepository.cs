using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventApplication.Models;
namespace EventApplication.Repository
{
    public class BookLightRepository : IBookLightRepository
    {
        EventDBEntities _db;
        public BookLightRepository(EventDBEntities eventDBEntities)
        {
            _db = eventDBEntities;
        }

        public IEnumerable<Light> LightList(string LightType)
        {
            try
            {
                if (LightType != null)
                {
                    var LightingList = (from templight in _db.Lights
                                        where templight.LightType == LightType
                                        select templight).ToList();
                    return LightingList;
                }
                else
                {
                    return Enumerable.Empty<Light>();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public int BookLight(BookingLight light)
        {
            try
            {
                _db.BookingLights.Add(light);
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}