using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parth_CHS.Models
{
    public class Rooms
    {
        public int RoomsId { get; set; }
        public int RoomNo { get; set; }
        public int FloorNo { get; set; }
        public string TypeOfRoom { get; set; }
        public decimal AreaOfRoom { get; set; }
    }
}