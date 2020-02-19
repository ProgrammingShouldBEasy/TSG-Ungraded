using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product;
using System.IO;

namespace DAL
{
    public class ShoppingDB
    {
        private Item MapLintoProduct(string line)
        {
            String[] props = line.Split(':');
           return new Item(props[0], Int32.Parse(props[1]));
        }
        private string MapProducttoLine(Item item)
        {
            return item.GetName() + ":" + item.GetQuantity();
        }
        private void WriteAllItems(List<Item> items)
        {
            using (StreamWriter writer = new StreamWriter("list.txt"))
            {
                foreach (Item x in items)
                {
                    writer.WriteLine(MapProducttoLine(x));
                }
            }
        }

        
        private List<Item> ReadAllItems()
        {
                List<Item> items = new List<Item>();
            try
            {
                using (StreamReader reader = new StreamReader("list.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        items.Add(MapLintoProduct(line));
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                return items;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Something don't work right.");
                Console.ReadLine();
            }
                return items;
        }
        public bool Create (Item item)
        {
            List<Item> items = ReadAllItems();
            if (items.FirstOrDefault(x => x.GetName() == item.GetName()) != null)
            {
                items.Add(item);
                WriteAllItems(items);
                return true;
            }

            else
            {
                return false;
            }
        }

        public List<Item> RetrieveByName(string name)
        {
            List<Item> items = ReadAllItems();
            return items.Where(x => x.GetName() == name).ToList();
        }

        public List<Item> RetrieveAll()
        {
            return ReadAllItems();
        }

        public bool UpdateQuantityByName(string name, int quantity)
        {
            List<Item> items = ReadAllItems();
            if (items.FirstOrDefault(x => x.GetName() == name) != null)
            {
                items.FirstOrDefault(x => x.GetName() == name).SetQuantity(quantity);
                WriteAllItems(items);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateNameByIndex(int index, string name)
        {
            List<Item> items = ReadAllItems();
            if (items.Count() > index)
            {
                items[index].SetName(name);
                WriteAllItems(items);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteByName(string name)
        {
            List<Item> items = ReadAllItems();
            if (items.FirstOrDefault(x => x.GetName() == name) != null)
            {
                items.RemoveAll(x => x.GetName() == name);
                WriteAllItems(items);
                return true;
            }

            else
            {
                return false;
            }
        }
        public bool DeleteByIndex(int index)
        {
            List<Item> items = ReadAllItems();
            if (items.Count < index)
            {
                items.RemoveAt(index);
                WriteAllItems(items);
                return true;
            }

            else
            {
                return false;
            }
        }
        public bool DeleteByQuantity(int quantity)
        {
            List<Item> items = ReadAllItems();
            if (items.Where(x => x.GetQuantity() == quantity).ToList().Count() > 0)
            {
                items.RemoveAll(x => x.GetQuantity() == quantity);
                WriteAllItems(items);
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
