using SWGLogic;
using SWGModels;
using SWGModels.Requests;
using SWGModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWG_Flooring_Order_System.Workflows
{
    public class RemoveOrder
    {
        public static void Execute()
        {
            int orderInt = 0;
            string response = null;
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
                    Console.WriteLine("Which order do you want to remove? Choose by the order number. Your entry must be an Order Number from the list.");
                    foreach (var x in orders)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Order Number: {x.OrderNumber}" +
                            $"\nCustomer Name: {x.CustomerName}" +
                            $"\nState: {x.State}" +
                            $"\nTax Rate: {x.TaxRate:P}" +
                            $"\nProduct: {x.ProductType}" +
                            $"\nArea: {x.Area} sq f" +
                            $"\nCost/sq f: {x.CostPreSquareFoot:c}" +
                            $"\nLabor Cost/sq f: {x.LaborCostPerSquareFoot:c}" +
                            $"\nMaterial Cost: {x.MaterialCost:c}" +
                            $"\nLabor Cost: {x.LaborCost:c}" +
                            $"\n" +
                            $"\nTax: {x.Tax:c}" +
                            $"\nTotal: {x.Total:c}");
                    }
                    while (!isValid && !orders.Exists(x => x.OrderNumber == orderInt))
                    {
                        isValid = Int32.TryParse(Console.ReadLine(), out orderInt);
                    }
                    isValid = false;
                    while (!isValid)
                    {
                        foreach (var x in orders.Where(x => x.OrderNumber == orderInt))
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Order Number: {x.OrderNumber}" +
                                $"\nCustomer Name: {x.CustomerName}" +
                                $"\nState: {x.State}" +
                                $"\nTax Rate: {x.TaxRate:P}" +
                                $"\nProduct: {x.ProductType}" +
                                $"\nArea: {x.Area} sq f" +
                                $"\nCost/sq f: {x.CostPreSquareFoot:c}" +
                                $"\nLabor Cost/sq f: {x.LaborCostPerSquareFoot:c}" +
                                $"\nMaterial Cost: {x.MaterialCost:c}" +
                                $"\nLabor Cost: {x.LaborCost:c}" +
                                $"\n" +
                                $"\nTax: {x.Tax:c}" +
                                $"\nTotal: {x.Total:c}");
                        }
                        Console.WriteLine("Would you like to delete this order? Y or N.");
                        response = Console.ReadLine();
                        isValid = response == "Y" || response == "N";
                    }
                    if (response == "Y")
                    {
                        UI2LogicRequest request = new UI2LogicRequest();
                        request.order = orders.FirstOrDefault(y => y.OrderNumber == orderInt);
                        request.dateTime = dateTime;
                        UI2LogicResponse removeResponse = OM.RemoveOrder(request);
                        if (removeResponse.success)
                        {
                            Console.WriteLine("Order deleted. Press any key to continue.");
                        }

                        else

                            Console.WriteLine("Something went wrong. Contact your system admin and buy them coffee.");
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
