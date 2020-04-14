using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class UserRole
    {
        public UserRole(string id, string roleName)
        {
            this.id = id;
            RoleName = roleName;
        }

        public UserRole()
        {
            this.id = "";
            RoleName = "";
        }

        public string id { get; set; }
        public string RoleName { get; set; }
    }
}