using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class Item
    {
        private string _name;
        private int _quantity;

        public Item (string name)
        {
            _name = name;
        }

        public Item (int quantity)
        {
            _quantity = quantity;
        }

        public Item (string name, int quantity)
        {
            _name = name;
            _quantity = quantity;
        }

        public Item ()
        {
            _name = null;
            _quantity = 0;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }
    }
}
