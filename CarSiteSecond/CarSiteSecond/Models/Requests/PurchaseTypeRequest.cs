using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Requests
{
    public class PurchaseTypeRequest
    {
        public PurchaseTypeRequest(List<PurchaseType> purchaseTypes, bool success, string message)
        {
            PurchaseTypes = purchaseTypes;
            Success = success;
            Message = message;
        }

        public PurchaseTypeRequest()
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