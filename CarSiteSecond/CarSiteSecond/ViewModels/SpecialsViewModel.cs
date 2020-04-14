using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.ViewModels
{
    public class SpecialsViewModel
    {
        public SpecialsViewModel(string title, string description, List<Special> specials)
        {
            Title = title;
            Description = description;
            Specials = specials;
        }

        public SpecialsViewModel()
        {
            Title = "";
            Description = "";
            Specials = new List<Special>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public List<Special> Specials { get; set; }
    }
}