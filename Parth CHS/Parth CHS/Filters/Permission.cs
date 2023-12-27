using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Parth_CHS.Filters
{
    public class Permission : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)

        {int DesignationId = Convert.ToInt32(HttpContext.Current.Session["Designation"] ?? 0);

            if (DesignationId == 5)
            {
                var values = new RouteValueDictionary(new
                {
                    action = "NoAccess",
                    controller = "Dashboard",
                    code = "0"
                });
                filterContext.Result = new RedirectToRouteResult(values);
            }
            Console.WriteLine("Before Controller");
        }
    }
}