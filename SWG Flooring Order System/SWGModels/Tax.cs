using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGModels
{
    public class Tax
    {
        public string StateAbreviation { get; set; }
        public string StateName { get; set; }
        public decimal TaxRate { get; set; }
    }
}
