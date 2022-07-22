using EventApplication.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    [ValidateSuperAdminSession]
    public class SuperAdminController : Controller
    {
        //
        // GET: /SuperAdmin/

        public ActionResult Dashboard()
        {
            return View();
        }

    }
}
