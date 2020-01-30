using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldSample
{
    class Program
    {
        //Stress testing the parameter inputs, optional parameters, params, output parameters, and return types of methods.
        static public string myMethod(int x, ref int z, out int a, int y = 0, string ac=null, params int[] Z)
        {
            a = 5;
            int xx = x;
            int b = y;
            string returnstring = ac;
            return returnstring;
        }
        static void Main()
        {

            //Console.WriteLine("Hello World!");
            //Console.WriteLine("My name is Cain.");
            //Console.WriteLine("C# is pretty great.");
            //Console.ReadLine();

            //// +,-,*,/

            //int x = 1;
            //int y = 2;
            //Console.WriteLine(x + " plus " + y + " equals " + (x + y));
            //Console.WriteLine(x + " minus " + y + " equals " + (x - y));
            //Console.WriteLine(x + " multiplied by " + y + " equals " + (x * y));
            //Console.WriteLine(x + " divided by " + y + " equals " + (x / y));

            //string testString = @"c:\root\folder\rolder\file";
            //Console.WriteLine(testString);

            //Every odd number from 1 to a 100 for loop
            //int x;
            //for (x=1; x < 101; x += 2)
            //{
            //    Console.WriteLine(x);
            //}

            //x = 1;

            //while (x < 101)
            //{
            //    Console.WriteLine(x);
            //    x += 2;
            //}

                //Ask the user what number to start at.
                //Change while loop to for loop
                int xLow;
                int xHigh;
                Console.WriteLine("Pick a low number.");
                string numberMin = Console.ReadLine();
                Console.WriteLine("Pick a high number.");
                string numberMax = Console.ReadLine();
                while ((!int.TryParse(numberMin, out xLow) || !int.TryParse(numberMax, out xHigh)) || (xLow >= xHigh))
                {
                    Console.WriteLine("Those were not valid numbers or the first number was not less than the high number.");
                    Console.WriteLine("Pick a low number.");
                    numberMin = Console.ReadLine();
                    Console.WriteLine("Pick a high number.");
                    numberMax = Console.ReadLine();
                }
                int xCount = xLow;
                for (; xCount < xHigh; xCount++)
                {
                    int y = xCount % 2;
                    if (y == 0)
                    {
                        Console.WriteLine(xCount);
                    }
                }

            //do
            //{
            //    Console.WriteLine(someBool);
            //    someBool = true;
            //    Console.WriteLine(someBool);
            //}
            //while (!someBool);

            ////if (someBool)
            ////{
            ////    someBool = false;
            ////    Console.WriteLine("if");
            ////}

            ////else
            ////{
            ////    someBool = false;
            ////    Console.WriteLine("else");
            ////}

            //Console.WriteLine();
            Console.ReadLine();
        }
    }
}
