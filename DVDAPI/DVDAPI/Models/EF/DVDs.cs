using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDAPI.Models.EF
{
    public class DVDs
    {
        public int id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        public string notes { get; set; }
    }
}