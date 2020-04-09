using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class Contact
    {
        public Contact(int id, string name, string email, string phone, string message)
        {
            this.id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Message = message;
        }

        public Contact()
        {
            this.id = 0;
            Name = "";
            Email = "";
            Phone = "";
            Message = "";
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}