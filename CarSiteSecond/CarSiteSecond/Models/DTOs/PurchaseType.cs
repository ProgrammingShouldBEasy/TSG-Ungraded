using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class PurchaseType
    {
        public PurchaseType(int id, string type)
        {
            this.id = id;
            Type = type;
        }

        public PurchaseType()
        {
            this.id = 0;
            Type = "";
        }

        public int id { get; set; }
        public string Type { get; set; }
    }
}