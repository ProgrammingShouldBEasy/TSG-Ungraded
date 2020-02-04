using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility_Classes
{
    public static class GetInput
    {
        public static int ForInt(int aMin, int bMax)
        {
            //Declaring local variables.
            string answer;
            bool isValid;
            int returnInt;

            //Assigning parameters to local variables.
            int min = aMin;
            int max = bMax;

            //Asking input and evaluating based on provided range and min/max.
            Console.WriteLine($"Please enter a valid number between {min} and {max}.");
            answer = Console.ReadLine();
            isValid = Int32.TryParse(answer, out returnInt);

            while (!isValid || returnInt < min || returnInt > max)
            {
                Console.WriteLine($"Please enter a valid number between {min} and {max}.");
                answer = Console.ReadLine();
                isValid = Int32.TryParse(answer, out returnInt);
            }

            return returnInt;
        }

        public static int ForInt()
        {
            //Declaring local variables.
            string answer;
            bool isValid;
            int returnInt;

            //Asking input and evaluating based on provided range and min/max.
            Console.WriteLine($"Please enter a valid number.");
            answer = Console.ReadLine();
            isValid = Int32.TryParse(answer, out returnInt);

            while (!isValid)
            {
                Console.WriteLine($"Please enter a valid number.");
                answer = Console.ReadLine();
                isValid = Int32.TryParse(answer, out returnInt);
            }

            return returnInt;
        }

        public static double ForDouble(int aMin, int bMax)
        {
            //Declaring local variables.
            string answer;
            bool isValid;
            double returnDouble;

            //Assigning parameters to local variables.
            double min = aMin;
            double max = bMax;

            //Asking input and evaluating based on provided range and min/max.
            Console.WriteLine($"Please enter a valid decimal number between {min} and {max}.");
            answer = Console.ReadLine();
            isValid = Double.TryParse(answer, out returnDouble);

            while (!isValid || returnDouble < min || returnDouble > max)
            {
                Console.WriteLine($"Please enter a valid decimal number between {min} and {max}.");
                answer = Console.ReadLine();
                isValid = Double.TryParse(answer, out returnDouble);
            }

            return returnDouble;
        }

        public static double ForDouble()
        {
            //Declaring local variables.
            string answer;
            bool isValid;
            double returnDouble;

            //Asking input and evaluating based on provided range and min/max.
            Console.WriteLine($"Please enter a valid decimal number between.");
            answer = Console.ReadLine();
            isValid = Double.TryParse(answer, out returnDouble);

            while (!isValid)
            {
                Console.WriteLine($"Please enter a valid decimal number between.");
                answer = Console.ReadLine();
                isValid = Double.TryParse(answer, out returnDouble);
            }

            return returnDouble;
        }

        public static decimal ForDecimal(int aMin, int bMax)
        {
            //Declaring local variables.
            string answer;
            bool isValid;
            decimal returnDecimal;

            //Assigning parameters to local variables.
            decimal min = aMin;
            decimal max = bMax;

            //Asking input and evaluating based on provided range and min/max.
            Console.WriteLine($"Please enter a valid, precise, decimal number between {min} and {max}.");
            answer = Console.ReadLine();
            isValid = Decimal.TryParse(answer, out returnDecimal);

            while (!isValid || returnDecimal < min || returnDecimal > max)
            {
                Console.WriteLine($"Please enter a valid, precise, decimal number between {min} and {max}.");
                answer = Console.ReadLine();
                isValid = Decimal.TryParse(answer, out returnDecimal);
            }

            return returnDecimal;
        }

        public static decimal ForDecimal()
        {
            //Declaring local variables.
            string answer;
            bool isValid;
            decimal returnDecimal;

            //Asking input and evaluating based on provided range and min/max.
            Console.WriteLine($"Please enter a valid, precise, decimal number.");
            answer = Console.ReadLine();
            isValid = Decimal.TryParse(answer, out returnDecimal);

            while (!isValid)
            {
                Console.WriteLine($"Please enter a valid, precise, decimal number.");
                answer = Console.ReadLine();
                isValid = Decimal.TryParse(answer, out returnDecimal);
            }

            return returnDecimal;
        }
    }
}
