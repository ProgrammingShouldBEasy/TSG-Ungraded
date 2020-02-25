using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels;

namespace SWGModels.Responses
{
    public class OrderResponse
    {
        public Order order { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}
