using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Requests
{
    public class CarRequest
    {
        public CarRequest(List<Car> cars, bool success, string message)
        {
            Cars = cars;
            Success = success;
            Message = message;
        }

        public CarRequest()
        {
            Cars = new List<Car>();
            Success = false;
            Message = "";
        }

        public List<Car> Cars { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}