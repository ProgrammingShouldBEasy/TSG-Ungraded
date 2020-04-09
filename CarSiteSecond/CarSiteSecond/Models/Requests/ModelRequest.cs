using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Requests
{
    public class ModelRequest
    {
        public ModelRequest(List<Model> models, bool success, string message)
        {
            Models = models;
            Success = success;
            Message = message;
        }

        public ModelRequest()
        {
            Models = new List<Model>();
            Success = false;
            Message = "";
        }

        public List<Model> Models { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
