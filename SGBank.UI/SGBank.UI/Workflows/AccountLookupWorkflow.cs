using SGBank.BLL;
using SGBank.models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class AccountLookupWorkflow
    {
        public void Execute()
        {
            AccountManager manager = AccountManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup an account");
            Console.WriteLine("-------------------------");
            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            AccountLookUpResponse response = manager.LookupAccount(accountNumber);

            if(response.success)
            {
                ConsoleIO.DisplayAccountDetails(response.Account);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.message);
            }

            Console.WriteLine("Press anykey to continue.");
            Console.ReadKey();
        }
    }
}
