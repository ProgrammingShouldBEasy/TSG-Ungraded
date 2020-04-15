using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.ViewModels
{
    public class InventoryViewModel
    {
        public InventoryViewModel(int year, string make, string model, int count, int stockValue)
        {
            Year = year;
            Make = make;
            Model = model;
            Count = count;
            StockValue = stockValue;
        }

        public InventoryViewModel()
        {
            Year = 0;
            Make = "";
            Model = "";
            Count = 0;
            StockValue = 0;
        }

        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Count { get; set; }
        public int StockValue { get; set; }
    }
}