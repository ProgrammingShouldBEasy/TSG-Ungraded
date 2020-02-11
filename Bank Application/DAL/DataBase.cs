using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class DataBase
    {
        List<Account> AccountsList = new List<Account> { new Account("John", 123, 1.00m), new Account("Johny", 124, 1.00m), new Account("Johnny", 125, 1.00m) };

        public Account GetAccount(int id)
        {
            Account result = null;

            foreach (Account x in AccountsList)
            {
                if (result.GetID() == id)
                {
                    result = x;
                }
            }
            return result;
        }
        public void ReplaceAccount (Account account, int id)
        {
            foreach (Account x in AccountsList)
            {
                if (x.GetID() == id)
                {
                    x = account;
                }
            }
        }

        public void RemoveAccount (Account account, int id)
        {
            foreach (Account x in AccountsList)
            {
                if (x.GetID() == id)
                {
                    AccountsList.Remove(x);
                }
            }
        }

        public void AddAccount (Account account, out string result)
        {
            bool isUnique = false;
            foreach (Account x in AccountsList)
            {
                if (x.GetID() == account.GetID())
                {
                    isUnique = false;
                }
            }

            if (isUnique == false)
            {
                result = "That Account ID has already been used, the account has not been added.";
            }

            else
            {
                result = "The Account has been added.";
            }
        }
    }
}
