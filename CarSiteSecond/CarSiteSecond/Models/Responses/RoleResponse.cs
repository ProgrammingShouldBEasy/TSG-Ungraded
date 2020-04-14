using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Responses
{
    public class RoleResponse
    {
        public RoleResponse(List<Role> roles, bool success, string message)
        {
            Roles = roles;
            Success = success;
            Message = message;
        }

        public RoleResponse()
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