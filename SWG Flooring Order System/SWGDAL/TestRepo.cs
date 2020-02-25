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
    public class TestRepo : IRepo
    {
        public List<Order> Orders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Product> Products { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Tax> Taxes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Order LoadOrder(string date, int orderNumber)
        {
            throw new NotImplementedException();
        }

        public OrderResponse LoadOrder(OrderRequest orderRequest)
        {
            throw new NotImplementedException();
        }

        public Product LoadProducts()
        {
            throw new NotImplementedException();
        }

        public Tax LoadTax()
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order, string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
