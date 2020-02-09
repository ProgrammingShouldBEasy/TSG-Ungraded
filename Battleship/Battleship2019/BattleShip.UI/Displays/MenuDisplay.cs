using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI.Displays
{
    public static class MenuDisplay
    {
        public static void Menu()
        {
            Console.WriteLine("WELCOME TO BATTLESHIP");
            Console.WriteLine("PRESS ANY KEY TO CONTINUE");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
