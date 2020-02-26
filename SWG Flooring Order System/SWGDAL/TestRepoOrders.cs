using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels;
using SWGModels.Interfaces;
using SWGModels.Responses;
using SWGModels.Requests;

namespace SWGDAL
{
    public class TestRepoOrders : IRepoOrders
    {
        DateTime date = DateTime.Today;
        List<Order> list = new List<Order> { new Order(1,"Wise","OH",6.25m,"Wood",100.00m,5.15m,4.75m) };

        public List<Order> LoadDate(DateTime date2)
        {
            if(date == date2)
            {
                return list;
            }

            else
            {
                return new List<Order>();
            }
        }

        public void Edit(OrderRequest orderRequest)
        {
            if (orderRequest.Date == date)
            {
                int index = list.FindIndex(x => x.OrderNumber == orderRequest.order.OrderNumber);
                list.RemoveAt(index);
                list.Add(orderRequest.order);
            }
        }

        public OrderResponse Load(OrderRequest orderRequest)
        {
            OrderResponse response = new OrderResponse();
            if (orderRequest.Date != date)
            {
                response.success = false;
                response.message = "There is no order from that date.";
                return response;
            }
            response.order = list.FirstOrDefault(x => x.OrderNumber == orderRequest.order.OrderNumber);
            if(response.order == null)
            {
                response.message = "Order does not exist.";
                response.success = false;
                return response;
            }

            response.success = true;
            return response;
        }

        public void Remove(OrderRequest orderRequest)
        {
            if (orderRequest.Date == date)
            {
                list.RemoveAll(x => x.OrderNumber == orderRequest.order.OrderNumber);
            }
        }

        public bool Save(OrderRequest orderRequest)
        {
            if (orderRequest.Date == date)
            {
                list.Add(orderRequest.order);
                return true;
            }
            return false;
        }
    }
}
