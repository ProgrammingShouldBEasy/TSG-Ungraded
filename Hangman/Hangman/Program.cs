using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Logic;
using NUnit.Framework;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = GameFactory.Create();
            bool gameWon = false;
            int misses = 0;
            int turn = 0;
            bool gameOver = false;
            bool containsEmpty;
            bool willPlay = true;

            while (willPlay)
            {
                List<char> guesses = new List<char>();
                string word = gm.ReturnWord();
                foreach (var x in word)
                {
                    Console.Write("_ ");
                }
                Console.WriteLine();
                while (gameOver == false)
                {
                    containsEmpty = false;
                    Console.WriteLine("What is your guess?");
                    string answer = Console.ReadLine().ToLower();
                    while (guesses.Contains(answer[0]) || answer.Length != 1)
                    {
                        Console.WriteLine("That's an invalid choice. Please choose again.");
                        answer = Console.ReadLine().ToLower();
                    }
                    guesses.Add(answer[0]);

                    if (!word.Contains(answer[0]))
                    {
                        misses++;
                    }
                    Console.Clear();
                    foreach (var x in word)
                    {
                        if (guesses.Contains(x))
                        {
                            Console.Write(x);
                        }
                        else
                        {
             
                            Console.Write("_");
                            containsEmpty = true;
                        }
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    turn++;
                    Console.WriteLine("Guesses: ");
                    foreach (var x in guesses)
                    {
                        Console.Write(x + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Turn: " + turn);
                    Console.WriteLine("Misses: " + misses);
                    gameWon = !containsEmpty;
                    gameOver = misses > 5 || gameWon;
                }
                Console.WriteLine(word);
                if (gameWon)
                {
                    Console.WriteLine("Good job, you won!");
                }

                else
                {
                    Console.WriteLine("Game Over.");
                }
                turn = 0;
                misses = 0;
                gameOver = false;
                gameWon = false;
                Console.WriteLine("Would you like to play again? Yes or No");
                string answer2 = Console.ReadLine();
                if (answer2 == "Yes")
                {
                    willPlay = true;
                }
                else
                {
                    willPlay = false;
                }
            }
            Console.ReadKey();
        }
    }
}
