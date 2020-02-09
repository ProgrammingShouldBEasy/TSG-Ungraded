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
        public void Cycle (string player1In, string player2In, Board board1In, Board board2In)
        {
            string player1 = player1In;
            string player2 = player2In;
            Board board1 = board1In;
            Board board2 = board2In;
            BoardDisplay PrintBoard = new BoardDisplay();
        }
    }
}
