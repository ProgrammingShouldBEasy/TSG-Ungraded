using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarSiteSecond.ViewModels
{
    public class HomeCarViewModel
    {
        public HomeCarViewModel(int id, string pictureSrc, int year, string make, string model, decimal price)
        {
            this.id = id;
            PictureSrc = pictureSrc;
            Year = year;
            Make = make;
            Model = model;
            Price = price;
        }

        public HomeCarViewModel()
        {
            id = 0;
            PictureSrc = "";
            Year = 0;
            Make = "";
            Model = "";
            Price = 0m;
        }

        public int id { get; set; }
        public string PictureSrc { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
    }
}