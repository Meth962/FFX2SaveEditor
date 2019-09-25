using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFX2SaveEditor
{
    public class Item
    {
        public byte ID { get; set; }
        public byte Category { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
    }

    public class Items
    {
        private Dictionary<int, Item> items = new Dictionary<int, Item>();

        public Item this[int index]
        {
            get { return items[index]; }
        }
    }
}
