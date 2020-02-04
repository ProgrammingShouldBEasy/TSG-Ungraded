using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility_Classes;

namespace Rock__Paper__Scissors
{
    class Program
    {
        public enum GameState
        {
            player = 1,
            computer = 2,
            tie = 3
        }

        public static GameState State { get; set; }
        public static GameState WhoWon(int playerWins, int computerWins)
        {
            int a = playerWins;
            int b = computerWins;

            if (a > b)
            {
                State = GameState.player;
            }

            else if (b > a)
            {
                State = GameState.computer;
            }

            else
            {
                State = GameState.tie;
            }

            return State;
        }
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
                rounds = GetInput.ForInt(1, 10);
                for (int i = 0; i < rounds; i++)
                {
                    Console.WriteLine("Pick a number: 1 for Rock, 2 for Paper, 3 for Scissors.");
                    choice = GetInput.ForInt(1, 3);

                    // Stores a computer choice to be evaluated against.
                    int choice2 = compChoice.Next(1, 4);
                    if (choice == choice2)
                    {
                        ties++;
                        Console.WriteLine("Tie!");
                    }

                    else if ((choice == 1 && choice2 == 3) || (choice == 3 && choice2 == 2) || (choice == 2 && choice2 == 1))
                    {
                        playerWins++;
                        Console.WriteLine("Player Win!");
                    }

                    else
                    {
                        compWins++;
                        Console.WriteLine("Computer Win!");
                    }
                }
                Console.WriteLine("Ties: " + ties + ". Player Wins: " + playerWins + ". Computer Wins: " + compWins + ".");
                Console.WriteLine("And the winner is: " + WhoWon(playerWins, compWins));

                do
                {
                    Console.WriteLine("Would you like to continue? Yes or No.");
                    answer = Console.ReadLine();
                }
                while ((answer != "Yes") && (answer != "No"));
            }
            Console.WriteLine("Thanks for playing!");
            Console.ReadLine();
        }
    }
}

