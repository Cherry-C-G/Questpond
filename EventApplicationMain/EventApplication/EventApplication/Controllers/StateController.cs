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
    public class StateController : ApiController
    {
        IDropdownCommonRepository IRepository;

        public StateController()
        {
            IRepository = new DropdownCommonRepository(new EventDBEntities());
        }
      
        // GET api/state/5
        public IEnumerable<State> Get(int id)
        {
            try
            {
                var data = IRepository.GetStatebyID(id);
                return data;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
       
    }
}
