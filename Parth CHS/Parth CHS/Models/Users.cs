using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parth_CHS.Models
{
    public class Users
    {
        public int Id  { get; set; } 
        public int RoomsId { get; set; } 
        public int DesignationId { get; set; } 
        public string FirstName { get; set; } 
        public string MiddleName { get; set; } 
        public string LastName { get; set; } 
        public Int64 PhoneNo { get; set; } 
        public Int64 AdharNo { get; set; } 
        public string EmailId { get; set; } 
        //public int MembersId { get; set; } 
        public string SocietyMembers { get; set; } 
        public int RoomNo { get; set; } 
        public int FloorNo { get; set; } 
        public string TypeOfRoom { get; set; } 
        public decimal AreaOfRoom { get; set; } 
        public bool Isactive { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; } 


    }
}