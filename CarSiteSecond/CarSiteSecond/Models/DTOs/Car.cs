using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class Car
    {
        public Car(int id, int modelID, int year, string bodyStyle, string transmission, string pictureSrc, int interiorID, int mileage, string vIN, decimal salePrice, decimal mSRP, bool featured, int colorID, string description)
        {
            this.id = id;
            ModelID = modelID;
            Year = year;
            BodyStyle = bodyStyle;
            Transmission = transmission;
            PictureSrc = pictureSrc;
            InteriorID = interiorID;
            Mileage = mileage;
            VIN = vIN;
            SalePrice = salePrice;
            MSRP = mSRP;
            Featured = featured;
            ColorID = colorID;
            Description = description;
        }

        public Car()
        {
            this.id = 0;
            ModelID = 0;
            Year = 0;
            BodyStyle = "";
            Transmission = "";
            PictureSrc = "";
            InteriorID = 0;
            Mileage = 0;
            VIN = "";
            SalePrice = 0m;
            MSRP = 0m;
            Featured = false;
            ColorID = 0;
            Description = "";
        }

        public int id { get; set; }
        public int ModelID { get; set; }
        public int Year { get; set; }
        public string BodyStyle { get; set; }
        public string Transmission { get; set; }
        public string PictureSrc { get; set; }
        public int InteriorID { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public bool Featured { get; set; }
        public int ColorID { get; set; }
        public string Description { get; set; }
    }
}