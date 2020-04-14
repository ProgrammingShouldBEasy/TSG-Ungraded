using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string id, string lastName, string firstName, string email, string role)
        {
            this.id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Role = role;
        }

        public UserViewModel()
        {
            this.id = "";
            LastName = "";
            FirstName = "";
            Email = "";
            Role = "";
        }

        public string id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}