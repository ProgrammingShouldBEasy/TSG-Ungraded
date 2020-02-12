using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class AccountsList
    {
        public List<Account> Accounts = new List<Account> { new Account(1, "John", 1.00m), new Account(2, "Johnn", 100m), new Account(3, "Johnny", 100000m) };

        public int Create(string name, decimal balance)
        {
            Random localRandom = new Random();
            int localInt = 0;
            bool isUnique = false;
            while (!isUnique)
            {
                localInt = localRandom.Next(0, 9999999);
                if (Accounts.FirstOrDefault(x => x.GetAccountNumber() == localInt) == null)
                {
                    isUnique = true;
                }

                else
                {
                    isUnique = false;
                }
            }

            Accounts.Add(new Account(localInt, name, balance));
            return localInt;
        }

        public Account RetrieveOneByName(string name)
        {
            return Accounts.FirstOrDefault(x => x.GetAccountName() == name);
        }

        public Account RetrieveOneByAccountNumber (int accountNumber)
        {
            return Accounts.FirstOrDefault(x => x.GetAccountNumber() == accountNumber);
        }

        public List<Account> RetrieveAll()
        {
            return Accounts.Where(x => x.GetBalance() >= 0).ToList();
        }

        public void Update(decimal change, int accountNumber)
        {
            Accounts.FirstOrDefault(x => x.GetAccountNumber() == accountNumber).UpdateBalance(change);
        }

        public void Delete(int accountNumber)
        {
            Accounts.RemoveAll(x => x.GetAccountNumber() == accountNumber);
        }
    }
}
