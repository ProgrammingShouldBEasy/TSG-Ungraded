using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Requests
{
    public class ContactRequest
    {
        public ContactRequest(List<Contact> contacts, bool success, string message)
        {
            Contacts = contacts;
            Success = success;
            Message = message;
        }

        public ContactRequest()
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