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
    public class FlowerDataController : ApiController
    {
        IFlowerRepository _IFlowerRepository;
        public FlowerDataController()
        {
            _IFlowerRepository = new FlowerRepository(new EventDBEntities());
        }

          
      

        // GET api/flowerdata
        public IEnumerable<Flower> Get()
        {
            try
            {
                return _IFlowerRepository.ShowFlower();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // GET api/flowerdata/5
        public Flower Get(int id)
        {
            try
            {
                return _IFlowerRepository.FlowerByID(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // POST api/flowerdata
        public void Post([FromBody]string value)
        {
        }

        // PUT api/flowerdata/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/flowerdata/5
        public string Delete(int id)
        {
            try
            {
                _IFlowerRepository.DeleteFlower(id);
                return "Success";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
