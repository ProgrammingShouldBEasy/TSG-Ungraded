using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMe
{
    class Program
    {
        static void Main(string[] args)
        {
            const int myInt = 10;
            Console.WriteLine("I've chosen a number. Betcha can't guess it!");
            int yourInt = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Your guess: " + yourInt);
            Console.WriteLine();
            Console.Write(yourInt + "? ");
            if (myInt == yourInt)
            {
                Console.WriteLine("Wow, nice guess! That was it!");
            }

            else if (yourInt < myInt)
            {
                Console.WriteLine("Ha, nice try - too low! I chose " + myInt + ".");
            }

            else if (yourInt > myInt)
            {
                Console.WriteLine("Too bad, way too high. I chose " + myInt + ".");
            }
            Console.ReadLine();
        }
    }
}
