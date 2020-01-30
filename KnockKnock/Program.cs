using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnock
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "A".ToLower();
            string b = "A";
            Console.WriteLine(".Equals " + a.Equals(b));
            Console.WriteLine("== " + a == b);
            DateTime AB = new DateTime();
            DateTime AC = new DateTime();
            Console.WriteLine(AB ==AC);
            Console.ReadLine();
            int newInt = 3 * 4;
            DateTime name = new DateTime();
            DateTime name2 = name;
        }
    }
}
