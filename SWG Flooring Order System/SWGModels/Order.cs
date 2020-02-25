using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGModels
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPreSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost { get; }
        public decimal LaborCost { get; }
        public decimal Tax { get; }
        public decimal Total { get; }

        public Order(int orderNumber, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot)
        {
            OrderNumber = orderNumber;
            CustomerName = customerName;
            State = state;
            TaxRate = taxRate;
            ProductType = productType;
            Area = area;
            CostPreSquareFoot = costPerSquareFoot;
            LaborCostPerSquareFoot = laborCostPerSquareFoot;
            MaterialCost = Area * CostPreSquareFoot;
            LaborCost = Area * LaborCostPerSquareFoot;
            Tax = (MaterialCost * LaborCost) / (TaxRate / 100);
            Total = MaterialCost + LaborCost + Tax;
        }

        public Order()
        {
            MaterialCost = Area * CostPreSquareFoot;
            LaborCost = Area * LaborCostPerSquareFoot;
            Tax = (MaterialCost * LaborCost) / (TaxRate / 100);
            Total = MaterialCost + LaborCost + Tax;
        }
    }
}
