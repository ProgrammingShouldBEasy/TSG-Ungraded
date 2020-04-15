using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.ViewModels
{
    public class SalesReportViewModel
    {
        public SalesReportViewModel(string userName, int totalSales, int totalVehicles)
        {
            UserName = userName;
            TotalSales = totalSales;
            TotalVehicles = totalVehicles;
        }

        public SalesReportViewModel()
        {
            UserName = "";
            TotalSales = 0;
            TotalVehicles = 0;
        }

        public string UserName { get; set; }
        public int TotalSales { get; set; }
        public int TotalVehicles { get; set; }
    }
}