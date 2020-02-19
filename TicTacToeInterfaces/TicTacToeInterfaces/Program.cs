using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeInterfaces.Models.Players;
using TicTacToeInterfaces.Models.Interfaces;
using TicTacToeInterfaces.Models.Boards;
using TicTacToeInterfaces.Models;

namespace TicTacToeInterfaces
{
    class Program
    {
        public static void DisplayBoard(GameBoard game)
        {
            Console.WriteLine($"{game.GetBoard(0, 0)}|{game.GetBoard(0, 1)}|{game.GetBoard(0, 2)}");
            Console.WriteLine("------");
            Console.WriteLine($"{game.GetBoard(1, 0)}|{game.GetBoard(1, 1)}|{game.GetBoard(1, 2)}");
            Console.WriteLine("------");
            Console.WriteLine($"{game.GetBoard(2, 0)}|{game.GetBoard(2, 1)}|{game.GetBoard(2, 2)}");
        }

        static void Main(string[] args)
        {
            IPlayer player1;
            IPlayer player2;
            bool gameOver = false;
            int turnCounter = 1;
            GameBoard gameBoard = new GameBoard(" ");

            Console.WriteLine("What is player 1?");
            string p1 = Console.ReadLine();

            if (p1 == "human")
            {
                player1 = new HumanPlayer();
            }
            else
            {
                player1 = new ComputerPlayer();
            }

            Console.WriteLine("What is player 2?");
            string p2 = Console.ReadLine();

            if (p2 == "human")
            {
                player2 = new HumanPlayer();
            }

            else
            {
                player2 = new ComputerPlayer();
            }



            while (gameOver == false)
            {
                DisplayBoard(gameBoard);
                gameBoard.SetBoard(player1.GetMove(), "X");
                gameOver = gameBoard.CheckWin();
                if (gameOver == false)
                {
                    DisplayBoard(gameBoard);
                    gameBoard.SetBoard(player2.GetMove(), "O");
                }
                turnCounter++;
                gameOver = turnCounter > 9 || gameBoard.CheckWin();
            }
            Console.WriteLine("Game Over! Someone won or no one won.");
            DisplayBoard(gameBoard);
            Console.ReadKey();

        }
    }
}
