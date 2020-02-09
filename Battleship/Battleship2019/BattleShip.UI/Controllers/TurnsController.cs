using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI.Displays;

namespace BattleShip.UI.Controllers
{
    public class TurnsController
    {
        public void CoordinatePrompt()
        {
            string coordinate;
            int coordinateRow;
            int coordinateColumn;
            string newString;
            Console.WriteLine("Please enter a coordinate from A - J and from 1 - 10. Example: A10.");
            coordinate = Console.ReadLine();
            while (
                //Makes sure the response is between 2-3 characters long.
                (coordinate.Length < 2 || coordinate.Length > 3)
                ||
                //Makes sure the first character in the response is A - J.
                (coordinate[0] != 'A' && coordinate[0] != 'B' && coordinate[0] != 'C' && coordinate[0] != 'D' && coordinate[0] != 'E' && coordinate[0] != 'F' && coordinate[0] != 'G' && coordinate[0] != 'H' && coordinate[0] != 'I' && coordinate[0] != 'J')
                ||
                //Makes sure the 2-3 characters in the response are 1 - 10.
                //"10"
                (
                (coordinate.Length == 3 && coordinate[1] != '1' && coordinate[2] != '0')
               &&
                //"1" - "9"
                (coordinate.Length == 2 && (coordinate[1] != '1' || coordinate[1] != '2' || coordinate[1] != '3' || coordinate[1] != '4' || coordinate[1] != '5' || coordinate[1] != '6' || coordinate[1] != '7' || coordinate[1] != '8' || coordinate[1] != '9')
                )
                )
                )

            {
                Console.WriteLine("Please provide a coordinate of the correct length, either 2 or 3 characters, starting with an uppercase letter from A - J and followed by a number from 1 - 10.");
                coordinate = Console.ReadLine();
            }

            switch (coordinate[0])
            {
                case 'A':
                    coordinateRow = 1;
                    break;
                case 'B':
                    coordinateRow = 2;
                    break;
                case 'C':
                    coordinateRow = 3;
                    break;
                case 'D':
                    coordinateRow = 4;
                    break;
                case 'E':
                    coordinateRow = 5;
                    break;
                case 'F':
                    coordinateRow = 6;
                    break;
                case 'G':
                    coordinateRow = 7;
                    break;
                case 'H':
                    coordinateRow = 8;
                    break;
                case 'I':
                    coordinateRow = 9;
                    break;
                case 'J':
                    coordinateRow = 10;
                    break;
                default:
                    break;
            }

            if (coordinate.Length == 2)
            {
                newString = coordinate.Substring(1, 1);
            }

            else
            {
                newString = coordinate.Substring(1, 2);
            }

            coordinateColumn = Int32.Parse(newString);
        }
        public void Cycle(string player1In, string player2In, Board board1In, Board board2In)
        {
            string player1 = player1In;
            string player2 = player2In;
            Board board1 = board1In;
            Board board2 = board2In;
            BoardDisplay PrintBoard = new BoardDisplay();
        }
    }
}
