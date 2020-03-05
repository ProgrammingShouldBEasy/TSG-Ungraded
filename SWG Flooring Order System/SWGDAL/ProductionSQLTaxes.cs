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
    public class ProductionSQLTaxes : IRepoTaxes
    {
        public List<Tax> LoadTaxes()
        {
            string connectionString = @"Data Source=DESKTOP-025GJT9;Initial Catalog=SGBank;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";
            List<Tax> taxes = new List<Tax>();

            SqlDataReader dataReader;
            sql = $"SELECT [StateAbbreviation], [state name], [tax rate] FROM States";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                taxes.Add(new Tax(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString(), decimal.Parse(dataReader.GetValue(2).ToString())));
            }
            cnn.Close();
            return taxes;
            throw new NotImplementedException();
        }
    }
}
