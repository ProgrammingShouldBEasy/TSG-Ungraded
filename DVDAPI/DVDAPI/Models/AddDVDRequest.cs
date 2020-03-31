using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DVDAPI.Models
{
    public class AddDVDRequest
    {
        //string title, string year, string director, string rating, string notes
        [Required]
        public string title { get; set; }
        [Required]
        public string releaseYear { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string rating { get; set; }
        public string notes { get; set; }
    }
}