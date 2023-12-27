using Parth_CHS.DataLayer;
using Parth_CHS.Filters;
using Parth_CHS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parth_CHS.Controllers
{
    [AccessFilter]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult DashboardView()
        {
            return View();
        }

        public ActionResult DashboardPaymentView( int Year)
        {

            List<DashboardModel> list = new List<DashboardModel>();
            DashboardDL dashboardDL = new DashboardDL();
            list = dashboardDL.UserDashboardPaymentView((int)Session["UserId"], Year);
            
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdatePayment(int Id)
        {
            DashboardDL dashboardDL = new DashboardDL();
            bool result = dashboardDL.UpdatePayment(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult NoAccess() 
        {
            return View();
        }
    }
}