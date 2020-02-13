using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Product;

namespace BLL
{
    public class ShoppingLogic
    {
        ShoppingDB DataBase = new ShoppingDB();

        public bool AddItem(string name, int quantity)
        {
            if (quantity > 0)
            {
                Item item = new Item(name, quantity);
                return DataBase.Create(item);
            }
            return false;
        }

        public List<Item> DisplayAllItems()
        {
            return DataBase.RetrieveAll();
        }

        public List<Item> DisplayItemByName(string name)
        {
            return DataBase.RetrieveByName(name);
        }

        public List<Item> DisplayAllByQuantity(int quantity)
        {
            return DataBase.RetrieveAll().Where(x => x.GetQuantity() == quantity).ToList();
        }

        public Item DisplayItemByIndex(int index)
        {
            return DataBase.RetrieveAll()[index];
        }

        public bool UpdateItemQuantity(string name, int quantity)
        {
            List<Item> items = DataBase.RetrieveAll().Where(x => x.GetName() == name).ToList();
            if (items.Count() > 0)
            {
                items.FirstOrDefault(x => x.GetName() == name).SetQuantity(quantity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateItemName(string currentName, string newName)
        {
            List<Item> items = DataBase.RetrieveAll();
            if (items.FirstOrDefault(x => x.GetName() == currentName) != null)
            {
                DataBase.UpdateNameByIndex(items.FindIndex(x => x.GetName() == currentName), newName);
                return true;
            }

            else
            {
                return false;
            }
        }

        public int DeleteItemByName(string name)
        {
            List<Item> items = DataBase.RetrieveAll().Where(x => x.GetName() == name).ToList();
            int count = items.Count();
            if (count > 0)
            {
                DataBase.DeleteByName(name);
            }

            return count;
        }

        public int DeleteAllItems()
        {
            List<Item> items = DataBase.RetrieveAll();
            int count = items.Count();
            for (int i = 0; i < count; i++)
            {
                DataBase.DeleteByIndex(0);
            }
            return count;
        }

        public int DeleteItemsByQuantity(int quantity)
        {
            List<Item> items = DataBase.RetrieveAll().Where(x => x.GetQuantity() == quantity).ToList();
            int count = items.Count();
            DataBase.DeleteByQuantity(quantity);
            return count;
        }
    }
}
