using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PatientManageSystemServer.Models;
using PatientManageSystemServer.EfContext;
using Microsoft.AspNetCore.Authorization;

namespace PatientManageSystemServer.Controllers
{
    // http://localhost:.../Patient/Add
    [EnableCors("MyPolicy")]
    [Authorize]
    public class PatientController : Controller
    {
       
        public IActionResult Update()
        {
            return View();
        }
    }
}
