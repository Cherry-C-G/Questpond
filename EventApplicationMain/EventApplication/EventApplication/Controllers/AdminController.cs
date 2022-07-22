using EventApplication.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    [ValidateAdminSession]
    public class AdminController : Controller
    {     
        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
