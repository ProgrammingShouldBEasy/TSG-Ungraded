using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.UI.Displays;
using BattleShip.UI.Controllers;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.BLL;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        { 
            //Player name fields.
            string player1;
            string player2;

            //Will play bool.
            bool play = true;

            //WorkFlow Controllers.
            MenuController Menu = new MenuController();
            NamesController Names = new NamesController();
            PlaceShipsController Place = new PlaceShipsController();
            TurnsController Turns = new TurnsController();
            EndController End = new EndController();

            //Game execution.
            while (play == true)
            {
                //Player board instances. Placed inside the while play iterator so a new Board instance is created per play session, the old ones will be garbage collected.
                Board Board1 = new Board();
                Board Board2 = new Board();

                Menu.Display();
                Names.GetFirst(out player1);
                Names.GetSecond(out player2);
                Names.Randomize(player1, player2, out player1, out player2);
                Place.PlaceFirst(player1, Board1, out Board1);
                Place.PlaceSecond(player2, Board2, out Board2);
                Turns.Cycle(player1, player2, Board1, Board2);
                End.Display(out play);
            }
            Console.ReadLine();
        }
    }
}
