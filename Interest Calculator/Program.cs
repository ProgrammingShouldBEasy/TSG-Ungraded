using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest_Calculator
{

    class Program
    {
        public static decimal Quarterly(decimal x, decimal y)
        {
            decimal principalCurrent = x;
            decimal principalEnd;
            decimal interestRate = y;
            for (int i = 0; i < 4; i++)
            {
                principalEnd = principalCurrent * (1 + (interestRate/ 4 / 100));
                principalCurrent = principalEnd;
            }
            return principalCurrent;
        }
        static void Main(string[] args)
        {
            int yearStart = 0;
            int yearNumber;
            int yearEnd;
            decimal principalCurrent;
            decimal interestRate;
            decimal interestEarned;
            decimal principalEnd;
            string answer;
            do
            {
                Console.WriteLine("What is your annual interest rate?");
                answer = Console.ReadLine();
            }while (!decimal.TryParse(answer, out interestRate));
            //interestRate = decimal.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("What was your initial principle?");
                answer = Console.ReadLine();
            } while (!decimal.TryParse(answer, out principalCurrent));
            //principalCurrent = decimal.Parse(Console.ReadLine());
            //yearNumber = Int32.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("How many years will the funds stay in the fund?");
                answer = Console.ReadLine();
            } while (!Int32.TryParse(answer, out yearNumber));
            yearEnd = yearStart + yearNumber;
            Console.WriteLine();
            Console.WriteLine("Calculating...");
            Console.WriteLine("Calculating...");
            for (; yearStart <= yearEnd; yearStart++)
            {
                Console.WriteLine($"Year: {yearStart+1}");
                Console.WriteLine($"Began with: ${principalCurrent:00.00}");
                principalEnd = Quarterly(principalCurrent, interestRate);
                interestEarned = principalEnd - principalCurrent;
                Console.WriteLine($"Earned ${interestEarned:00.00}");
                Console.WriteLine($"Ended with ${principalEnd:00.00}");
                principalCurrent = principalEnd;
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
