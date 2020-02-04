using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morning_Work_2_4_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayInput;
            int arraySize;
            string answer;
            Console.WriteLine("How many numbers do you want to enter?");
            answer = Console.ReadLine();
            bool isValid = Int32.TryParse(answer, out arraySize);
            
            while (!isValid)
            {
                Console.WriteLine("Please enter a valid number.");
                isValid = Int32.TryParse(answer, out arraySize);
            }
            int[] myArray = new int[arraySize];

            for (int i=0; i<arraySize; i++)
            {
                Console.WriteLine("Please enter a number.");
                answer = Console.ReadLine();
                isValid = Int32.TryParse(answer, out arrayInput);

                while (!isValid)
                {
                    Console.WriteLine("Please enter a valid number.");
                    isValid = Int32.TryParse(answer, out arrayInput);
                }
                myArray[i] = arrayInput;
            }

            for (int i = 0; i < myArray.Length; i++)
            {

                if (myArray[i] % 2 == 0)
                {
                    Console.WriteLine(myArray[i]);
                }
            }

            Console.ReadLine();
        }
    }
}
