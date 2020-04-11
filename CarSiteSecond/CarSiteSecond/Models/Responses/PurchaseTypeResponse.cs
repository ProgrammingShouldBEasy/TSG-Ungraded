using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Responses
{
    public class PurchaseTypeResponse
    {
        public PurchaseTypeResponse(List<PurchaseType> purchaseTypes, bool success, string message)
        {
            PurchaseTypes = purchaseTypes;
            Success = success;
            Message = message;
        }

        public PurchaseTypeResponse()
        {
            PurchaseTypes = new List<PurchaseType>();
            Success = false;
            Message = "";
        }

        public List<PurchaseType> PurchaseTypes { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}