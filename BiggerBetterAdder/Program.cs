using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggerBetterAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many miles can you run?");
            int milesRun = Int32.Parse(Console.ReadLine());
            Console.WriteLine("I can run " + (milesRun * 3 + 1) + " miles.");
            Console.WriteLine("How many hotdogs can you eat?");
            int hotDogsEat = Int32.Parse(Console.ReadLine());
            Console.WriteLine("I can eat " + (hotDogsEat * 3 + 1) + " hotdogs.");
            Console.WriteLine("How many languages do you know?");
            int languagesKnown = Int32.Parse(Console.ReadLine());
            Console.WriteLine("I know " + (languagesKnown * 3 + 1) + " languages.");
            Console.ReadLine();
        }
    }
}
