using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun_with_Enums
{
    class Enums
    {
        public enum OrderStatus
        {
            Quote = 1,
            Purchased = 2,
            Shipped,
            Delivered
        }
    }
    class Program
    {
        public static Enums.OrderStatus Status
        { get; set; }
        static void Main(string[] args)
        {
            Status = Enums.OrderStatus.Purchased;
            Console.WriteLine(Status);
            Console.ReadLine();
        }
    }
}
