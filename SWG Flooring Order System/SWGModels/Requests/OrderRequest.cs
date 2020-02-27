using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels;

namespace SWGModels.Requests
{
    public class OrderRequest
    {
        public List<Order> list { get; set; }
        public DateTime Date { get; set; }
    }
}
