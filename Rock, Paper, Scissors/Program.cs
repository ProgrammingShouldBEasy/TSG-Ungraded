using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock__Paper__Scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            int ties = 0;
            int playerWins = 0;
            int compWins = 0;
            int choice;
            int rounds;
            string answer = "Yes";
            Random compChoice = new Random();

            while (answer == "Yes")
            {
                Console.WriteLine("How many rounds would you like to play?");
                if (Int32.TryParse(Console.ReadLine(), out rounds) && rounds > 0 && rounds <= 10)
                {
                    for (int i = 0; i < rounds; i++)
                    {
                        Console.WriteLine("Pick a number: 1 for Rock, 2 for Paper, 3 for Scissors.");
                        answer = Console.ReadLine();
                        do
                        {
                            if (!Int32.TryParse(answer, out choice) && (choice < 0 || choice > 3))
                            {
                                Console.WriteLine("Pick a number: 1 for Rock, 2 for Paper, 3 for Scissors.");
                                answer = Console.ReadLine();
                            }
                        }
                        while (!Int32.TryParse(answer, out choice) && (choice < 0 || choice > 3));
                        // Stores a computer choice to be evaluated against.
                        int choice2 = compChoice.Next(1, 3);
                        if (choice == choice2)
                        {
                            ties++;
                        }

                        else if ((choice == 1 && choice2 == 3) || (choice == 3 && choice2 == 2) || (choice == 2 && choice2 == 1))
                        {
                            playerWins++;
                        }

                        else
                        {
                            compWins++;
                        }
                    }
                    Console.WriteLine("Ties: " + ties + ". Player Wins: " + playerWins + ". Computer Wins: " + compWins + ".");
                    if ((ties > compWins) && (ties > playerWins))
                    {
                        Console.WriteLine("It's a tie!");
                    }

                    if (playerWins > compWins)
                    {
                        Console.WriteLine("The player has won!");
                    }

                    else
                    {
                        Console.WriteLine("The computer has won!");
                    }

                    do
                    {
                        Console.WriteLine("Would you like to continue? Yes or No.");
                        answer = Console.ReadLine();
                    }
                    while ((answer != "Yes") && (answer != "No"));
                }
                answer = "No";
            }
            Console.WriteLine("Thanks for playing!");
            Console.ReadLine();
        }
    }
}
