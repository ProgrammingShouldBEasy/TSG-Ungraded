using SGBank.BLL;
using SGBank.models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter a deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if (response.success)
            {
                Console.WriteLine("Deposit completed!");
                Console.WriteLine($"Account Number: {response.Account._number}");
                Console.WriteLine($"Old balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount deposited: {response.Amount:c}");
                Console.WriteLine($"New balance: {response.Account._balance:c}");
            }
            else
            {
                Console.WriteLine("An error occurrred: ");
                Console.WriteLine(response.message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
