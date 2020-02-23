using SGBank.BLL;
using SGBank.models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class WithdrawWorkFlow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager manager = AccountManagerFactory.Create();

            Console.WriteLine("Please enter your account number.");
            string number = Console.ReadLine();
            Console.WriteLine("Please enter your withdrawal amount.");
            decimal withdrawal = decimal.Parse(Console.ReadLine());

            AccountWithdrawResponse response = manager.WithdrawRules(number, withdrawal);

            if(response.success)
            {
                Console.WriteLine("Success!");
                ConsoleIO.DisplayAccountDetails(response.Account);
            }

            else
            {
                Console.WriteLine("Something went wrong.");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
