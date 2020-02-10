using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI.Controllers;
using BattleShip.UI.Displays;

namespace BattleShip.UI.Controllers
{
    //Ships         
    //Destroyer,
    //Submarine,
    //Cruiser,
    //Battleship,
    //Carrier
    public class PlaceShipsController
    {
        CoordinatePromptController GetCoordinate = new CoordinatePromptController();
        BoardDisplay localDisplay = new BoardDisplay();
        public void PlaceFirst(string player1, Board board1In, out Board board1Out)
        {
            int row;
            int column;
            string direction = null;
            PlaceShipRequest Placer = new PlaceShipRequest();
            string player = player1;
            Console.WriteLine($"{player}, it's your turn to place your ships.");
            Board localBoard = board1In;
            bool valid = false;

            Console.WriteLine("Here's your board.");
            localDisplay.Display(localBoard);

            while (!valid)
            {
                Console.WriteLine("Provide a starting coordinate for your Destroyer.");
                GetCoordinate.CoordinatePrompt(out row, out column);
                while (direction != "Up" && direction != "Down" && direction != "Left" && direction != "Right")
                {
                    Console.WriteLine("Provide a direction for your Destroyer: Up, Down, Left, or Right.");
                    direction = Console.ReadLine();
                }
                Placer.Coordinate = new Coordinate(row, column);
                switch (direction)
                {
                    case "Up":
                        Placer.Direction = ShipDirection.Up;
                        break;
                    case "Down":
                        Placer.Direction = ShipDirection.Down;
                        break;
                    case "Left":
                        Placer.Direction = ShipDirection.Left;
                        break;
                    case "Right":
                        Placer.Direction = ShipDirection.Right;
                        break;
                    default:
                        break;
                }
                Placer.ShipType = ShipType.Destroyer;
                ShipPlacement localEnum = localBoard.PlaceShip(Placer);
                if (localEnum == ShipPlacement.Ok)
                    valid = true;
            }

            valid = false;
            direction = null;

            while (!valid)
            {
                Console.WriteLine("Provide a starting coordinate for your Submarine.");
                GetCoordinate.CoordinatePrompt(out row, out column);
                while (direction != "Up" && direction != "Down" && direction != "Left" && direction != "Right")
                {
                    Console.WriteLine("Provide a direction for your Submarine: Up, Down, Left, or Right.");
                    direction = Console.ReadLine();
                }
                Placer.Coordinate = new Coordinate(row, column);
                switch (direction)
                {
                    case "Up":
                        Placer.Direction = ShipDirection.Up;
                        break;
                    case "Down":
                        Placer.Direction = ShipDirection.Down;
                        break;
                    case "Left":
                        Placer.Direction = ShipDirection.Left;
                        break;
                    case "Right":
                        Placer.Direction = ShipDirection.Right;
                        break;
                    default:
                        break;
                }
                Placer.ShipType = ShipType.Submarine;
                ShipPlacement localEnum = localBoard.PlaceShip(Placer);
                if (localEnum == ShipPlacement.Ok)
                    valid = true;
            }

            valid = false;
            direction = null;

            while (!valid)
            {
                Console.WriteLine("Provide a starting coordinate for your Cruiser.");
                GetCoordinate.CoordinatePrompt(out row, out column);
                while (direction != "Up" && direction != "Down" && direction != "Left" && direction != "Right")
                {
                    Console.WriteLine("Provide a direction for your Cruiser: Up, Down, Left, or Right.");
                    direction = Console.ReadLine();
                }
                Placer.Coordinate = new Coordinate(row, column);
                switch (direction)
                {
                    case "Up":
                        Placer.Direction = ShipDirection.Up;
                        break;
                    case "Down":
                        Placer.Direction = ShipDirection.Down;
                        break;
                    case "Left":
                        Placer.Direction = ShipDirection.Left;
                        break;
                    case "Right":
                        Placer.Direction = ShipDirection.Right;
                        break;
                    default:
                        break;
                }
                Placer.ShipType = ShipType.Cruiser;
                ShipPlacement localEnum = localBoard.PlaceShip(Placer);
                if (localEnum == ShipPlacement.Ok)
                    valid = true;
            }

            valid = false;
            direction = null;

            while (!valid)
            {
                Console.WriteLine("Provide a starting coordinate for your Battleship.");
                GetCoordinate.CoordinatePrompt(out row, out column);
                while (direction != "Up" && direction != "Down" && direction != "Left" && direction != "Right")
                {
                    Console.WriteLine("Provide a direction for your Battleship: Up, Down, Left, or Right.");
                    direction = Console.ReadLine();
                }
                Placer.Coordinate = new Coordinate(row, column);
                switch (direction)
                {
                    case "Up":
                        Placer.Direction = ShipDirection.Up;
                        break;
                    case "Down":
                        Placer.Direction = ShipDirection.Down;
                        break;
                    case "Left":
                        Placer.Direction = ShipDirection.Left;
                        break;
                    case "Right":
                        Placer.Direction = ShipDirection.Right;
                        break;
                    default:
                        break;
                }
                Placer.ShipType = ShipType.Battleship;
                ShipPlacement localEnum = localBoard.PlaceShip(Placer);
                if (localEnum == ShipPlacement.Ok)
                    valid = true;
            }

            valid = false;
            direction = null;

            while (!valid)
            {
                Console.WriteLine("Provide a starting coordinate for your Carrier.");
                GetCoordinate.CoordinatePrompt(out row, out column);
                while (direction != "Up" && direction != "Down" && direction != "Left" && direction != "Right")
                {
                    Console.WriteLine("Provide a direction for your Carrier: Up, Down, Left, or Right.");
                    direction = Console.ReadLine();
                }
                Placer.Coordinate = new Coordinate(row, column);
                switch (direction)
                {
                    case "Up":
                        Placer.Direction = ShipDirection.Up;
                        break;
                    case "Down":
                        Placer.Direction = ShipDirection.Down;
                        break;
                    case "Left":
                        Placer.Direction = ShipDirection.Left;
                        break;
                    case "Right":
                        Placer.Direction = ShipDirection.Right;
                        break;
                    default:
                        break;
                }
                Placer.ShipType = ShipType.Carrier;
                ShipPlacement localEnum = localBoard.PlaceShip(Placer);
                if (localEnum == ShipPlacement.Ok)
                    valid = true;
            }

            board1Out = localBoard;
            Console.WriteLine($"{player}, your ships have been placed. Press any key to clear the board and let the next player place their ships.");
            Console.ReadKey();
            Console.Clear();
        }

