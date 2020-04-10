using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSiteSecond.Models.Identity
{
    public class CarSiteDbContext : IdentityDbContext<AppUser>
    {
        public CarSiteDbContext() : base("CarSite")
        {

        }
    }
}