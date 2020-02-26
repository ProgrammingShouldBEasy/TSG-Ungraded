using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels;
using SWGModels.Interfaces;

namespace SWGDAL.Data
{
    public class TestRepoTaxes : IRepoTaxes
    {
        List<Tax> list = new List<Tax> { new Tax("OH","Ohio",6.25m), new Tax("PA","Penssylvania",6.75m), new Tax("MI","Michigan",5.75m), new Tax("IN","Indiana",6.00m)};
        public List<Tax> LoadTaxes()
        {
            return list;
        }
    }
}
