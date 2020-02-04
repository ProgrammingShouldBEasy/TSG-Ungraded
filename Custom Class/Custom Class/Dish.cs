using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Class
{
    public class Dish
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsBroken { get; set; }
        public bool IsASet { get; set; }
        public Purpose Use { get; set; }

    }
}
