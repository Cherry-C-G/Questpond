using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientModel;
using ProjectDbContext;

namespace MVCCoreMayTraining.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private PatientDbContext _db = null;
        public PatientController(PatientDbContext db )
        {
            _db = db;
            _db.Database.EnsureCreated();
        }
        public IActionResult Index() // <-- invoke add page
        {
            return View("AddPatient");
        }
        public IActionResult AddtoDb(Patient obj) // <-- 
        {
            _db.Patients.Add(obj); // in memor
            _db.SaveChanges(); // physical committ

            return View("PatientDisplay");
        }
    }
}