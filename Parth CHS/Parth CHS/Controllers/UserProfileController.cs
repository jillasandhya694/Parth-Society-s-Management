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
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult GetUserProfileDetails()
        {

            Users data = new Users();
            UserDL userDL = new UserDL();
            data = userDL.GetUserDetailsById((int)Session["UserId"]);


            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveUserProfileEditedDetails(Users data)
        {
            UserDL usersDL = new UserDL();
            bool result = usersDL.UpdateUserDetails(data);


            return Json(result, JsonRequestBehavior.AllowGet);

        }

    }

    
}