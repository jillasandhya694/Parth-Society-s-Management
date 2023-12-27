using Parth_CHS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parth_CHS.DataLayer
{
    public class MaintenanceDL
    {
        private SqlConnection connection;

        public MaintenanceDL()
        {
            connection = new SqlConnection("server = .; Database = ParthCHS; Trusted_Connection = True;");
        }

        public List<ManageMaintenance> GetMaintenanceByDates(DateTime startdate, DateTime enddate) 
        {
            List<ManageMaintenance> list = new List<ManageMaintenance>();

            connection.Open();
            SqlCommand command = GetSqlCommand("GetdataByDate_Manage_Maintenance");
            command.Parameters.AddWithValue("@Startdate", startdate);
            command.Parameters.AddWithValue("@Enddate", enddate);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    ManageMaintenance data = new ManageMaintenance();

                    data.MaintenanceId = (int)reader["MaintenanceId"];
                    data.Decribe = (string)reader["Decribe"];
                    data.Entrydate = (DateTime)reader["Entrydate"];
                    data.Amount = (decimal)reader["Amount"];

                    list.Add(data);


                }
            }
            connection.Close();
            return list;
        }

        public bool InsertMaintenanceDetails(ManageMaintenance data) 
        {
            connection.Open();
            SqlCommand command = GetSqlCommand("InsertIntoManage_Maintenance");
            command.Parameters.AddWithValue("@Decribe", data.Decribe);
            command.Parameters.AddWithValue("@Entrydate", data.Entrydate);
            command.Parameters.AddWithValue("@Amount", data.Amount);

            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }


        public ManageMaintenance GetGMSumRecordBySP(int Month, int Year) 
        {
            ManageMaintenance data =  null;

            connection.Open();
            SqlCommand command = GetSqlCommand("GetSum_MM_By_Month_Year");
            command.Parameters.AddWithValue("@Month", Month);
            command.Parameters.AddWithValue("@Year", Year);
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    data = new ManageMaintenance();
                    data.Month = (int)reader["Monthz"];
                    data.Year = (int)reader["Yearz"];
                    data.DateCreated = (DateTime)reader["DateCorrected"];
                    data.TotalAmount = (decimal)reader["TotalAmount"];
                    data.TotalAmountReceived = (int)reader["TotalReceived"];

                    break;
                }
                
            }
            connection.Close();
            return data;
        }
        public bool InsertTotalMaintenanRecord(int Month, int Year, DateTime startdate, DateTime enddate)
        {
            connection.Open();
            SqlCommand command = GetSqlCommand("InsertIntoTotalMaintainance");
            command.Parameters.AddWithValue("@Month", Month);
            command.Parameters.AddWithValue("@Year", Year);
            command.Parameters.AddWithValue("@Startdate", startdate);
            command.Parameters.AddWithValue("@Enddate", enddate);

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