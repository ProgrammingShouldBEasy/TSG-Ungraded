using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels.Interfaces;
using SWGModels;
using System.IO;

namespace SWGDAL
{
    public class ProductionRepoTaxes : IRepoTaxes
    {
        public string filePath;

        public ProductionRepoTaxes()
        {
            filePath = @"C:\Users\Cain\source\repos\TSG Ungraded\SWG Flooring Order System\SWGDAL\Data\Taxes.txt";
        }

        public List<Tax> LoadTaxes()
        {
            return ReadFromFileTaxes();
        }

        private List<Tax> ReadFromFileTaxes()
        {
            List<Tax> list = new List<Tax>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] columns;
                string line;

                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    columns = line.Split('°');
                    Tax tax = new Tax(columns[0], (columns[1]), decimal.Parse(columns[2]));
                    list.Add(tax);
                }
                return list;
            }
        }
    }
}
