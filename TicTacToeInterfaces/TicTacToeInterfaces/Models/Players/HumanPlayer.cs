using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeInterfaces.Models.Interfaces;

namespace TicTacToeInterfaces.Models.Players
{
    public class HumanPlayer : IPlayer
    {
        public Choices GetMove()
        {
            Console.WriteLine("What is your choice? 1-9.");
            return (Choices)Int32.Parse(Console.ReadLine());
        }
    }
}
