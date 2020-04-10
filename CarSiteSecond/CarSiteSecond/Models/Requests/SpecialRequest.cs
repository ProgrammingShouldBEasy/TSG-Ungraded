using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Requests
{
    public class SpecialRequest
    {
        public SpecialRequest(List<Special> specials, bool success, string message)
        {
            Specials = specials;
            Success = success;
            Message = message;
        }

        public SpecialRequest()
        {
            Specials = new List<Special>();
            Success = false;
            Message = "";
        }

        public List<Special> Specials { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}