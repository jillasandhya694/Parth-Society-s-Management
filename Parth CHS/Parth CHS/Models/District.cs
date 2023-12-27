using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parth_CHS.Models
{
    public class District
    {
        public int DistrictId { get; set; }
        public string District_ { get; set; }
        public int StateId { get; set; }
        public bool IsActive { get; set; }

    }
}