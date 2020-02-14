using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Main_Menu
    {
        private const string separatorBar = "==============================================";

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Management System");
            Console.WriteLine(separatorBar);
            Console.WriteLine("1. List Students");
            Console.WriteLine("2. Add Student.");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. Edit Student GPA");
            Console.WriteLine("");
            Console.WriteLine("Q - Quit");
            Console.WriteLine(separatorBar);
            Console.WriteLine("");
            Console.WriteLine("Enter choice:");
        }

        private static bool ProcessChoice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("List Student");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Add Student");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("Remove Student");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("Edit Student");
                    Console.ReadKey();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("That was not a valid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

            return true;
        }
    
    public static void Show()
        {
            bool continueRunning = true;
            while (continueRunning == true)
            {
                DisplayMenu();
                continueRunning = ProcessChoice();
            }
        }
    }
}
