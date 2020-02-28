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
    public class EditOrder
    {
        public static void Execute()
        {
            UI2LogicRequest request = new UI2LogicRequest();
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
                    Console.WriteLine("Which order do you want to edit? Choose by the order number. Your entry must be an Order Number from the list.");
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
                    request.order = orders.FirstOrDefault(x => x.OrderNumber == orderInt);
                    isValid = false;
                    while (!isValid)
                    {
                        Console.WriteLine("What is the Customer Name? Can only include [a-z][A-Z][0-9], periods, and commas.");
                        string name = Console.ReadLine();
                            List<char> filteredName = name.Where(x => Char.IsLetterOrDigit(x) || x.Equals(',') || x.Equals('.') || x.Equals(' ')).ToList();
                            isValid = name == "" || filteredName.Count() == name.Length && name != null && (name.ToLower().Contains("a") || name.ToLower().Contains("b") || name.ToLower().Contains("c") || name.ToLower().Contains("d") || name.ToLower().Contains("e") || name.ToLower().Contains("f") || name.ToLower().Contains("g") || name.ToLower().Contains("h") || name.ToLower().Contains("i") || name.ToLower().Contains("j") || name.ToLower().Contains("k") || name.ToLower().Contains("l") || name.ToLower().Contains("m") || name.ToLower().Contains("n") || name.ToLower().Contains("o") || name.ToLower().Contains("p") || name.ToLower().Contains("q") || name.ToLower().Contains("r") || name.ToLower().Contains("s") || name.ToLower().Contains("t") || name.ToLower().Contains("u") || name.ToLower().Contains("v") || name.ToLower().Contains("w") || name.ToLower().Contains("x") || name.ToLower().Contains("y") || name.ToLower().Contains("z"));
                            if (isValid && name != "")
                            {
                                request.order.CustomerName = name;
                            }
                        
                        else
                        {
                            request.order.CustomerName = orders.FirstOrDefault(y => y.OrderNumber == orderInt).CustomerName;
                        }
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
                        string state = Console.ReadLine();
                        isValid = taxes.Exists(x => x.StateName.ToLower() == state.ToLower()) || state == "";

                        if (isValid && state != "")
                        {
                            request.order.State = state;
                        }

                        else
                        {
                            request.order.State = orders.FirstOrDefault(y => y.OrderNumber == orderInt).State;
                        }
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

                        string productType = Console.ReadLine();
                        isValid = products.Exists(x => x.ProductType.ToLower() == productType.ToLower()) || productType == "";

                        if (isValid && productType != "")
                        {
                            request.order.ProductType = productType;
                        }

                        else
                        {
                            request.order.ProductType = orders.FirstOrDefault(y => y.OrderNumber == orderInt).ProductType;
                        }
                    }

                    isValid = false;
                    while (!isValid)
                    {
                        Console.WriteLine("What is the Area in square feet? Must be greater than 100.");
                        string areaString = Console.ReadLine();
                        decimal areaDecimal;
                        isValid = decimal.TryParse(areaString, out areaDecimal) && areaDecimal > 100 || areaString == "";

                        if (isValid && areaString != "")
                        {
                            request.order.Area = areaDecimal;
                        }

                        else
                        {
                            request.order.Area = orders.FirstOrDefault(x => x.OrderNumber == orderInt).Area;
                        }
                    }
                    isValid = false;
                    while (!isValid)
                    {
                        Console.WriteLine("Is this edited order correct? Y or N.");
                        Console.WriteLine();
                        Console.WriteLine($"Order Number: {request.order.OrderNumber}" +
                            $"\nCustomer Name: {request.order.CustomerName}" +
                            $"\nState: {request.order.State}" +
                            $"\nTax Rate: {request.order.TaxRate:P}" +
                            $"\nProduct: {request.order.ProductType}" +
                            $"\nArea: {request.order.Area} sq f" +
                            $"\nCost/sq f: {request.order.CostPreSquareFoot:c}" +
                            $"\nLabor Cost/sq f: {request.order.LaborCostPerSquareFoot:c}" +
                            $"\nMaterial Cost: {request.order.MaterialCost:c}" +
                            $"\nLabor Cost: {request.order.LaborCost:c}" +
                            $"\n" +
                            $"\nTax: {request.order.Tax:c}" +
                            $"\nTotal: {request.order.Total:c}");
                        response = Console.ReadLine();
                        isValid = response == "Y" || response == "N";
                    }
                    if (response == "Y")
                    {
                        orders = OM.GetOrders(dateTime);
                        int orderNumber;
                        if (orders != null && orders.Count() > 0)
                        {
                            orderNumber = orders.Max(x => x.OrderNumber) + 1;
                        }
                        else
                        {
                            orderNumber = 1;
                        }

                        request.order.OrderNumber = orderNumber;
                        OM.AddOrder(request);
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
}