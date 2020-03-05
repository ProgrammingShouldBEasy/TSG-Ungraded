using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels.Interfaces;
using SWGModels.Requests;
using SWGModels.Responses;
using System.Data;
using System.Data.SqlClient;
using SWGModels;

namespace SWGDAL
{
    public class ProductionSQLOrders : IRepoOrders
    {        

        public OrderResponse Load(OrderRequest orderRequest)
        {
            string connectionString = @"Data Source=DESKTOP-025GJT9;Initial Catalog=SGBank;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql;

            sql = $"Select Orders.orderNumber, Orders.name, Orders.state, Orders.area, Products.[product name], Products.[price per sq ft], Products.[labor per sq ft], States.[tax rate] FROM Orders JOIN Products ON Orders.productID = Products.ProductID JOIN States ON States.StateAbbreviation = Orders.state WHERE Orders.OrderDate = '{orderRequest.Date.ToShortDateString()}'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            List<Order> list = new List<Order>();
            while (dataReader.Read())
            {
                //int orderNumber 0, string customerName 1, string state 2, decimal taxRate 7, string productType 4, decimal area 3, decimal costPerSquareFoot 5, decimal laborCostPerSquareFoot 6
                Order order = new Order(Int32.Parse(dataReader.GetValue(0).ToString()),
                    dataReader.GetValue(1).ToString(),
                    dataReader.GetValue(2).ToString(),
                    decimal.Parse(dataReader.GetValue(7).ToString()),
                    dataReader.GetValue(4).ToString(),
                    decimal.Parse(dataReader.GetValue(3).ToString()),
                    decimal.Parse(dataReader.GetValue(5).ToString()),
                    decimal.Parse(dataReader.GetValue(6).ToString()));
                list.Add(order);
            }
            OrderResponse response = new OrderResponse();
            response.list = list;
            dataReader.Close();
            command.Dispose();
            cnn.Close();
            if (list.Count() == 0)
            {
                response.message = "No orders exist for that date.";
                response.success = false;
                return response;
            }

            response.message = "Orders exist";
            response.success = true;
            return response;
            throw new NotImplementedException();
        }

        public void Save(OrderRequest orderRequest)
        {
            string connectionString = @"Data Source=DESKTOP-025GJT9;Initial Catalog=SGBank;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";
            List<string> products = new List<string>();

            SqlDataReader dataReader;
            sql = $"SELECT ProductID, [product name] FROM Products";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                products.Add(dataReader.GetValue(0).ToString()+""+dataReader.GetValue(1));
            }

            string insert = "";
            for (int i = 0; i < orderRequest.list.Count(); i++)
            {
                insert +=$"('{orderRequest.Date.ToShortDateString()}','{orderRequest.list.ElementAt(i).CustomerName}','{orderRequest.list.ElementAt(i).State[0].ToString().ToUpper() + orderRequest.list.ElementAt(i).State[1].ToString().ToUpper()}','{products.FirstOrDefault(x=>x.Contains(orderRequest.list.ElementAt(i).ProductType))[0]}','{orderRequest.list.ElementAt(i).Area}'),";
            }
            cnn.Close();
            cnn.Open();
            insert = insert.Substring(0, insert.Length - 1);
            sql = $"DELETE FROM Orders " +
                $"\nWHERE OrderDate = '{orderRequest.Date.ToShortDateString()}';" +
                $"\nINSERT INTO Orders (OrderDate, name, state, productID, area)" +
                $"\nVALUES" +
                $"\n{insert};";
            command = new SqlCommand(sql, cnn);
            adapter.UpdateCommand = new SqlCommand(sql, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            cnn.Close();
            command.Dispose();
        }
    }
}
