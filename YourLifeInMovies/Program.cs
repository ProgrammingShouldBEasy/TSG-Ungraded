using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLifeInMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey, let's play a game! What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ok, " + name + ", when were you born?");
            int year = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Well " + name + "...");
            if (year < 2005)
            {
                Console.WriteLine("Did you know that Pixar's 'Up' came out over a decade ago?");
            }

            if (year < 1995)
            {
                Console.WriteLine("And that the first Harry Potter came out over 15 years ago.");
            }

            if (year < 1985)
            {
                Console.WriteLine("Also, Space Jame came out not last decade, but the one before THAT.");
            }

            if (year < 1975)
            {
                Console.WriteLine("And the original Jurassic Park release is closer to the first lunar landing than it is today.");
            }

            if (year < 1965)
            {
                Console.WriteLine("Finally, the MASH TV series has been around for almost half a century!");
            }
            Console.ReadLine();
        }
    }
}
