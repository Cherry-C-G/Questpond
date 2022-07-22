using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EventApplication.Filters
{
    public class AntiForgeryValidate : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string cookieToken = "";
            string formToken = "";
            string Date = "";
            string Time = "";

            IEnumerable<string> tokenHeaders;
            if (actionContext.Request.Headers.TryGetValues("RequestVerificationToken", out tokenHeaders))
            {
                string[] tokens = tokenHeaders.First().Split('*');
                if (tokens.Length == 5)
                {
                    var UserID = tokens[0].Trim();
                    cookieToken = tokens[1].Trim();
                    formToken = tokens[2].Trim();
                    Date = tokens[3].Trim();
                    Time = tokens[4].Trim();
                }
                System.Web.Helpers.AntiForgery.Validate(cookieToken, formToken);
                if (Date != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

}