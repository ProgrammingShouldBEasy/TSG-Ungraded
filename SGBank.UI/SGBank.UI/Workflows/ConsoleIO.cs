using SGBank.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class ConsoleIO
    {
        public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine($"Account number: {account._number}");
            Console.WriteLine($"Name: {account._name}");
            Console.WriteLine($"Balance: {account._balance:c}");
        }
    }
}
