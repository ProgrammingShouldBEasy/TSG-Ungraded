using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.ViewModels
{
    public class VehicleViewModel
    {
        public VehicleViewModel(int id, List<string> make, List<string> model, List<string> type, string bodyStyle, int year, string transmission, List<string> color, List<string> interior, int mileage, string vIN, int mSRP, int salePrice, string description, bool featured, string pictureSrc, HttpPostedFileBase fileBase)
        {
            this.id = id;
            Make = make;
            Model = model;
            Type = type;
            BodyStyle = bodyStyle;
            Year = year;
            Transmission = transmission;
            Color = color;
            Interior = interior;
            Mileage = mileage;
            VIN = vIN;
            MSRP = mSRP;
            SalePrice = salePrice;
            Description = description;
            Featured = featured;
            PictureSrc = pictureSrc;
            UploadedFile = fileBase;
        }

        public VehicleViewModel()
        {
            id = 0;
            Make = new List<string>();
            Model = new List<string>();
            Type = new List<string>();
            BodyStyle = "";
            Year = 0;
            Transmission = "";
            Color = new List<string>();
            Interior = new List<string>();
            Mileage = 0;
            VIN = "";
            MSRP = 0;
            SalePrice = 0;
            Description = "";
            Featured = false;
            PictureSrc = "";
            UploadedFile = null;
            Purchased = false;
        }

        public int id { get; set; }
        public List<string> Make { get; set; }
        public List<string> Model { get; set; }
        public List<string> Type { get; set; }
        public string BodyStyle { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public List<string> Color { get; set; }
        public List<string> Interior { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public int MSRP { get; set; }
        public int SalePrice { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
        public string PictureSrc { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
        public bool Purchased { get; set; }
    }
}