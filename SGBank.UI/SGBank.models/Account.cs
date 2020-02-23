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
        public string _name;
        public string _number;
        public decimal _balance;
        public AccountType _Type;

        public Account(string name, string number, decimal balance, AccountType Type)
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
