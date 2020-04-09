using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Requests
{
    public class MakeRequest
    {
        public MakeRequest(List<Make> makes, bool success, string message)
        {
            Makes = makes;
            Success = success;
            Message = message;
        }

        public MakeRequest()
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