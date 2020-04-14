using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.ViewModels
{
    public class ModelViewModel
    {
        public ModelViewModel(string make, string dateAdded, string user, string model, List<string> modelsList)
        {
            Make = make;
            DateAdded = dateAdded;
            User = user;
            Model = model;
            MakesList = modelsList;
        }

        public ModelViewModel()
        {
            Make = "";
            DateAdded = "";
            User = "";
            Model = "";
            MakesList = new List<string>();
        }

        public string Make { get; set; }
        public string DateAdded { get; set; }
        public string User { get; set; }
        public string Model { get; set; }
        public List<string> MakesList { get; set; }
    }
}