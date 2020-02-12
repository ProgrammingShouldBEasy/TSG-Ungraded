using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BLL;
using Utility_Classes;

namespace Banking_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            BankDB FirstNational = new BankDB();

            while (!quit)
            {

                int choice;
                int accountNumber = 0;
                decimal money = 0;
                string name = null;
                decimal balance = 0;

                Console.Clear();
                Console.WriteLine("Welcome to the First National Bank of TSG!");
                Console.WriteLine("Would you like to:\n" +
                                  "1. Create an Account.\n" +
                                  "2. Delete an Account.\n" +
                                  "3. Deposit funds.\n" +
                                  "4. Withdraw funds.\n" +
                                  "5. Get all accounts.\n" +
                                  "6. Get an account by name.\n" +
                                  "7. Get an account by Account Number.\n" +
                                  "8. Get all accounts with balance of $10,000 or greater.\n" +
                                  "9. Get the date that an account was created.\n" +
                                  "10. Quit.");
                choice = GetInput.ForInt(1, 10);
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("What is your name?");
                        name = Console.ReadLine();
                        int newAccountNumber = FirstNational.CreateAccount(name, 0m);
                        Console.WriteLine($"A new account has been created for {name} and the Account Number is {newAccountNumber}.");
                        break;
                    case 2:
                        Console.WriteLine("What the Account Number for the account you would like to delete?");
                        accountNumber = GetInput.ForInt();
                        if (FirstNational.DeleteAccount(accountNumber))
                        {
                            Console.WriteLine("The account has been successfully deleted.");
                        }
                        else
                        {
                            Console.WriteLine("There is no account by that number.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("How much would you like to deposit?");
                        money = GetInput.ForDecimal();
                        Console.WriteLine("What is the account number?");
                        accountNumber = GetInput.ForInt();
                        if (FirstNational.Deposit(money, accountNumber, out balance))
                        {
                            Console.WriteLine($"{name} has deposited ${money} and the new balance is {balance}.");
                        }

                        else
                        {
                            Console.WriteLine($"{name} cannot deposit ${money}, as that would leave a negative balance.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("How much would you like to deposit?");
                        money = GetInput.ForDecimal();
                        Console.WriteLine("What is the account number?");
                        accountNumber = GetInput.ForInt();
                        if (FirstNational.Withdraw(money, accountNumber, out balance))
                        {
                            Console.WriteLine($"{name} has deposited ${money} and the new balance is {balance}.");
                        }

                        else
                        {
                            Console.WriteLine($"{name} cannot deposit ${money}, as that would leave a negative balance.");
                        }
                        break;
                    case 5:
                        List<Account> AllAccounts = FirstNational.DisplayAllAccounts();
                        foreach (Account x in AllAccounts)
                        {
                            Console.WriteLine("=====================================================\n" +
                                              $"The Name on the Account is: {x.GetAccountName()}\n" +
                                              $"The Account Number is: {x.GetAccountNumber()}\n" +
                                              $"The Balance is: {x.GetBalance()}\n" +
                                              $"The Date Created is: " + x.GetDateCreated().Date.ToShortDateString() + "\n" +
                                              "=====================================================\n");
                        }
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        quit = true;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }

            Console.ReadLine();
        }
    }
}
