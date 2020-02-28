using SWGLogic;
using SWGModels;
using SWGModels.Requests;
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
                isValid = filteredName.Count() == customerName.Length && customerName != null && (customerName.ToLower().Contains("a") || customerName.ToLower().Contains("b") || customerName.ToLower().Contains("c") || customerName.ToLower().Contains("d") || customerName.ToLower().Contains("e") || customerName.ToLower().Contains("f") || customerName.ToLower().Contains("g") || customerName.ToLower().Contains("h") || customerName.ToLower().Contains("i") || customerName.ToLower().Contains("j") || customerName.ToLower().Contains("k") || customerName.ToLower().Contains("l") || customerName.ToLower().Contains("m") || customerName.ToLower().Contains("n") || customerName.ToLower().Contains("o") || customerName.ToLower().Contains("p") || customerName.ToLower().Contains("q") || customerName.ToLower().Contains("r") || customerName.ToLower().Contains("s") || customerName.ToLower().Contains("t") || customerName.ToLower().Contains("u") || customerName.ToLower().Contains("v") || customerName.ToLower().Contains("w") || customerName.ToLower().Contains("x") || customerName.ToLower().Contains("y") || customerName.ToLower().Contains("z"));
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
                UI2LogicRequest request = new UI2LogicRequest();
                request.order = order;
                request.dateTime = dateTime;
                OM.AddOrder(request);
            }
        }
    }
}
