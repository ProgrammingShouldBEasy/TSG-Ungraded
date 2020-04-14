using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class ModelForView
    {
        public ModelForView(int id, string modelName, string makeName, DateTime dateAdded, string userID)
        {
            this.id = id;
            ModelName = modelName;
            MakeName = makeName;
            DateAdded = dateAdded;
            UserID = userID;
        }

        public ModelForView()
        {
            this.id = 0;
            ModelName = "";
            MakeName = "";
            DateAdded = DateTime.Now;
            UserID = "";
        }

        public int id { get; set; }
        public string ModelName { get; set; }
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserID { get; set; }
    }
}