using Parth_CHS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parth_CHS.DataLayer
{
    public class PaymentDL
    {
        private SqlConnection connection;

        public PaymentDL()
        {
            connection = new SqlConnection("server = .; Database = ParthCHS; Trusted_Connection = True;");
        }


        public List<PaymentModel> GetOwnersShareDetails(int Month, int Year)
        {
            List<PaymentModel> list = new List<PaymentModel>();

            connection.Open();
            SqlCommand command = GetSqlCommand("GetOwnersMonthlyShareTblwithUsers");
            command.Parameters.AddWithValue("@Month", Month);
            command.Parameters.AddWithValue("@Year", Year);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    PaymentModel data = new PaymentModel();

                    data.Month = (int)reader["Month"];
                    data.Year = (int)reader["Year"];
                    data.Id = (int)reader["Id"];
                    data.Amount = (decimal)reader["Amount"];
                    data.BillDate = (DateTime)reader["BillDate"];
                    data.Status = (int)reader["Status"];

                    if (reader["PaymentDate"] != DBNull.Value) {
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