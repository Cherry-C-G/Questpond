using EventApplication.Filters;
using EventApplication.Models;
using EventApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventApplication.Controllers
{
    [AntiForgeryValidate]
    public class VenueDataController : ApiController
    {
        IVenueRepository _IVenueRepository;
        public VenueDataController()
        {
            _IVenueRepository = new VenueRepository(new EventDBEntities());
        }

        // GET api/venuedata
        public IEnumerable<Venue> Get()
        {
            try
            {
                return _IVenueRepository.ShowVenue();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // GET api/venuedata/5
        public Venue Get(int id)
        {
            try
            {
                return _IVenueRepository.VenueByID(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // POST api/venuedata
        public void Post([FromBody]string value)
        {
        }

        // PUT api/venuedata/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/venuedata/5
        public string Delete(int id)
        {
            try
            {
                _IVenueRepository.DeleteVenue(id);
                return "Success";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
