using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility_Classes;
using DishCRUD;
using Menus;

namespace CRUDdyClassesAndFunctions
{
    class Program
    {
        public static void Main(string[] args)
        {
            Menu myMenu = new Menu();
            myMenu.Prompt();
            Console.ReadLine();
        }
    }
}
