using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels;
using SWGModels.Requests;
using SWGModels.Responses;
using SWGModels.Interfaces;
using System.IO;

namespace SWGDAL
{
    public class ProductionRepoOrders : IRepoOrders
    {
        public string filePath;

        public ProductionRepoOrders()
        {
            filePath = @"C:\Users\Cain\source\repos\TSG Ungraded\SWG Flooring Order System\SWGDAL\Data\";
        }

        public OrderResponse Load(OrderRequest orderRequest)
        {
            OrderResponse response = new OrderResponse();
            if (File.Exists($"{filePath}Orders_" + orderRequest.Date.ToString("MMddyyyy") + ".txt"))
            {
                response.list = ReadFromFileOrders($"{filePath}Orders_" + orderRequest.Date.ToString("MMddyyyy") + ".txt");
            }

            if (response.list == null)
            {
                response.success = false;
                response.message = "No orders exist at this date.";
                return response;
            }

            response.success = true;
            return response;
        }

        public string OrdertoText(Order order)
        {
            return $"{order.OrderNumber}°{order.CustomerName}°{order.State}°{order.TaxRate}°{order.ProductType}°{order.Area}°{order.CostPreSquareFoot}°{order.LaborCostPerSquareFoot}°{order.MaterialCost}°{order.LaborCost}°{order.Tax}°{order.Total}";
        }

        private List<Order> ReadFromFileOrders(string filePath2)
        {
            List<Order> list = new List<Order>();
            using (StreamReader sr = new StreamReader(filePath2))
            {
                string[] columns;
                string line;

                sr.ReadLine();
                while((line = sr.ReadLine()) != null)
                {
                    columns = line.Split('°');
                    Order order = new Order(Int32.Parse(columns[0]), columns[1], columns[2], decimal.Parse(columns[3]), columns[4], decimal.Parse(columns[5]), decimal.Parse(columns[6]), decimal.Parse(columns[7]));
                    list.Add(order);
                }
                return list;
            }
        }

        public void Save(OrderRequest orderRequest)
        {
                WritetoFile(orderRequest.list, $"{filePath}Orders_" + orderRequest.Date.ToString("MMddyyyy") + ".txt");
        }

        private void WritetoFile(List<Order> list, string filePath2)
        {
            if (File.Exists(filePath2))
            {
                File.Delete(filePath2);
            }

            using (StreamWriter sw = new StreamWriter(filePath2))
            {
                sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (Order x in list)
                {
                    sw.WriteLine(OrdertoText(x));
                }
            }
        }
    }
}