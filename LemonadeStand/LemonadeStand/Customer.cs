using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        int temp;
        public float demand;
        float thirst;
        float buyPower;
        float maxPrice;
        public bool willBuy;
        Random r;
        //constructor
        public Customer(int temp, Random r)
        {
            this.temp = temp;
            this.r = r;
        }
        public void GetPropensityToBuy()
        {
            float demandRandom = r.Next(0, 101);
            demand = (float)demandRandom / 100;
        }
        public void MaxPrice()
        {
            float maxPriceRandom = r.Next(100, 150);
            maxPrice = (float)maxPriceRandom / 100;
        }
        public void GetThirst()
        {
            float tempFloat = (float)temp / 100;
            thirst = demand + tempFloat;
        }
        public void GetBuyPower(float recipeStrength, float price)
        {
            buyPower = (thirst * recipeStrength)*(maxPrice-price);
        }
        public void BuyLemonadeDecision()
        {
            if (buyPower > 1)
            {
                willBuy = true;
            }
            else
            {
                willBuy = false;
            }
        }
    }
}
