using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Responses
{
    public class UserResponse
    {
        public UserResponse(List<User> users, bool success, string message)
        {
            Users = users;
            Success = success;
            Message = message;
        }

        public UserResponse()
        {
            Users = new List<User>();
            Success = false;
            Message = "";
        }

        public List<User> Users { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}