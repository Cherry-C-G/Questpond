using EventApplication.Filters;
using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventApplication.Controllers
{

    public class CheckUsernameController : ApiController
    {
        private EventDBEntities db = new EventDBEntities();

        // GET api/checkusername
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/checkusername/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/checkusername
        public bool Post([FromBody]Registration registration)
        {
            try
            {
                bool val = false;

                if (registration != null)
                {
                    var data = (from mdata in db.Registrations
                                where mdata.Username == registration.Username & mdata.RoleID == 2
                                select mdata).Count();
                    if (data > 0)
                    {
                        return val = true;
                    }
                    else
                    {
                        return val;
                    }
                }
                else
                {
                    return val;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // PUT api/checkusername/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/checkusername/5
        public void Delete(int id)
        {
        }
    }
}
