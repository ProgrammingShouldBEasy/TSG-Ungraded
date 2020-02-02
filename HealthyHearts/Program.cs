using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHearts
{
    class Program
    {
        static void Main(string[] args)
        {
            //Valid user input.
            Console.WriteLine("What's your age?");
            int age = Int32.Parse(Console.ReadLine());
            int max = 220 - age;
            double targetLow = max * .5;
            int intTargetLow = (int)targetLow;
            double targetHigh = max * .85;
            int intTargetHigh = (int)targetHigh;
            Console.WriteLine("Your maximum heart rate should be " + max + " beats per minute.");
            Console.WriteLine("Your target HR Zone is " + intTargetLow + " - " + intTargetHigh + " beats per minute.");
            Console.ReadLine();
        }
    }
}
