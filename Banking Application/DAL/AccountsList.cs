using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.IO;

namespace DAL
{
    public class AccountsList
    {
        private string MapAccountstoLine (Account account)
        {
            return $"{account.GetAccountName()}~{account.GetAccountNumber()}~{account.GetBalance()}~{account.GetDateCreated()}";
        }

        private void WriteAllAccounts (List<Account> accounts)
        {
            using (StreamWriter writer = new StreamWriter(@"accounts.txt"))
            {
                foreach (Account x in accounts)
                {
                    writer.WriteLine(MapAccountstoLine(x));
                }
            }
        }

        private Account MapLinetoAccount(string line)
        {
            string[] props = line.Split('~');
            Account account = new Account(int.Parse(props[1]), props[0], decimal.Parse(props[2]), props[3]);

            return account;        
        }

        private List<Account> ReadAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            using(StreamReader reader = new StreamReader(@"accounts.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    accounts.Add(MapLinetoAccount(line));
                }
            }
            return accounts;
        }

        public int Create(string name, decimal balance)
        {
            List<Account> Accounts = ReadAllAccounts();
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
            WriteAllAccounts(Accounts);
            return localInt;
        }

        public List<Account> RetrieveAllByName(string name)
        {
            List<Account> Accounts = ReadAllAccounts();
            return Accounts.FindAll(x => x.GetAccountName() == name);
        }

        public Account RetrieveOneByAccountNumber (int accountNumber)
        {
            List<Account> Accounts = ReadAllAccounts();
            return Accounts.FirstOrDefault(x => x.GetAccountNumber() == accountNumber);
        }

        public List<Account> RetrieveAll()
        {
            List<Account> Accounts = ReadAllAccounts();
            return Accounts;
        }

        public void Update(decimal change, int accountNumber)
        {
            List<Account> Accounts = ReadAllAccounts();
            Accounts.FirstOrDefault(x => x.GetAccountNumber() == accountNumber).UpdateBalance(change);
            WriteAllAccounts(Accounts);
        }

        public void Delete(int accountNumber)
        {
            List<Account> Accounts = ReadAllAccounts();
            Accounts.RemoveAll(x => x.GetAccountNumber() == accountNumber);
            WriteAllAccounts(Accounts);
        }
    }
}
