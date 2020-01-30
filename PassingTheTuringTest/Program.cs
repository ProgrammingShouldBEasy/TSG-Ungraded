using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingTheTuringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Hi, " + name + "! I'm Cain.");
            Console.WriteLine("What is your favorite color?");
            string color = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Huh, " + color + "? Mine's Electric Lime.");
            Console.WriteLine();
            Console.WriteLine("I really like limes. They're my faovrite fruit, too.");
            Console.WriteLine("What's YOUR favorite fruit, " + name + "?");
            string fruit = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Really? " + fruit + "? That's wild!");
            Console.WriteLine("Speaking of favorites, what's your favorite number?");
            int number = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine(number + " is a cool number. Mine's -7.");
            Console.WriteLine("Did you know " + number + " * -7 is " + number * -7 + "? That's a cool number too!");
            Console.WriteLine("Well, thanks for talking to me, " + name + "!");
            Console.ReadLine();
        }
    }
}
