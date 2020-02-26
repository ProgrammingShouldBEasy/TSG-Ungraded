using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels;
using SWGModels.Interfaces;

namespace SWGDAL
{
    public class ProductionRepoProducts : IRepoProducts
    {
        public string filePath;

        public ProductionRepoProducts()
        {
            filePath = @"C:\Users\Cain\source\repos\TSG Ungraded\SWG Flooring Order System\SWGDAL\Data\Products.txt";
        }

        public List<Product> LoadProducts()
        {
            return ReadFromFileProducts();
        }

        private List<Product> ReadFromFileProducts()
        {
            List<Product> list = new List<Product>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] columns;
                string line;

                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    columns = line.Split('°');
                    Product product = new Product(columns[0], decimal.Parse(columns[1]), decimal.Parse(columns[2]));
                    list.Add(product);
                }
                return list;
            }
        }
    }
}
