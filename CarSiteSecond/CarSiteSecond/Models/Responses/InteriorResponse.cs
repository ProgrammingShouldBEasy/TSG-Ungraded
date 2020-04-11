using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Responses
{
    public class InteriorResponse
    {
        public InteriorResponse(List<Interior> interiors, bool success, string message)
        {
            Interiors = interiors;
            Success = success;
            Message = message;
        }

        public InteriorResponse()
        {
            Interiors = new List<Interior>();
            Success = false;
            Message = "";
        }

        public List<Interior> Interiors { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}