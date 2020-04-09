using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class Model
    {
        public Model(int id, string modelName, int makeID, DateTime dateAdded, string userID)
        {
            this.id = id;
            ModelName = modelName;
            MakeID = makeID;
            DateAdded = dateAdded;
            UserID = userID;
        }

        public Model()
        {
            this.id = 0;
            ModelName = "";
            MakeID = 0;
            DateAdded = DateTime.Now;
            UserID = "";
        }

        public int id { get; set; }
        public string ModelName { get; set; }
        public int MakeID { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserID { get; set; }
    }
}