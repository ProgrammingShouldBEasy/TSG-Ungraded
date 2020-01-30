using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllTheTrivia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What unit is equivalent to 1,024 Gigabytes?");
            string answer1 = Console.ReadLine();
            Console.WriteLine("Which planet is the only one that rotates clockwise in our Solar System?");
            string answer2 = Console.ReadLine();
            Console.WriteLine("The largest volcano ever discovered in our Solar System is located on which planet?");
            string answer3 = Console.ReadLine();
            Console.WriteLine("What is the most abundant element in the earth's atmosphere?");
            string answer4 = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Wow, 1,024 Gigabytes is a " + answer4 + "!");
            Console.WriteLine("I didn't know that the largest ever volcano was discovered on " + answer3 + "!");
            Console.WriteLine("That's amazing that " + answer2 + " is the most abundant element in the atmosphere...");
            Console.WriteLine(answer1 + " is the only planet that rotates clockwise, neat!");
            Console.ReadLine();
        }
    }
}
