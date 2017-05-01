using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using System.Net;

namespace HelloWorld
{
    public class AuthorizeIPAddressAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentRequest = filterContext.HttpContext.Request;
            if (currentRequest.UserHostAddress == "::1")
            {
                //Say it is forbidden
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                //or throw an exception
                //throw new Exception();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}