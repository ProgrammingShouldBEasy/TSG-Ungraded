using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.DTOs
{
    public class User
    {
        public User(string id, string email, string phoneNumber, string userName)
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
            UserName = userName;
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
            UserName = "";
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
        public string UserName { get; set; }
    }
}