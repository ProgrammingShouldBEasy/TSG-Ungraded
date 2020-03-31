using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DVDAPI.Models.POCOs;
using System.Data.SqlClient;

namespace DVDAPI.Models.EF
{
    public class DVDEntities : DbContext
    {
        public DVDEntities()
            : base("EF")
        { 
        }

        public DbSet<DVDs> DVDs { get; set; }
    }
}