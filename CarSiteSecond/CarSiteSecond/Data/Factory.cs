using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.Interfaces;
using CarSiteSecond.Data.Repos;

namespace CarSiteSecond.Data
{
    static public class Factory
    {
        static public IRepo Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "QA":
                    return new CarSiteRepoQA();
                case "PROD":
                    return new CarSiteRepoProduction();
                default:
                    throw new Exception("Configuration file is not configured correctly.");
            }
        }
    }    
}