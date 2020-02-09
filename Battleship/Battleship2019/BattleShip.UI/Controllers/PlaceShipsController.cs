using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI.Controllers
{
    public class PlaceShipsController
    {
        public void PlaceFirst (string player1, Board board1In, out Board board1Out)
        {
            string localString = player1;
            Board localBoard = board1In;
            board1Out = localBoard;
        }

        public void PlaceSecond (string player2, Board board2In, out Board board2Out)
        {
            string localstring = player2;
            Board localboard = board2In;
            board2Out = localboard;
        }
    }
}
