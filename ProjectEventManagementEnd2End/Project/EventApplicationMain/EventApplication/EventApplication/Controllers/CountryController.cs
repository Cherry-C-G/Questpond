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
    public class CountryController : ApiController
    {
        IDropdownCommonRepository IRepository;

        public CountryController()
        {
            IRepository = new DropdownCommonRepository(new EventDBEntities());
        }

        // GET api/country
        public IEnumerable<Country> Get()
        {
            try
            {
                var data = IRepository.GetCountry();
                return data;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // GET api/country/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/country
        public void Post([FromBody]string value)
        {
        }

        // PUT api/country/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/country/5
        public void Delete(int id)
        {
        }
    }
}
