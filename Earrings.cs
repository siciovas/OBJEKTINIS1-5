using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_23
{
    class Earrings : Juvelry
    {
        public string ClaspType { get; set; }

        public Earrings(char type, string manufacturer, string name, string metal, int weight, int purity, int cost, string claspType) : base(type, 
            manufacturer, name, metal, weight, purity, cost)
        {
            ClaspType = claspType;
        }

        public override string ToString()
        {
            return string.Format("| {0,-15} | {1,-20} | {2,-10} | {3,-10} | {4, -10} | {5,-10} | {6,-10} |", Manufacturer, Name, Metal, Weight, 
                Purity, Cost, ClaspType);
        }
    }
}
