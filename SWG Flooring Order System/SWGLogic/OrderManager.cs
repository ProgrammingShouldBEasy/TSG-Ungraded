using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels;
using SWGDAL;
using SWGModels.Interfaces;
using SWGModels.Requests;
using SWGModels.Responses;

namespace SWGLogic
{
    public class OrderManager
    {
        IRepoOrders OrdersDB;
        IRepoProducts ProductsDB;
        IRepoTaxes TaxesDB;

        private List<Order> currentList = new List<Order>();

        public OrderManager(IRepoOrders a, IRepoProducts b, IRepoTaxes c)
        {
            OrdersDB = a;
            ProductsDB = b;
            TaxesDB = c;
        }

        private string LoadOrders(DateTime date)
        {
            OrderRequest request = new OrderRequest();
            request.Date = date;
            OrderResponse response = OrdersDB.Load(request);
            if(response.success == true)
            {
                currentList = response.list;
                return "Orders have been successfully loaded.";
            }
            return response.message;
        }

        private void Save(DateTime date)
        {
            OrderRequest request = new OrderRequest();
            request.list = currentList;
            request.Date = date;
            OrdersDB.Save(request);
        }

        public List<Order> GetOrders(DateTime date)
        {
            LoadOrders(date);
            return currentList;
        }

        public void AddOrder(Order order, DateTime date)
        {
            LoadOrders(date);
            currentList.Add(order);
            Save(date);
        }

        public void EditOrder(Order order, DateTime date)
        {
            LoadOrders(date);
            currentList.RemoveAll(x => x.OrderNumber == order.OrderNumber);
            currentList.Add(order);
            Save(date);
        }

        public void RemoveOrder(Order order, DateTime date)
        {
            LoadOrders(date);
            currentList.RemoveAll(x => x.OrderNumber == order.OrderNumber);
            Save(date);
        }

        public List<Product> GetProducts()
        {
            return ProductsDB.LoadProducts();
        }

        public List<Tax> GetTaxes()
        {
            return TaxesDB.LoadTaxes();
        }
    }
}