        public void PlaceSecond(string player2, Board board2In, out Board board2Out)
        {
            int row;
            int column;
            string direction = null;
            PlaceShipRequest Placer = new PlaceShipRequest();
            string player = player2;
            Console.WriteLine($"{player}, it's your turn to place your ships.");
            Board localBoard = board2In;
            bool valid = false;

            Console.WriteLine("Here's your board.");
            localDisplay.Display(localBoard);

            while (!valid)
            {
                Console.WriteLine("Provide a starting coordinate for your Destroyer.");
                GetCoordinate.CoordinatePrompt(out row, out column);
                while (direction != "Up" && direction != "Down" && direction != "Left" && direction != "Right")
                {
                    Console.WriteLine("Provide a direction for your Destroyer: Up, Down, Left, or Right.");
                    direction = Console.ReadLine();
                }
                Placer.Coordinate = new Coordinate(row, column);
                switch (direction)
                {
                    case "Up":
                        Placer.Direction = ShipDirection.Up;
                        break;
                    case "Down":
                        Placer.Direction = ShipDirection.Down;
                        break;
                    case "Left":
                        Placer.Direction = ShipDirection.Left;
                        break;
                    case "Right":
                        Placer.Direction = ShipDirection.Right;
                        break;
                    default:
                        break;
                }
                Placer.ShipType = ShipType.Destroyer;
                ShipPlacement localEnum = localBoard.PlaceShip(Placer);
                if (localEnum == ShipPlacement.Ok)
                    valid = true;
            }

            valid = false;
            direction = null;

            while (!valid)
            {
                Console.WriteLine("Provide a starting coordinate for your Submarine.");
                GetCoordinate.CoordinatePrompt(out row, out column);
                while (direction != "Up" && direction != "Down" && direction != "Left" && direction != "Right")
                {
                    Console.WriteLine("Provide a direction for your Submarine: Up, Down, Left, or Right.");
                    direction = Console.ReadLine();
                }
                Placer.Coordinate = new Coordinate(row, column);
                switch (direction)
                {
                    case "Up":
                        Placer.Direction = ShipDirection.Up;
                        break;
                    case "Down":
                        Placer.Direction = ShipDirection.Down;
                        break;
                    case "Left":
                        Placer.Direction = ShipDirection.Left;
                        break;
                    case "Right":
                        Placer.Direction = ShipDirection.Right;
                        break;
                    default:
                        break;
                }
                Placer.ShipType = ShipType.Submarine;
                ShipPlacement localEnum = localBoard.PlaceShip(Placer);
                if (localEnum == ShipPlacement.Ok)
                    valid = true;
            }

            valid = false;
            direction = null;

            while (!valid)
            {
                Console.WriteLine("Provide a starting coordinate for your Cruiser.");
                GetCoordinate.CoordinatePrompt(out row, out column);
                while (direction != "Up" && direction != "Down" && direction != "Left" && direction != "Right")
                {
                    Console.WriteLine("Provide a direction for your Cruiser: Up, Down, Left, or Right.");
                    direction = Console.ReadLine();
                }
                Placer.Coordinate = new Coordinate(row, column);
                switch (direction)
                {
                    case "Up":
                        Placer.Direction = ShipDirection.Up;
                        break;
                    case "Down":
                        Placer.Direction = ShipDirection.Down;
                        break;
                    case "Left":
                        Placer.Direction = ShipDirection.Left;
                        break;
                    case "Right":
                        Placer.Direction = ShipDirection.Right;
                        break;
                    default:
                        break;
                }
                Placer.ShipType = ShipType.Cruiser;
                ShipPlacement localEnum = localBoard.PlaceShip(Placer);
                if (localEnum == ShipPlacement.Ok)
                    valid = true;
            }

            valid = false;
            direction = null;

            while (!valid)
            {
                Console.WriteLine("Provide a starting coordinate for your Battleship.");
                GetCoordinate.CoordinatePrompt(out row, out column);
                while (direction != "Up" && direction != "Down" && direction != "Left" && direction != "Right")
                {
                    Console.WriteLine("Provide a direction for your Battleship: Up, Down, Left, or Right.");
                    direction = Console.ReadLine();
                }
                Placer.Coordinate = new Coordinate(row, column);
                switch (direction)
                {
                    case "Up":
                        Placer.Direction = ShipDirection.Up;
                        break;
                    case "Down":
                        Placer.Direction = ShipDirection.Down;
                        break;
                    case "Left":
                        Placer.Direction = ShipDirection.Left;
                        break;
                    case "Right":
                        Placer.Direction = ShipDirection.Right;
                        break;
                    default:
                        break;
                }
                Placer.ShipType = ShipType.Battleship;
                ShipPlacement localEnum = localBoard.PlaceShip(Placer);
                if (localEnum == ShipPlacement.Ok)
                    valid = true;
            }

            valid = false;
            direction = null;

            while (!valid)
            {
                Console.WriteLine("Provide a starting coordinate for your Carrier.");
                GetCoordinate.CoordinatePrompt(out row, out column);
                while (direction != "Up" && direction != "Down" && direction != "Left" && direction != "Right")
                {
                    Console.WriteLine("Provide a direction for your Carrier: Up, Down, Left, or Right.");
                    direction = Console.ReadLine();
                }
                Placer.Coordinate = new Coordinate(row, column);
                switch (direction)
                {
                    case "Up":
                        Placer.Direction = ShipDirection.Up;
                        break;
                    case "Down":
                        Placer.Direction = ShipDirection.Down;
                        break;
                    case "Left":
                        Placer.Direction = ShipDirection.Left;
                        break;
                    case "Right":
                        Placer.Direction = ShipDirection.Right;
                        break;
                    default:
                        break;
                }
                Placer.ShipType = ShipType.Carrier;
                ShipPlacement localEnum = localBoard.PlaceShip(Placer);
                if (localEnum == ShipPlacement.Ok)
                    valid = true;
            }

            board2Out = localBoard;

            Console.WriteLine($"{player}, your ships have been placed. Press any key to clear the board and begin play.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
