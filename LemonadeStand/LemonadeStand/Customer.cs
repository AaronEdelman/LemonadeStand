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
        float demand;
        float thirst;
        float buyPower;
        float maxPrice;
        public bool willBuy;
        //constructor
        public Customer(int temp)
        {
            this.temp = temp;
        }
        public void GetPropensityToBuy()
        {
            float demandRandom = new Random().Next(0, 101);
            demand = (float)demandRandom / 100;
        }
        public void MaxPrice()
        {
            float maxPriceRandom = new Random().Next(100, 150);
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
