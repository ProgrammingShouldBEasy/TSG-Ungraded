using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class User
    {
        public User(string id, string email, string phoneNumber, string firstName, string lastName)
        {
            Id = id;
            Email = email;
            EmailConfirmed = false;
            PasswordHash = "";
            SecurityStamp = "";
            PhoneNumber = phoneNumber;
            PhoneNumberConfirmed = false;
            TwoFactorEnabled = false;
            LockoutEndDateUtc = DateTime.Now;
            LockOutEnabled = false;
            AccessFailedCount = 0;
            FirstName = firstName;
            LastName = lastName;
        }

        public User()
        {
            Id = "";
            Email = "";
            EmailConfirmed = false;
            PasswordHash = "";
            SecurityStamp = "";
            PhoneNumber = "";
            PhoneNumberConfirmed = false;
            TwoFactorEnabled = false;
            LockoutEndDateUtc = DateTime.Now;
            LockOutEnabled = false;
            AccessFailedCount = 0;
            FirstName = "";
            LastName = "";
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public bool LockOutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}