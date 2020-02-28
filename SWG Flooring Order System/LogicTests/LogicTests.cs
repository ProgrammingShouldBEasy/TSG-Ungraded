using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGLogic;
using NUnit.Framework;
using SWGModels;
using SWGModels.Requests;

namespace LogicTests
{
    //Unit Tests:
    //Add:
    //1 passes
    //invalid name
    //invalid product
    //invalid state
    //date in the past
    //area less than 100
    //
    //Edit:
    //1 passes
    //invalid product
    //invalid state
    //date in the past
    //area less than 100
    //
    //Remove:
    //1 passes
    //invalid date
    //invalid order number
    //
    //Load
    //count

    //        List<Order> list = new List<Order> { new Order(1,"Wise","OH",6.25m,"Wood",100.00m,5.15m,4.75m) };
    //        List<Product> list = new List<Product> { new Product("Carpet",2.25m,2.10m), new Product("Laminate",1.75m,2.10m), new Product("Tile",3.50m,4.15m), new Product("Wood",5.15m,4.75m) };
    //        List<Tax> list = new List<Tax> { new Tax("OH","Ohio",6.25m), new Tax("PA","Penssylvania",6.75m), new Tax("MI","Michigan",5.75m), new Tax("IN","Indiana",6.00m)};
    [TestFixture]
    public class LogicTests
    {
        //Add:
        //1 passes
        //invalid name
        //invalid product
        //invalid state
        //date in the past
        //area less than 100
        //
        [TestCase("Name", "Ohio", "Carpet", 101, true)]
        [TestCase(";", "Ohio", "Carpet", 101, false)]
        [TestCase("Name", "Utah", "Carpet", 101, false)]
        [TestCase("Name", "Ohio", "Carpet", 100, false)]
        [TestCase("Name", "Ohio", "lkjasd", 100, false)]
        public void Add(string b, string c, string d, decimal e, bool f)
        {
            OrderManager OM = OrderManagerFactory.Create();
            Order order = new Order(2, b, c, 6.25m, d, e, 2.25m, 2.10m);
            UI2LogicRequest request = new UI2LogicRequest();
            request.order = order;
            request.dateTime = DateTime.Today.AddDays(1);
            Assert.AreEqual(f, OM.AddOrder(request).success);
        }

        [TestCase("Name", "Ohio", "Carpet", 101, false)]
        public void AddPast(string b, string c, string d, decimal e, bool f)
        {
            OrderManager OM = OrderManagerFactory.Create();
            Order order = new Order(2, b, c, 6.25m, d, e, 2.25m, 2.10m);
            UI2LogicRequest request = new UI2LogicRequest();
            request.order = order;
            request.dateTime = DateTime.Today.AddDays(-1);
            Assert.AreEqual(f, OM.AddOrder(request).success);
        }

        //Edit:
        //1 passes
        //invalid product
        //invalid state
        //date in the past
        //area less than 100
        //
        [TestCase("Name", "Ohio", "Carpet", 101, true)]
        [TestCase(";", "Ohio", "Carpet", 101, false)]
        [TestCase("Name", "Utah", "Carpet", 101, false)]
        [TestCase("Name", "Ohio", "Carpet", 100, false)]
        [TestCase("Name", "Ohio", "lkjasd", 100, false)]
        public void Edit(string b, string c, string d, decimal e, bool f)
        {
            OrderManager OM = OrderManagerFactory.Create();
            Order order = new Order(2, b, c, 6.25m, d, e, 2.25m, 2.10m);
            UI2LogicRequest request = new UI2LogicRequest();
            request.order = order;
            request.dateTime = DateTime.Today.AddDays(1);
            Assert.AreEqual(f, OM.EditOrder(request).success);
        }

        [TestCase("Name", "Ohio", "Carpet", 101, false)]
        public void EditPast(string b, string c, string d, decimal e, bool f)
        {
            OrderManager OM = OrderManagerFactory.Create();
            Order order = new Order(2, b, c, 6.25m, d, e, 2.25m, 2.10m);
            UI2LogicRequest request = new UI2LogicRequest();
            request.order = order;
            request.dateTime = DateTime.Today.AddDays(-1);
            Assert.AreEqual(f, OM.EditOrder(request).success);
        }

        //Remove:
        //1 passes
        //invalid date
        //invalid order number
        //
        [TestCase]
        public void RemovePass()
        {
            OrderManager OM = OrderManagerFactory.Create();
            Order order = new Order(1, "Wise", "OH", 6.25m, "Wood", 100.00m, 5.15m, 4.75m);
            UI2LogicRequest request = new UI2LogicRequest();
            request.order = order;
            request.dateTime = DateTime.Today;
            Assert.AreEqual(true, OM.RemoveOrder(request).success);
        }

        [TestCase]
        public void RemoveFailDate()
        {
            OrderManager OM = OrderManagerFactory.Create();
            Order order = new Order(1, "Wise", "OH", 6.25m, "Wood", 100.00m, 5.15m, 4.75m);
            UI2LogicRequest request = new UI2LogicRequest();
            request.order = order;
            request.dateTime = DateTime.Today.AddDays(1);
            Assert.AreEqual(false, OM.RemoveOrder(request).success);
        }

        [TestCase]
        public void RemoveFailOrderNumber()
        {
            OrderManager OM = OrderManagerFactory.Create();
            Order order = new Order(2, "Wise", "OH", 6.25m, "Wood", 100.00m, 5.15m, 4.75m);
            UI2LogicRequest request = new UI2LogicRequest();
            request.order = order;
            request.dateTime = DateTime.Today;
            Assert.AreEqual(false, OM.RemoveOrder(request).success);
        }
    }
}
