using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parth_CHS.Filters;
using Parth_CHS.Models;

namespace Parth_CHS.Controllers
{
    [AccessFilter]
    [Permission]
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Members()
        {
            List<WomenEvents> objlist = new List<WomenEvents>();
            using (SqlConnection cn = new SqlConnection("server=.; Database= Women ; Trusted_Connection= True;"))
            {
                cn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = cn;
                command.CommandText = "GetallWomendetails";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        WomenEvents F = new WomenEvents();
                        F.Id = (int)reader["Id"];
                        F.FirstName = (string)reader["FirstName"];
                        F.MiddleName = (string)reader["MiddleName"];
                        F.LastName = (string)reader["LastName"];
                        F.PhoneNo = (Int64)reader["PhoneNo"];
                        F.AdharNo = (Int64)reader["AdharNo"];
                        F.EmailId = (string)reader["EmailId"];
                        F.RoomNo = (int)reader["RoomNo"];
                        F.FloorNo = (int)reader["FloorNo"];
                        F.Designation = (string)reader["Designation"];


                        objlist.Add(F);

                    }
                    cn.Close();

                }


            }
            return View(objlist);
        }

        public ActionResult GetDesignation()
        {
            List<WomenDesignation> designationList = new List<WomenDesignation>();
            using (SqlConnection connection = new SqlConnection("server = .; Database = Women; Trusted_Connection = True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "GetallDesignation";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WomenDesignation data = new WomenDesignation();
                        data.Id = (int)reader["Id"];
                        data.Designation = (string)reader["Designation"];
                        designationList.Add(data);
                    }
                }
                connection.Close();
            }
            return Json(designationList, JsonRequestBehavior.AllowGet);


        }

        public ActionResult GetRoomNos() {
            List<WomenRoomNo> roomNolist = new List<WomenRoomNo>();

            using (SqlConnection connection = new SqlConnection("server = .; Database = Women; Trusted_Connection = True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "GetallRoom";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WomenRoomNo data = new WomenRoomNo();
                        data.Id = (int)reader["Id"];
                        data.RoomNo = (int)reader["RoomNo"];
                        data.FloorNo = (int)reader["FloorNo"];
                        roomNolist.Add(data);
                    }
                
                
                }
                connection.Close();




            }
            return Json(roomNolist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveMembersdetails(WomenEvents data) 
        {
            using (SqlConnection cn = new SqlConnection("server=.; Database= Women; Trusted_Connection = True; "))
            {
                cn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = cn;
                command.CommandText = "InsertIntoWomen_tbl";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FirstName", data.FirstName);
                command.Parameters.AddWithValue("@MiddleName", data.MiddleName);
                command.Parameters.AddWithValue("@LastName", data.LastName);
                command.Parameters.AddWithValue("@PhoneNo", data.PhoneNo);
                command.Parameters.AddWithValue("@AdharNo", data.AdharNo);
                command.Parameters.AddWithValue("@EmailId", data.EmailId);
                command.Parameters.AddWithValue("@RoomId", data.RoomsId);
                command.Parameters.AddWithValue("@DesignationId", data.DesignationId);

                command.ExecuteNonQuery();
                cn.Close();

            }

            return Json(true, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetWomendetailsById(int Id) 
        
        {
            WomenEvents data = new WomenEvents();
            using (SqlConnection cn = new SqlConnection("server = .; Database = Women; Trusted_Connection = True;"))
            {
                cn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = cn;
                command.CommandText = "GetWomenMemberById";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Id = (int)reader["Id"];
                        data.FirstName = (string)reader["FirstName"];
                        data.MiddleName = (string)reader["MiddleName"];
                        data.LastName = (string)reader["LastName"];
                        data.PhoneNo = (Int64)reader["PhoneNo"];
                        data.AdharNo = (Int64)reader["AdharNo"];
                        data.EmailId = (string)reader["EmailId"];
                        data.RoomsId = (int)reader["RoomId"];
                        data.RoomNo = (int)reader["RoomNo"];
                        data.FloorNo = (int)reader["FloorNo"];
                        data.DesignationId = (int)reader["DesignationId"];
                        data.Designation = (string)reader["Designation"];
                       
                        break;
                    }
                }
                cn.Close();

            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveEditedMembersdetails(WomenEvents data)
        {
            using (SqlConnection cn = new SqlConnection("server=.; Database= Women; Trusted_Connection = True; "))
            {
                cn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = cn;
                command.CommandText = "UpdateWomendetails";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", data.Id);
                command.Parameters.AddWithValue("@FirstName", data.FirstName);
                command.Parameters.AddWithValue("@MiddleName", data.MiddleName);
                command.Parameters.AddWithValue("@LastName", data.LastName);
                command.Parameters.AddWithValue("@PhoneNo", data.PhoneNo);
                command.Parameters.AddWithValue("@AdharNo", data.AdharNo);
                command.Parameters.AddWithValue("@EmailId", data.EmailId);
                command.Parameters.AddWithValue("@RoomId", data.RoomsId);
                command.Parameters.AddWithValue("@DesignationId", data.DesignationId);

                command.ExecuteNonQuery();
                cn.Close();

            }

            return Json(true, JsonRequestBehavior.AllowGet);


        }

        public ActionResult DeleteWomendetailsById(int Id) 
        {
            using (SqlConnection cn = new SqlConnection("server = .; Database = Women; Trusted_Connection = True;"))
            {
                cn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = cn;
                command.CommandText = "DeleteWomenDetails";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();
                cn.Close();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }

}
