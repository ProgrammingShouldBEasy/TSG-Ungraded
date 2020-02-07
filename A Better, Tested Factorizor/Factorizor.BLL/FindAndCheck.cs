using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class FindAndCheck
    {
        public string[] FactorFinder(int x)
        {
            //Number to be factored.
            int number = x;
            //One of the pair.
            int one = 0;
            //Two of the pair.
            int two = 0;
            //Stores result.
            string result;
            //Number of factor pairs.
            int count = 0;
            //Default array if number is not greater than 0.
            string[] noFactors = new string[1] {"This number cannot be factored."};

            //Validates number is great han 0.
            if (number > 0)
            {

                //Determining number of factored pairs.
                for (int i = 0; i < number; i++)
                {
                    for (i = 0; i < number; i++)
                    {
                        if (one * two == number)
                        {
                            count++;
                        }
                        two++;
                    }
                    one++;
                }

                //Generating a string array of correct size.
                string[] factors = new string[count];

                //Storing factored pairs into the string array.
                for (int i = 0; i < number; i++)
                {
                    for (i = 0; i < number; i++)
                    {
                        if (one * two == number)
                        {
                            result = $"{one} x {two} {number}.";
                            factors.Append(result);
                        }
                        two++;
                    }
                    one++;
                }

                return factors;
            }
            else
            {
                return noFactors;
            }
        }

        public bool PerfectChecker(int x)
        {
            //Store number.
            int number = x;
            //Holds if it's perfect.
            bool isPerfect = false;
            //Stores result;
            int sum = 0;
            //One of the pairs.
            int one = 0;
            //Two of the pairs.
            int two = 0;
            //Number of proper divisors.
            int count = 0;

            //Validates number is greater than 0;
            if (number > 0)
            {
                //Determines number of proper divisors.
                for (int i = 0; i < number; i++)
                {
                    for (i = 0; i < number; i++)
                    {
                        if (one * two == number)
                        {
                            count++;
                        }
                        two++;
                    }
                    one++;
                }

                //Holds array of proper divisors.
                int[] divisors = new int[count];

                //Determines proper divisor.
                for (int i = 0; i < number; i++)
                {
                    for (i = 0; i < number; i++)
                    {
                        if (one * two == number)
                        {
                            divisors.Append(one);
                        }
                        two++;
                    }
                    one++;
                }

                //Sums the divisors.
                for (int i = 0; i < divisors.Length; i++)
                {
                    sum += divisors[i];
                }

                //Calculates if the sum is equal to the number.
                if (sum == number)
                {
                    isPerfect = true;
                }
            }

            return isPerfect;
        }

        public bool PrimeChecker(int x)
        {
            //Stores number to be factored.
            int number = x;
            //Stores whether the number is prime.
            bool isPrime = false;
            //One of the pairs.
            int one = 0;
            //Two of the pairs.
            int two = 0;
            //Counts if there are any factors.
            int count = 0;

            //Validate input is greater than 0.
            if (number > 0)
            {
                //Determines if a number has any factors.
                for (int i = 0; i < number; i++)
                {
                    for (i = 0; i < number; i++)
                    {
                        if (one * two == number)
                        {
                            count++;
                        }
                        two++;
                    }
                    one++;
                }

                //Evaluates if the number is prime.
                if (count == 0)
                {
                    isPrime = true;
                }
            }

            return isPrime;
        }
    }
}
