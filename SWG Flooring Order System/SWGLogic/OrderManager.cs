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

        public OrderManager(IRepoOrders a, IRepoProducts b, IRepoTaxes c)
        {
            OrdersDB = a;
            ProductsDB = b;
            TaxesDB = c;
        }

        public List<Order> DisplayOrders(string date)
        {
            OrderRequest request = new OrderRequest();
            request.Date = DateTime.Parse(date);
            return OrdersDB.LoadDate(DateTime.Parse(date));
        }

        public OrderResponse Display(Order order, DateTime date)
        {
            OrderRequest request = new OrderRequest();
            request.order = order;
            request.Date = date;
            return OrdersDB.Load(request);
        }

        public bool AddOrder(Order order, DateTime date)
        {
            OrderRequest request = new OrderRequest();
            request.Date = date;
            request.order = order;
            return OrdersDB.Save(request);
        }

        public bool EditOrder()
        {
            throw new NotImplementedException();
        }

        public bool RemoveOrder()
        {
            throw new NotImplementedException();
        }
    }
}
