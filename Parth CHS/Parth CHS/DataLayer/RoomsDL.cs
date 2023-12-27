using Parth_CHS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parth_CHS.DataLayer
{
    public class RoomsDL
    {
        private SqlConnection connection;
        public RoomsDL()
        {
            connection = new SqlConnection("server = .; Database = ParthCHS; Trusted_Connection = True;");
        }
        public List<Rooms> GetAllRoomsDetails()
        {
            List<Rooms>listOFRooms = new List<Rooms>();

            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Getallrooms_data_SP";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Rooms data = new Rooms();
                    data.RoomsId = (int)reader["RoomsId"];
                    data.RoomNo = (int)reader["RoomNo"];
                    data.FloorNo = (int)reader["FloorNo"];
                    data.TypeOfRoom = (string)reader["TypeOfRoom"];
                    data.AreaOfRoom = (decimal)reader["AreaOfRoom"];
                    listOFRooms.Add(data);
                }
            }
            connection.Close();

            return listOFRooms;
        }

        
    }
}