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
        //Shot Status        
        //Invalid,
        //Duplicate,
        //Miss,
        //Hit,
        //HitAndSunk,
        //Victory
        public void Cycle(string player1In, string player2In, Board board1In, Board board2In)
        {
            int row = 0;
            int column = 0;
            string player1 = player1In;
            string player2 = player2In;
            Board board1 = board1In;
            Board board2 = board2In;
            BoardDisplay PrintBoard = new BoardDisplay();
            Coordinate localCoordinate = new Coordinate(column, row);
            FireShotResponse localFireShotResponse = new FireShotResponse();
            CoordinatePromptController GetCoordinate = new CoordinatePromptController();

            while (localFireShotResponse.ShotStatus != ShotStatus.Victory)
            {
                localFireShotResponse.ShotStatus = ShotStatus.Invalid;
                while (localFireShotResponse.ShotStatus == ShotStatus.Duplicate || localFireShotResponse.ShotStatus == ShotStatus.Invalid)
                {
                    Console.WriteLine($"{player1}, here's your board. Please choose a valid, unused coordinate to fire at.");
                    PrintBoard.Display(board2);
                    GetCoordinate.CoordinatePrompt(out row, out column);
                    localCoordinate.XCoordinate = column;
                    localCoordinate.YCoordinate = row;
                    localFireShotResponse = board2.FireShot(localCoordinate);
                }

                switch (localFireShotResponse.ShotStatus)
                {
                    case ShotStatus.Hit:
                        Console.WriteLine($"That's a hit!");
                        break;
                    case ShotStatus.HitAndSunk:
                        Console.WriteLine($"That's a hit and you sunk {player2}'s {localFireShotResponse.ShipImpacted}!");
                        break;
                    case ShotStatus.Miss:
                        Console.WriteLine("You missed.");
                        break;
                    case ShotStatus.Victory:
                        Console.WriteLine($"{player1}, you have sunk all of {player2}'s ships and you have won the game! Congratulations!");
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press any key to clear the board and continue.");
                Console.ReadKey();
                Console.Clear();

                if (localFireShotResponse.ShotStatus != ShotStatus.Victory)
                {
                    localFireShotResponse.ShotStatus = ShotStatus.Invalid;
                    while (localFireShotResponse.ShotStatus == ShotStatus.Duplicate || localFireShotResponse.ShotStatus == ShotStatus.Invalid)
                    {
                        Console.WriteLine($"{player2}, here's your board. Please choose a valid, unused coordinate to fire at.");
                        PrintBoard.Display(board1);
                        GetCoordinate.CoordinatePrompt(out row, out column);
                        localCoordinate.XCoordinate = column;
                        localCoordinate.YCoordinate = row;
                        localFireShotResponse = board1.FireShot(localCoordinate);
                    }

                    switch (localFireShotResponse.ShotStatus)
                    {
                        case ShotStatus.Hit:
                            Console.WriteLine($"That's a hit!");
                            break;
                        case ShotStatus.HitAndSunk:
                            Console.WriteLine($"That's a hit and you sunk {player2}'s {localFireShotResponse.ShipImpacted}!");
                            break;
                        case ShotStatus.Miss:
                            Console.WriteLine("You missed.");
                            break;
                        case ShotStatus.Victory:
                            Console.WriteLine($"{player1}, you have sunk all of {player2}'s ships and you have won the game! Congratulations!");
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine("Press any key to clear the board and continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
