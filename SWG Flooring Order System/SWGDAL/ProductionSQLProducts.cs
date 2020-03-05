using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGModels;
using SWGModels.Interfaces;

namespace SWGDAL
{
    public class ProductionSQLProducts : IRepoProducts
    {
        public List<Product> LoadProducts()
        {
            string connectionString = @"Data Source=DESKTOP-025GJT9;Initial Catalog=SGBank;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";
            List<Product> products = new List<Product>();

            SqlDataReader dataReader;
            sql = $"SELECT [product name], [price per sq ft], [labor per sq ft] FROM Products";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                products.Add(new Product(dataReader.GetValue(0).ToString(), decimal.Parse(dataReader.GetValue(1).ToString()), decimal.Parse(dataReader.GetValue(2).ToString())));
            }
            cnn.Close();
            command.Dispose();
            return products;
            throw new NotImplementedException();
        }
    }
}
