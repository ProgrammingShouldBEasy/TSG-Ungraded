using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            Exercise18();
            Exercise20();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> list = DataLoader.LoadProducts().Where(x => x.UnitsInStock == 0).ToList();
            foreach (var x in list)
            {
                Console.WriteLine(x.ProductID);
                Console.WriteLine(x.ProductName);
                Console.WriteLine(x.UnitPrice);
                Console.WriteLine(x.UnitsInStock);
            }
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> list = DataLoader.LoadProducts().Where(x => x.UnitsInStock > 0 && x.UnitPrice > 3).ToList();
            foreach (var x in list)
            {
                Console.WriteLine(x.ProductName);
                Console.WriteLine(x.ProductID);
                Console.WriteLine(x.UnitPrice);
                Console.WriteLine(x.UnitsInStock);
            }
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            //How would I express this in Query syntax?
            List<Order> orders = DataLoader.LoadCustomers().Where(x => x.Region == "WA").OrderBy(a => a.CustomerID).SelectMany(o => o.Orders).ToList();

            foreach (var x in orders)
            {
                Console.WriteLine(x.OrderID);
                Console.WriteLine(x.OrderDate);
                Console.WriteLine(x.Total);
            }
            var queryOrders = (from c in DataLoader.LoadCustomers()
                               where c.Region is "WA"
                               from o in c.Orders
                               orderby c.CustomerID
                               group o by c.CustomerID
                                       ).ToList();

            foreach (var x in queryOrders)
            {
                Console.WriteLine(x.Key);
                foreach (var y in x)
                {
                    Console.WriteLine(y.OrderDate);
                    Console.WriteLine(y.OrderID);
                    Console.WriteLine(y.Total);
                }
            }
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var anonymousProduct = from x in DataLoader.LoadProducts().Where(x => x.ProductName != null)
                                   select new
                                   {
                                       ProductName = x.ProductName
                                   };
            foreach (var x in anonymousProduct)
            {
                Console.WriteLine(x.ProductName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var anonymousProduct = from x in DataLoader.LoadProducts().Where(x => x.ProductName != null)
                                   select new
                                   {
                                       ProductName = x.ProductName,
                                       ProductID = x.ProductID,
                                       ProductPrice = x.UnitPrice * 1.25m,
                                       ProductStock = x.UnitsInStock,
                                       ProductCategory = x.Category
                                   };
            foreach (var x in anonymousProduct)
            {
                Console.WriteLine(x.ProductCategory);
                Console.WriteLine(x.ProductID);
                Console.WriteLine(x.ProductName);
                Console.WriteLine(x.ProductPrice);
                Console.WriteLine(x.ProductStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var anonymousProduct = from x in DataLoader.LoadProducts().Where(x => x.ProductName != null)
                                   select new
                                   {
                                       ProductName = x.ProductName.ToUpper(),
                                       ProductCategory = x.Category.ToUpper()
                                   };
            foreach (var x in anonymousProduct)
            {
                Console.WriteLine(x.ProductName);
                Console.WriteLine(x.ProductCategory);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            var anonymousProduct = from x in DataLoader.LoadProducts().Where(x => x.ProductName != null)
                                   select new
                                   {
                                       ProductName = x.ProductName,
                                       ProductID = x.ProductID,
                                       ProductPrice = x.UnitPrice,
                                       ProductStock = x.UnitsInStock,
                                       ProductCategory = x.Category,
                                       ReOrder = x.UnitsInStock < 3
                                   };
            foreach (var x in anonymousProduct)
            {
                Console.WriteLine(x.ProductCategory);
                Console.WriteLine(x.ProductID);
                Console.WriteLine(x.ProductName);
                Console.WriteLine(x.ProductPrice);
                Console.WriteLine(x.ProductStock);
                Console.WriteLine(x.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var anonymousProduct = from x in DataLoader.LoadProducts().Where(x => x.ProductName != null)
                                   select new
                                   {
                                       ProductName = x.ProductName,
                                       ProductID = x.ProductID,
                                       ProductPrice = x.UnitPrice,
                                       ProductStock = x.UnitsInStock,
                                       ProductCategory = x.Category,
                                       StockValue = (x.UnitsInStock * x.UnitPrice)
                                   };
            foreach (var x in anonymousProduct)
            {
                Console.WriteLine(x.ProductCategory);
                Console.WriteLine(x.ProductID);
                Console.WriteLine(x.ProductName);
                Console.WriteLine(x.ProductPrice);
                Console.WriteLine(x.ProductStock);
                Console.WriteLine(x.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            List<int> list = DataLoader.NumbersA.Where(x => x % 2 == 0).ToList();
            foreach (var x in list)
            {
                Console.WriteLine(x.ToString());
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> Order500 = DataLoader.LoadCustomers().Where(x => x.Orders.Any(o => o.Total < 500)).ToList();
            foreach (var x in Order500)
            {
                Console.WriteLine(x.CustomerID);
            }
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            List<int> list = DataLoader.NumbersC.Where(x => x % 2 != 0).Take(3).ToList();
            foreach (var x in list)
            {
                Console.WriteLine(x.ToString());
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            List<int> list = DataLoader.NumbersB.Where(x => x != .1).Skip(3).ToList();
            foreach (var x in list)
            {
                Console.WriteLine(x.ToString());
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            List<Customer> customers = (from c in DataLoader.LoadCustomers()
                                        where c.Region is "WA"
                                        select c).ToList();

            var anonType = from c in customers
                           select new
                           {
                               companyName = c.CompanyName,
                               orderRecent = c.Orders.OrderBy(o => o.OrderDate).Last()
                           };
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            foreach (var x in DataLoader.NumbersC.TakeWhile(a => a < 6))
            {
                Console.WriteLine(x.ToString());
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            foreach (var x in DataLoader.NumbersC.SkipWhile(a => a % 3 != 0))
            {
                Console.WriteLine(x.ToString());
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            foreach (var x in DataLoader.LoadProducts().OrderBy(b => b.ProductName))
            {
                Console.WriteLine(x.ProductName);
                Console.WriteLine(x.ProductID);
                Console.WriteLine(x.Category);
                Console.WriteLine(x.UnitPrice);
                Console.WriteLine(x.UnitsInStock);
            }
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            foreach (var y in DataLoader.LoadProducts().OrderByDescending(a => a.UnitsInStock))
            {
                Console.WriteLine(y.ProductName);
                Console.WriteLine(y.ProductID);
                Console.WriteLine(y.Category);
                Console.WriteLine(y.UnitPrice);
                Console.WriteLine(y.UnitsInStock);
            }
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            foreach (var y in DataLoader.LoadProducts().OrderByDescending(b => b.UnitPrice).OrderBy(a => a.Category))
            {
                Console.WriteLine("Category " + y.Category);
                Console.WriteLine("Name " + y.ProductName);
                Console.WriteLine("ID " + y.ProductID);
                Console.WriteLine("Price " + y.UnitPrice);
                Console.WriteLine("Quantity " + y.UnitsInStock);
            }
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            foreach (var x in DataLoader.NumbersB.Reverse(a => a))
            {
                Console.WriteLine(x.ToString());
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            foreach (var x in DataLoader.LoadProducts().GroupBy(a => a.Category))
            {
                Console.WriteLine("============================");
                Console.WriteLine(x.Key);
                Console.WriteLine("============================");
                int i = 1;
                foreach (var y in x)
                {
                    Console.WriteLine(i + " " + y.ProductName);
                    i++;
                }
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {

        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {

        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {

        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {

        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {

        }
    }
}
