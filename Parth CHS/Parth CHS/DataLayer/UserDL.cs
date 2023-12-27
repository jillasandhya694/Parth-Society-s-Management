using Parth_CHS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Parth_CHS.DataLayer
{
    public class UserDL
    {
        private SqlConnection connection;
        public UserDL()
        {
            connection = new SqlConnection("server = .; Database = ParthCHS; Trusted_Connection = True;");
        }
        public Users GetUserByUserName(string Username)
        {
            Users data = new Users();
            
            connection.Open();
            SqlCommand command = getSQLCommand("GetUserByUserName");
          
            command.Parameters.AddWithValue("@UserName", Username);
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
                    data.DesignationId = (int)reader["MembersId"];
                    data.Isactive = (bool)reader["Isactive"];
                    data.UserName = (string)reader["UserName"];
                    data.Password = (string)reader["Password"];

                    break;
                }
            }
            connection.Close();
   
            return data;
        }
        public List<Users> GetAllUser()
        {
            List<Users> listUsers = new List<Users>();
           
            connection.Open();

            SqlCommand command = getSQLCommand("GetallUser_data_SP");
            

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    Users F = new Users();
                    F.Id = (int)reader["Id"];
                    F.FirstName = (string)reader["FirstName"];
                    F.MiddleName = (string)reader["MiddleName"];
                    F.LastName = (string)reader["LastName"];
                    F.PhoneNo = (Int64)reader["PhoneNo"];
                    F.AdharNo = (Int64)reader["AdharNo"];
                    F.EmailId = (string)reader["EmailId"];
                    F.SocietyMembers = (string)reader["SocietyMembers"];
                    F.RoomNo = (int)reader["RoomNo"];
                    F.FloorNo = (int)reader["FloorNo"];
                    F.TypeOfRoom = (string)reader["TypeOfRoom"];
                    F.AreaOfRoom = (decimal)reader["AreaOfRoom"];
                    F.Isactive = (bool)reader["Isactive"];

                    listUsers.Add(F);

                }
            }

            connection.Close();
          
            return listUsers;
        }
        public Users GetUserDetailsById(int userId)
        {
            Users data = new Users();
           
            connection.Open();
            SqlCommand command = getSQLCommand("GetUserById");
            command.Parameters.AddWithValue("@Id", userId);

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
                    data.SocietyMembers = (string)reader["SocietyMembers"];
                    data.RoomNo = (int)reader["RoomNo"];
                    data.FloorNo = (int)reader["FloorNo"];
                    data.TypeOfRoom = (string)reader["TypeOfRoom"];
                    data.AreaOfRoom = (decimal)reader["AreaOfRoom"];
                    data.DesignationId = (int)reader["DesignationId"];
                    data.RoomsId = (int)reader["RoomsId"];
                    break;
                }
            }
            connection.Close();
            return data;
        }
        public bool UpdateUserDetails(Users data)
        {
            connection.Open();
            SqlCommand command = getSQLCommand("UpdateUsersDetails");
            
            command.Parameters.AddWithValue("@Id", data.Id);
            command.Parameters.AddWithValue("@FirstName", data.FirstName);
            command.Parameters.AddWithValue("@MiddleName", data.MiddleName);
            command.Parameters.AddWithValue("@LastName", data.LastName);
            command.Parameters.AddWithValue("@PhoneNo", data.PhoneNo);
            command.Parameters.AddWithValue("@AdharNo", data.AdharNo);
            command.Parameters.AddWithValue("@EmailId", data.EmailId);
            command.Parameters.AddWithValue("@RoomsId", data.RoomsId);
            command.Parameters.AddWithValue("@MembersId", data.DesignationId);

            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }
        public bool InsertUserDetails(Users data) 
        {
            
            connection.Open();
            SqlCommand command = getSQLCommand("InsertUsersDetails");
       
            command.Parameters.AddWithValue("@FirstName", data.FirstName);
            command.Parameters.AddWithValue("@MiddleName", data.MiddleName);
            command.Parameters.AddWithValue("@LastName", data.LastName);
            command.Parameters.AddWithValue("@PhoneNo", data.PhoneNo);
            command.Parameters.AddWithValue("@AdharNo", data.AdharNo);
            command.Parameters.AddWithValue("@EmailId", data.EmailId);
            command.Parameters.AddWithValue("@RoomsId", data.RoomsId);
            command.Parameters.AddWithValue("@MembersId", data.DesignationId);

            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        public bool UpdateUserAccess(int UserId, bool IsActive) 
        {
            bool result = false;

            connection.Open();
            SqlCommand command = getSQLCommand("UpdateUserAccess");
     

            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@IsActive", IsActive);


            command.ExecuteNonQuery();
            connection.Close();
            result = true;


            return result;
        }
        private SqlCommand getSQLCommand(string spName)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = spName;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            return command;
        }



    }



}