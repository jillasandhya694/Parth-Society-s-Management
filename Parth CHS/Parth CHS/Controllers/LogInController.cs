using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parth_CHS.DataLayer;
using Parth_CHS.Models;

namespace Parth_CHS.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult LogIn()
        {

            return View();
        }

        public ActionResult CheckLogin(string Username, string Password)
        {
          
            UserDL userDL = new UserDL();
            Users data = userDL.GetUserByUserName(Username);
            bool Isactive = true;

            if (data == null)
            {
                //error logic
                return RedirectToAction("Error", "LogIn");

            }
            else
            {
                if (Password == data.Password & Isactive == data.Isactive)
                {
                    //success
                    Session["UserId"] = data.Id;
                    Session["Username"] = data.UserName;
                    Session["UserEmailId"] = data.Password;
                    Session["Designation"] = data.DesignationId;
                    return RedirectToAction("DashboardView", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Error", "LogIn");

                }
            }
        }
        public ActionResult Error()
        {

            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();


            return RedirectToAction("LogIn", "LogIn");
        }



    }
}






