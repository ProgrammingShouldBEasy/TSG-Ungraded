using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels.Requests;
using SWGModels.Responses;

namespace SWGModels.Interfaces
{
    public interface IRepoOrders
    {
        OrderResponse Load(OrderRequest orderRequest);
        bool Save(OrderRequest orderRequest);
        void Edit(OrderRequest orderRequest);
        void Remove(OrderRequest orderRequest);
        List<Order> LoadDate(DateTime date);
    }
}
