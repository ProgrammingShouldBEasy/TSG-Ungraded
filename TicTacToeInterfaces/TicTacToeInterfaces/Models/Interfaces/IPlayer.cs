using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeInterfaces.Models.Interfaces
{
    interface IPlayer
    {
        Choices GetMove();
    }
}
