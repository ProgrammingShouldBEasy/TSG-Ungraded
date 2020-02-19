using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeInterfaces.Models.Interfaces;
using TicTacToeInterfaces.Models;

namespace TicTacToeInterfaces.Models.Players
{
    public class ComputerPlayer : IPlayer
    {
        public Choices GetMove()
        {
            Random moveSelector = new Random();
            return (Choices)moveSelector.Next(1, 10);
        }
    }
}
