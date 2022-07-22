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
    public class LoginController : Controller
    {
        ILoginRepository db;
        public LoginController()
        {
            db = new LoginRepository(new EventDBEntities());
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection fc)
        {
            if (fc["Username"] != null && fc["password"] != null)
            {
                var Username = fc["Username"];
                var password = fc["password"];

                var result = db.ValidateUser(Username, password);

                if (result != null)
                {
                    if (result.ID == 0 || result.ID < 0)
                    {
                        ViewBag.errormessage = "Entered Invalid Username and Password";
                    }
                    else
                    {
                        var RoleID = result.RoleID;
                        remove_Anonymous_Cookies(); //Remove Anonymous_Cookies
                        AddCookie_For_API_Validation(result.ID);
                        Session["UserID"] = Convert.ToString(result.ID);
                        Session["RoleID"] = Convert.ToString(result.RoleID);
                        if (RoleID == 1)
                        {
                            return RedirectToAction("Dashboard", "Admin");
                        }
                        else if (RoleID == 2)
                        {
                            return RedirectToAction("Dashboard", "CustomerDashboard");
                        }
                        else if (RoleID == 3)
                        {
                            return RedirectToAction("Dashboard", "SuperAdmin");
                        }
                    }
                }
                else
                {
                    ViewBag.errormessage = "Entered Invalid Username and Password";
                    return View();
                }
            }
            return View();
        }

        public void AddCookie_For_API_Validation(int ID)
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

        [HttpGet]
        public ActionResult Logout()
        {
            if (Request.Cookies["EventChannel"] != null)
            {
                var cookie = new HttpCookie("EventChannel");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login", "Login");

        }

        [NonAction]
        public void remove_Anonymous_Cookies()
        {
            if (Request.Cookies["EventChannel"] != null)
            {
                var cookie = new HttpCookie("EventChannel");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
        }

    }
}



