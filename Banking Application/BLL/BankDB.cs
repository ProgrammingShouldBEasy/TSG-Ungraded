using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class BankDB
    {
        AccountsList DataBase = new AccountsList();

        public bool Withdraw(decimal change, int accountNumber, out decimal balance)
        {
            Account localAccount = DataBase.RetrieveOneByAccountNumber(accountNumber);
            if ((localAccount.GetBalance() - change) >= 0)
            {
                DataBase.Update(-change, accountNumber);
                balance = localAccount.GetBalance();
                return true;
            }

            balance = localAccount.GetBalance();
            return false;
        }

        public bool Deposit(decimal change, int accountNumber, out decimal balance)
        {
            Account localAccount = DataBase.RetrieveOneByAccountNumber(accountNumber);
            if ((localAccount.GetBalance() + change) >= 0)
            {
                DataBase.Update(change, accountNumber);
                balance = localAccount.GetBalance();
                return true;
            }

            balance = localAccount.GetBalance();
            return false;
        }

        public List<Account> GetHighRollers()
        {
            return DataBase.RetrieveAll().Where(x => x.GetBalance() >= 10000).ToList();
        }

        public List<Account> DisplayAccountByName(string name)
        {
            return DataBase.RetrieveAllByName(name);
        }

        public Account DisplayAccountByNumber(int accountNumber)
        {
            return DataBase.RetrieveOneByAccountNumber(accountNumber);
        }

        public List<Account> DisplayAllAccounts()
        {
           return DataBase.RetrieveAll();
        }
        public int CreateAccount(string name, decimal balance)
        {
            return DataBase.Create(name, balance);
        }

        public bool DeleteAccount(int accountNumber)
        {
            if (DataBase.RetrieveOneByAccountNumber(accountNumber) != null)
            {
                DataBase.Delete(accountNumber);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}