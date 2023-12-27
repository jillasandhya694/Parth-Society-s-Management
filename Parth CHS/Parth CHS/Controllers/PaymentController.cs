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
    [Permission]
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult PaymentView()
        {
            return View();
        }

        public ActionResult PaymentViewTable(int Month, int Year)
        {
            List<PaymentModel> list = new List<PaymentModel>();
            PaymentDL paymentDL = new PaymentDL();
            list = paymentDL.GetOwnersShareDetails(Month, Year);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}