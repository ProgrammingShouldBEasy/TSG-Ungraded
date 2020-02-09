using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI.Controllers
{
    public class NamesController
    {
        public void GetFirst (out string player1)
        {
            Console.WriteLine("Please enter the name for Player 1.");
            string localString = Console.ReadLine();
            player1 = localString;
            Console.WriteLine($"Thank you, Player 1 is named {player1}. Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public void GetSecond (out string player2)
        {
            Console.WriteLine("Please enter the name for Player 2.");
            string localString = Console.ReadLine();
            player2 = localString;
            Console.WriteLine($"Thank you, Player 2 is named {player2}. Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public void Randomize (string player1In, string player2In, out string player1Out, out string player2Out)
        {
            string localString1;
            string localString2;
            Random NameRandomizer = new Random();
            if (NameRandomizer.Next(1, 3) == 1)
            {
                localString1 = player1In;
                localString2 = player2In;
            }
            else
            {
                localString1 = player2In;
                localString2 = player1In;
            }
            player1Out = localString1;
            player2Out = localString2;
            Console.WriteLine($"{localString1} wil be going first and {localString2} will be going second.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
