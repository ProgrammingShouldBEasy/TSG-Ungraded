using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dog_Genetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Random calculator = new Random();
            int breed1 = 100 - calculator.Next(0, 100);
            int breed2 = calculator.Next(0, 100 - breed1);
            int breed3 = calculator.Next(0, 100 - breed1 - breed2);
            int breed4 = calculator.Next(0, 100 - breed1 - breed2 - breed3);
            int breed5 = 100 - (breed1 + breed2 + breed3 + breed4);
            string dogName;
            Console.WriteLine("What's the name of your dog?");
            dogName = Console.ReadLine();
            Console.WriteLine("Well then, I have this highly reliable report on Sir Fluffy McFlufferkins Esquire's prestigious background right here.");
            Console.WriteLine();
            Console.WriteLine(dogName + " is:");
            Console.WriteLine();
            Console.WriteLine(breed1 + "% St. Bernard.");
            Console.WriteLine(breed2 + "% Chihuaha.");
            Console.WriteLine(breed3 + "% Dramatic Rednosed Asian Pug.");
            Console.WriteLine(breed4 + "% Common Cur.");
            Console.WriteLine(breed5 + "% King Doberman.");
            Console.WriteLine();
            Console.WriteLine("Wow, that's QUITE the dog!");
            Console.ReadLine();
        }
    }
}
