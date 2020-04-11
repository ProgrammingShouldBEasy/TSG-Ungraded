using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class Interior
    {
        public Interior(int id, string interiorName)
        {
            this.id = id;
            InteriorName = interiorName;
        }

        public Interior()
        {
            this.id = 0;
            InteriorName = "";
        }

        public int id { get; set; }
        public string InteriorName { get; set; }
    }
}