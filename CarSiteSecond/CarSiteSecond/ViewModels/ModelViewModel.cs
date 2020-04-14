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
            ModelsList = modelsList;
        }

        public ModelViewModel()
        {
            Make = "";
            DateAdded = "";
            User = "";
            Model = "";
            ModelsList = new List<string>();
        }

        public string Make { get; set; }
        public string DateAdded { get; set; }
        public string User { get; set; }
        public string Model { get; set; }
        public List<string> ModelsList { get; set; }
    }
}