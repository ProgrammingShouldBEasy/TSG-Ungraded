using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Item_Manager.Models;
using Item_Manager.Data;
using System.Configuration;

namespace Item_Manager.Logic
{
    public class FeaturesFactory
    {
        public static Features Create()
        {
            switch (ConfigurationManager.AppSettings["data"].ToLower())
            {
                case "prod":
                    return new Features(new BookRepository());
                case "test":
                    return new Features(new BookRepoTest());
                default:
                    return new Features(new BookRepository());

            }
        }
    }
}
