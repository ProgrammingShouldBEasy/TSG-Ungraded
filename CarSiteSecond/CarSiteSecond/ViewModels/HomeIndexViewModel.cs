using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.ViewModels;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.ViewModels
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel(List<HomeCarViewModel> hMCVMs, List<Special> specials)
        {
            HMCVMs = hMCVMs;
            Specials = specials;
        }

        public HomeIndexViewModel()
        {
            HMCVMs = new List<HomeCarViewModel>();
            Specials = new List<Special>();
        }

        public List<HomeCarViewModel> HMCVMs { get; set; }
        public List<Special> Specials { get; set; }
    }
}