using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace EventApplicationAPI.Filters
{
    public class ValidateUserAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;
            if (headers.Contains("ValidID"))
            {
                string token = headers.GetValues("ValidID").First();

                if (token.Equals("######150######"))
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