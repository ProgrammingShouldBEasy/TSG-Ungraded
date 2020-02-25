using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels.Requests;
using SWGModels.Responses;

namespace SWGModels.Interfaces
{
    public interface IRepo
    {
        OrderResponse LoadOrder(OrderRequest orderRequest);
        void SaveOrder(Order order, string filePath);
        Product LoadProducts();
        Tax LoadTax();

    }
}
