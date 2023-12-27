using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Parth_CHS.Filters
{
    public class AccessFilter : FilterAttribute, IActionFilter, IResultFilter, IExceptionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var UserId = Convert.ToInt32(HttpContext.Current.Session["UserId"] ?? 0);
            if (UserId == 0)
            {
                var values = new RouteValueDictionary(new
                {
                    action = "Login",
                    controller = "Login"  ,
                    code = "0"
                });
                filterContext.Result = new RedirectToRouteResult(values);
            }
            Console.WriteLine("Before Controller");
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Console.WriteLine("After Controller");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Console.WriteLine("Before View");
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Console.WriteLine("After View");
        }

        public void OnException(ExceptionContext filterContext)
        {
            Console.WriteLine("OnException");
        }
    }
}