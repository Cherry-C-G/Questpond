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
    public class FooddataController : ApiController
    {
        IFoodRepository _IFoodRepository;
        public FooddataController()
        {
            _IFoodRepository = new FoodRepository(new EventDBEntities());
        }

        // GET api/fooddata
        public IEnumerable<Food> Get()
        {
            try
            {
                return _IFoodRepository.ShowFood();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // GET api/fooddata/5
        public Food Get(int id)
        {
            try
            {
                return _IFoodRepository.FoodByID(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // POST api/fooddata
        public void Post([FromBody]string value)
        {
        }

        // PUT api/fooddata/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/fooddata/5
        public string Delete(int id)
        {
            try
            {
                _IFoodRepository.DeleteFood(id);
                return "Success";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
