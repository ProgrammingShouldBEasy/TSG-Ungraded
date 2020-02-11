using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Account
    {
        private static int _nextID = 0;
        private string _name;
        private int _id;
        private decimal _balance;
        private int _accountNumber;

        public Account(string name, int accountNumber, decimal balance)
        {
            _nextID++;
            _id = _nextID;
            _name = name;
            _balance = balance;
            _accountNumber = accountNumber;
        }

        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }

        public int GetID()
        {
            return _id;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void SetBalance(decimal change)
        {
            if ((_balance + change) < 0)
            {
                _balance += change;
            }
        }

        public int GetAccountNumber()
        {
            return _accountNumber;
        }

        public void SetAccountNumber(int accountNumber)
        {
            if (accountNumber < 0)
            {
                _accountNumber = accountNumber;
            }
        }
    }
}
