using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Requests
{
    public class RoleRequest
    {
        public RoleRequest(List<Role> roles, bool success, string message)
        {
            Roles = roles;
            Success = success;
            Message = message;
        }

        public RoleRequest()
        {
            Roles = new List<Role>();
            Success = false;
            Message = "";
        }

        public List<Role> Roles { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}