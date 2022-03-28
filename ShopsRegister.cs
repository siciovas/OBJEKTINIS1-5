using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_23
{
    class ShopsRegister
    {
        private ShopsContainer allShops = new ShopsContainer();

        public ShopsRegister(ShopsContainer shops)
        {
            for(int i = 0; i < shops.Count; i++)
            {
                allShops.Add(shops.Get(i));
            }
        }

        /// <summary>
        /// First bubble (Finds heaviest ring, earrings, collar)
        /// </summary>
        /// <param name="type">Type of juvelry</param>
        /// <returns>Heaviest ring/earrings/collar</returns>
        public Juvelry FindHeaviest(char type)
        {
            Juvelry heaviest = null;
            int maxWeight = int.MinValue;

            for(int i = 0; i < allShops.Count; i++)
            {
                for(int j = 0; j < allShops.Get(i).AllJuvelry.Count; j++)
                {
                    Juvelry current = allShops.Get(i).AllJuvelry.GetJuvelry(j);
                    if (current.Type == type && current.Weight > maxWeight)
                    {
                        heaviest = current;
                        maxWeight = current.Weight;
                    }
                }
            }
            return heaviest;
        }

        /// <summary>
        /// Second bubble (Finds highest praba's in every shop)
        /// </summary>
        /// <param name="index">Index of shop (First, second, third)</param>
        /// <returns>Number how many highest praba's are in every shop</returns>

        public int FindNumberOfHighestPurity(int index)
        {
            int count = 0;

            for (int i = 0; i < allShops.Get(index).AllJuvelry.Count; i++)
            {
                Juvelry current = allShops.Get(index).AllJuvelry.GetJuvelry(i);

                if (current.IsHighest())
                {
                    count++;
                }
            }
                return count;
            
        }

        /// <summary>
        /// Third bubble (Finds juvelries that can be bought in every shop)
        /// </summary>
        /// <returns>Juvelries that are in all shops</returns>

        public JuvelryContainer FindSameInAllShops() 
        {
            JuvelryContainer inAllShops = new JuvelryContainer();

            for(int i = 0; i < allShops.Get(0).AllJuvelry.Count; i++)
            {
                Juvelry current = allShops.Get(0).AllJuvelry.GetJuvelry(i);
                if(allShops.Get(1).AllJuvelry.Contains(current) && allShops.Get(2).AllJuvelry.Contains(current))
                {
                    inAllShops.AddJuvelry(current);
                }
            }
            return inAllShops;
        }

        /// <summary>
        /// Fourth bubble (Finds every juvelry that is cheapest than 300)
        /// </summary>
        /// <returns>List of cheapest juvelries</returns>
        public JuvelryContainer FindCheaperThan300()
        {
            JuvelryContainer cheapest = new JuvelryContainer();

            for(int i = 0; i < allShops.Count; i++)
            {
                for(int j = 0; j < allShops.Get(i).AllJuvelry.Count; j++)
                {
                    Juvelry current = allShops.Get(i).AllJuvelry.GetJuvelry(j);
                    if (current.Cost < 300 && !cheapest.Contains(current))
                    {
                        cheapest.AddJuvelry(current);
                    }
                }
            }
            return cheapest;
        }
    }
}
