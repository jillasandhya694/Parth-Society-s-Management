using Parth_CHS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parth_CHS.DataLayer
{
    public class SocietyMemberDL
    {
        public SqlConnection connection;
        public SocietyMemberDL() 
        {
            connection = new SqlConnection("server = .; Database = ParthCHS; Trusted_Connection = True;");
        }
        public List<SocietyMember> GetAllSocietyMembers()

        {
            List<SocietyMember> designationList = new List<SocietyMember>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "GetallSocietyMembers_data_SP";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    SocietyMember data = new SocietyMember();
                    data.Id = (int)reader["Id"];
                    data.SocietyMembers = (string)reader["SocietyMembers"];
                    designationList.Add(data);
                }
            }
            connection.Close();
            return designationList;
        }
    }
}