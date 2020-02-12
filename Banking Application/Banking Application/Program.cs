using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BLL;

namespace Banking_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            BankDB FirstNational = new BankDB();

            Console.WriteLine("Welcome to the First National Bank of TSG!");
            Console.WriteLine("Would you like to Create an account, Deposit funds, Withdraw funds, find all the accounts with a balance of $10,000 or greater, Delete an account, ");

            Console.ReadLine();
        }
    }
}
