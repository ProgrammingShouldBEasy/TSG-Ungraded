using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI.Controllers
{
    public class EndController
    {
        public void Display (out bool play)
        {
            bool localBool;
            string answer = null;
            while (answer != "Yes" && answer != "No")
            {
                Console.WriteLine("The game is over. Would you like to play again? Yes or No?");
                answer = Console.ReadLine();
            }

            if (answer == "Yes")
            {
                localBool = true;
            }

            else
            {
                localBool = false;
            }

            play = localBool;
        }
    }
}
