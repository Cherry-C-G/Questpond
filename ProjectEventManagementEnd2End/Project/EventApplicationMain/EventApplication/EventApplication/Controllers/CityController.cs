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
    public class CityController : ApiController
    {
        IDropdownCommonRepository IRepository;

        public CityController()
        {
            IRepository = new DropdownCommonRepository(new EventDBEntities());
        }

        // GET api/city
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/city/5
        public IEnumerable<City> Get(int id)
        {
            try
            {
                var data = IRepository.GetCitybyID(id);
                return data;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // POST api/city
        public void Post([FromBody]string value)
        {
        }

        // PUT api/city/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/city/5
        public void Delete(int id)
        {
        }
    }
}
