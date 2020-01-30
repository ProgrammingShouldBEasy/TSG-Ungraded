using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMadLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            string one;
            string two;
            string three;
            string four;
            string five;
            string six;
            string seven;
            string eight;
            string nine;
            string ten;

            Console.WriteLine("I need a noun: ");
            one = Console.ReadLine();
            Console.WriteLine("Now an adjective: ");
            two = Console.ReadLine();
            Console.WriteLine("Another noun: ");
            three = Console.ReadLine();
            Console.WriteLine("And a number: ");
            four = Console.ReadLine();
            Console.WriteLine("Another adjective: ");
            five = Console.ReadLine();
            Console.WriteLine("A plural noun: ");
            six = Console.ReadLine();
            Console.WriteLine("Another one: ");
            seven = Console.ReadLine();
            Console.WriteLine("One more: ");
            eight = Console.ReadLine();
            Console.WriteLine("A verb (infinitive form): ");
            nine = Console.ReadLine();
            Console.WriteLine("Same verb (past participle): ");
            ten = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("*** NOW LETS GET MAD (libs) ***");
            Console.WriteLine(one + ": the " + two + " frontier. These are the voyages of the starship " + three + ". Its " + four + "-year mission: to explore strange " + five + " " + six + ", to seek out " + five + " " + seven + " and " + five + " " + eight + ", to boldly " + nine + " where no one has " + ten + " before.");

            Console.ReadLine();
        }
    }
}
