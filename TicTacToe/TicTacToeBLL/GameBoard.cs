using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeBLL
{
    public class GameBoard
    {
        //NW = 0,0 - N = 0,1 - NE = 0,2
        //W  = 1,0 - C = 1,1 - E  = 1,2
        //SW = 2,0 - S = 2,1 - SE = 2,2

        private char[,] playTable = new char[3, 3];
        Random Players = new Random();
        private string player1;
        private string player2;
        public int turnCounter;

        public void SetBoard()
        {
            playTable[0, 0] = ' ';
            playTable[0, 1] = ' ';
            playTable[0, 2] = ' ';
            playTable[1, 0] = ' ';
            playTable[1, 1] = ' ';
            playTable[1, 2] = ' ';
            playTable[2, 0] = ' ';
            playTable[2, 1] = ' ';
            playTable[2, 2] = ' ';
        }

        public bool AssignBoard(int x, string y)
        {
            bool isAvailable = false;
            int left = 0;
            int right = 0;
            char choice;

            switch (x)
            {
                case 1:
                    left = 0;
                    right = 0;
                    break;
                case 2:
                    left = 0;
                    right = 1;
                    break;
                case 3:
                    left = 0;
                    right = 2;
                    break;
                case 4:
                    left = 1;
                    right = 0;
                    break;
                case 5:
                    left = 1;
                    right = 1;
                    break;
                case 6:
                    left = 1;
                    right = 2;
                    break;
                case 7:
                    left = 2;
                    right = 0;
                    break;
                case 8:
                    left = 2;
                    right = 1;
                    break;
                case 9:
                    left = 2;
                    right = 2;
                    break;
                default:
                    break;
            }

            if (playTable[left, right] == ' ')
            {
                isAvailable = true;
                if (y == "player1")
                {
                    choice = 'O';
                }

                else
                {
                    choice = 'X';
                }
                playTable[left, right] = choice;
                turnCounter++;
            }
            return isAvailable;
        }

        public char readTable(int x, int y)
        {
            char value = playTable[x, y];
            return value;
        }

        public bool checkWin()
        {
            bool isOver = false;

            if (readTable(0, 0) == readTable(0, 1) && readTable(0, 0) == readTable(0, 2) && readTable(0, 0) != ' ')
            {
                isOver = true;
            }

            if (readTable(0, 0) == readTable(1, 1) && readTable(0, 0) == readTable(2, 2) && readTable(0, 0) != ' ')
            {
                isOver = true;
            }

            if (readTable(0, 0) == readTable(1, 0) && readTable(0, 0) == readTable(2, 0) && readTable(0, 0) != ' ')
            {
                isOver = true;
            }

            if (readTable(1, 0) == readTable(1, 1) && readTable(1, 0) == readTable(1, 2) && readTable(1, 0) != ' ')
            {
                isOver = true;
            }

            if (readTable(2, 0) == readTable(1, 1) && readTable(2, 0) == readTable(0, 2) && readTable(2, 0) != ' ')
            {
                isOver = true;
            }

            if (readTable(2, 0) == readTable(2, 1) && readTable(2, 0) == readTable(2, 2) && readTable(2, 0) != ' ')
            {
                isOver = true;
            }

            if (readTable(0, 0) == readTable(0, 1) && readTable(0, 1) == readTable(0, 2) && readTable(0, 0) != ' ')
            {
                isOver = true;
            }

            if (readTable(0, 2) == readTable(1, 2) && readTable(0, 2) == readTable(2, 2) && readTable(0, 2) != ' ')
            {
                isOver = true;
            }

            return isOver;
        }

        public void assignPlayers(string x, string y)
        {
            if (Players.Next(1, 3) == 1)
            {
                player1 = x;
                player2 = y;
            }

            else
            {
                player1 = y;
                player2 = x;
            }
        }

        public void getPlayers(out string one, out string two)
        {
            one = player1;
            two = player2;
        }
    }
}

