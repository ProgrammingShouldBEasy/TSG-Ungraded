using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWG_Flooring_Order_System.Workflows;
using SWGLogic;

namespace SWG_Flooring_Order_System.Workflows
{
    public class MainMenu
    {
        public static void Execute()
        {
            bool execute = true;
            while (execute)
            {
                bool isValid = false;
                string response = null;
                string bar = "=================================================";

                Console.Clear();
                Console.SetWindowSize(203, 40);
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (bar.Length / 2)) + "}", bar));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Flooring Program".Length) - (bar.Length / 2)) + "}", "=Flooring Program"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("1.Display Orders".Length) - (bar.Length / 2)) + "}", "=1.Display Orders"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("2. Add Order".Length) - (bar.Length / 2)) + "}", "=2. Add Order"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("3. Edit Order".Length) - (bar.Length / 2)) + "}", "=3. Edit Order"));             
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("4. Remove Order".Length) - (bar.Length / 2)) + "}", "=4. Remove Order"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("=Q.Quit".Length) - (bar.Length / 2)) + "}", "=Q. Quit"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (bar.Length / 2)) + "}", bar));
                while (!isValid)
                {
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("==Please enter a valid choice, 1-4 or Q for Quit.".Length) - (bar.Length / 2)) + "}", "=Please enter a valid choice, 1 - 4 or Q for Quit."));
                    Console.SetCursorPosition((Console.WindowWidth / 2) - "=".Length - (bar.Length / 2), 9);
                    response = Console.ReadLine();
                    if (response == "1" || response == "2" || response == "3" || response == "4" || response == "Q")
                    {
                        isValid = true;
                    }
                }

                switch (response)
                {
                    case "1":
                        DisplayOrder.Execute();
                        break;
                    case "2":
                        AddOrder.Execute();
                        break;
                    case "3":
                        EditOrder.Execute();
                        break;
                    case "4":
                        RemoveOrder.Execute();
                        break;
                    case "Q":
                        execute = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
