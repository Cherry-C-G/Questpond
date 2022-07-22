using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Filters
{
    public class ValidateAdminSession : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["RoleID"])))
            {

                string UserCurrentRole = (string)filterContext.HttpContext.Session["RoleID"];

                if (UserCurrentRole != "1") //Admin Role = 1
                {
                    ViewResult result = new ViewResult();
                    result.ViewName = "Error";
                    result.ViewBag.ErrorMessage = "Invalid User";
                    filterContext.Result = result;
                }

            }
            else
            {
                ViewResult result = new ViewResult();
                result.ViewName = "Error";
                result.ViewBag.ErrorMessage = "You Session has been Expired";
                filterContext.Result = result;
            }
        }
    }

    public class ValidateSuperAdminSession : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["RoleID"])))
            {

                string UserCurrentRole = (string)filterContext.HttpContext.Session["RoleID"];

                if (UserCurrentRole != "3") //Admin Role = 1
                {
                    ViewResult result = new ViewResult();
                    result.ViewName = "Error";
                    result.ViewBag.ErrorMessage = "Invalid User";
                    filterContext.Result = result;
                }

            }
            else
            {
                ViewResult result = new ViewResult();
                result.ViewName = "Error";
                result.ViewBag.ErrorMessage = "You Session has been Expired";
                filterContext.Result = result;
            }
        }
    }

    public class ValidateUserSession : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["RoleID"])))
            {

                string UserCurrentRole = (string)filterContext.HttpContext.Session["RoleID"];

                if (UserCurrentRole != "2") //Admin Role = 1
                {
                    ViewResult result = new ViewResult();
                    result.ViewName = "Error";
                    result.ViewBag.ErrorMessage = "Invalid User";
                    filterContext.Result = result;
                }

            }
            else
            {
                ViewResult result = new ViewResult();
                result.ViewName = "Error";
                result.ViewBag.ErrorMessage = "You Session has been Expired";
                filterContext.Result = result;
            }
        }
    }
}