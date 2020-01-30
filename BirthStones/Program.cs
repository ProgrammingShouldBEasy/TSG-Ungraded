using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthStones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What month's birthstone do you want to know?");
            string input = Console.ReadLine();
            int number;
            while (!Int32.TryParse(input, out number)  || (number < 0 || number > 13))
            {
                Console.WriteLine("I need a number between 1 and 12");
                input = Console.ReadLine();
            }


            switch (number)
            {
                case 1:
                    Console.WriteLine("Garnet");
                    break;
                case 2:
                    Console.WriteLine("Amethyst");
                    break;
                case 3:
                    Console.WriteLine("Aquamarine");
                    break;
                case 4:
                    Console.WriteLine("Diamond");
                    break;
                case 5:
                    Console.WriteLine("Emerald");
                    break;
                case 6:
                    Console.WriteLine("Pearl");
                    break;
                case 7:
                    Console.WriteLine("Ruby");
                    break;
                case 8:
                    Console.WriteLine("Peridot");
                    break;
                case 9:
                    Console.WriteLine("Sapphire");
                        break;
                case 10:
                    Console.WriteLine("Opal");
                    break;
                case 11:
                    Console.WriteLine("Topaz");
                    break;
                case 12:
                    Console.WriteLine("Turquoise");
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }
    }
}
