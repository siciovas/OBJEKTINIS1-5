using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_23
{
    class ShopsContainer
    {
        private Shop[] shops;
        private int Capacity;
        public int Count { get; set; }

        public ShopsContainer(int capacity = 16)
        {
            Capacity = capacity;
            shops = new Shop[capacity];
        }

        public void Add(Shop shop)
        {
            if(Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            shops[Count++] = shop;
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if(minimumCapacity > Capacity)
            {
                Shop[] temp = new Shop[minimumCapacity];
                for(int i = 0; i < Count; i++)
                {
                    temp[i] = shops[i];
                }
                Capacity = minimumCapacity;
                shops = temp;
            }
        }

        public Shop Get(int index)
        {
            return shops[index];
        }

        public void RemoveAt(int index)
        {
            shops[index] = shops[Count - 1];
            shops[Count - 1] = null;
            Count--;
        }
    }
}
