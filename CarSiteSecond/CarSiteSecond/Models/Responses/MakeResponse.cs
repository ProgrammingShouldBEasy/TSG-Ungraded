using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Responses
{
    public class MakeResponse
    {
        public MakeResponse(List<Make> makes, bool success, string message)
        {
            Makes = makes;
            Success = success;
            Message = message;
        }

        public MakeResponse()
        {
            Makes = new List<Make>();
            Success = false;
            Message = "";
        }

        public List<Make> Makes { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}