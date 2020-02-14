using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Item_Manager.Logic;
using Item_Manager.Models;
using Utility_Classes;

namespace Item_Manager
{
    class Program
    {
        private static string bar = "========================================";
        private static void MenuDisplay()
        {

            Console.Clear();
            Console.WriteLine(bar);
            Console.WriteLine(bar);
            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine(bar);
            Console.WriteLine("1. Add a book.");
            Console.WriteLine("2. Edit a book.");
            Console.WriteLine("3. Look-up a book.");
            Console.WriteLine("4. Delete a book.");
            Console.WriteLine("5. Delete the entire library.");
            Console.WriteLine("Q - Quit");
            Console.WriteLine(bar);
            Console.WriteLine(bar);
        }

        private static string GetBookData()
        {
            Console.WriteLine("Please enter some information for your book:");
            Console.Write("What is your book title? ");
            string title = Console.ReadLine();
            Console.Write("Who is the author of your book? ");
            string author = Console.ReadLine();
            Console.WriteLine("How many pages are in your book? ");
            int pageCount = GetInput.ForInt(0, int.MaxValue);
            Console.WriteLine("How many chpaters are in your book?");
            int chapterCount = GetInput.ForInt(0, int.MaxValue);
            return $"{title}, {author}, {pageCount}, {chapterCount}";
        }

        private static int ChooseBookfromList(List<Book> list)
        {

            Console.WriteLine("Please select your book from the following list:");
            int i = 0;
            foreach (Book x in list)
            {
                i++;
                Console.WriteLine($"{i}. {x.Title}");
            }

            return GetInput.ForInt(1, list.Count());
        }
        private static bool Execute()
        {
            Features processor = new Features();
            string choice = Console.ReadLine();
            string[] bookData;
            switch (choice)
            {
                case "1":
                    bookData = GetBookData().Split(',');
                    if (processor.Add(bookData[0], bookData[1], int.Parse(bookData[2]), int.Parse(bookData[3])) == true)
                    {
                        Console.WriteLine($"{bookData[0]} by {bookData[1]} has been added!");
                    }
                    else
                    {
                        Console.WriteLine("The book was unable to be added.");
                    }
                    break;
                case "2":
                    int index = ChooseBookfromList(processor.ListAll());
                    Console.WriteLine("What would you like to replace this book with?");
                    bookData = GetBookData().Split(',');
                    bool wasSuccessful = processor.Edit(bookData[0], bookData[1], int.Parse(bookData[2]), int.Parse(bookData[3]), index - 1);
                    if (wasSuccessful)
                    {
                        Console.WriteLine("Your edit was successful!");
                    }
                    else
                    {
                        Console.WriteLine("Your edit was unsuccessful.");
                    }
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "Q":
                    return true;
                default:
                    break;
            }
            return false;
        }

        static void Main(string[] args)
        {
            bool quit = false;
            while (!quit)
            {
                MenuDisplay();
                quit = Execute();
            }
        }
    }
}
