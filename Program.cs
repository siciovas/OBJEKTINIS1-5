using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ShopsContainer shops = new ShopsContainer();
            shops.Add(InOut.ReadShopData("shop1.txt"));
            shops.Add(InOut.ReadShopData("shop2.txt"));
            shops.Add(InOut.ReadShopData("shop3.txt"));

            ShopsRegister register = new ShopsRegister(shops);

            //FIRST BUBBLE
            Juvelry heaviestRing = register.FindHeaviest('R');
            Juvelry heaviestEarrings = register.FindHeaviest('E');
            Juvelry heaviestCollar = register.FindHeaviest('C');

            //SECOND BUBBLE
            int highestPurityFirstShop = register.FindNumberOfHighestPurity(0);
            int highestPuritySecondShop = register.FindNumberOfHighestPurity(1);
            int highestPurityThirdShop = register.FindNumberOfHighestPurity(2);

            //THIRD BUBBLE
            JuvelryContainer inAllShops = register.FindSameInAllShops();

            //FOURTH BUBBLE
            JuvelryContainer cheaperThan300 = register.FindCheaperThan300();
            cheaperThan300.Sort();

            //PRINTING
            InOut.PrintHeaviestToConsole(heaviestRing, heaviestEarrings, heaviestCollar);
            InOut.PrintHighestPurityCountToConsole(highestPurityFirstShop, highestPuritySecondShop, highestPurityThirdShop);
            InOut.PrintJuvelryInAllShopsToTXT(inAllShops, "Visur.txt");
            InOut.PrintCheaperThan300ToTXT(cheaperThan300, "300.txt ");

            Console.ReadLine();
        }
    }
}
