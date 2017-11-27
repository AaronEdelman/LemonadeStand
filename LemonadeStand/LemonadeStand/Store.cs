using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        public string lemons = "lemons";
        public float lemonPrice = .65F;
        public string sugar = "sugar";
        public float sugarPrice = .98F;
        public string ice = "ice";
        public float icePrice = .49F;

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
