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
    public class EquipmentdataController : ApiController
    {
        IEquipmentRepository _IEquipmentRepository;
        public EquipmentdataController()
        {
            _IEquipmentRepository = new EquipmentRepository(new EventDBEntities());
        }

        // GET api/equipmentdata
        public IEnumerable<Equipment> Get()
        {
            try
            {
                return _IEquipmentRepository.ShowEquipment();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // GET api/equipmentdata/5
        public Equipment Get(int id)
        {
            try
            {
                return _IEquipmentRepository.GetEquipmentByID(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // POST api/equipmentdata
        public void Post([FromBody]string value)
        {
        }

        // PUT api/equipmentdata/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/equipmentdata/5
        public string Delete(int id)
        {
            try
            {
                _IEquipmentRepository.DeleteEquipment(id);
                return "Success";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
