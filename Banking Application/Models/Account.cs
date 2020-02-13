using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Account
    {
        private int _accountNumber;
        private string _customerName;
        private decimal _balance;
        readonly DateTime _DateCreated = DateTime.Now;

        public Account (int accountNumber, string name, decimal balance)
        {
            _accountNumber = accountNumber;
            _customerName = name;
            _balance = balance;
        }

        public Account (int accountNumber, string name, decimal balance, string localDate)
        {
            _accountNumber = accountNumber;
            _customerName = name;
            _balance = balance;
            _DateCreated = DateTime.Parse(localDate);
        }

        public DateTime GetDateCreated()
        {
            return _DateCreated;
        }

        public decimal UpdateBalance(decimal change)
        {
            if ((_balance += change) < 0)
            {
                _balance += change;
            }

            return _balance;
        }

        public decimal GetBalance()
        {
            return _balance;
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

        public string GetAccountName()
        {
            return _customerName;
        }

        public void SetAccountName(string name)
        {
            _customerName = name;
        }
    }
}
