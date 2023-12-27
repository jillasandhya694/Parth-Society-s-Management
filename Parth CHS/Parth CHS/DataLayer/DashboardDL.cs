using Parth_CHS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parth_CHS.DataLayer
{
    public class DashboardDL
    {
        private SqlConnection connection;

        public DashboardDL()
        {
            connection = new SqlConnection("server = .; Database = ParthCHS; Trusted_Connection = True;");
        }


        public List<DashboardModel> UserDashboardPaymentView(int a, int b) 
        {
            List<DashboardModel> list = new List<DashboardModel>();

            connection.Open();
            SqlCommand command = GetSqlCommand("GetUserYearlyDashboardPayment");
            command.Parameters.AddWithValue("@UserId", a);
            command.Parameters.AddWithValue("@Year", b);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    DashboardModel data = new DashboardModel();

                    data.Month = (int)reader["Month"];
                    data.Year = (int)reader["Year"];
                    data.Id = (int)reader["Id"];
                    data.Amount = (decimal)reader["Amount"];
                    data.BillDate = (DateTime)reader["BillDate"];
                    data.Status = (int)reader["Status"];

                    if (reader["PaymentDate"] != DBNull.Value)
                    {
                        data.PaymentDate = (DateTime)reader["PaymentDate"];
                    }
                    data.UserId = (int)reader["UserId"];
                    data.FirstName = (string)reader["FirstName"];
                    data.MiddleName = (string)reader["MiddleName"];
                    data.LastName = (string)reader["LastName"];

                    list.Add(data);


                }
            }
            connection.Close();



            return list;
        }

        public bool UpdatePayment(int Id)
        {
            connection.Open();
            SqlCommand command = GetSqlCommand("UpdatePaymentById");

            command.Parameters.AddWithValue("@Id", Id);
            
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        private SqlCommand GetSqlCommand(string spname)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = spname;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}