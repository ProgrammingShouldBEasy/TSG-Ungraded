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

        private bool LoadOrders(DateTime date)
        {
            OrderRequest request = new OrderRequest();
            request.Date = date;
            OrderResponse response = OrdersDB.Load(request);
            if(response.success == true)
            {
                currentList = response.list;
                return false;
            }
            return true;
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

        public UI2LogicResponse AddOrder(UI2LogicRequest request)
        {
            UI2LogicResponse response = new UI2LogicResponse();
            response.order = request.order;
            List<char> filteredName = request.order.CustomerName.Where(x => Char.IsLetterOrDigit(x) || x.Equals(',') || x.Equals('.') || x.Equals(' ')).ToList();
            
            if (request.order.CustomerName == null || (filteredName.Count() != request.order.CustomerName.Length) || !(request.order.CustomerName.ToLower().Contains("a") || request.order.CustomerName.ToLower().Contains("b") || request.order.CustomerName.ToLower().Contains("c") || request.order.CustomerName.ToLower().Contains("d") || request.order.CustomerName.ToLower().Contains("e") || request.order.CustomerName.ToLower().Contains("f") || request.order.CustomerName.ToLower().Contains("g") || request.order.CustomerName.ToLower().Contains("h") || request.order.CustomerName.ToLower().Contains("i") || request.order.CustomerName.ToLower().Contains("j") || request.order.CustomerName.ToLower().Contains("k") || request.order.CustomerName.ToLower().Contains("l") || request.order.CustomerName.ToLower().Contains("m") || request.order.CustomerName.ToLower().Contains("n") || request.order.CustomerName.ToLower().Contains("o") || request.order.CustomerName.ToLower().Contains("p") || request.order.CustomerName.ToLower().Contains("q") || request.order.CustomerName.ToLower().Contains("r") || request.order.CustomerName.ToLower().Contains("s") || request.order.CustomerName.ToLower().Contains("t") || request.order.CustomerName.ToLower().Contains("u") || request.order.CustomerName.ToLower().Contains("v") || request.order.CustomerName.ToLower().Contains("w") || request.order.CustomerName.ToLower().Contains("x") || request.order.CustomerName.ToLower().Contains("y") || request.order.CustomerName.ToLower().Contains("z")))
            {
                response.success = false;
                response.message = "The Customer Name is invalid.";
                return response;
            }

            if(request.dateTime <= DateTime.Today)
            {
                response.success = false;
                response.message = "The order is not set for the future.";
                return response;
            }

            List<Tax> taxes = TaxesDB.LoadTaxes();
            if(!taxes.Exists(x => x.StateName.ToLower() == request.order.State.ToLower()))
            {
                response.success = false;
                response.message = "There is no tax rate for this state.";
                return response;
            }

            List<Product> products = ProductsDB.LoadProducts();
            if(!products.Exists(x => x.ProductType.ToLower() == request.order.ProductType.ToLower()))
            {
                response.success = false;
                response.message = "We do not sell that product type.";
                return response;
            }

            if (request.order.Area <= 100)
            {
                response.success = false;
                response.message = "Area must be greater than 100 square feet.";
                return response;
            }

            LoadOrders(request.dateTime);
            currentList.Add(request.order);
            Save(request.dateTime);
            response.success = true;
            response.message = "Order was successfully added.";
            return response;
        }

        public void EditOrder(Order order, DateTime date)
        {
            LoadOrders(date);
            currentList.RemoveAll(x => x.OrderNumber == order.OrderNumber);
            currentList.Add(order);
            Save(date);
        }

        public UI2LogicResponse RemoveOrder(UI2LogicRequest request)
        {
            UI2LogicResponse response = new UI2LogicResponse();
            
            bool exists = LoadOrders(request.dateTime);
            if (exists && currentList.FirstOrDefault(x => x.OrderNumber == request.order.OrderNumber) != null)
            {
                currentList.RemoveAll(x => x.OrderNumber == request.order.OrderNumber);
                Save(request.dateTime);
                response.success = true;
                response.message = "Orders file exists at that location and the order exists.";
                return response;
            }

            else if (!exists)
            {
                response.success = false;
                response.message = "Order file does not exist";
                return response;
            }

            else if(currentList.FirstOrDefault(x => x.OrderNumber == request.order.OrderNumber) == null)
            {
                response.success = false;
                response.message = "Order does not exist in that file";
                return response;
            }

            response.success = false;
            response.message = "Unknown outcome has occurred.";
            return response;
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
