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
    public class ProductionRepo : IRepo, IFileIO
    {
        public string filePathProducts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string filePathTaxes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string filePathParent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ProductionRepo()
        {
            filePathParent = @"C:\Users\Cain\source\repos\TSG Ungraded\SWG Flooring Order System\SWGDAL\Data\";
            filePathProducts = @"C:\Users\Cain\source\repos\TSG Ungraded\SWG Flooring Order System\SWGDAL\Data\Products.txt";
            filePathTaxes = @"C:\Users\Cain\source\repos\TSG Ungraded\SWG Flooring Order System\SWGDAL\Data\Taxes.txt";
        }

        public OrderResponse LoadOrder(OrderRequest orderRequest)
        {
            OrderResponse response = new OrderResponse();
            response.order = ReadFromFileOrders($"{filePathParent}Orders_" + orderRequest.Date.ToString("MMDDYYYY") + ".txt").FirstOrDefault(x => x.OrderNumber == orderRequest.order.OrderNumber);

            if (response.order == null)
            {
                response.success = false;
                response.message = "Order does not exist.";
                return response;
            }

            response.success = true;
            return response;
        }

        public Product LoadProducts()
        {
            throw new NotImplementedException();
        }

        public Tax LoadTax()
        {
            throw new NotImplementedException();
        }

        public string OrdertoText(Order order)
        {
            return $"{order.OrderNumber}°{order.CustomerName}°{order.State}°{order.TaxRate}°{order.ProductType}°{order.Area}°{order.CostPreSquareFoot}°{order.LaborCostPerSquareFoot}°{order.MaterialCost}°{order.LaborCost}°{order.Tax}°{order.Total}";
        }

        public List<Order> ReadFromFileOrders(string filePath)
        {
            List<Order> list = new List<Order>();
            using (StreamReader sr = new StreamReader(filePath))
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

        public List<Product> ReadFromFileProducts(string filePath)
            {
                throw new NotImplementedException();
            }

        public List<Tax> ReadFromFileTaxes(string filePath)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order, string filePath)
        {
            List<Order> list = ReadFromFileOrders(filePath);
            list.Add(order);
            WritetoFile(list, filePath);
        }

        public void WritetoFile(List<Order> list, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (StreamWriter sw = new StreamWriter(filePath))
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
