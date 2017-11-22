using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        string lemons = "lemons";
        float lemonPrice = .65F;
        string sugar = "sugar";
        float sugarPrice = .98F;
        string ice = "ice";
        float icePrice = .49F;

        public void DisplayPrice(string product, float productPrice)
        {
            string productCost = productPrice.ToString();
            Console.WriteLine(product + " costs $" + productCost);
        }
        public void DisplayAllPrices()
        {
            DisplayPrice(lemons, lemonPrice);
            DisplayPrice(sugar, sugarPrice);
            DisplayPrice(ice, icePrice);
        }
    }
}
