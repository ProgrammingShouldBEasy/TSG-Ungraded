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
                int accountNumber;
                decimal money;
                string name;
                decimal balance;

                Console.Clear();
                Console.WriteLine("Welcome to the First National Bank of TSG!");
                Console.WriteLine("Would you like to:\n" +
                                  "1. Create an Account.\n" +
                                  "2. Delete an Account.\n" +
                                  "3. Deposit funds.\n" +
                                  "4. Withdraw funds.\n" +
                                  "5. Get all accounts.\n" +
                                  "6. Get all accounts by name.\n" +
                                  "7. Get an account by Account Number.\n" +
                                  "8. Get all accounts with balance of $10,000 or greater.\n" +
                                  "9. Quit.");
                choice = GetInput.ForInt(1, 9);
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
                        money = GetInput.ForDecimal(0, int.MaxValue);
                        Console.WriteLine("What is the account number?");
                        accountNumber = GetInput.ForInt();
                        if (FirstNational.Deposit(money, accountNumber, out balance))
                        {
                            Console.WriteLine(FirstNational.DisplayAccountByNumber(accountNumber).GetAccountName() + $" has deposited {money:C} and the new balance is {balance:C}.");
                        }

                        else
                        {
                            Console.WriteLine(FirstNational.DisplayAccountByNumber(accountNumber).GetAccountName() + $" cannot deposit {money:C}, as that would leave a negative balance.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("How much would you like to withdraw?");
                        money = GetInput.ForDecimal(0, int.MaxValue);
                        Console.WriteLine("What is the account number?");
                        accountNumber = GetInput.ForInt();
                        if (FirstNational.Withdraw(money, accountNumber, out balance))
                        {
                            Console.WriteLine(FirstNational.DisplayAccountByNumber(accountNumber).GetAccountName() + $" has withdrawn {money:C} and the new balance is {balance:C}.");
                        }

                        else
                        {
                            Console.WriteLine(FirstNational.DisplayAccountByNumber(accountNumber).GetAccountName() + $" cannot withdraw {money:C}, as that would leave a negative balance.");
                        }
                        break;
                    case 5:
                        foreach (Account a in FirstNational.DisplayAllAccounts())
                        {
                            Console.WriteLine("=====================================================\n" +
                                              $"The Name on the Account is: {a.GetAccountName()}\n" +
                                              $"The Account Number is: {a.GetAccountNumber()}\n" +
                                              $"The Balance is: {a.GetBalance():C}\n" +
                                              $"The Date Created is: " + a.GetDateCreated() + "\n" +
                                              "=====================================================\n");
                        }
                        break;
                    case 6:
                        Console.WriteLine("What is the name on the account you would like displayed?");
                        name = Console.ReadLine();
                        List<Account> accounts = FirstNational.DisplayAccountByName(name);
                        if (accounts.Count() != 0)
                        {
                            foreach (Account x in accounts)
                            {
                                Console.WriteLine("=====================================================\n" +
                                                  $"The Name on the Account is: {x.GetAccountName()}\n" +
                                                  $"The Account Number is: {x.GetAccountNumber()}\n" +
                                                  $"The Balance is: {x.GetBalance():C}\n" +
                                                  $"The Date Created is: " + x.GetDateCreated() + "\n" +
                                                  "=====================================================\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no account by that name.");
                        }
                        break;
                    case 7:
                        Console.WriteLine("What is the name on the account you would like displayed?");
                        accountNumber = GetInput.ForInt();
                        Account z = FirstNational.DisplayAccountByNumber(accountNumber);
                        if (z != null)
                        {
                            Console.WriteLine("=====================================================\n" +
                                              $"The Name on the Account is: {z.GetAccountName()}\n" +
                                              $"The Account Number is: {z.GetAccountNumber()}\n" +
                                              $"The Balance is: {z.GetBalance():C}\n" +
                                              $"The Date Created is: " + z.GetDateCreated() + "\n" +
                                              "=====================================================\n");
                        }
                        else
                        {
                            Console.WriteLine("There is no account by that name.");
                        }
                        break;
                    case 8:
                        foreach (Account y in FirstNational.GetHighRollers())
                        {
                            Console.WriteLine("=====================================================\n" +
                                              $"The Name on the Account is: {y.GetAccountName()}\n" +
                                              $"The Account Number is: {y.GetAccountNumber()}\n" +
                                              $"The Balance is: {y.GetBalance()}\n" +
                                              $"The Date Created is: " + y.GetDateCreated() + "\n" +
                                              "=====================================================\n");
                        }
                        break;
                    case 9:
                        quit = true;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
