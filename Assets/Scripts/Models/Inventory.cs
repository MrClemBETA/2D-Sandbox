using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class Inventory
    {
        public List<Item> Items { get; private set; }
        public int MaxItems { get; private set; }

        public Inventory(int maxItems)
        {
            Items = new List<Item>();
            MaxItems = maxItems;
        }

        public bool AddItem(Item item)
        {
            if (Items.Count == MaxItems)
            {
                return false;
            }
            else
            {
                Items.Add(item);
                return true;
            }
        }

        public Item RemoveItem(int index)
        {
            Item temp = Items[index];
            Items.RemoveAt(index);
            return temp;
        }
    }
}
