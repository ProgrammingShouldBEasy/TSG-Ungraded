using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionFactorial
{
    class Program
    {
        static int recursiveFactorial (int x)
        {
            if (x == 0)
            {
                
            }
            int sum = x - 1;
            return recursiveFactorial(sum); 
        }
        static void Main(string[] args)
        {
            int i;
            int sum;
            int intput=0;
            string input=null;
            do
            {
                Console.WriteLine("This is a factorial program, starting with one. Please provide an upper limit.");
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out intput));

            for (i=0; i<intput; i++)
            {
                sum = i + 1;
                Console.WriteLine(sum);
            }
            
            Console.ReadLine();
        }
    }
}
