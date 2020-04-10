using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class Special
    {
        public Special(int id, string title, string text)
        {
            this.id = id;
            Title = title;
            Text = text;
        }

        public Special()
        {
            this.id = 0;
            Title = "";
            Text = "";
        }

        public int id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}