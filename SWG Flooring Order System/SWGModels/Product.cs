using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGModels
{
    public class Product
    {
        public string ProductType { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }

        public Product(string a, decimal b, decimal c)
        {
            ProductType = a;
            CostPerSquareFoot = b;
            LaborCostPerSquareFoot = c;
        }
    }
}
