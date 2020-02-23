using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SGBank.DAL;

namespace SGBank.BLL
{
    public static class AccountManagerFactory
    {
        public static AccountManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
