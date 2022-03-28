using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L5_23
{
    class InOut
    {
        public static Shop ReadShopData(string fileName)
        {
            using(StreamReader reader = new StreamReader(fileName))
            {
                string title, address, phoneNumber;

                title = reader.ReadLine();
                address = reader.ReadLine();
                phoneNumber = reader.ReadLine();

                Shop shop = new Shop(title, address, phoneNumber);

                string line = null;

                while( (line = reader.ReadLine()) != null )
                {
                    string[] values = line.Split(';');

                    char type = Char.Parse(values[0]);
                    string manufacturer = values[1];
                    string name = values[2];
                    string metal = values[3];
                    int weight = int.Parse(values[4]);
                    int purity = int.Parse(values[5]);
                    int cost = int.Parse(values[6]);

                    switch(type)
                    {
                        case 'R':
                            int size = int.Parse(values[7]);
                            Ring ring = new Ring(type, manufacturer, name, metal, weight, purity, cost, size);
                            shop.AddRing(ring);
                            break;
                        case 'E':
                            string claspType = values[7];
                            Earrings earrings = new Earrings(type, manufacturer, name, metal, weight, purity, cost, claspType);
                            shop.AddEarrings(earrings);
                            break;
                        case 'C':
                            int length = int.Parse(values[7]);
                            Collar collar = new Collar(type, manufacturer, name, metal, weight, purity, cost, length);
                            shop.AddCollar(collar);
                            break;
                    }
                }
                return shop;
            }
        }

        /// <summary>
        /// Prints first bubble (Find heaviest ring, heaviest earrings, heaviest collar)
        /// </summary>
        /// <param name="heaviestRing">Heaviest ring from all shops</param>
        /// <param name="heaviestEarrings">Heaviest earrings from all shops</param>
        /// <param name="heaviestCollar">Heaviest collar from all shops</param>
        public static void PrintHeaviestToConsole(Juvelry heaviestRing, Juvelry heaviestEarrings, Juvelry heaviestCollar)
        {
            Console.WriteLine("Sunkiausias žiedas:");
            Console.WriteLine(new string('-', 107));
            Ring heaviestR = heaviestRing as Ring;
            Console.WriteLine(string.Format("| {0,-15} | {1,-20} | {2,-10} | {3,-10} | {4, -10} | {5,-10} | {6,-10} |", "Gamintojas", "Pavadinimas", "Metalas",
                "Svoris", "Praba", "Kaina", "Dydis"));
            Console.WriteLine(new string('-', 107));
            Console.WriteLine(heaviestR.ToString());
            Console.WriteLine(new string('-', 107));


            Console.WriteLine("Sunkiausi auskarai:");
            Earrings heaviestE = heaviestEarrings as Earrings;
            Console.WriteLine(new string('-', 107));
            Console.WriteLine(string.Format("| {0,-15} | {1,-20} | {2,-10} | {3,-10} | {4, -10} | {5,-10} | {6,-10} |", "Gamintojas", "Pavadinimas",
                "Metalas", "Svoris", "Praba", "Kaina", "Užsegimas"));
            Console.WriteLine(new string('-', 107));
            Console.WriteLine(heaviestE.ToString());
            Console.WriteLine(new string('-', 107));

            Console.WriteLine("Sunkiausia grandinėlė:");    
            Collar heaviestC = heaviestCollar as Collar;
            Console.WriteLine(new string('-', 107));
            Console.WriteLine(string.Format("| {0,-15} | {1,-20} | {2,-10} | {3,-10} | {4, -10} | {5,-10} | {6,-10} |", "Gamintojas", "Pavadinimas",
                "Metalas", "Svoris", "Praba", "Kaina", "Ilgis"));
            Console.WriteLine(new string('-', 107));
            Console.WriteLine(heaviestC.ToString());
            Console.WriteLine(new string('-', 107));
        }
        /// <summary>
        /// Prints second bubble (Find highest praba's in every shop)
        /// </summary>
        /// <param name="inFirstShop">First shop</param>
        /// <param name="inSecondShop">Second shop</param>
        /// <param name="inThirdShop">Third shop</param>
        public static void PrintHighestPurityCountToConsole(int inFirstShop, int inSecondShop, int inThirdShop)
        {
            Console.WriteLine("Pirmoje parduotuvėje yra {0} aukščiausios prabos gaminių/ai.", inFirstShop);
            Console.WriteLine("Antoje parduotuvėje yra {0} aukščiausios prabos gaminių/ai.", inSecondShop);
            Console.WriteLine("Trečioje parduotuvėje yra {0} aukščiausios prabos gaminių/ai.", inThirdShop);
        }

        /// <summary>
        /// Prints third bubble (Find juvelry that is in every shop)
        /// </summary>
        /// <param name="inAllShops"></param>
        /// <param name="fileName">Current file name</param>

        public static void PrintJuvelryInAllShopsToTXT(JuvelryContainer inAllShops, string fileName)
        {
            using(var writer = File.CreateText(fileName))
            {
                for(int i = 0; i < inAllShops.Count; i++)
                {
                    if (inAllShops.GetJuvelry(i).Type == 'R')
                    {
                        Ring ring = inAllShops.GetJuvelry(i) as Ring;
                        writer.WriteLine(ring.ToString());
                    }
                    else if (inAllShops.GetJuvelry(i).Type == 'E')
                    {
                        Earrings earrings = inAllShops.GetJuvelry(i) as Earrings;
                        writer.WriteLine(earrings.ToString());
                    }
                    else if (inAllShops.GetJuvelry(i).Type == 'C')
                    {
                        Collar collar = inAllShops.GetJuvelry(i) as Collar;
                        writer.WriteLine(collar.ToString());
                    }
                }
            }
            
        }

        /// <summary>
        /// Prints fourth bubble (Find juvelries that cost under 300)
        /// </summary>
        /// <param name="cheaperThan300"></param>
        /// <param name="fileName"></param>

        public static void PrintCheaperThan300ToTXT(JuvelryContainer cheaperThan300, string fileName)
        {
            using(var writer = File.CreateText(fileName))
            {
                for(int i = 0; i < cheaperThan300.Count; i++)
                {
                    if (cheaperThan300.GetJuvelry(i).Type  == 'R')
                    {
                        Ring ring = cheaperThan300.GetJuvelry(i) as Ring;
                        writer.WriteLine(ring.ToString());
                    }
                    else if (cheaperThan300.GetJuvelry(i).Type == 'E')
                    {
                        Earrings earrings = cheaperThan300.GetJuvelry(i) as Earrings;
                        writer.WriteLine(earrings.ToString());
                    }
                    else if (cheaperThan300.GetJuvelry(i).Type == 'C')
                    {
                        Collar collar = cheaperThan300.GetJuvelry(i) as Collar;
                        writer.WriteLine(collar.ToString());
                    }
                }
            }
        }
    }
}
