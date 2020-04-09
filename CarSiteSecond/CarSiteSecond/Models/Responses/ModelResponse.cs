using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Responses
{
    public class ModelResponse
    {
        public ModelResponse(List<Model> models, bool success, string message)
        {
            Models = models;
            Success = success;
            Message = message;
        }

        public ModelResponse()
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