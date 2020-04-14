using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Requests
{
    public class UserRoleRequest
    {
        public UserRoleRequest(List<UserRole> userRole, bool success, string message)
        {
            UserRoles = userRole;
            Success = success;
            Message = message;
        }

        public UserRoleRequest()
        {
            UserRoles = new List<UserRole>();
            Success = false;
            Message = "";
        }

        public List<UserRole> UserRoles { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}