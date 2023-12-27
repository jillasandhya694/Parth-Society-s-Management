using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parth_CHS.Models
{
    public class PaymentModel
    {
        
        public int Month { get; set; }
        public int Year { get; set; }
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillDate { get; set; }
        public int Status { get; set; }
        public DateTime PaymentDate { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

    }
}