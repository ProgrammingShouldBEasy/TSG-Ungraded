using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeBLL;
using Utility_Classes;

namespace TicTacToeUI
{
    class TicTacToeUIL
    {
        public static void DisplayBoard(GameBoard game)
        {
            Console.WriteLine($"{game.readTable(0, 0)}|{game.readTable(0, 1)}|{game.readTable(0, 2)}");
            Console.WriteLine("------");
            Console.WriteLine($"{game.readTable(1, 0)}|{game.readTable(1, 1)}|{game.readTable(1, 2)}");
            Console.WriteLine("------");
            Console.WriteLine($"{game.readTable(2, 0)}|{game.readTable(2, 1)}|{game.readTable(2, 2)}");
        }
        static void Main(string[] args)
        {
            bool willParse = false;
            string answer = null;
            int choice;
            bool willQuit = false;
            bool isAvailable = false;
            bool isWinner = false;
            bool playAgain = true;
            string player1;
            string player2;
            string winner = "no one";
            GameBoard game = new GameBoard();

            while (playAgain)
            {
                while (!willQuit)
                {
                    //Begin play and assign names.
                    game.SetBoard();
                    Console.WriteLine("Hello! Welcome to Tic-Tac-Toe! Please enter the name for Player 1");
                    player1 = Console.ReadLine();
                    Console.WriteLine("Please enter the name for Player 2");
                    player2 = Console.ReadLine();

                    //Shuffle names.
                    game.assignPlayers(player1, player2);

                    //Return names.
                    game.getPlayers(out player1, out player2);

                    //Display board.
                    DisplayBoard(game);

                    //Exit condition.
                    while (!willQuit && !isWinner)
                    {
                        //Turn.
                        //Player1
                        Console.WriteLine($"{player1}, you are placing \"O\". Please enter your choice for location or \"Q\" for quit.");
                        Console.WriteLine("You can choose from the following locations:");
                        Console.WriteLine("1,2,3");
                        Console.WriteLine("4,5,6");
                        Console.WriteLine("7,8,9");
                        //Validate and prompt until empty.
                        answer = Console.ReadLine();
                        if (answer == "Q")
                        {
                            willQuit = true;
                        }
                        else
                        {
                            willParse = Int32.TryParse(answer, out choice);
                            if (willParse && choice > 0 && choice < 10)
                            {
                                isAvailable = game.AssignBoard(choice, "player1");
                                while (!isAvailable)
                                {
                                    isAvailable = game.AssignBoard(GetInput.ForInt(1, 9), "player1");
                                }
                            }

                            else
                                while (!isAvailable)
                                {
                                    Console.WriteLine("Please enter an empty location.");
                                    isAvailable = game.AssignBoard(GetInput.ForInt(1, 9), "player1");
                                }

                        }

                        isAvailable = false;
                        //Display result.
                        DisplayBoard(game);
                        //Check winner.
                        if (game.turnCounter == 9)
                        {
                            isWinner = true;
                            winner = "no one";
                        }
                        else
                        {
                            isWinner = game.checkWin();
                            if (isWinner)
                            {
                                winner = player1;
                            }
                        }

                        if (!willQuit && !isWinner)
                        {
                            answer = null;
                            //Player2
                            Console.WriteLine($"{player2}, you are placing \"X\". Please enter your choice for location or hit \"Q\" to quit.");
                            Console.WriteLine("You can choose from the following locations:");
                            Console.WriteLine("1,2,3");
                            Console.WriteLine("4,5,6");
                            Console.WriteLine("7,8,9");
                            //Validate and prompt until empty.
                            answer = Console.ReadLine();
                            if (answer == "Q")
                            {
                                willQuit = true;
                            }
                            else
                            {
                                willParse = Int32.TryParse(answer, out choice);
                                if (willParse && choice > 0 && choice < 10)
                                {
                                    isAvailable = game.AssignBoard(choice, "player1");
                                    while (!isAvailable)
                                    {
                                        isAvailable = game.AssignBoard(GetInput.ForInt(1, 9), "player2");
                                    }
                                }

                                else
                                    while (!isAvailable)
                                    {
                                        Console.WriteLine("Please enter an empty location.");
                                        isAvailable = game.AssignBoard(GetInput.ForInt(1, 9), "player2");
                                    }

                            }
                            isAvailable = false;

                            //Display result.
                            DisplayBoard(game);
                            //Check winner.
                            if (game.turnCounter == 9)
                            {
                                winner = "no one";
                                isWinner = true;
                            }

                            else
                            {
                                isWinner = game.checkWin();
                                if (isWinner)
                                {
                                    winner = player2;
                                }
                            }
                        }
                    }
                    Console.WriteLine($"The game is over and {winner} has won!");

                    Console.WriteLine("Would you like to play again? Yes or No.");
                    answer = Console.ReadLine();
                    while (answer != "Yes" && answer != "No")
                    {
                        Console.WriteLine("Would you like to play again? Yes or No.");
                        answer = Console.ReadLine();
                    }
                    if (answer == "Yes")
                    {
                        playAgain = true;
                        willQuit = false;
                        isWinner = false;
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
