using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome_WarmUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write your palindrome.");
            string input = Console.ReadLine();
            Console.WriteLine(input);
            char[] check = input.ToCharArray();
            Array.Reverse(check);
            Console.WriteLine(check);
            string final = new string(check);
            Console.WriteLine(final);
            if (input == final)
            {
                Console.WriteLine("True");
            }

            else
            {
                Console.WriteLine("False");
            }
            Console.ReadLine();
        }
    }
}
