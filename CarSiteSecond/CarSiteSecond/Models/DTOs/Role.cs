using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class Role
    {
        public Role(string userID, string roleID)
        {
            UserID = userID;
            RoleID = roleID;
        }

        public Role()
        {
            UserID = "";
            RoleID = "";
        }

        public string UserID { get; set; }
        public string RoleID { get; set; }
    }
}