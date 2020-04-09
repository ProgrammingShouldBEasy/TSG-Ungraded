using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Requests
{
    public class SaleRequest
    {
        public SaleRequest(List<Sale> sales, bool success, string message)
        {
            Sales = sales;
            Success = success;
            Message = message;
        }

        public SaleRequest()
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