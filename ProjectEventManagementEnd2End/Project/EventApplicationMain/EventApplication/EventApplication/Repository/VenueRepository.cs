using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Repository
{
    public class VenueRepository : IVenueRepository
    {
        EventDBEntities _db;
        public VenueRepository(EventDBEntities objcontext)
        {
            _db = objcontext;
        }

        public void SaveVenue(Venue venue)
        {
            try
            {
                _db.Venues.Add(venue);
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateVenue(Venue venue)
        {
            try
            {
                if (venue.VenueFilename != null)
                {
                    _db.Entry(venue).State = System.Data.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    _db.Venues.Attach(venue);
                    _db.Entry(venue).Property(x => x.VenueName).IsModified = true;
                    _db.Entry(venue).Property(x => x.VenueCost).IsModified = true;
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Venue> ShowVenue()
        {
            try
            {
                var VenueList = from venue in _db.Venues select venue;
                return VenueList.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public Venue VenueByID(int id)
        {
            try
            {
                Venue venue = _db.Venues.Find(id);
                return venue;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public void DeleteVenue(int id)
        {
            try
            {
                Venue venue = _db.Venues.Find(id);
                _db.Venues.Remove(venue);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}