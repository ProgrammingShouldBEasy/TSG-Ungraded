using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGModels.Interfaces
{
    public interface IFileIO
    {
        List<Order> ReadFromFileOrders(string filePath);
        void WritetoFile(List<Order> list, string filePath);
        string OrdertoText(Order order);
        string filePathParent { get; set; }
        string filePathProducts { get; set; }
        string filePathTaxes { get; set; }
        List<Tax> ReadFromFileTaxes(string filePath);
        List<Product> ReadFromFileProducts(string filePath);
    }
}
