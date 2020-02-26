using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels;
using SWGModels.Interfaces;

namespace SWGDAL
{
    public class TestRepoProducts : IRepoProducts
    {
        List<Product> list = new List<Product> { new Product("Carpet",2.25m,2.10m), new Product("Laminate",1.75m,2.10m), new Product("Tile",3.50m,4.15m), new Product("Wood",5.15m,4.75m) };
        public List<Product> LoadProducts()
        {
            return list;
        }
    }
}
