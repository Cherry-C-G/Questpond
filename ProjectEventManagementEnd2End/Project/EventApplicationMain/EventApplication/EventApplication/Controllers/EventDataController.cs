using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventApplication.Controllers
{
    public class EventDataController : ApiController
    {
        EventDBEntities _db;
        public EventDataController()
        {
            _db = new EventDBEntities();
        }
        // GET api/eventdata
        public IEnumerable<Event> Get()
        {
            try
            {
                return _db.Events.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // GET api/eventdata/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/eventdata
        public void Post([FromBody]string value)
        {

        }

        // PUT api/eventdata/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/eventdata/5
        public void Delete(int id)
        {
        }
    }
}
