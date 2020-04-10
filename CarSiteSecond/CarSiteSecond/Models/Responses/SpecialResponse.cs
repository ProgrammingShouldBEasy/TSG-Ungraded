using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Responses
{
    public class SpecialResponse
    {
        public SpecialResponse(List<Special> specials, bool success, string message)
        {
            Specials = specials;
            Success = success;
            Message = message;
        }

        public SpecialResponse()
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