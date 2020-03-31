using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using DVDAPI.Models.Intefaces;
using DVDAPI.Models.Repos;

namespace DVDAPI.Models
{
    public static class Factory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "SampleData":
                    return new DvdRepositoryMock();
                case "EntityFramework":
                    return new DvdRepositoryEF();
                case "ADO":
                    return new DvdRepositoryADO();
                default:
                    throw new Exception("Configuration file is not configured correctly.");
            }
        }
    }
}