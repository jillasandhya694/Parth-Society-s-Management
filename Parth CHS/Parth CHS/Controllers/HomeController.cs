using Parth_CHS.DataLayer;
using Parth_CHS.Filters;
using Parth_CHS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
namespace Parth_CHS.Controllers
{
    [AccessFilter]
    [Permission]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // List<Users> objlist = new List<Users>();
            UserDL userDL = new UserDL();
            List<Users> objlist = userDL.GetAllUser();
            return View(objlist);
        }

        public ActionResult Contact()
        {
            var data = (int)TempData["Testing"];
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult GetUserDetailsById(int userId)
        {
            //bool data1 = Convert.ToBoolean("true");
            //string data2 = Convert.ToString(2);
            //decimal data3 = Convert.ToDecimal("12.5");
            //int data34 = Convert.ToInt32(data3);
            //long data5 = Convert.ToInt64(data34);
            //if (data3 == Convert.ToDecimal(data2))
            //{

            //}
            Users data = new Users();
            UserDL userDL = new UserDL();
            data = userDL.GetUserDetailsById(userId);
          
           
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllRooms()
        {
            List<Rooms> listOFRooms = new List<Rooms>();
            RoomsDL roomsDL = new RoomsDL();
            listOFRooms = roomsDL.GetAllRoomsDetails();

            

            return Json(listOFRooms, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDesignations()
        {
            List<SocietyMember> designationList = new List<SocietyMember>();
            SocietyMemberDL designation = new SocietyMemberDL();
            designationList = designation.GetAllSocietyMembers();
            
            return Json(designationList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveEditedDetails(Users data)
        {
            UserDL usersDL = new UserDL();
          bool result = usersDL.UpdateUserDetails(data);
            

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SaveUserDetails(Users data)
        {

            UserDL userDL = new UserDL();
            bool result = userDL.InsertUserDetails(data);

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpdateUserAccess(int UserId, bool IsActive)
        {
            UserDL userDL = new UserDL();
            bool result = userDL.UpdateUserAccess(UserId, IsActive);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStates()
        {
            List<State> stateList = new List<State>();
            using (SqlConnection connection = new SqlConnection("server = .; Database = ParthCHS; Trusted_Connection = True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "GetAllStates";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        State data = new State();
                        data.StateId = (int)reader["StateId"];
                        data.State_ = (string)reader["State"];
                        data.IsActive = (bool)reader["IsActive"];
                        stateList.Add(data);
                    }
                }
                connection.Close();
            }
            return Json(stateList, JsonRequestBehavior.AllowGet);


        }

        public ActionResult GetDistricts(int StateId)
        {
            List<District> districtList = new List<District>();
            using (SqlConnection connection = new SqlConnection("server = .; Database = ParthCHS; Trusted_Connection = True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "GetAllDistrictByStates";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stateId", StateId);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        District data = new District();
                        data.DistrictId = (int)reader["DistrictId"];
                        data.District_ = (string)reader["District"];
                        data.StateId = (int)reader["StateId"];
                        data.IsActive = (bool)reader["IsActive"];
                        districtList.Add(data);
                    }
                }
                connection.Close();
            }
            return Json(districtList, JsonRequestBehavior.AllowGet);
        }

            public ActionResult GetCity(int DistrictId)

            {
                List<City> CityList = new List<City>();
                using (SqlConnection connection = new SqlConnection("server = .; Database = ParthCHS; Trusted_Connection = True;"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "GetCityByDistrict";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DistrictId", DistrictId);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            City data = new City();
                            data.CityId = (int)reader["CityId"];
                            data.City_ = (string)reader["City"];
                            data.DistrictId = (int)reader["DistrictId"];
                            data.IsActive = (bool)reader["IsActive"];
                            CityList.Add(data);
                        }
                    }
                    connection.Close();
                }
                return Json(CityList, JsonRequestBehavior.AllowGet);


            }

       
    }
}