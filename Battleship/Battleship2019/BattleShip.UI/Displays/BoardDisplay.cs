using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI.Displays
{
    public class BoardDisplay
    {
        public void Display (Board boardIn)
        {
            Board localBoard = boardIn;
            int x = 1;
            int y = 1;
            string localY = null;

            Coordinate localCoordinate = new Coordinate(x, y);

            Console.WriteLine("Board");
            Console.WriteLine(" ||1||2||3||4||5||6||7||8||9|10|");
            for (int i = 0; i < 10; i++)
            {
                switch (y)
                {
                    case 1:
                        localY = "A";
                        break;
                    case 2:
                        localY = "B";
                        break;
                    case 3:
                        localY = "C";
                        break;
                    case 4:
                        localY = "D";
                        break;
                    case 5:
                        localY = "E";
                        break;
                    case 6:
                        localY = "F";
                        break;
                    case 7:
                        localY = "G";
                        break;
                    case 8:
                        localY = "H";
                        break;
                    case 9:
                        localY = "I";
                        break;
                    case 10:
                        localY = "J";
                        break;
                    default:
                        break;
                }
                Console.Write($"{localY}|");
                for (int ii = 0; ii < 10; ii++)
                {
                    localCoordinate.XCoordinate = x;
                    localCoordinate.YCoordinate = y;
                    switch (localBoard.CheckCoordinate(localCoordinate))
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("|H|");
                            break;
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("|M|");
                            break;
                        case ShotHistory.Unknown:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("| |");
                            break;
                        default:
                            break;
                    }
                    x++;
                }
                Console.WriteLine();
                x = 1;
                y++;
            }
        }
    }
}
