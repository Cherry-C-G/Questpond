using EventApplication.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
      [ValidateUserSession]
    public class CustomerDashboardController : Controller
    {
        //
        // GET: /CustomerDashboard/

        public ActionResult Dashboard()
        {
            return View();
        }

    }
}
