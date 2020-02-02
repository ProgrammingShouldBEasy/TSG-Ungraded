using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paired_Programming
{
    class Program
    {
        //Demonstrating combining local variables to return a single value that accounts for both, which works around the limitation of a method only being able to return a single value.
        // Other solutions would include returning an object and referencing the members.
        public static string Combiner(string x, string y, out int[] xx, out int[] yy, out int[] zz)
        {
            xx = null;
            yy = null;
            zz = null;
            string a = x;
            string b = y;
            string c = a + b;

            return c;
        }

        //I cannot instantiate an object within the scope of a method and output that object to the scope of the caller, as the reference is only valid during the method runtime. Once it goes out of scope, the object loses it's reference and is garbage collected unless the pointer is passed as the return value. I can also manipulate the object in method that was constructed in the scope of the caller, passing the object into the method, assigning the pointer of the caller-scoped object to the method-scoped object, and then manipulating the object. I do not need to return a value, because I manipulated the data within the method and discarded local variable that temporarily held the pointer address to an object in the same scope as the caller. Either way, I can manipulate pre-existing objects by passing their pointer or instantiating new objects within the scope of the method, pass the pointer as the return value, and maintain the object from the heap.
        public static void returnTest(DateTime x)
        {
            DateTime someDate = new DateTime();
            someDate = x;
            someDate.AddDays(1);
        }

        public static string Flip()

        {
            Random coinFlip = new Random();
            double isHeads = coinFlip.NextDouble();
            string result;
                if (isHeads < .5)
                {
                    result = "Heads";
                }

                else
                {
                    result = "Tails";
                }

            return result;
        }
        static void Main(string[] args)
        {
            int x;
            Random rng1 = new Random();
            x = rng1.Next(0, 101);
            Console.WriteLine(x);

            string[] results = new string[x];

            int i;
            for (i=0;i<x;i++)
            {
                results[i] = Flip();
                Console.WriteLine(results[i]);
                Random sleepRNG = new Random();
                System.Threading.Thread.Sleep(sleepRNG.Next(0,300));
            }

            int headCount=0;
            int tailCount=0;
            for (i = 0; i < results.Count(); i++)

            {
                string eval = results[i];
                switch (eval)
                {
                    case "Heads":
                        headCount++;
                        break;
                    case "Tails":
                        tailCount++;
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine("Number of heads: " + headCount);
            Console.WriteLine("Number of tails: " + tailCount);
            if (headCount < tailCount)
            {
                Console.WriteLine("Tails wins.");
            }

            else if (headCount > tailCount)
            {
                Console.WriteLine("Heads wins.");
            }

            else
            {
                Console.WriteLine("Tie game.");
            }

            Console.WriteLine("Array length: " + i);

            Console.ReadLine();
        }
    }
}
