using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product;
using Utility_Classes;
using BLL;

namespace Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingLogic List = new ShoppingLogic();
            bool quit = false;
            while (quit == false)
            {
                int answer;
                int quantity;
                string name;
                Console.WriteLine("Welcome to the Shopping List!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Please choose from the available menu options:\n" +
                                  "1. Display the list.\n" +
                                  "2. Display an items by name.\n" +
                                  "3. Display all items by quantity.\n" +
                                  "4. Add an item.\n" +
                                  "5. Update an item by name.\n" +
                                  "6. Update an item by quantity.\n" +
                                  "7. Delete an item by name.\n" +
                                  "8. Delete items by quantity.\n" +
                                  "9. Quit.");
                answer = GetInput.ForInt(1, 9);
                Console.Clear();
                switch(answer)
                {
                    case 1:
                        //Display all items by iterating for each in the List<Item>
                        List<Item
                        Console.WriteLine(List.DisplayAllItems());
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        quit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
