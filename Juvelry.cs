using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_23
{
    class Juvelry
    {
        public char Type { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Metal { get; set; }
        public int Weight { get; set; }
        public int Purity { get; set; }
        public int Cost { get; set; }

        public Juvelry(char type, string manufacturer, string name, string metal, int weight, int purity, int cost)
        {
            Type = type;
            Manufacturer = manufacturer;
            Name = name;
            Metal = metal;
            Weight = weight;
            Purity = purity;
            Cost = cost;
        }

        public override bool Equals(object obj)
        {
            return this.Name == ((Juvelry)obj).Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

       public static bool operator > (Juvelry a, Juvelry b)
        {
            if (a.Manufacturer.CompareTo(b.Manufacturer) == 0)
            {
                if (a.Name.CompareTo(b.Name) == 0)
                {
                    return a.Cost.CompareTo(b.Cost) > 0;
                }
                else
                {
                    return a.Name.CompareTo(b.Name) > 0;
                }
            }

            else return a.Manufacturer.CompareTo(b.Manufacturer) > 0;
        }

        public static bool operator <(Juvelry a, Juvelry b)
        {
            if (a.Manufacturer.CompareTo(b.Manufacturer) == 0)
            {
                if (a.Name.CompareTo(b.Name) == 0)
                {
                    return a.Cost.CompareTo(b.Cost) < 0;
                }
                else
                {
                    return a.Name.CompareTo(b.Name) < 0;
                }
            }

            else return a.Manufacturer.CompareTo(b.Manufacturer) < 0;
        }

        public  bool IsHighest()
        {

            if (this.Name == "Platina" && (this.Purity == 950))
            {
                return true;
            }

            else if (this.Name == "Auksas" && (this.Purity == 375 || this.Purity == 585 || this.Purity == 750))
            {
                return true;
            }

            else if(this.Name == "Sidabras" && (this.Purity == 800 || this.Purity == 830 || this.Purity == 925))
            {
                return true;
            }

            else if(this.Name == "Paladis" && (this.Purity == 500 || this.Purity == 850))
            {
                return true;
            }

            return true;
        }


    }
}
