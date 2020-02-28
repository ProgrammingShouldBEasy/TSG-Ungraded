using SWGLogic;
using SWGModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWG_Flooring_Order_System.Workflows
{
    public class DisplayOrder
    {
        public static void Execute()
        {
            bool isValid = false;
            string dateString;
            DateTime dateTime = DateTime.Today;
            OrderManager OM = OrderManagerFactory.Create();
            while (!isValid)
            {
                Console.WriteLine("What is the date of your order? It must be in a valid format: MM/DD/YYY.");
                dateString = Console.ReadLine();
                isValid = DateTime.TryParse(dateString, out dateTime);
            }
            isValid = false;
            List<Order> orders = OM.GetOrders(dateTime);
            while (!isValid)
            {
                if (orders != null && orders.Count() > 0)
                {
                    Console.WriteLine("Which order do you want to display? Choose by the order number. Your entry must be an Order Number from the list.");
                    foreach (var x in orders)
                    {
                        Console.WriteLine($"{x.CustomerName}, {x.OrderNumber}");
                    }
                    int orderInt = 0;
                    while (!(isValid && orders.Exists(x => x.OrderNumber == orderInt)))
                    {
                        isValid = Int32.TryParse(Console.ReadLine(), out orderInt);
                    }
                    foreach (var x in orders.Where(x => x.OrderNumber == orderInt))
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Order Number: {x.OrderNumber}" +
                            $"\nCustomer Name: {x.CustomerName}" +
                            $"\nState: {x.State}" +
                            $"\nTax Rate: {x.TaxRate}%" +
                            $"\nProduct: {x.ProductType}" +
                            $"\nArea: {x.Area} sq f" +
                            $"\nCost/sq f: {x.CostPreSquareFoot:c}" +
                            $"\nLabor Cost/sq f: {x.LaborCostPerSquareFoot:c}" +
                            $"\nMaterial Cost: {x.MaterialCost:c}" +
                            $"\nLabor Cost: {x.LaborCost:c}" +
                            $"\n" +
                            $"\nTax: {x.Tax:c}" +
                            $"\nTotal: {x.Total:c}");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("There are no orders for that date.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    isValid = true;
                }
            }
        }
    }
}
