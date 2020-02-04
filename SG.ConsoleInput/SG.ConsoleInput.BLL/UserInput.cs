using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.ConsoleInput.BLL
{
    public class UserInput
    {
        public static int GetIntFromUser(string prompt)
        {
            bool first = true;
            int result;
            string userInput;
            do
            {
                if (!first)
                {
                    Console.WriteLine("That is not a valid input.");
                }

                first = false;

                Console.WriteLine(prompt);
                userInput = Console.ReadLine();

            } while (!int.TryParse(userInput, out result));

            return result;
        }
    }
}
