using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDAPI.Models.POCOs;

namespace DVDAPI.Models.Responses
{
    public class ResponseDVDs
    {
        public List<DVD> DVDs { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResponseDVDs()
        {
            DVDs = new List<DVD>();
            Success = false;
            Message = "";
        }

        public ResponseDVDs(List<DVD> dVDs, bool success, string message)
        {
            DVDs = dVDs;
            Success = success;
            Message = message;
        }
    }
}