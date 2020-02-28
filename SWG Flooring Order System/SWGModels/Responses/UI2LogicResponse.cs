using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGModels.Responses
{
    public class UI2LogicResponse
    {
        public Order order { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}
