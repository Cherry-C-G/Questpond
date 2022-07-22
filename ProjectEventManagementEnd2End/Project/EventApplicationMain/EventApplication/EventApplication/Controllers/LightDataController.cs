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
    public class LightDataController : ApiController
    {
        ILightRepository _ILightRepository;
        public LightDataController()
        {
            _ILightRepository = new LightRepository(new EventDBEntities());
        }

        // GET api/lightdata
        public IEnumerable<Light> Get()
        {
            try
            {
                return _ILightRepository.ShowLight();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // GET api/lightdata/5
        public Light Get(int id)
        {
            try
            {
                return _ILightRepository.LightByID(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // POST api/lightdata
        public void Post([FromBody]string value)
        {
        }

        // PUT api/lightdata/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/lightdata/5
        public string Delete(int id)
        {
            try
            {
                _ILightRepository.DeleteLight(id);
                return "Success";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
