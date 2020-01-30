using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontForgetToStoreIt
{
    class Program
    {
        static void Main(string[] args)
        {
            int meaningOfLifeAndEverything = 42;
            double pi = 3.124159;
            string cheese, color;

            Console.WriteLine("Give me pi to at least 5 decimals: ");
            Convert.ToDouble(Console.ReadLine());

            // We've got Convert.ToDouble down but meaningOfLifeAndEverything is an INT
            // so we'll have to use Convert.ToInt32
            Console.WriteLine("What is the meaning of life, the universe, and everything?");
            Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is your favorite kind of cheese? ");
            cheese = Console.ReadLine();

            Console.WriteLine("Do you like the color red or blue more? ");
            color = Console.ReadLine();

            Console.WriteLine("Ooh, " + color + " " + cheese +" sounds delicious!");
            Console.WriteLine("The circumstance of life is " +( 2 * pi * meaningOfLifeAndEverything));
            Console.ReadLine();
        }
    }
}
