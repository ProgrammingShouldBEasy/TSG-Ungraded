using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int track = 0;
                int theAnswer;
                int playerGuess;
                string playerInput;
                Random r = new Random();
                theAnswer = r.Next(1, 21);
                bool isTrue = true;
                string modeString;


            Console.WriteLine("What is your name?");
            string playerName = Console.ReadLine();
            if (playerName != "Q")
            {

                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("What mode do you want? Type Easy for 1-5, Normal for 1-20, and Hard for 1-50 number range.");
                    modeString = Console.ReadLine();
                } while (!(modeString == "Easy") || (modeString == "Normal") || (modeString == "Hard"));
                switch (modeString)

                {
                    case "Easy":
                        theAnswer = r.Next(1, 6);
                        break;
                    case "Normal":
                        theAnswer = r.Next(1, 21);
                        break;
                    case "Hard":
                        theAnswer = r.Next(1, 51);
                        break;
                    default:
                        break;
                } 
                if (modeString != "Q")
                {
                    while (isTrue)
                    {
                        // get player input
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Enter your guess: ");
                        track++;
                        playerInput = Console.ReadLine();
                        if (playerInput != "Q")
                        {
                            //attempt to convert the string to a number
                            if (int.TryParse(playerInput, out playerGuess))
                                if (playerGuess <= 20 && playerGuess >= 1)
                                {
                                    {
                                        if (playerGuess == theAnswer)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"{theAnswer} was the number.  You Win, " + playerName + "!");
                                            break;
                                        }
                                        else
                                        {
                                            if (playerGuess > theAnswer)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Your guess was too High, " + playerName + "!");
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Your guess was too low, " + playerName + "!");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(playerName + ", that was an incorrect number. Please try again, " + playerName + "!");
                                }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("That wasn't a number, " + playerName + "!");
                            }
                        }
                        else { isTrue = false; }
                    }
                }
                if (track == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The game is over. You got it on the first try, " + playerName + "!");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("The game is over. It took you " + track + " tries, " + playerName + "!");
            Console.ReadKey();
        }
    }
}
