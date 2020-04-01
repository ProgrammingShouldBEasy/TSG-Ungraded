using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDAPI.Models.POCOs
{
    public class DVD
    {
        public int dvdId { get; set; }
        public string title { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        public int releaseYear { get; set; }
        public string notes { get; set; }

        public DVD()
        {
            dvdId = 0;
            title = "";
            director = "";
            rating = "";
            releaseYear = 1990;
            notes = "";
        }
        public DVD(int dvdIda, string titlea, string directora, string ratinga, int releaseYeara, string notesa)
        {
            dvdId = dvdIda;
            title = titlea;
            director = directora;
            rating = ratinga;
            releaseYear = releaseYeara;
            notes = notesa;
        }
    }
}