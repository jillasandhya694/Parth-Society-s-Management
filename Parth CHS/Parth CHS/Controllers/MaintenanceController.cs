using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parth_CHS.DataLayer;
using Parth_CHS.Filters;
using Parth_CHS.Models;

namespace Parth_CHS.Controllers

{
    [AccessFilter]
    [Permission]
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
        public ActionResult Page()
        {
            return View();
        }


        public ActionResult CheckMonthYear(int Month, int Year)
        {
            int days = Month % 2 == 1 ? 31 : 30;
            days = Month == 2 ? 28 : days;
            DateTime ST = new DateTime(Year, Month, 01); //   yyyy/mm/01
            DateTime ET = new DateTime(Year, Month, days);

            //  string startDatetime = Convert.ToString(ST);

            List<ManageMaintenance> list = new List<ManageMaintenance>();
            MaintenanceDL manageDL = new MaintenanceDL();
            list = manageDL.GetMaintenanceByDates(ST, ET);
          
            return Json(list, JsonRequestBehavior.AllowGet);

        }


        public ActionResult SaveMaintenanceDetails(ManageMaintenance data)
        {
            int month = data.Entrydate.Month;
            int year = data.Entrydate.Year;
            MaintenanceDL maintenanceDL = new MaintenanceDL();
            ManageMaintenance maintenancedata = maintenanceDL.GetGMSumRecordBySP(month,year);
            bool result = false;
            if (maintenancedata == null)
            {

                result = maintenanceDL.InsertMaintenanceDetails(data);
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        public ActionResult SaveGMsumRecord(int Month, int Year)
        {
            MaintenanceDL maintenanceDL = new MaintenanceDL();
            ManageMaintenance data = maintenanceDL.GetGMSumRecordBySP(Month, Year);
            bool result = false;

            if (data == null) 
            {

                int days = Month % 2 == 1 ? 31 : 30;
                days = Month == 2 ? 28 : days;
                DateTime ST = new DateTime(Year, Month, 01);
                DateTime ET = new DateTime(Year, Month, days);

                  result = maintenanceDL.InsertTotalMaintenanRecord(Month, Year, ST, ET);


            }

            return Json(result, JsonRequestBehavior.AllowGet);


        }
        

    }

}