using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarSiteSecond.ViewModels
{
    public class PurchaseViewModel
    {
        public PurchaseViewModel(int carId, int year, string bodyStyle, string trans, string color, string interior, int mileage, string vIN, decimal salePrice, decimal mSRP, string description, string pictureSrc, string make, string model, string email, string street1, string street2, string city, string state, string zip, string phone, string cusName, string saleName, decimal purchasePrice, List<string> purchaseTypes)
        {
            this.carId = carId;
            Year = year;
            BodyStyle = bodyStyle;
            Trans = trans;
            Color = color;
            Interior = interior;
            Mileage = mileage;
            VIN = vIN;
            SalePrice = salePrice;
            MSRP = mSRP;
            Description = description;
            PictureSrc = pictureSrc;
            Make = make;
            Model = model;
            Email = email;
            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            Zip = zip;
            Phone = phone;
            CusName = cusName;
            SaleId = saleName;
            PurchasePrice = purchasePrice;
            PurchaseTypes = purchaseTypes;
        }

        public PurchaseViewModel()
        {
            this.carId = 0;
            Year = 0;
            BodyStyle = "";
            Trans = "";
            Color = "";
            Interior = "";
            Mileage = 0;
            VIN = "";
            SalePrice = 0m;
            MSRP = 0m;
            Description = "";
            PictureSrc = "";
            Make = "";
            Model = "";
            Email = "";
            Street1 = "";
            Street2 = "";
            City = "";
            State = "";
            Zip = "";
            Phone = "";
            CusName = "";
            SaleId = "";
            PurchasePrice = 0m;
            PurchaseTypes = new List<string>();
        }

        public int carId { get; set; }
        public int Year { get; set; }
        public string BodyStyle { get; set; }
        public string Trans { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        [DisplayFormat(DataFormatString = "{0:n}", ApplyFormatInEditMode = true)]
        public int Mileage { get; set; }
        public string VIN { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public decimal SalePrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public decimal MSRP { get; set; }
        public string Description { get; set; }
        public string PictureSrc { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string CusName { get; set; }
        public string SaleId { get; set; }
        public decimal PurchasePrice { get; set; }
        public List<string> PurchaseTypes { get; set; }

    }
}