using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class Sale
    {
        public Sale(int id, int purchaseType, string name, string email, string street1, string street2, string city, string state, string zip, string phone, int carID, string userID, decimal purchasePrice)
        {
            this.id = id;
            PurchaseType = purchaseType;
            Name = name;
            Email = email;
            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            Zip = zip;
            Phone = phone;
            CarID = carID;
            UserID = userID;
            PurchasePrice = purchasePrice;
        }

        public Sale()
        {
            this.id = 0;
            PurchaseType = 0;
            Name = "";
            Email = "";
            Street1 = "";
            Street2 = "";
            City = "";
            State = "";
            Zip = "";
            Phone = "";
            CarID = 0;
            UserID = "";
            PurchasePrice = 0m;
        }

        public int id { get; set; }
        public int PurchaseType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public int CarID { get; set; }
        public string UserID { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}