using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Responses
{
    public class ContactResponse
    {
        public ContactResponse(List<Contact> contacts, bool success, string message)
        {
            Contacts = contacts;
            Success = success;
            Message = message;
        }

        public ContactResponse()
        {
            Contacts = new List<Contact>();
            Success = false;
            Message = "";
        }

        public List<Contact> Contacts { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}