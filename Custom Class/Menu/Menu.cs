using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility_Classes;
using DishCRUD;

namespace Menus
{
    public class Menu
    {
        CRUD Controller = new CRUD();
        public void Prompt()
        {
            string output = null;

            while (output != "Quit")
            {
                Console.WriteLine("Do you want to Create, Retrieve, Retrieve All, Delete, or Quit?");
                output = Console.ReadLine();

                while (output != "Create" && output != "Retrieve" && output != "Retrieve All" && output != "Delete" && output != "Quit")
                {
                    Console.WriteLine("Do you want to Create, Retrieve, Retrieve All, Delete, or Quit?");
                    output = Console.ReadLine();
                }

                switch (output)
                {
                    case "Create":
                        Console.WriteLine("Please provide a name for your Dish.");
                        string name = Console.ReadLine();
                        Controller.Create(name);
                        break;
                    case "Retrieve":
                        Console.WriteLine("What location do you want to see?");
                        int index = GetInput.ForInt();
                        Controller.Retrieve(index);
                        break;
                    case "Retrieve All":
                        Controller.RetrieveAll();
                        break;
                    case "Delete":
                        Console.WriteLine("What location do you want to delete?");
                        index = GetInput.ForInt();
                        Controller.Delete(index);
                        break;
                    case "Quit":
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
