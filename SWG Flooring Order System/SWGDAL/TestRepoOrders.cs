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

        public OrderResponse Load(OrderRequest orderRequest)
        {
            OrderResponse response = new OrderResponse();
            if (orderRequest.Date != date)
            {
                response.success = false;
                response.message = "There is no order from that date.";
                return response;
            }
            response.list = list;
            response.success = true;
            return response;
        }

        public void Save(OrderRequest orderRequest)
        {
                list = orderRequest.list;
        }
    }
}
