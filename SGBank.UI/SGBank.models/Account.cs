using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.models;

namespace SGBank.models
{
    public class Account
    {
        private string _name;
        private int _number;
        private decimal _balance;
        private AccountType _Type;

        public Account(string name, int number, decimal balance, AccountType Type)
        {
            _name = name;
            _number = number;
            _balance = balance;
            _Type = Type;
        }
        public Account()
        {

        }
    }
}
