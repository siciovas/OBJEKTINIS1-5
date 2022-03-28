using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_23
{
    class JuvelryContainer
    {
        private Juvelry[] allJuvelry;
        private int Capacity;
        public int Count { get; set; }

        public JuvelryContainer(int capacity = 20)
        {
            Capacity = capacity;
            allJuvelry = new Juvelry[capacity];
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if(minimumCapacity > Capacity)
            {
                Juvelry[] temp = new Juvelry[minimumCapacity];
                for(int i = 0; i < Count; i++)
                {
                    temp[i] = allJuvelry[i];
                }
                Capacity = minimumCapacity;
                allJuvelry = temp;
            }
        }

        public void AddContainer(JuvelryContainer juvelry)
        {
            for (int i = 0; i < juvelry.Count; i++)
            {
                if (Count == Capacity)
                {
                    EnsureCapacity(Capacity * 2);
                }
                allJuvelry[Count++] = juvelry.GetJuvelry(i);
            }
        }

        public void AddJuvelry(Juvelry juvelry)
        {
            allJuvelry[Count] = juvelry;
            Count++;
        }

        public void SetJuvelry(int index, Juvelry juvelry)
        {
            allJuvelry[index] = juvelry;
        }

        public Juvelry GetJuvelry(int index)
        {
            return allJuvelry[index];
        }

        public void RemoveJuvelry(Juvelry juvelry)
        {
            int i = 0;
            while (i < Count)
            {
                if (allJuvelry[i].Equals(juvelry))
                {
                    Count--;
                    for (int j = i; j < Count; j++)
                    {
                        allJuvelry[j] = allJuvelry[j + 1];
                    }
                    break;
                }
                i++;
            }
        }

        public bool Contains(Juvelry juvelry)
        {
            return allJuvelry.Contains(juvelry);
        }

        public void Sort()
        {
            for(int i = 0; i < this.Count-1; i++)
            {
                Juvelry a = allJuvelry[i];
                int index = i;

                for(int j = i + 1; j < this.Count; j++)
                {
                    if(allJuvelry[j] < a)
                    {
                        a = allJuvelry[j];
                        index = j;
                    }
                }
                allJuvelry[index] = allJuvelry[i];
                allJuvelry[i] = a;
            }
        }

    }
}
