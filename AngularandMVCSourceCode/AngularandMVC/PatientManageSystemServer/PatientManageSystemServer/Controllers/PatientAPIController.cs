using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PatientManageSystemServer.EfContext;
using PatientManageSystemServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientManageSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Authorize]
    public class PatientAPIController : ControllerBase
    {
        // GET: api/<PatientAPIController>
        [HttpGet]
        public IActionResult Get()
        {
            PatientDbContext db = new PatientDbContext();

            List<Patient> pats = db.patients.ToList<Patient>();
            return Ok(pats);
        }

        // GET api/<PatientAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PatientAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Patient obj)
        {
            PatientDbContext db = new PatientDbContext();
            db.patients.Add(obj);
            db.SaveChanges();
            List<Patient> pats = db.patients.ToList<Patient>();
            return Ok(pats);
        }

            // PUT api/<PatientAPIController>/5
            [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
