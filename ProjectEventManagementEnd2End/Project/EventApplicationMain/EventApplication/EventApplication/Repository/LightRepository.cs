using EventApplication.Filters;
using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Repository
{
    [AntiForgeryValidate]
    public class LightRepository : ILightRepository
    {
        EventDBEntities _db;
        public LightRepository(EventDBEntities EventDBEntities)
        {
            _db = EventDBEntities;
        }

        public void SaveLight(Models.Light Light)
        {
            try
            {

                _db.Lights.Add(Light);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IEnumerable<Models.Light> ShowLight()
        {
            try
            {
                var Lightlist = (from Lights in _db.Lights select Lights);
                return Lightlist.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void DeleteLight(int id)
        {
            try
            {
                Light Light = _db.Lights.Find(id);
                _db.Lights.Remove(Light);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Light LightByID(int id)
        {
            try
            {
                return _db.Lights.Find(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void UpdateLight(Light Light)
        {
            try
            {
                if (Light.LightFilename != null)
                {
                    _db.Entry(Light).State = System.Data.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    _db.Lights.Attach(Light);
                    _db.Entry(Light).Property(x => x.LightName).IsModified = true;
                    _db.Entry(Light).Property(x => x.LightType).IsModified = true;
                    _db.Entry(Light).Property(x => x.LightCost).IsModified = true;
                    
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}