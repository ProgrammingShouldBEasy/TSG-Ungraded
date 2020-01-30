using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingUserInput
{
    class Program
    {
        static void Main(string[] args)
        {
            string yourName;
            string yourQuest;
            double velocityOfSwallow;

            // We can use Console.ReadLine to asisgn value to our strings
            // because its default is string
            Console.WriteLine("What is your name? ");
            yourName = Console.ReadLine();

            Console.WriteLine("What is your quest? ");
            yourQuest = Console.ReadLine();

            /* When we get to our double data type, we have to do a bit of type changing
                so we'll use Convert.ToDouble method
                and put Console.ReadLine() as the argument.
            */

            Console.WriteLine("What is the airspeed velocity of an unladen swallow?");
            velocityOfSwallow = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("How do you know " + velocityOfSwallow + " is correct, " + yourName + "?");
            Console.WriteLine("You didn't even know if the swallow was African or European!");
            Console.WriteLine("Maybe skip answering things about birds and instead go " + yourQuest + ".");
            Console.ReadLine();
        }
    }
}
