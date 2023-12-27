using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parth_CHS.Models
{
    public class ManageMaintenance
    {

        public int MaintenanceId { get; set; }
        public string Decribe { get; set; }
        public DateTime Entrydate { get; set; }
        public decimal Amount { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalAmountReceived { get; set; }
    }
}