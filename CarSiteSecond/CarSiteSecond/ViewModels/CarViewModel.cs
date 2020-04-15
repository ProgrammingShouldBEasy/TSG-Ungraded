using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarSiteSecond.ViewModels
{
    public class CarViewModel
    {
        public CarViewModel()
        {
            this.id = 0;
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
            UploadedFile = null;
    }

        public CarViewModel(int id, int year, string bodyStyle, string trans, string color, string interior, int mileage, string vIN, decimal salePrice, decimal mSRP, string description, string pictureSrc, string make, string model, HttpPostedFileBase file)
        {
            this.id = id;
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
            UploadedFile = file;
        }

        public int id { get; set; }
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
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}