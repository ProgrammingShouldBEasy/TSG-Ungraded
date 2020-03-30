using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDAPI.Models.POCOs
{
    public class DVD
    {
        public int DvdId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Notes { get; set; }

        public DVD()
        {
            DvdId = 0;
            Title = "";
            Director = "";
            Rating = "";
            ReleaseYear = DateTime.Now;
            Notes = "";
        }
        public DVD(int dvdId, string title, string director, string rating, DateTime releaseYear, string notes)
        {
            DvdId = dvdId;
            Title = title;
            Director = director;
            Rating = rating;
            ReleaseYear = releaseYear;
            Notes = notes;
        }
    }
}