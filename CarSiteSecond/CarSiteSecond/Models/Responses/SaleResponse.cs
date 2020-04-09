using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Responses
{
    public class SaleResponse
    {
        public SaleResponse(List<Sale> sales, bool success, string message)
        {
            Sales = sales;
            Success = success;
            Message = message;
        }

        public SaleResponse()
        {
            Sales = new List<Sale>();
            Success = false;
            Message = "";
        }

        public List<Sale> Sales { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}