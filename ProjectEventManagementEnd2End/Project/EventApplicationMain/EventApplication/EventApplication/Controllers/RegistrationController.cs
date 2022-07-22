using EventApplication.Models;
using EventApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    public class RegistrationController : Controller
    {
        IRegistrationRepository IRepository;

        public RegistrationController()
        {
            IRepository = new RegistrationRepository(new EventDBEntities());
        }

        public ActionResult Registration()
        {
            try
            {
                AddCookie_For_API_Validation(4); //Anonymous 
                return View();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public JsonResult Registration(Registration registration)
        {
            try
            {
                if (registration != null)
                {
                    var result = IRepository.NEW_Customer(registration);
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

        [NonAction]
        public void AddCookie_For_API_Validation(int ID)
        {
            try
            {
                string cookieToken;
                string formToken;
                AntiForgery.GetTokens(null, out cookieToken, out formToken);
                ViewBag.cookieToken = cookieToken;
                ViewBag.formToken = formToken;
                Random rm = new Random();
                var cookie = new HttpCookie("EventChannel");
                cookie.Value = ID + "*" + cookieToken + "*" + formToken + "*" + DateTime.Now.Date.ToShortDateString() + "*" + DateTime.Now.Date.ToShortTimeString();
                Response.Cookies.Add(cookie);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
