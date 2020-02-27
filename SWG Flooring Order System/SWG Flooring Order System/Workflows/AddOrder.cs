using SWGLogic;
using SWGModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWG_Flooring_Order_System.Workflows
{
    public class AddOrder
    {
        public static void Execute()
        {
            OrderManager OM = OrderManagerFactory.Create();
            string date = null;
            string customerName = null;
            string state = null;
            string productType = null;
            string areaString = null;
            decimal areaDecimal = 0;
            bool isValid = false;
            string response = null;
            DateTime dateTime = DateTime.Today;

            while (!isValid)
            {
                Console.WriteLine("What is the date of your order? It must be in the future and in a valid format: MM/DD/YYY.");
                date = Console.ReadLine();
                DateTime.TryParse(date, out dateTime);
                isValid = dateTime > DateTime.Today;
            }
            isValid = false;
            while (!isValid)
            {
                Console.WriteLine("What is the Customer Name? Can only include [a-z][A-Z][0-9], periods, and commas.");
                customerName = Console.ReadLine();
                List<char> filteredName = customerName.Where(x => Char.IsLetterOrDigit(x) || x.Equals(',') || x.Equals('.') || x.Equals(' ')).ToList();
                isValid = filteredName.Count() == customerName.Length && customerName != null;
            }
            isValid = false;
            while (!isValid)
            {
                Console.WriteLine("What State is this order for? It must be selected from the following: ");
                List<Tax> taxes = OM.GetTaxes();
                foreach (var x in taxes)
                {
                    Console.WriteLine($"{x.StateAbreviation}, {x.StateName}, Tax Rate: {x.TaxRate}");
                }
                state = Console.ReadLine();
                isValid = taxes.Exists(x => x.StateName.ToLower() == state.ToLower());
            }
            isValid = false;
            while (!isValid)
            {
                Console.WriteLine("What Product Type is this? It must be selected from the following: ");
                List<Product> products = OM.GetProducts();
                foreach (var x in products)
                {
                    Console.WriteLine($"{x.ProductType}, Cost/sq f: {x.CostPerSquareFoot}, Labor Cost/sq f: {x.LaborCostPerSquareFoot}");
                }
                productType = Console.ReadLine();
                isValid = products.Exists(x => x.ProductType.ToLower() == productType.ToLower());
            }
            isValid = false;
            while (!isValid)
            {
                Console.WriteLine("What is the Area in square feet? Must be greater than 100.");
                areaString = Console.ReadLine();
                isValid = decimal.TryParse(areaString, out areaDecimal) && areaDecimal > 100;
            }
            isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Is this the order you want to create? Y or N.");
                Console.WriteLine($"Date: {date}, Name: {customerName}, State: {state}, Product: {productType}, Area: {areaDecimal}.");
                response = Console.ReadLine();
                isValid = response == "Y" || response == "N";
            }
            if (response == "Y")
            {
                List<Order> orders = OM.GetOrders(dateTime);
                int orderNumber;
                if (orders != null && orders.Count() > 0)
                {
                    orderNumber = orders.Max(x => x.OrderNumber) + 1;
                }
                else
                {
                    orderNumber = 1;
                }
                
                Order order = new Order(orderNumber, customerName, state, OM.GetTaxes().FirstOrDefault(x => x.StateName.ToLower() == state.ToLower()).TaxRate, productType, areaDecimal, OM.GetProducts().FirstOrDefault(x => x.ProductType.ToLower() == productType.ToLower()).CostPerSquareFoot, OM.GetProducts().FirstOrDefault(x => x.ProductType.ToLower() == productType.ToLower()).LaborCostPerSquareFoot);
                OM.AddOrder(order, dateTime);
            }
        }
    }
}
