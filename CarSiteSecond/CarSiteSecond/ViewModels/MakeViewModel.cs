using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.ViewModels
{
    public class MakeViewModel
    {
        public MakeViewModel(string make, string dateAdded, string user)
        {
            Make = make;
            DateAdded = dateAdded;
            User = user;
        }

        public MakeViewModel()
        {
            Make = "";
            DateAdded = "";
            User = "";
        }

        public string Make { get; set; }
        public string DateAdded { get; set; }
        public string User { get; set; }
    }
}