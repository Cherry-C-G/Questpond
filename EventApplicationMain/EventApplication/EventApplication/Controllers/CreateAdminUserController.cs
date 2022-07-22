using EventApplication.Filters;
using EventApplication.Models;
using EventApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    [ValidateSuperAdminSession]
    public class CreateAdminUserController : Controller
    {
        IRegistrationRepository IRepository;

        public CreateAdminUserController()
        {
            IRepository = new RegistrationRepository(new EventDBEntities());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegisterAdmin(Registration registration)
        {
            try
            {
                if (registration != null)
                {
                    var result = IRepository.NEW_Admin(registration);
                    return Json(result);
                }
                else
                {
                    return Json("Failed");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
