using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility_Classes;
using DishCRUD;

namespace DishCRUD
{
    public class CRUD
    {
        Dish[] localArray = new Dish[10];
        public void Create(string y)
        {
            Dish newDish = new Dish();
            newDish.Name = y;
            bool foundNull = false;

            do
            {
                for (int i = 0; i < localArray.Length; i++)
                {
                    if (localArray[i] == null && foundNull == false)
                    {
                        localArray[i] = newDish;
                        foundNull = true;
                    }
                }
            } while (!foundNull);
        }

        //Add options and validations/error handling for retrieving attributes of the Dish at that location.
        public void Retrieve(int y)
        {
            int index = y;
            Dish localDish = new Dish();
            if (localArray[index] != null)
            {
                localDish = localArray[index];
                Console.WriteLine($"{localDish.Name}");
            }
            else
            {
                Console.WriteLine("There is no Dish at this location.");
            }
        }

        //Add options and validations/error handling for retrieving attributes of the Dish at that location.
        public void RetrieveAll()
        {
            Dish localDish = new Dish();
            for (int i = 0; i < localArray.Length; i++)
            {
                if (localArray[i] != null)
                {
                    localDish = localArray[i];
                    Console.WriteLine($"{localDish.Name}");
                }
            }
        }

        public void Update(int y)
        {
            string attribute = null;
            string name = null;
            int quantity;
            bool isBroken;
            bool isASet;
            int index = y;
            string answer = null;
            Dish localDish = new Dish();
            localDish = localArray[index];

            while (attribute != "Name" || attribute != "Quantity" || attribute != "IsBroken" || attribute != "IsASet" || attribute != "Purpose")
            {
                Console.WriteLine("What attribute would you like to change? Choose from: Name, Quantity, IsBroken, IsASet, and Purpose.");
                attribute = Console.ReadLine();
            }
            switch (attribute)
            {
                case "Name":
                    Console.WriteLine($"What name would like to name {localDish.Name}?");
                    name = Console.ReadLine();
                    localDish.Name = name;
                    Console.WriteLine($"Your Dish has been named: {localDish.Name}");
                    break;
                case "Quantity":
                    Console.WriteLine($"What quantity would you like to assign to {localDish.Name}?");
                    quantity = GetInput.ForInt();
                    localDish.Quantity = quantity;
                    Console.WriteLine($"You now have {localDish.Quantity} of {localDish.Name}");
                    break;
                case "IsBroken":
                    while (answer != "Yes" || answer != "No")
                    {
                        Console.WriteLine($"Is your {localDish.Name} broken? Yes or No, please.");
                        answer = Console.ReadLine();
                    }
                    if (answer == "Yes")
                    {
                        isBroken = true;
                        localDish.IsBroken = isBroken;
                        Console.WriteLine($"Your {localDish.Name} is broken. Great job, butter fingers.");
                    }
                    else
                    {
                        isBroken = false;
                        localDish.IsBroken = isBroken;
                        Console.WriteLine($"Your {localDish.Name} is intact. Great job, way to be an adult.");
                    }
                    break;
                case "IsASet":
                    while (answer != "Yes" || answer != "No")
                    {
                        Console.WriteLine($"Is your {localDish.Name} part of a set? Yes or No, please.");
                        answer = Console.ReadLine();
                    }
                    if (answer == "Yes")
                    {
                        isASet = true;
                        localDish.IsASet = isASet;
                        Console.WriteLine($"Your {localDish.Name} is now a part of a set. Gotta catch 'em all!");
                    }
                    else
                    {
                        isASet = false;
                        localDish.IsASet = isASet;
                        Console.WriteLine($"Your {localDish.Name} is a strong, independent dish, it doesn't need a set.");
                    }
                    break;
                case "Purpose":
                    while (answer != "Cup" || answer != "Utensil" || answer != "Plate" || answer != "Bowl" || answer != "Pot" || answer != "Pan" || answer != "Bakeware")
                    {
                        Console.WriteLine($"What kind of dish is {localDish.Name}? Choose either Cup, Utensil, Plate, Bowl, Pot, Pan, or Bakeware.");
                        answer = Console.ReadLine();
                    };
                    switch (answer)
                    {
                        case "Cup":
                            localDish.Use = Purpose.Cup;
                            break;
                        case "Utensil":
                            localDish.Use = Purpose.Utensil;
                            break;
                        case "Plate":
                            localDish.Use = Purpose.Plate;
                            break;
                        case "Bowl":
                            localDish.Use = Purpose.Bowl;
                            break;
                        case "Pot":
                            localDish.Use = Purpose.Pot;
                            break;
                        case "Pan":
                            localDish.Use = Purpose.Pan;
                            break;
                        case "Bakeware":
                            localDish.Use = Purpose.Bakeware;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        public void Delete(int y)
        {
            int index = y;
            localArray[index] = null;
        }
    }
}
