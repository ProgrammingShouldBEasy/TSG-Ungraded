using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeInterfaces.Models.Boards
{
    public class GameBoard
    {
        private string[,] board = new string[3, 3];

        public GameBoard (string input)
        {
            board[0, 0] = input;
            board[0, 1] = input;
            board[0, 2] = input;
            board[1, 0] = input;
            board[1, 1] = input;
            board[1, 2] = input;
            board[2, 0] = input;
            board[2, 1] = input;
            board[2, 2] = input;
        }

        public GameBoard()
        { }
        public void SetBoard (Choices input, string player)
        {
            switch (input)
            {
                case Choices.NW:
                    board[0, 0] = player;
                    break;
                case Choices.N:
                    board[0, 1] = player;
                    break;
                case Choices.NE:
                    board[0, 2] = player;
                    break;
                case Choices.W:
                    board[1, 0] = player;
                    break;
                case Choices.C:
                    board[1, 1] = player;
                    break;
                case Choices.E:
                    board[1, 2] = player;
                    break;
                case Choices.SW:
                    board[2, 0] = player;
                    break;
                case Choices.S:
                    board[2, 1] = player;
                    break;
                case Choices.SE:
                    board[2, 2] = player;
                    break;
                default:
                    break;
            }
        }

        public string GetBoard (int a, int b)
        {
            return board[a, b];
        }

        public bool CheckWin()
        {
            if (GetBoard(0, 0) == GetBoard(0, 1) && GetBoard(0, 0) == GetBoard(0, 2) && GetBoard(0, 0) != " ")
            {
                return true;
            }

            if (GetBoard(0, 0) == GetBoard(1, 1) && GetBoard(0, 0) == GetBoard(2, 2) && GetBoard(0, 0) != " ")
            {
                return true;
            }

            if (GetBoard(0, 0) == GetBoard(1, 0) && GetBoard(0, 0) == GetBoard(2, 0) && GetBoard(0, 0) != " ")
            {
                return true;
            }

            if (GetBoard(1, 0) == GetBoard(1, 1) && GetBoard(1, 0) == GetBoard(1, 2) && GetBoard(1, 0) != " ")
            {
                return true;
            }

            if (GetBoard(2, 0) == GetBoard(1, 1) && GetBoard(2, 0) == GetBoard(0, 2) && GetBoard(2, 0) != " ")
            {
                return true;
            }

            if (GetBoard(2, 0) == GetBoard(2, 1) && GetBoard(2, 0) == GetBoard(2, 2) && GetBoard(2, 0) != " ")
            {
                return true;
            }

            if (GetBoard(0, 0) == GetBoard(0, 1) && GetBoard(0, 1) == GetBoard(0, 2) && GetBoard(0, 0) != " ")
            {
                return true;
            }

            if (GetBoard(0, 2) == GetBoard(1, 2) && GetBoard(0, 2) == GetBoard(2, 2) && GetBoard(0, 2) != " ")
            {
                return true;
            }

            return false;
        }
    }
}
