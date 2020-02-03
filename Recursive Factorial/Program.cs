using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Factorial
{
    class Program
    {
        public static int Recursive(int x)
        {
            int input = x;
            int output = input;
            input--;
            while (input > 0)
            {
                output += input;
                input--;
                Recursive(input);
            }
            return output;
        }
        static void Main(string[] args)
        {
            int input;
            string answer;
            bool yes;
            do
            {
                Console.WriteLine("What number would you like factored?");
                answer = Console.ReadLine();
                yes = Int32.TryParse(answer, out input);
            }
             while (!Int32.TryParse(answer, out input));
            Console.WriteLine("Facorial " + input + " : " + Recursive(input));
            Console.ReadLine();
        }
    }
}
