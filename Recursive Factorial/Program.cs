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
            int output = 0;
            if (input > 0)
            {
                output += input;
                input--;
            }
            Recursive(input);
            return output;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Facorial 3 = " + Recursive(3));
            Console.ReadLine();
        }
    }
}
