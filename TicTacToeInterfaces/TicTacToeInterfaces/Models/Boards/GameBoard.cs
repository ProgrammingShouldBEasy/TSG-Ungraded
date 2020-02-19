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

        public GameBoard(string input)
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
        public bool SetBoard(Choices input, string player)
        {
            switch (input)
            {
                case Choices.NW:
                    if (board[0, 0] == "X" || board[0, 0] == "O")
                    { 
                        return false; 
                    }
                    else
                    {
                        board[0, 0] = player;
                        return true;
                    }
                case Choices.N:
                    if (board[0, 1] == "X" || board[0, 1] == "O")
                    {
                        return false;
                    }
                    else
                    {
                        board[0, 1] = player;
                        return true;
                    }
                case Choices.NE:
                    if (board[0, 2] == "X" || board[0, 2] == "O")
                    {
                        return false;
                    }
                    else
                    {
                        board[0, 2] = player;
                        return true;
                    }
                case Choices.W:
                    if (board[1, 0] == "X" || board[1, 0] == "O")
                    {
                        return false;
                    }
                    else
                    {
                        board[1, 0] = player;
                        return true;
                    }
                case Choices.C:
                    if (board[1, 1] == "X" || board[1, 1] == "O")
                    {
                        return false;
                    }
                    else
                    {
                        board[1, 1] = player;
                        return true;
                    }
                case Choices.E:
                    if (board[1, 2] == "X" || board[1, 2] == "O")
                    {
                        return false;
                    }
                    else
                    {
                        board[1, 2] = player;
                        return true;
                    }
                case Choices.SW:
                    if (board[2, 0] == "X" || board[2, 0] == "O")
                    {
                        return false;
                    }
                    else
                    {
                        board[2, 0] = player;
                        return true;
                    }
                case Choices.S:
                    if (board[2, 1] == "X" || board[2, 1] == "O")
                    {
                        return false;
                    }
                    else
                    {
                        board[2, 1] = player;
                        return true;
                    }
                case Choices.SE:
                    if (board[2, 2] == "X" || board[2, 2] == "O")
                    {
                        return false;
                    }
                    else
                    {
                        board[2, 2] = player;
                        return true;
                    }
                default:
                    return false;
            }
        }

        public string GetBoard(int a, int b)
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
