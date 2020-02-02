using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_Sums
{
    class Program
    {
        static int Sum (int[] array)
        {
            //Running sum.
            int sum = 0;
            //i is the counter that goes from 0 to the length of the array
            for (int i = 0; i < array.Length; i++)
            {
                //adds the value at the i index of the array
                sum += array[i];
            }
            //returns the grand total
            return sum;
        }
        static void Main(string[] args)
        {
            //Instantiates each array by hardcoding their values, the index size is implied.
            int[] array1 = new int[] { 1, 90, -33, -55, 67, -16, 28, -55, 15 };
            int[] array2 = new int[] { 999, -60, -77, 14, 160, 301 };
            int[] array3 = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, -99 };

            //Passing in each array in turn, outputting their summative results.
            Console.WriteLine("#1 Array Sum: " + Sum(array1));
            Console.WriteLine("#2 Array Sum: " + Sum(array2));
            Console.WriteLine("#3 Array Sum: " + Sum(array3));

            Console.ReadLine();
        }
    }
}
