using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class Make
    {
        public Make(int id, string makeName, DateTime dateAdded, int myProperty, string userID)
        {
            this.id = id;
            MakeName = makeName;
            DateAdded = dateAdded;
            MyProperty = myProperty;
            UserID = userID;
        }

        public Make()
        {
            this.id = 0;
            MakeName = "";
            DateAdded = DateTime.Now;
            MyProperty = 0;
            UserID = "";
        }

        public int id { get; set; }
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public int MyProperty { get; set; }
        public string UserID { get; set; }
    }
}