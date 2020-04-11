using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class Color
    {
        public Color(int id, string colorName)
        {
            this.id = id;
            ColorName = colorName;
        }

        public Color()
        {
            this.id = 0;
            ColorName = "";
        }

        public int id { get; set; }
        public string ColorName { get; set; }
    }
}